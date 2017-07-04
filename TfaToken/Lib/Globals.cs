using Nethereum.Geth;
using Nethereum.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace TfaToken.Lib
{
    public static class Globals
    {
        public static Environment Environment = Environment.Private;

        public static string Password { get; } = "password";
        public static string SolCompiler { get; } = @"D:\Prasanna\BlockChain\Repos\Compiler\solc.exe";

        public static string AccountAddress
        {
            get
            {
                if(Globals.Environment == Environment.Rinkeby)
                {
                    return "0x65873e9f02633f8b87ca1896bd811c58ad000a15";
                }
                else
                {
                    return "0x1e2f51e97f2772dafe59d345bbe48c32a7d2b46b";
                }
            }
        }

        public static string CompanyAddress
        {
            get
            {
                if (Globals.Environment == Environment.Rinkeby)
                {
                    return "0x2f2000bbd0e461b21fea55f952d8154e4e2e20f0";
                }
                else
                {
                    return "0x22d0744a13a8e17904789c8f5271bd7ae74e09c5";
                }
            }
        }

        // Process variables
        public static string ProcessContractName { get; } = "Process";
        public static BigInteger ProcessContractGas { get; set; } = 300000;
        public static BigInteger ProcessContractValue { get; set; } = 0;

        public static BigInteger ProcessTransactionGas { get; set; } = 30000;
        public static BigInteger ProcessTransactionValue { get; set; } = 0;

        public static EthContractData ProcessEthData { get; set; } = new EthContractData();

        // Token variables
        public static string TokenContractName { get; } = "EthToken";
        public static string TokenContractCode { get; } = @"D:\Prasanna\BlockChain\Repos\Samples\TfaToken\Contracts\EthToken.sol";
        public static BigInteger TokenContractGas { get; set; } = 3000000;
        public static BigInteger TokenContractValue { get; set; } = UnitConversion.Convert.ToWei(1000, UnitConversion.EthUnit.Finney);
        public static BigInteger TokenTransferDeductGas { get; set; } = 30000;
        public static BigInteger TokenTransferDeductValue { get; set; } = 0;
        public static EthContractData TokenEthData { get; set; } = new EthContractData();

        public static int TokenInitialCredit { get; } = 1000;

    }
}
