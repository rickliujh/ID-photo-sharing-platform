using System.Threading.Tasks;

namespace ChainAccess.Ethereum.DateAccess
{
    public class DataRead : EthereumBase
    {
        public DataRead()
        {
        }

        public async Task<string> GetDataFromChain(string transationId)
        {
            var hexResult = await Web3
                .Eth
                .Transactions
                .GetTransactionByHash
                .SendRequestAsync(transationId);

            var result = new Nethereum
                .Hex
                .HexConvertors
                .HexUTF8StringConvertor()
                .ConvertFromHex(hexResult.Input);

            return result;
        }
    }
}
