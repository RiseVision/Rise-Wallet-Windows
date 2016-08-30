using System;
using System.Windows.Forms;
using RiseSharp;
using RiseSharp.Core.Common;
namespace Rise_Wallet
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form options = new Form2();
            //options.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string RAccount = textBox1.Text;
        }
        public delegate void PassDataToSecondForm(TextBox text);
        public void button1_Click(object sender, EventArgs e)
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
            //Form form2 = new Form2();
           // form2.Show();

        }
        //public string textBoxForm1
        //{
        //    get { return textBox1.Text; }
        //}
        private void label1_Click(object sender, EventArgs e)
        {
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

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter Wallet: You should use this while accessing your wallet. \n\nCreate a new wallet: This should be used to create a new wallet to store your RISE Coins.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
