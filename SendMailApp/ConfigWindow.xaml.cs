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
using System.Windows.Shapes;

namespace SendMailApp
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void btDefault_Click(object sender, RoutedEventArgs e)
        {
            Config cf = (Config.GetInstance()).getDefaultStatus();

            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            (Config.GetInstance()).UpdateStatus(tbSmtp.Text, tbUserName.Text,
                tbPassWord.Password, int.Parse(tbPort.Text), cbSsl.IsChecked ?? false);
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            btApply_Click(sender, e);
            this.Close();
        }
        bool ch = false;
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (ch)
            {
                MessageBoxResult result = MessageBox.Show("変更が反映されていません","title",MessageBoxButton.OKCancel);
                if(result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            ch = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config cf = Config.GetInstance();
            tbSmtp.Text = cf.Smtp;
            tbUserName.Text = cf.MailAddress;
            tbPort.Text = cf.Port.ToString();
            tbPassWord.Password = cf.PassWord;
            tbSender.Text = cf.MailAddress;
            cbSsl.IsChecked = cf.Ssl;

            ch = false;
        }
    }
}
