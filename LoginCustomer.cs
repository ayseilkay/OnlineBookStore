using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore
{
    class LoginCustomer
    {
        private static LoginCustomer instance;
        public Customer customer;
        private LoginCustomer() { }
        public static LoginCustomer getInstance()
        {
            if (instance == null)
            {
                instance = new LoginCustomer();
            }
            return instance;
        }
    }
}
