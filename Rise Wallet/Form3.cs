using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rise_Wallet
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RiseSharp.Core.Helpers.AccountHelper.GetAccount(textBox1.Text);
                //label1.Equals("Success");
                System.Windows.Forms.MessageBox.Show("Welcome \n" + RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox1.Text).IdString);
                Rise_Wallet.Properties.Settings.Default.Textbox = RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox1.Text).IdString;
            }
            catch
            {
                //label1.Equals("Fail");
                System.Windows.Forms.MessageBox.Show("Failed");
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var secret = RiseSharp.Core.Helpers.CryptoHelper.GenerateSecret();
                MessageBox.Show(secret);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text Files|*.txt";
                saveFileDialog1.Title = "Save your Wallet Secret Passphrase";
                saveFileDialog1.ShowDialog();
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName);
                file.WriteLine(secret);
                file.Close();
            }
            catch
            {
                MessageBox.Show("You've choosen not to save your Passphrase.\n\nPlease note that if you dont remember your wallet passphrase, we can't help you retrieve it back.\n\nRegards,\nRISE Staff");
            }
        }
    }
}
