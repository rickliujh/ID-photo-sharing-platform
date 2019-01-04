using Xunit;
using Chain_Access.Ethereum;
using Nethereum.Geth;

namespace Chain_Access.tests.Ethereum.tests
{
    public class AccountTests
    {
        string adderss = null;
        string passwd = "123456";
        Account account;

        public AccountTests()
        {
            account = new Account(new Web3Geth("http://localhost:8080/"));
        }

        [Fact]
        public async void CreateAccount()
        {
            adderss = await account.CreateAccountAsync(passwd);
            Assert.NotEmpty(adderss);
        }

        [Fact]
        public async void UnlockAccount_right_passwd()
        {
            var result = await account
                .UnlockAccountAsync("0xcf480adbebd2deda0e8bced70e03820bc3d7f1f7", passwd);
            Assert.True(result);
        }

        [Fact]
        public async void UnlockAccount_wrong_passwd()
        {
            var wrongPasswd = "132";
            var result = await account
                .UnlockAccountAsync(adderss, wrongPasswd);
            Assert.False(result);
        }
    }
}
