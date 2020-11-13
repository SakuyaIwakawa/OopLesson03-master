using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace SendMailApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        SmtpClient sc = new SmtpClient();
        public MainWindow()
        {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("送信はキャンセルされました。");
            }
            else
            {
                MessageBox.Show("送信完了！");
            }
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage("ojsinfosys01@gmail.com", tbTo.Text);

                if(tbCc.Text != "")
                msg.CC.Add(tbCc.Text);

                if(tbBcc.Text != "")
                msg.Bcc.Add(tbBcc.Text);

                msg.Subject = tbTitle.Text;
                msg.Body = tbBody.Text;

                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("ojsinfosys01@gmail.com", "ojsInfosys2020");

                sc.SendMailAsync(msg);
                //sc.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            sc.SendAsyncCancel();
        }

        private void btConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindowShow();
        }

        private static void ConfigWindowShow()
        {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Config.GetInstance().DeSerialize();
            }
            catch (FileNotFoundException)
            {
                ConfigWindowShow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Config.GetInstance().Serialise();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addfileBT_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                addfile.Items.Add(dialog.FileName);
            }
        }

        private void deleteBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sel = addfile.SelectedIndex;
                addfile.Items.RemoveAt(sel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
