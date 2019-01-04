using Nethereum.Geth;
using System;

namespace ChainAccess.Ethereum
{
    public class EthereumBase
    {
        public string ConnectionUrl { get; set; }
        protected Web3Geth Web3 { get; set; }

        public EthereumBase()
        {
            if (ConnectionUrl == null)
            {
                throw new Exception("Need to specify a connection string!");
            }
            Web3 = new Web3Geth(ConnectionUrl);
        }

        public EthereumBase(string connectionUrl)
        {
            ConnectionUrl = connectionUrl;
            Web3 = new Web3Geth(ConnectionUrl);
        }
    }
}
