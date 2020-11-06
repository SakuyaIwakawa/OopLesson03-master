using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailApp
{
    class Config
    {
        private static Config Instance { get; set; }

        public string Smtp { get; set; }
        public string MailAddress { get; set; }
        public string PassWord { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }

        public static Config GetInstance()
        {
            if(Instance == null)
            {
                Instance = new Config();
            }
            return Instance;
        }

        public Config getDefaultStatus()
        {
            Config obj = new Config
            {
                Smtp = "smtp.gmail.com",
                MailAddress = "ojsinfosys01@gmail.com",
                PassWord = "ojsInfosys2020",
                Port = 587,
                Ssl = true,
            };
            return obj;
        }

        public void DefaultSet()
        {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }
        public bool UpdateStatus(string smtp,string mailAddress,string passWord, int port, bool ssl)
        {
            this.Smtp = Smtp;
            this.Port = Port;
            this.MailAddress = MailAddress;
            this.PassWord = PassWord;
            this.Ssl = Ssl;

            return true;
        }
    }
}
