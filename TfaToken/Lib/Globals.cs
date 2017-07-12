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
                    return "0x65873e9f02633F8b87CA1896bD811C58Ad000a15";
                }
                else
                {
                    return "0x1e2F51E97f2772dafE59d345BBE48C32A7d2B46b";
                }
            }
        }

        public static string CompanyAddress { get; set; }

        static Globals()
        {
            if (Globals.Environment == Environment.Rinkeby)
            {
                Globals.CompanyAddress = "0x2F2000bbD0e461b21FEA55F952d8154e4E2e20f0";
            }
            else
            {
                Globals.CompanyAddress = "0x22D0744A13A8e17904789c8f5271bd7AE74e09c5";
                //Globals.CompanyAddress = "0x4E6814370FFa7Bc60f7f617bd269F1C4e8fA57BB";
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
        public const string TokenName = "Transfora Coin";
        public const string TokenSymbol = "TFA";
        public const int TokenInitialSupply = 100000000;
        public const int TokenDecimalUnits = 2;

        public static string TokenContractName { get; } = "EthToken";
        public const string TokenContractCode = @"D:\Prasanna\BlockChain\Repos\Samples\TfaToken\Contracts\EthToken.sol";
        public static BigInteger TokenContractGas { get; set; } = 3000000;
        public static BigInteger TokenContractValue { get; set; } = UnitConversion.Convert.ToWei(1000, UnitConversion.EthUnit.Finney);

        public static BigInteger TokenTransactionGas { get; set; } = 900000;
        public static BigInteger TokenTransactionValue { get; set; } = 0;
        public static EthContractData TokenEthData { get; set; } = new EthContractData();

        // Token functions
        public const string TokenTranferFunction = "transfer";
        public const string TokenDeductFunction = "deduct";
        public const string TokenKillFunction = "kill";
        public const int TokenInitialCredits = 100000;
        public const int TokenContractDeduct = 1000;
        public const int TokenTransactionDeduct = 100;
    }
}
