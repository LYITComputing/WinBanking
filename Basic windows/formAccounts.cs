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
    public partial class formAccounts : Form
    {
        //A list of accounts passed to the constructor
        private List<BankAccount> accounts;
        //public formAccounts(string message)
        public formAccounts(List<BankAccount> bankAccounts)
        {
            accounts = bankAccounts;
            InitializeComponent();
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            //Initialise the controls on the form using the data in the List<BankAccount> accounts field
            InitialiseListView();
            InitialiseListBoxView();
        }

        private void InitialiseListBoxView()
        {
            //this.listViewAccounts.Items.Add(accounts);
            this.listBoxAccounts.DataSource = accounts;
            this.listBoxAccounts.DisplayMember = "Number";
        }

        private void InitialiseListView()
        {
            //Initialise the list view with accounts
            listViewAccounts.View = View.Details;
            listViewAccounts.GridLines = true;

            // Create columns for the account#, owner and balance account properties.
            listViewAccounts.Columns.Add(new ColumnHeader());
            this.listViewAccounts.Columns[0].Text = "Account #";
            this.listViewAccounts.Columns[0].Width = 100;

            listViewAccounts.Columns.Add(new ColumnHeader());
            this.listViewAccounts.Columns[1].Text = "Owner";
            this.listViewAccounts.Columns[1].Width = 100;

            listViewAccounts.Columns.Add(new ColumnHeader());
            this.listViewAccounts.Columns[2].Text = "Balance";
            this.listViewAccounts.Columns[2].Width = 100;


            //Iterate through the list of accounts and construct an appropriate list item
            foreach (BankAccount acc in accounts)
            {
                ListViewItem tempItem = new ListViewItem(new string[] { acc.Number, acc.Owner, acc.Balance.ToString() });
                listViewAccounts.Items.Add(tempItem);
            }
        }
    }
}
