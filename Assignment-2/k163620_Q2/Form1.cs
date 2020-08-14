using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace k163620_Q2
{
    public partial class Form1 : Form
    {
        public string rec="", subj, msg;
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //rec = textBox1.Text;
           // Console.WriteLine(rec);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
                rec = textBox1.Text;
            if (!rec.Equals(""))
            {
                msg = richTextBox1.Text;
                subj = textBox2.Text;
                textBox1.Text = "";
                textBox2.Text = "";
                richTextBox1.Text = "";
                string fileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                string Path = System.Configuration.ConfigurationManager.AppSettings["Path"].ToString();
                //XmlWriter writer = XmlWriter.Create("E:\\Sem7\\IPT\\Ass2\\k163620_Q2\\Emails\\" + fileName + ".xml");
                XmlWriter writer = XmlWriter.Create(Path + fileName + ".xml");
                Console.WriteLine();
                writer.WriteStartElement("EmailMessage");
                writer.WriteElementString("To", rec);
                writer.WriteElementString("Subject", subj);
                writer.WriteElementString("MessageBody", msg);
                writer.WriteEndElement();
                writer.Close();
                writer.Flush();
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            //subj = textBox2.Text;
           // Console.WriteLine(subj);

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            //msg = richTextBox1.Text;
            //Console.WriteLine(msg);
        }
    }
}
