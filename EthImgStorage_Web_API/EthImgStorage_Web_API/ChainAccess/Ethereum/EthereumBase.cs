using Nethereum.Geth;
using System;

namespace ChainAccess.Ethereum
{
    public class EthereumBase
    {
        public string ConnectionUrl { get; set; }
        public Web3Geth Web3 { get; set; }

        public EthereumBase()
        {
            ConnectionUrl = "http://localhost:8080/";
            Web3 = new Web3Geth(ConnectionUrl);
        }

        public void initialization(string connectionUrl)
        {
            ConnectionUrl = connectionUrl;
            if (ConnectionUrl == null)
                throw new Exception("Need to specify a connection string!");

            Web3 = new Web3Geth(ConnectionUrl);
        }
    }
}
