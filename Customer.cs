using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace OnlineBookStore
{
    class Customer
    {
        private string CustomerName;
        private string CustomerLastname;
        private string CustomerEmail;
        private string CustomerPhonenumber;
        private string customerPassword;
        private string CustomerCart;
        public string[] printCustomerDetails()
        {
            LoginCustomer CustomerProfile = LoginCustomer.getInstance();
            Customer csm = CustomerProfile.customer;
            string[] CustomerDetailList = { csm.CustomerName1, csm.CustomerLastname1,
            csm.CustomerEmail1, csm.CustomerPhonenumber1, csm.customerPassword1 };
            return CustomerDetailList;
        }
        public string CustomerName1
        {
            get { return CustomerName; }
            set { CustomerName = value; }
        }
        public string CustomerLastname1
        {
            get { return CustomerLastname; }
            set { CustomerLastname = value; }
        }
        public string CustomerEmail1
        {
            get { return CustomerEmail; }
            set { CustomerEmail = value; }
        }
        public string CustomerPhonenumber1
        {
            get { return CustomerPhonenumber; }
            set { CustomerPhonenumber = value; }
        }
        public string CustomerCart1
        {
            get { return CustomerCart; }
            set { CustomerCart = value; }
        }
        public string customerPassword1
        {
            get { return customerPassword; }
            set { customerPassword = value; }
        }
    }
}
