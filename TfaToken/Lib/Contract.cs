using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Geth;
using Nethereum.Hex.HexTypes;

namespace TfaToken.Lib
{
    public class Contract
    {
        private string AccountAddress;
        private string Password;
        private Web3Geth Web3;

        public EthContractData EthData { get; set; }

        public Contract(string senderAddress, string password)
        {
            this.AccountAddress = senderAddress;
            this.Password = password;

            this.Web3 = new Web3Geth();
        }

        public void Compile(string code, string contractName)
        {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Globals.SolCompiler,
                    Arguments = @"--bin --abi",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            StreamWriter sw = proc.StandardInput;
            sw.WriteLine(code);
            sw.Dispose();
            Dictionary<string, EthContractData> ethData = new Dictionary<string, EthContractData>();
            EthContractData currentData = new EthContractData();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                // do something with line
                if(line.IndexOf("stdin") > 0)
                {
                    string currentContractName = line.Substring(line.IndexOf(":") + 1).Replace("=", "").Trim();
                    currentData = new EthContractData();
                    ethData.Add(currentContractName, currentData);
                }
                else if (line == "Binary: ")
                {
                    currentData.ByteCode = "0x" + proc.StandardOutput.ReadLine();
                }
                else if (line == "Contract JSON ABI")
                {
                    currentData.Abi = proc.StandardOutput.ReadLine();
                }
            }
            proc.Dispose();

            EthData = ethData[contractName];
        }

        public async Task Deploy(BigInteger gas, BigInteger value, params object[] values)
        {
            await UnlockAccount();
            
            string transactionHash =
                await this.Web3.Eth.DeployContract.SendRequestAsync(EthData.Abi, EthData.ByteCode, this.AccountAddress, new HexBigInteger(gas), new HexBigInteger(value), values);
            var receipt = await this.Web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            while (receipt == null)
            {
                Thread.Sleep(5000);
                receipt = await this.Web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
            }

            EthData.Address = receipt.ContractAddress;
        }

        public async Task Register(string code, string contractName, BigInteger gas, BigInteger value, params object[] values)
        {
            this.Compile(code, contractName);
            await this.Deploy(gas, value, values);
        }

        public async Task<string> SendTransaction(string abi, string contractAddress, BigInteger gas, BigInteger value, string functionName, params object[] functionInput)
        {
            await UnlockAccount();

            var contract = this.Web3.Eth.GetContract(abi, contractAddress);
            var function = contract.GetFunction(functionName);
            return await function.SendTransactionAsync(this.AccountAddress, new HexBigInteger(gas), new HexBigInteger(value), functionInput);
        }

        public async Task<T> Call<T>(string functionName, params object[] functionInput)
        {
            var contract = this.Web3.Eth.GetContract(EthData.Abi, EthData.Address);

            var function = contract.GetFunction(functionName);

            return await function.CallAsync<T>(functionInput);
        }

        public async Task UnlockAccount()
        {
            await this.Web3.Personal.UnlockAccount.SendRequestAsync(this.AccountAddress, this.Password, 120);
        }
    }
}
