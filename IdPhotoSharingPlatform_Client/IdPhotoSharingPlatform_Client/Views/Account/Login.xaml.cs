using IdPhotoSharingPlatform_Client.Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using IdPhotoSharingPlatform_Client.Http;
using System.Collections.Generic;

namespace IdPhotoSharingPlatform_Client.Views.Account
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        private string url = "https://localhost:44332/api//Login/";
        public AccountData Account { get; set; }

        public event EventHandler LoginSuccessed;

        public Login(AccountData account)
        {
            InitializeComponent();
            Account = account;
        }

        public async Task<bool> DoLogin()
        {
            var data = new Dictionary<string, string>();
            data["Account"] = Account.Address;
            data["Password"] = Account.Password;
            var result = await HttpPost.DoPostAsync(data, url);
            if (result == "true") return true;
            return false;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account.Address = this.address.Text;
                Account.Password = this.password.Text;
                var isSuccessful = await DoLogin();
                if (!isSuccessful)
                {
                    MessageBox.Show("登录失败！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    LoginSuccessed.Invoke(this, null);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("网络超时!", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
