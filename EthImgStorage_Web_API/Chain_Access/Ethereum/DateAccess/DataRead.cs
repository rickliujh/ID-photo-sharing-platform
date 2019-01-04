using Nethereum.Geth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chain_Access.Ethereum.DateAccess
{
    public class DataRead : EthereumBase
    {
        public DataRead(Web3Geth web3)
        {
            Web3 = web3;
        }
    }
}
