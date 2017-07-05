using System.Numerics;
using Nethereum.Util;

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
                    return "0x1e2F51E97f2772dafE59d345BBE48C32A7d2B46b";
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
                    return "0x22D0744A13A8e17904789c8f5271bd7AE74e09c5";
                }
            }
        }

        // Process variables
        public const string ProcessContractName = "Process";
        public static BigInteger ProcessContractGas { get; set; } = 300000;
        public static BigInteger ProcessContractValue { get; set; } = 0;

        public static BigInteger ProcessTransactionGas { get; set; } = 30000;
        public static BigInteger ProcessTransactionValue { get; set; } = 0;

        public static EthContractData ProcessEthData { get; set; } = new EthContractData();

        // Token variables
        public const string TokenName = "TfaToken";
        public const string TokenSymbol = "TFA";
        public const int TokenInitialSupply = 10000000;
        public const int TokenDecimalUnits = 2;

        public static string TokenContractName { get; } = "EthToken";
        public const string TokenContractCode = @"D:\Prasanna\BlockChain\Repos\Samples\TfaToken\Contracts\EthToken.sol";
        public static BigInteger TokenContractGas { get; set; } = 3000000;
        public static BigInteger TokenContractValue { get; set; } = UnitConversion.Convert.ToWei(1000, UnitConversion.EthUnit.Finney);

        public static BigInteger TokenTransferDeductGas { get; set; } = 900000;
        public static BigInteger TokenTransferDeductValue { get; set; } = 0;
        public static EthContractData TokenEthData { get; set; } = new EthContractData();

        // Token functions
        public const string TokenTranferFunction = "transfer";
        public const string TokenDeductFunction = "deduct";
        public const int TokenInitialCredits = 100000;
        public const int TokenContractDeduct = 1000;
        public const int TokenTransactionDeduct = 100;
    }
}
