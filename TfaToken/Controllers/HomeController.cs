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

        public async Task<EthContractData> CreateToken()
        {
            TokenContract token = new TokenContract();
            await token.RegisterContract();
            return Globals.TokenEthData;
        }

        // publish
        public async Task<EthContractData> RegisterProcessContract([FromBody] ProcessContractRegisterData data)
        {
            ProcessContract process = new ProcessContract();
            await process.RegisterContract(data.States);
            return Globals.ProcessEthData;
        }

        // approve & initiate
        public async Task<bool> InitiateProcessContract([FromBody] ProcessContractData data)
        {
            ProcessContract process = new ProcessContract();
            await process.Intantiate(data.State, data.FormCode, data.Comments, data.Approver);
            return true;
        }
    }
}
