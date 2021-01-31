using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiVSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            this.TransparencyKey = this.BackColor;
            this.TopMost = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Left = 0;
            this.Top = 0;
          
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            //var dir = Directory.CreateDirectory(@"C:\Exe");
            try
            {
                var timer = new System.Threading.Timer(
               d => AntiAttack(),
               null,
               TimeSpan.Zero,
               TimeSpan.FromMinutes(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Over " + ex + "done");                
            }
           
        }

         public void AntiAttack() 
        {
            
            foreach (var process in Process.GetProcessesByName("Vsample"))
            {
                // now check the modules of the process
                process.Kill();
            }

            try
            {
                Directory.Delete(@"C:\Exe", true);
            }
            catch (Exception)
            {
                MessageBox.Show("Done Buddy Corrupt Files Deleted!!!");
            }
          
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue("Ulder", false);

            Microsoft.Win32.RegistryKey AntikeyStack = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("AntiUlder", Application.ExecutablePath.ToString());

            Application.Exit();
        }
    }
}
