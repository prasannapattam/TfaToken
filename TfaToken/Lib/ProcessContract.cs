using System.Text;
using System.Threading.Tasks;

namespace TfaToken.Lib
{
    public class ProcessContract
    {
        public async Task<bool> RegisterContract(string states)
        {
            string code = this.GetContractCode(states);

            Contract contract = new Contract(Globals.AccountAddress, Globals.Password);
            await contract.Register(code, Globals.ProcessContractName, Globals.ProcessContractGas, Globals.ProcessContractValue);

            // setting the static variables
            Globals.ProcessEthData = contract.EthData;

            return true;
        }

        public async Task Intantiate(string state, string formCode, string comments, string approver)
        {
            Contract contract = new Contract(Globals.AccountAddress, Globals.Password);
            await contract.SendTransaction(Globals.ProcessEthData.Abi, Globals.ProcessEthData.Address, Globals.ProcessTransactionGas, Globals.ProcessTransactionValue, state, formCode, comments, approver);
        }

        private string GetContractCode(string states)
        {
            string[] arr = states.Split(',');

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"
pragma solidity ^0.4.11;

contract Process {

    struct Instance {
        string FormCode;
        string Comments;
        string Approver;
    }

    mapping(string => Instance) instances;       
            ");

            foreach (string str in arr)
            {
                sb.AppendLine(@"

    function " + str.Trim() + @"(string FormCode, string Comments, string Approver) public {
        instances[FormCode] = Instance({ FormCode: FormCode, Comments: Comments,  Approver: Approver});
    }
");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

    }
}
