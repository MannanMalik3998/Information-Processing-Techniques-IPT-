using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace k163620_Q3
{
    public partial class Service1 : ServiceBase
    {
        private static Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000*60*15;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        protected override void OnStop()
        {
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            SendMail();
        }

        private static void SendMail() {

            XmlDocument doc = new XmlDocument();
            //foreach (string file in Directory.GetFiles("E:\\Sem7\\IPT\\Ass2\\k163620_Q2\\Emails", "*.xml"))
            foreach (string file in Directory.GetFiles(System.Configuration.ConfigurationManager.AppSettings["Path"].ToString(), "*.xml"))
            {
                //doc.Load("E:\\Sem7\\IPT\\Ass2\\k163620_Q2\\Emails\\2019-10-03 20-12-42.xml");
                doc.Load(file);
                File.Delete(file);
                XmlNode n = doc.DocumentElement;

                string sender = System.Configuration.ConfigurationManager.AppSettings["Sender"].ToString();
                string pass = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(sender);

                mail.To.Add(n.ChildNodes[0].InnerText);
                mail.Subject = n.ChildNodes[1].InnerText;
                mail.Body = n.ChildNodes[2].InnerText;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender, pass);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);


            }
            
        }
    }
}
