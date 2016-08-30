using RiseSharp.Core.Api;
using RiseSharp.Core.Api.Messages.Node;
using RiseSharp.Core.Api.Models;
using RiseSharp.Core.Helpers;
using RiseSharp.Core.Extensions;
using RiseSharp.Core.Exceptions;
using RiseSharp.Core;
using RiseSharp.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Diagnostics;
using RiseSharp.Core.Services;

namespace Rise_Wallet
{
    public partial class Form2 : Form
    {
       // Form1 Form42;
        string text;
        public Form2()
        {
            //Form_42 = Form42;
            
            InitializeComponent();
        }
        //public string textBoxForm2
        //{
        //    set { text = value; }
        //}
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            
            IRiseNodeApi _api = new RiseNodeApi(new ApiInfo
            {
                //Host = "yourhostip", // This can be any Rise node in the network, default is https://wallet.rise.vision
                //Port = "port"
                UseHttps = true
            });

            // gets account balance from other Rise nodes,  /api/accounts/getBalance
            var response = await _api.GetAccountBalanceAsync(new AccountRequest


            {
                Address = RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox3.Text).IdString
            });
                //label3.Text = Convert.ToString(response.Balance);
        }
       

        private async void label3_Click(object sender, EventArgs e)
        {
            IRiseNodeApi _api = new RiseNodeApi(new ApiInfo
            {
                //Host = "yourhostip", // This can be any Rise node in the network, default is https://wallet.rise.vision
                //Port = "port"
                UseHttps = true
            });

            // gets account balance from other Rise nodes,  /api/accounts/getBalance
            var response = await _api.GetAccountBalanceAsync(new AccountRequest

            {
                Address = RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox3.Text).IdString
            });
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //Rise_Wallet.Properties.Settings.Default.Textbox.t
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Undergoing Development , This will have more info about things in this wallet");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            IRiseNodeApi _api = new RiseNodeApi(new ApiInfo
            {
                //Host = "yourhostip", // This can be any Rise node in the network, default is https://wallet.rise.vision
                //Port = "port"
                UseHttps = true
            });
            try 
            {
                var _service = new AccountService(textBox3.Text);
                long amt;long.TryParse(textBox2.Text, out amt);
                 var result = await _service.SendAsync(textBox1.Text, amt);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void walletPassphraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //textBox3.Text = Form42.textBox1.Text;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 10)
            {
                RiseSharp.Core.Helpers.AccountHelper.GetAccount(textBox1.Text);
                //label1.Equals("Success");
                System.Windows.Forms.MessageBox.Show("Welcome \n" + RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox3.Text).IdString);
                Rise_Wallet.Properties.Settings.Default.Textbox = RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox3.Text).IdString;
                textBox3.ReadOnly = true;
                button2.Hide();
                button3.Hide();
                label3.Text = RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox3.Text).IdString;
               
            }
            //else if (textBox3.Text.Length < 0)
            //    {
            //    //label1.Equals("Fail");
            //    System.Windows.Forms.MessageBox.Show("You have to enter your wallet secret passphrase in order to access your wallet");

            //}
            else
            {
                MessageBox.Show("An Error has occurred");
            }

        }

        private void button3_Click(object sender, EventArgs e)
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
                textBox3.Text = secret;
                textBox3.ReadOnly = true;
                button2.Hide();
                button3.Hide();
                label3.Text = RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox3.Text).IdString;
            }
            catch
            {
                MessageBox.Show("You've choosen not to save your Passphrase.\n\nPlease note that if you dont remember your wallet passphrase, we can't help you retrieve it back.\n\nRegards,\nRISE Staff");
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            textBox3.ResetText();
            button2.Show();
            button3.Show();
            label3.ResetText();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar= checkBox1.Checked ? '\0' : '*';
        }

        private async void label7_MouseClick(object sender, MouseEventArgs e)
            
        {
            IRiseNodeApi _api = new RiseNodeApi(new ApiInfo
            {
                //Host = "yourhostip", // This can be any Rise node in the network, default is https://wallet.rise.vision
                //Port = "port"
                UseHttps = true
            });
            var response = await _api.GetAccountBalanceAsync(new AccountRequest

            {
                Address = RiseSharp.Core.Helpers.CryptoHelper.GetAddress(textBox3.Text).IdString
            });
             //var amt1 = Convert.ToDouble(response);
             //var damt = amt1 / Math.Pow(10, 8);
             label7.Text = Convert.ToDouble(response.Balance.ToString());
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //private async void label3_TextChanged(object sender, EventArgs e)
        //{
        //    IRiseNodeApi _api = new RiseNodeApi(new ApiInfo
        //    {
        //        //Host = "yourhostip", // This can be any Rise node in the network, default is https://wallet.rise.vision
        //        //Port = "port"
        //        UseHttps = true
        //    });

        //    // gets account balance from other Rise nodes,  /api/accounts/getBalance
        //    var response = await _api.GetAccountBalanceAsync(new AccountRequest

        //    {
        //        Address = Rise_Wallet.Properties.Settings.Default.Textbox
        //});
        //    label3.Text= Convert.ToString(response.Balance.ToString());

        //}
    }
}
   

