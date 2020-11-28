using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OxyPlot;

namespace lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double Entropy(string text, int count)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();
            double h = 0;
            for (int i = 0; i<text.Length-(count-1); ++i)
            {
                string buf = text.Substring(i, count);
                if(counter.ContainsKey(buf))
                {
                    counter[buf] = counter[buf] + 1;
                }
                else
                {
                    counter.Add(buf, 1);
                }
            }
            double[] ver = new double[counter.Count];
            for (int i=0; i< ver.Length; ++i)
            {
                double a = counter.ElementAt(i).Value;
                double b = text.Length;
                ver[i] = a/b;
            }
            for (int i = 0; i < ver.Length; ++i)
            {
                h += ver[i]*Math.Log(ver[i], 2);
            }
            return h;
        }
        private double[] hk;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sub = null;
            string result = null;
            char[] let = textBox1.Text.ToCharArray();
            for (int i=0; i<textBox1.Text.Length; ++i)
            {
                if (Char.IsLetter(let[i]))
                {
                    sub = textBox1.Text.Substring(i, 1);
                    result = String.Concat(result, sub);
                }
            }
            result = result.ToLower();
            hk = new double[5] { Entropy(result, 1)/1, Entropy(result, 2)/2, Entropy(result, 3)/3, Entropy(result, 4)/4, Entropy(result, 5)/5 };
            label2.Text = String.Concat(label2.Text, " ", hk[0].ToString());
            label3.Text = String.Concat(label3.Text, " ", hk[1].ToString());
            label4.Text = String.Concat(label4.Text, " ", hk[2].ToString());
            label5.Text = String.Concat(label5.Text, " ", hk[3].ToString());
            label6.Text = String.Concat(label6.Text, " ", hk[4].ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 openform = new Form2(hk);
            openform.Show();
        }

       

    }
}
