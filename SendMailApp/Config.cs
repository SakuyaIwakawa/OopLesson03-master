using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp
{
    class Config
    {
        private static Config instance;

        public string Smtp { get; set; }
        public string MailAddress { get; set; }
        public string PassWord { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }

        public static Config GetInstance()
        {
            if(instance == null)
            {
                instance = new Config();
            }
            return instance;
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
        public void Serialise()
        {
            using (var writer = XmlWriter.Create("config.xml"))
            {
                var serializer = new XmlSerializer(instance.GetType());
                serializer.Serialize(writer, instance);
            }
        }

        public void DeSerialize()
        {
            using(var reader = XmlReader.Create(new StringReader("config.xml")))
            {
                var serializer = new XmlSerializer(typeof(Config));
                instance = serializer.Deserialize(reader) as Config;
            }
        }
    }
}
