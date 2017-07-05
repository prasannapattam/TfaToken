using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TfaToken.Lib;

namespace TfaToken.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contract()
        {
            return View();
        }

        public async Task<string> CreateAccount()
        {
            Company company = new Company();
            return await company.CreateAccount();
        }

        public async Task<EthContractData> CreateToken()
        {
            TokenContract token = new TokenContract();
            await token.RegisterContract();
            return Globals.TokenEthData;
        }

        public async Task<bool> BuyTokens([FromBody] TokenCredits credits)
        {
            TokenContract token = new TokenContract();
            await token.Transfer(credits.Tokens);
            return true;
        }

        public async Task<bool> DeductTokens([FromBody] TokenCredits credits)
        {
            TokenContract token = new TokenContract();
            await token.Deduct(credits.Tokens);
            return true;
        }

        // publish
        public async Task<EthContractData> RegisterProcessContract([FromBody] ProcessContractRegisterData data)
        {
            ProcessContract process = new ProcessContract();
            await process.RegisterContract(data.States);

            TokenContract token = new TokenContract();
            await token.Deduct(Globals.TokenContractDeduct);

            return Globals.ProcessEthData;
        }

        // approve & initiate
        public async Task<bool> InitiateProcessContract([FromBody] ProcessContractData data)
        {
            ProcessContract process = new ProcessContract();
            await process.Intantiate(data.State, data.FormCode, data.Comments, data.Approver);

            TokenContract token = new TokenContract();
            await token.Deduct(Globals.TokenTransactionDeduct);

            return true;
        }

        public async Task<bool> Kill()
        {
            TokenContract token = new TokenContract();
            return await token.Kill();
        }
    }
}
