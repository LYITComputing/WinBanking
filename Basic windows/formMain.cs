using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banking;

namespace Basic_windows
{
    public partial class frmMain : Form
    {
        //List of accounts
        List<BankAccount> accounts;
        public frmMain()
        {
            InitializeComponent();

            //Initialise the bank accounts list
            accounts = new List<BankAccount>();
        }


        private void btnMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The name of the new customer is {this.textBoxName.Text}");
        }

        private void textBoxBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Check to see if the character is a control character, not a digit or not a '.'
            if(char.IsControl(e.KeyChar))
            {
                MessageBox.Show($"we have a control character: {e.KeyChar}");
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                //If it is a control character, non numeric o r not a '-' we handle it
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to create this new account?";
            string caption = "Confirm account creation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message,caption, buttons);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                // Closes the parent form.
                this.Close();
            }
            else
            {
                //Create a new account
                var newAccount = new BankAccount(textBoxName.Text, Convert.ToDecimal(textBoxBalance.Text));
                accounts.Add(newAccount);
                MessageBox.Show("Account created successfully");
                this.textBoxBalance.Text = "";
                this.textBoxName.Text = "";
                this.buttonDisplayAccounts.Visible = true;
            }

        }

        private void buttonDisplayAccounts_Click(object sender, EventArgs e)
        {
            //formAccounts accountsForm = new formAccounts("will this work?");
            formAccounts accountsForm = new formAccounts(this.accounts);
            accountsForm.Show();
        }
    }
}


