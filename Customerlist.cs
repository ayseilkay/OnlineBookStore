using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OnlineBookStore
{
    class Customerlist
    {
        Customer my_customer;
        public ArrayList ReadXML()
        {
            ArrayList allrecord = new ArrayList();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + @"\\CustomerList.xml");
                XmlNodeList nodelist = xmlDoc.SelectNodes("/ArrayOfCustomer/Customer");
                foreach (XmlNode item in nodelist)
                {
                    my_customer = new Customer();
                    my_customer.CustomerName1 = item.SelectSingleNode("CustomerName").InnerText;
                    my_customer.customerPassword1 = item.SelectSingleNode("CustomerPassword").InnerText;
                    my_customer.CustomerLastname1 = item.SelectSingleNode("CustomerLastName").InnerText;
                    my_customer.CustomerEmail1 = item.SelectSingleNode("CustomerEmail").InnerText;
                    my_customer.CustomerPhonenumber1 = item.SelectSingleNode("CustomerPhoneNumber").InnerText;
                    allrecord.Add(my_customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return allrecord;
        }
    }
}
