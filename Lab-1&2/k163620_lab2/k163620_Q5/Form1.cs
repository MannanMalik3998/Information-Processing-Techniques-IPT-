using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace k163620_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            localhost.Currency curr = new localhost.Currency();
            string value = textBox1.Text;
            string convertFrom = (textBox2.Text).ToUpper();
            string convertTo = (textBox3.Text).ToUpper();

            double val = Double.Parse(value);
            
            textBox4.Text= (curr.currencyConverter(val,convertFrom,convertTo)).ToString();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
