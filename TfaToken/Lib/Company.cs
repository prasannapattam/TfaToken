using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TfaToken.Lib
{
    public class Company
    {
        public async Task<string> CreateAccount()
        {
            Personal personal = new Personal();

            Globals.CompanyAddress = await personal.NewAccount();

            //assigning initial credit
            TokenContract token = new TokenContract();
            await token.Transfer();

            return Globals.CompanyAddress;
        }
    }
}
