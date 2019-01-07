using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChainAccess.Ethereum;
using EthImgStorage_Web_API.Models.AccountModels;
using EthImgStorage_Web_API.Models.DataBase;
using System;
using System.Linq;

namespace EthImgStorage_Web_API.Controllers.AccoutController
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class LoginController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login data)
        {
            var account = new Account();
            var dbContext = new PlatformDbContext();
            Message.Code = 0;
            Message.Msg = "success！";

            //TODO:判断管理员账户是否可用
            //var user = dbContext.Users.SingleOrDefault(a =>  a.Mobile == data.AdminAccountMobile);
            //if(user == null)
            //{
            //    Message.Error = "Did not find this account!";
            //    Message.Code = 1;
            //    return new JsonResult(Message);
            //}
            //if (user.Password != MD5Encrypt16(data.AdminPassword))
            //{
            //    Message.Error = "Account password is incorrect!";
            //    Message.Code = 1;
            //    return new JsonResult(Message);
            //}
            //var isSuccess = await account.UnlockAccountAsync(user.EthereumAddress, data.AdminPassword);
            //if (!isSuccess)
            //{
            //    Message.Error = "Account or Password wrong!";
            //    Message.Code = 1;
            //    return new JsonResult(Message);
            //}

            //TODO:向以太坊客户端申请地址
            //var newAddress = await account.CreateAccountAsync(data.NewAccountPassword);
            var newAddress = "0xd5e4076669b70db438855832d85b9c174680f46b";

            //TODO:将所有信息写入数据库
            await dbContext.Users.AddAsync(new User
            {
                Mobile = data.NewAccountMobile,
                Name = data.NewAccountName,
                Password = MD5Encrypt16(data.NewAccountPassword),
                EthereumAddress = newAddress,
                LoginTime = DateTime.Now,
                Character = Character.User
            });

            var result = await dbContext.SaveChangesAsync();

            //if (result == null)
            //{
            //    Message.Error = "Save to database error！";
            //    Message.Code = 1;   
            //}

            return new JsonResult(Message);
        }
    }
}