using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                "10000000", "TfaToken", 2, "TFA"
                );

            // setting the static variables
            Globals.TokenEthData = contract.EthData;

            return true;
        }

        private string GetContractCode()
        {
            return File.ReadAllText(Globals.TokenContractCode);
        }
    }
}
