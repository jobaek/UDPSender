using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPsender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static byte[] CreateSpecialByteArray(string data, int length)
        {
            var arr = new byte[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (byte)data[i];
            }
            return arr;
        }

        static void udelay(long us)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            long v = (us * System.Diagnostics.Stopwatch.Frequency) / 1000000;
            while (sw.ElapsedTicks < v)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipaddr = textBox1.Text;
            int port = Int32.Parse(textBox2.Text);
            long interval = long.Parse(textBox4.Text);
            int count = Int32.Parse(textBox5.Text);

            UdpClient udpClient = new UdpClient(ipaddr, port);

            for(int i = 0; i < count; i++)
            {
                for(int idx=0; idx<listBox1.Items.Count; idx++)
                {
                    string strData = listBox1.Items[idx].ToString();
                    Byte[] sendBytes = CreateSpecialByteArray(strData, strData.Length);

                    udpClient.Send(sendBytes, sendBytes.Length);
                    udelay(interval);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
                listBox1.Items.Add(textBox3.Text);
        }
    }
}
