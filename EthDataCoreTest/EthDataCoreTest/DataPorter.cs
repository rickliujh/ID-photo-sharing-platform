using Nethereum.Geth;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Numerics;

namespace DataProcess
{
    class DataPorter
    {
        private string url { get; set; }

        //Incoming url calls privatechain via http
        public DataPorter(string Url)
        {
            url = Url;
        }

        public string WriteData(string senderAddress, string Password, string Data, string DataName)
        {
            string TxHash = null;
            //Connection privatechain RPC socket
            Web3Geth Web3 = new Web3Geth(url);

            //Write data to privatechain
            try
            {

                ///Get Transaction count
                //var txCount = Web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(senderAddress);
                //Console.WriteLine(txCount.Result.Value);

                
                
                ///Send transactions and input data
                var x = new TransactionInput(new HexUTF8String(Data).HexValue, new HexBigInteger("0xffffff"), senderAddress);
                
                ///Unlock account
                ulong? ul = null;
                Web3.Personal.UnlockAccount.SendRequestAsync(senderAddress, Password, ul);

                var result = Web3.Eth.Transactions.SendTransaction.SendRequestAsync(x);
                TxHash = result.Result;

                //Console.WriteLine(result.Result);

                ///<summary>
                ///Alternate writing
                ///Web3.Eth.Transactions.SendTransaction.
                ///    SendRequestAsync(new TransactionInput(Data, "0x9ffef1d06f9c684d618b9c2e0df76298996b0dae",
                ///    senderAddress, new HexBigInteger(long.Parse("0xffffffff")), new HexBigInteger(long.Parse("0xffffffff")),
                ///    new HexBigInteger(new BigInteger(100))));


                ///new HexBigInteger("2000"), new HexBigInteger(new BigInteger(200))
                ///first Tx Hash"0x55dd48ab1527a0c4547a9aed94f83af6e9fa71315e4c4b368b5686e8dd59a787"
                ///</ summary >

                ///Save transation to DataMap
                //new ImageDataMap().AddImageToMap(DataName, senderAddress, TxHash);
            }
            catch (Exception e)
            {
                TxHash = e.Message;
                throw;
            }

            //Get Transaction count
            //txCount = Web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(senderAddress);
            //Console.WriteLine(txCount.Result.Value);

            return TxHash;

        }

        public string ReadData(string Hx)
        {
            //Connection privatechain RPC socket
            Web3Geth Web3 = new Web3Geth(url);
            //Get transactions massage
            var result = Web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(Hx);
            //return Input
            return ConvertHexStringToString(result.Result.Input);
        }



        private string ConvertHexStringToString(string Str)
        {
            return new Nethereum.Hex.HexConvertors.HexUTF8StringConvertor().ConvertFromHex(Str);
        }

        public BigInteger GetTransactionCount(string senderAddress)
        {
            Web3Geth Web3 = new Web3Geth(url);
            var result = Web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(senderAddress);
            return result.Result.Value;
        }
    }
}
