using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Permissions;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Service2
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
            Run();
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string[] lines = File.ReadAllLines(System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString());
            System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString(), string.Empty);


            foreach (string line in lines)
            {
                //Console.WriteLine(line);
                String[] str = line.Split('$');
                SendMail(str[1],str[2]);
                //File.Copy(str[0], System.Configuration.ConfigurationManager.AppSettings["Path"].ToString() + str[1], true);

            }

        }

        private static void SendMail(String folder,String size)
        {
            
            
            string sender = System.Configuration.ConfigurationManager.AppSettings["Sender"].ToString();
            string pass = System.Configuration.ConfigurationManager.AppSettings["Pass"].ToString();
            string rec = System.Configuration.ConfigurationManager.AppSettings["Receiver"].ToString();

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(sender);
            mail.To.Add(rec);
            mail.Subject ="Folder_Change_Notificaion";
            mail.Body = folder+" modified\nSize: "+size+" bytes";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(sender, pass);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);


            

        }


        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            // Create a new FileSystemWatcher and set its properties.            
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = System.Configuration.ConfigurationManager.AppSettings["MonitorPath"].ToString();

            // Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories.             
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName
                                    | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            // Add event handlers.            
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            //watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;
            // Begin watching.              
            watcher.EnableRaisingEvents = true;

        }

        // Define the event handlers.        
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.          
            using (StreamWriter file = File.AppendText(System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString()))
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter())
            {
                //file.WriteLine($"{e.FullPath}${e.ChangeType}${e.Name}");
                FileInfo f = new FileInfo(e.FullPath);
                file.WriteLine($"{e.FullPath}${e.Name}${f.Length}");
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            using (StreamWriter file = File.AppendText(System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString()))
            {
                FileInfo f = new FileInfo(e.FullPath);
                file.WriteLine($"{e.FullPath}${e.Name}${f.Length}");
            }
        }

        protected override void OnStop()
        {
        }
    }
}
