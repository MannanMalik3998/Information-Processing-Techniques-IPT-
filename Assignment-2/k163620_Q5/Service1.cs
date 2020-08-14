using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace k163620_Q5
{
    public partial class Service1 : ServiceBase
    {
        private static Timer timer;
        public static int var=1;
        //private static Boolean chk = false;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 10000 * 6;// *var;

            if(timer.Interval== 3600000 ){//1 hour gap reached
                //var = 1;
                timer.Interval = 10000 * 6;
            }

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            Run();
        }

        protected override void OnStop()
        {
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            
            string[] lines = File.ReadAllLines(System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString());
            if (lines.Length==0) {
                timer.Interval += 2000;

                //var *= 2;
                using (StreamWriter file = File.AppendText(System.Configuration.ConfigurationManager.AppSettings["File"].ToString()))
                {
                    file.WriteLine($"Timer increased by 2 minutes: {timer.Interval}");
                }
                return;
            }
            var = 1;
            System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString(), string.Empty);


            foreach (string line in lines)
            {
                //Console.WriteLine(line);
                String[] str = line.Split('$');
                File.Copy(str[0], System.Configuration.ConfigurationManager.AppSettings["Path"].ToString() + str[1], true);
            }

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
                file.WriteLine($"{e.FullPath}${e.Name}");
            }
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            using (StreamWriter file = File.AppendText(System.Configuration.ConfigurationManager.AppSettings["LogPath"].ToString()))
            {
                file.WriteLine($"{e.FullPath}${e.Name}");
            }
        }
    }
}
