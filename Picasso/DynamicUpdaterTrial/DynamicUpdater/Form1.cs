using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;


namespace DynamicUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        static System.Net.Sockets.TcpClient Socket;
        private void Form1_Load(object sender, EventArgs e)
        {

            Socket = new System.Net.Sockets.TcpClient();
            Socket.Connect(Dns.Resolve("picassoemu.no-ip.info").AddressList[0].ToString(), 85);
            AskNews();

        }
        private void AskNews()
        {
            StreamReader SR = new StreamReader(Socket.GetStream());
            label1.Text = SR.ReadLine();
            while(!SR.EndOfStream)
                label1.Text = label1.Text + "\n" + SR.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        public static Process proc;
        public static Thread autorestart;
        private void button1_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show("This version of !PiCaSsO! Launcher is only destinated to indicate the news. As the !PiCaSsO! Emu isn't public yet, why would you like to start it?", "Version information");
            
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Press OK to stop the server", "Confirmation", MessageBoxButtons.OKCancel);
            if( DialogResult.Cancel == dr);
            else{
            Process Process;
            Process = Process.GetCurrentProcess();
            autorestart.Abort();
            proc.CloseMainWindow();
            Process.CloseMainWindow();
            return;
            }
        }
        public static void AutoRestarter()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (proc.HasExited == true)
                proc.Start();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            /*proc = Process.Start("!PiCaSsO!.exe");
            button1.Visible = false;
            button2.Visible = true;
            autorestart = new Thread(new ThreadStart(DynamicUpdater.Form1.AutoRestarter));
            autorestart.Start();*/
        /*
            MessageBox.Show("This version of !PiCaSsO! Launcher is only destinated to indicate the news. As the !PiCaSsO! Emu isn't public yet, why would you like to start it?", "Version information");



        }*/
    }
}