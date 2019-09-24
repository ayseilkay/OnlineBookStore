using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }
 
        private void Profile_Load(object sender, EventArgs e)
        {
            LoginCustomer customerprofile = LoginCustomer.getInstance();
            string[] profile = customerprofile.customer.printCustomerDetails();
            lblName.Text = profile[0];
            lblLastname.Text = profile[1];
            lblEmail.Text = profile[2];
            lblPhone.Text = profile[3];
            lblcartnumberprof.Visible = false;
            lblcartnumber.Visible = false;
        
            Random rnd = new Random();
            float ordernumber = rnd.Next(10000, 90000);
            lblOrderNumber.Text = "" + ordernumber;
            lblAmount.Text = "" + Home.shopCart.PaymentAmount;
            lblPaymentType.Text = "" + Home.shopCart.PaymentType;
            if (Home.shopCart.PaymentType == "Credit Card")
            {
                lblcartnumberprof.Visible = true;
                lblcartnumber.Visible = true;
                lblnname.Text = Home.shopCart.CreditCartName;
                lblnnumber.Text = Home.shopCart.CreditCardnumber;
            }
        }
    }
}
