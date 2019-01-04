using Nethereum.Geth;
using System.Threading.Tasks;

namespace Chain_Access.Ethereum.DateAccess
{
    public class DataRead : EthereumBase
    {
        public DataRead(Web3Geth web3)
        {
            Web3 = web3;
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
