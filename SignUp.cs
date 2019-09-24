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
using System.Xml;
using System.Xml.Linq;

namespace OnlineBookStore
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        Customerlist customerlist = new Customerlist();
        private void btnSignup_Click(object sender, EventArgs e)
        {
            ArrayList allrecord = customerlist.ReadXML();
            bool flag=false;
            foreach (Customer csm in allrecord)
            {
                if (txtMail.Text == csm.CustomerEmail1)
                {
                    MessageBox.Show("This email is already used!");
                    flag = true;
                }
            }

            if (txtPassword.Text != txtPassword2.Text)
            {
                MessageBox.Show("Passwords are not matching!");
            }
            else if (chkMA.Checked == false)
            {
                MessageBox.Show("First, you have to accept Membership Agreement.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
            else if (txtPassword.Text == txtPassword2.Text && chkMA.Checked == true&&flag==false)
            {
                XDocument x = XDocument.Load(@"CustomerList.xml");
                x.Element("ArrayOfCustomer").Add(
                new XElement("Customer",
                new XElement("CustomerName", txtName.Text), new XElement("CustomerLastName", txtLastname.Text),
                new XElement("CustomerEmail", txtMail.Text),
                new XElement("CustomerPhoneNumber", txtPhone.Text),
                new XElement("CustomerPassword", txtPassword.Text)
                ));
                x.Save(@"CustomerList.xml");
                MessageBox.Show("Record  is Completed");
            }
            string buttonname = "SignUpCreate";
            SaveLog.Savelog(buttonname);
        }

        public bool UsernameCheck()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + @"\\CustomerList.xml");
                XmlNodeList nodelist = xmlDoc.SelectNodes("/ArrayOfCustomer/Customer");
                foreach (XmlNode item in nodelist)
                {
                    if (txtName.Text == item.SelectSingleNode("CustomerName").InnerText)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            this.Hide();
            signin.Show();         
            string buttonname = "Return";
            SaveLog.Savelog(buttonname);
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            txtName.Text = "";
        }

        private void txtLastname_MouseClick(object sender, MouseEventArgs e)
        {
            txtLastname.Text = "";
        }

        private void txtMail_MouseClick(object sender, MouseEventArgs e)
        {
            txtMail.Text = "";
        }

        private void txtPhone_MouseClick(object sender, MouseEventArgs e)
        {
            txtPhone.Text = "";
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
        }

        private void txtPassword2_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword2.Text = "";
            txtPassword2.PasswordChar = '*';
        }

        private void chkMA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to teda.com. Teda Services provide website features and other products and services to you when you visit or shop at teda.com, use teda products or services, use software provided by teda in connection with any of the foregoing (collectively, Teda Services).", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
