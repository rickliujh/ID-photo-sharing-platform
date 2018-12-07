using System;
using Xunit;

namespace DataProcessingCenter.Tests
{
    public class AccountTests
    {
        string url = "http://localhost:8080/";

        [Fact]
        public async void NewAccount_work()
        {   
            var account = new Account.Account();
            var result = await account.CreateAccountAsync(url, "123456");
            Console.WriteLine(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async void UnlockAccount_work()
        {
            var account = new Account.Account();
            var isSuccessful = await account.UnlockAccountAsync(url, "0xdc6626c228f2f093ab1dc052b6a75f48bfadbd5c", "123456");
            Assert.True(isSuccessful);
        }
    }
}
