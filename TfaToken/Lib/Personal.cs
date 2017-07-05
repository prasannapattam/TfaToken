using Nethereum.Geth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TfaToken.Lib
{
    public class Personal
    {
        public async Task<string> NewAccount()
        {
            Web3Geth web3 = new Web3Geth();

            return await web3.Personal.NewAccount.SendRequestAsync(Globals.Password);
        }
    }
}
