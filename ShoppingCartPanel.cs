using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    class ShoppingCartPanel : Panel
    {
        TextBox txtquantity;
        Label lbltotalprice;
        ItemToPurchase item;

        public void create(ItemToPurchase item)
        {
            this.item = item;
            this.Size = new Size(450, 75);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Visible = true;

            PictureBox picture = new PictureBox();
            picture.Size = new Size(40, 65);
            picture.Image = item.product.Image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(35, 5);

            Label lblname = new Label();
            lblname.AutoSize = true;
            lblname.Text = item.product.Name1;
            lblname.Location = new System.Drawing.Point(90, 25);

            txtquantity = new TextBox();
            txtquantity.TextAlign = HorizontalAlignment.Center;
            txtquantity.Size = new Size(25, 10);
            txtquantity.Text = item.quantity.ToString();
            txtquantity.ReadOnly = true;
            txtquantity.Location = new System.Drawing.Point(260, 25);

            Button btndecrease = new Button();
            btndecrease.Image = Properties.Resources.down;
            btndecrease.Size = new Size(20, 20);
            btndecrease.FlatStyle = FlatStyle.Flat;
            btndecrease.FlatAppearance.BorderSize = 0;
            btndecrease.Location = new System.Drawing.Point(235, 25);
            btndecrease.Click += new EventHandler(btnDecrease);

            Button btnincrease = new Button();
            btnincrease.Image = Properties.Resources.up;
            btnincrease.Size = new Size(20, 20);
            btnincrease.FlatStyle = FlatStyle.Flat;
            btnincrease.FlatAppearance.BorderSize = 0;
            btnincrease.Location = new System.Drawing.Point(290, 25);
            btnincrease.Click += new EventHandler(btnIncrease);

            lbltotalprice = new Label();
            lbltotalprice.AutoSize = true;
            lbltotalprice.Text = (item.product.Price1 * item.quantity).ToString() + " TL";
            lbltotalprice.Location = new System.Drawing.Point(390, 25);

            Button btndelete = new Button();
            btndelete.Image = Properties.Resources.Delete;
            btndelete.Size = new Size(30, 30);
            btndelete.FlatStyle = FlatStyle.Flat;
            btndelete.FlatAppearance.BorderSize = 0;
            btndelete.Location = new System.Drawing.Point(3, 20);
            btndelete.Click += new EventHandler(btnDelete);

            this.Controls.Add(btnincrease);
            this.Controls.Add(btndecrease);
            this.Controls.Add(picture);
            this.Controls.Add(lblname);
            this.Controls.Add(btndelete);
            this.Controls.Add(txtquantity);
            this.Controls.Add(lbltotalprice);
        }

        private void btnDelete(object sender, EventArgs e)
        {

            for (int i = 0; i < int.Parse(txtquantity.Text); i++)
            {
                Home.shopCart.ItemsToPurchase.Remove(item);
            }
            Home.cart.refresh();
            string buttonname = "Delete";
            SaveLog.Savelog(buttonname);
        }

        public void btnIncrease(object sender, EventArgs e)
        {
            item.quantity++;
            float total = (item.product.Price1) * item.quantity;
            lbltotalprice.Text = total.ToString();
            txtquantity.Text = item.quantity.ToString() + " TL";
            Home.cart.refresh();
            string buttonname = "Increase";
            SaveLog.Savelog(buttonname);
        }

        public void btnDecrease(object sender, EventArgs e)
        {
            item.quantity--;
            if (item.quantity < 1)
                item.quantity = 1;
            float total = (item.product.Price1) * item.quantity;
            lbltotalprice.Text = total.ToString();
            txtquantity.Text = "" + item.quantity + " TL";
            Home.cart.refresh();
            string buttonname = "Decrease";
            SaveLog.Savelog(buttonname);
        }
    }
}
