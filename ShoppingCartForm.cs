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
    public partial class ShoppingCartForm : Form
    {
        public ShoppingCartForm()
        {
            InitializeComponent();
        }

        private void ShoppingCartForm_Load(object sender, EventArgs e)
        {
            foreach (var item in Home.shopCart.ItemsToPurchase)
            {
                ShoppingCartPanel panel = new ShoppingCartPanel();
                panel.create(item);
                flowLayoutPanel1.Controls.Add(panel);
            }
            totalamount();
        }

        public void totalamount()
        {
            float amount = 0;
            for (int i = 0; i < Home.shopCart.ItemsToPurchase.Count; i++)
            {
                amount += Home.shopCart.ItemsToPurchase[i].quantity * Home.shopCart.ItemsToPurchase[i].product.Price1;
            }
            lblAmount.Text = amount.ToString();          
        }

        public void refresh()
        {
            flowLayoutPanel1.Controls.Clear();
            lblAmount.Text = totalprice();
            foreach (var item in Home.shopCart.ItemsToPurchase)
            {
                ShoppingCartPanel panel = new ShoppingCartPanel();
                panel.create(item);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        public static string totalprice()
        {
            float amount = 0;
            for (int i = 0; i < Home.shopCart.ItemsToPurchase.Count; i++)
            {
                amount += Home.shopCart.ItemsToPurchase[i].quantity * Home.shopCart.ItemsToPurchase[i].product.Price1;
            }
            foreach (var item in Home.shopCart.ItemsToPurchase)
            {
                if (item.product == null)
                {
                    return 0.ToString();
                }
            }
            Home.shopCart.PaymentAmount = amount;
            return amount.ToString();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (float.Parse(totalprice()) > 0)
            {
                Payment pay = new Payment();
                this.Hide();
                pay.ShowDialog();            
            }
            else
            {
                MessageBox.Show("Shopping cart is empty!");
            }
            string buttonname = "Buy";
            SaveLog.Savelog(buttonname);
        }
    }
}
