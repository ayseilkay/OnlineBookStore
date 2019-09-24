using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace OnlineBookStore
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }   
        Customerlist customerlist = new Customerlist();
        private void btnLogin_Click(object sender, EventArgs e)
        {        
            ArrayList allrecord = customerlist.ReadXML();
            bool success = false;
            foreach (Customer item in allrecord)
            {
                if (txtMail.Text == item.CustomerName1 && txtPassword.Text == item.customerPassword1)
                {
                    success = true;
                    LoginCustomer logincustomer = LoginCustomer.getInstance();
                    logincustomer.customer = item;                 
                    break;
                }
            }
            if (success == true)
            {
                this.Hide();
                Home signin = new Home();
                string buttonname = "Login";
                SaveLog.Savelog(buttonname);
                DialogResult dr = signin.ShowDialog();
                if (dr == DialogResult.OK)
                {                   
                    this.ShowDialog();
                }
                else
                    Application.Exit();
            }
            else
            {
                MessageBox.Show("E-mail or password is wrong\nTry Again Please!");             
            }
            
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignUp sgnup = new SignUp();
            this.Hide();
            sgnup.ShowDialog();
            this.Show();
            string buttonname = "SignUp";
            SaveLog.Savelog(buttonname);
        }
    }
}
