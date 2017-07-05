using System.IO;
using System.Threading.Tasks;

namespace TfaToken.Lib
{
    public class TokenContract
    {
        public async Task<bool> RegisterContract()
        {
            string code = this.GetContractCode();

            Contract contract = new Contract(Globals.AccountAddress, Globals.Password);
            await contract.Register(code, Globals.TokenContractName, Globals.TokenContractGas, Globals.TokenContractValue,
                Globals.TokenInitialSupply, Globals.TokenName, Globals.TokenDecimalUnits, Globals.TokenSymbol
                );

            // setting the static variables
            Globals.TokenEthData = contract.EthData;

            return true;
        }

        public async Task<bool> Transfer(int credits = Globals.TokenInitialCredits)
        {
            Contract contract = new Contract(Globals.AccountAddress, Globals.Password);

            await contract.SendTransaction(Globals.TokenEthData.Abi, Globals.TokenEthData.Address, Globals.TokenTransferDeductGas, Globals.TokenTransferDeductValue, Globals.TokenTranferFunction, Globals.CompanyAddress, credits);
            return true;
        }

        public async Task<bool> Deduct(int credits)
        {
            Contract contract = new Contract(Globals.AccountAddress, Globals.Password);

            await contract.SendTransaction(Globals.TokenEthData.Abi, Globals.TokenEthData.Address, Globals.TokenTransferDeductGas, Globals.TokenTransferDeductValue, Globals.TokenDeductFunction, Globals.CompanyAddress, credits);
            return true;
        }

        private string GetContractCode()
        {
            return File.ReadAllText(Globals.TokenContractCode);
        }
    }
}
