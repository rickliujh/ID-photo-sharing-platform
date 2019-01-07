namespace EthImgStorage_Web_API.Models.AccountModels
{
    public class Login
    {
        public long AdminAccountMobile { get; set; }
        public string AdminPassword { get; set; }
        public long NewAccountMobile { get; set; }
        public string NewAccountName { get; set; }
        public string NewAccountPassword { get; set; }
    }
}
