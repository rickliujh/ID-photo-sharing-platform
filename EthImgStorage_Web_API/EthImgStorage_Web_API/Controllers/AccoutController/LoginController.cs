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

            //TODO:判断管理员账户是否可用
            var user = DbContext.Users.SingleOrDefault(a => a.Mobile == data.AdminAccountMobile);
            if (user == null)
            {
                Message.Error = "Did not find this account!";
                Message.Code = 1;
                return new JsonResult(Message);
            }
            if (user.Password != MD5Encrypt16(data.AdminPassword))
            {
                Message.Error = "Account password is incorrect!";
                Message.Code = 1;
                return new JsonResult(Message);
            }

            //TODO:判断该手机号是否存在
            var isExist = DbContext.Users.SingleOrDefault(a => a.Mobile == data.NewAccountMobile);
            if (isExist != null)
            {
                Message.Error = "Account already exists!";
                Message.Code = 1;
                return new JsonResult(Message);
            }

            //TODO:向以太坊客户端申请地址
            var newAddress = await account.CreateAccountAsync(data.NewAccountPassword);

            //TODO:将所有信息写入数据库
            await DbContext.Users.AddAsync(new User
            {
                Mobile = data.NewAccountMobile,
                Name = data.NewAccountName,
                Password = MD5Encrypt16(data.NewAccountPassword),
                EthereumAddress = newAddress,
                LoginTime = DateTime.Now,
                Character = Character.User
            });

            var result = await DbContext.SaveChangesAsync();

            //if (result == null)
            //{
            //    Message.Error = "Save to database error！";
            //    Message.Code = 1;   
            //}

            Message.Code = 0;
            Message.Msg = "success！";
            return new JsonResult(new { Message = Message });
        }
    }
}