using IdPhotoSharingPlatform_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IdPhotoSharingPlatform_Client.Views.Account;

namespace IdPhotoSharingPlatform_Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsLogin { get; private set; }
        public IdCardData IdCard { get; set; }
        public AccountData AccountInfo { get; set; }

        

        public MainWindow()
        {
            InitializeComponent();
            IsLogin = false;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AccountInfo = new AccountData();
            var login = new Login(AccountInfo);
            login.LoginSuccessed += Login_LoginSuccessed;
            login.Show();         
        }

        private void Login_LoginSuccessed(object sender, EventArgs e)
        {
            IsLogin = true;
            loginInfo.Text = $"已登录 | 账户：{AccountInfo.Address}";
            login.IsEnabled = false;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            IsLogin = false;
            loginInfo.Text = "未登录";
            login.IsEnabled = true;
        }
    }
}
