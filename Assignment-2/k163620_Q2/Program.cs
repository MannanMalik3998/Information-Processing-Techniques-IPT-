using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace k163620_Q2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 myForm = new Form1();
            Application.Run(myForm);

            /*
            Console.WriteLine(myForm.rec + " " + myForm.subj + " " + myForm.msg);
            XmlWriter writer = XmlWriter.Create("E:\\Sem7\\IPT\\Ass2\\k163620_Q2\\Emails\\" + myForm.rec + ".xml");
                writer.WriteStartElement("EmailMessage");
                writer.WriteElementString("To",myForm.rec);
                writer.WriteElementString("Subject",myForm.subj);
                writer.WriteElementString("MessageBody",myForm.msg);
                writer.WriteEndElement();
                writer.Close();
                writer.Flush();
            */
        }
    }
}
