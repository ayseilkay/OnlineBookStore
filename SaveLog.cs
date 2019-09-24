using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    static class SaveLog
    {
        public static void Savelog(string btnname)
        {
            try
            {
                LoginCustomer logcustomer = LoginCustomer.getInstance();
                FileStream logfile = new FileStream(System.Windows.Forms.@Application.StartupPath + @"\\Log.txt", FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(logfile);
                writer.Write(logcustomer.customer.CustomerName1 + "   " + btnname + "  " + DateTime.Now.ToString() + Environment.NewLine);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
