using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace k163620_Q4
{
    public struct news
    {
        public String title;
        public String publishDate;
        public String desc;
        public String newsChannel;
    }
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
            timer.Interval = 1000*60*5 ;
            //timer.Interval = 10000 ;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // XmlReaderSettings settings = new XmlReaderSettings();
            // settings.DtdProcessing = DtdProcessing.Parse;

            string url1 = "https://www.suchtv.pk/sports.feed";
            string url2 = "https://www.samaa.tv/feed";

            //string url1 = "http://tribune.com.pk/pakistan/sindh/feed";
            //
            //"http://feeds.bbci.co.uk/news/rss.xml?edition=int";
            //"http://newslens.pk/category/economic-development/feed";
          //  string url2 = "http://newslens.pk/category/human-rights/feed";
                //"http://rss.cnn.com/rss/edition_asia.rss";
                //"https://www.suchtv.pk/sports.feed";


                news[] n = extractFeed(url2, "SamaaTv");//newschannel 1 feed

                
                news[] n2 = extractFeed(url1, "SuchTv");//newschannel 2 feed
                

                makeXML(n, n2);
            
        }

        public static void makeXML(news[] n1, news[] n2)
        {
            //XmlWriter writer = XmlWriter.Create(@"E:\Sem7\IPT\Ass2\k163620_Q4\rssFeed.xml");
            XmlWriter writer = XmlWriter.Create(System.Configuration.ConfigurationManager.AppSettings["path"].ToString());
            writer.WriteStartDocument();
            writer.WriteStartElement("NewsFeed");

            foreach (news i in n1)
            {
                //in while loop
                writer.WriteStartElement("NewsItem");
                writer.WriteElementString("Title", i.title);
                writer.WriteElementString("Description", i.desc);
                writer.WriteElementString("PublishedDate", i.publishDate);
                writer.WriteElementString("NewsChannel", i.newsChannel);
                writer.WriteEndElement();
            }
            foreach (news i in n2)
            {
                //in while loop
                writer.WriteStartElement("NewsItem");
                writer.WriteElementString("Title", i.title);
                writer.WriteElementString("Description", i.desc);
                writer.WriteElementString("PublishedDate", i.publishDate);
                writer.WriteElementString("NewsChannel", i.newsChannel);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }

        public static news[] extractFeed(String url, String NewsChannel)
        {
            XmlReader reader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            //Console.WriteLine(feed.Items.Count()+" total news");

            news[] n = new news[feed.Items.Count()];

            int c = 0;
            foreach (SyndicationItem item in feed.Items)
            {

                n[c].title = item.Title.Text.ToString();
                n[c].desc = Regex.Replace(item.Summary.Text, @"<.+?>", String.Empty).ToString();
                n[c].publishDate = item.PublishDate.ToString();
                n[c].newsChannel = NewsChannel;

                c++;
            }
            return n;
        }

        protected override void OnStop()
        {
        }
    }
}
