using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    class MagazinePanel : Panel
    {
        Magazine magazine;
        public void create(Magazine propertiesofmagazine)
        {
            magazine = propertiesofmagazine;
            this.Size = new Size(165, 280);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.FixedSingle;

            PictureBox picture = new PictureBox();
            picture.Size = new Size(80, 120);
            picture.Image = propertiesofmagazine.Image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(40, 5);

            Label lblname = new Label();
            lblname.AutoSize = false;
            lblname.Size = new Size(165, 20);
            lblname.TextAlign = ContentAlignment.MiddleCenter;
            lblname.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold);
            lblname.Location = new System.Drawing.Point(0, 140);
            lblname.Text = propertiesofmagazine.Name1;

            Label lblcategory = new Label();
            lblcategory.AutoSize = false;
            lblcategory.Size = new Size(165, 15);
            lblcategory.TextAlign = ContentAlignment.MiddleCenter;
            lblcategory.Location = new System.Drawing.Point(0, 160);
            lblcategory.Text = propertiesofmagazine.Category1;

            Label lblprice = new Label();
            lblprice.AutoSize = false;
            lblprice.Size = new Size(165, 15);
            lblprice.TextAlign = ContentAlignment.MiddleCenter;
            lblprice.Font = new System.Drawing.Font("Arial", 10f, System.Drawing.FontStyle.Regular);
            lblprice.Location = new System.Drawing.Point(0, 210);
            lblprice.Text = propertiesofmagazine.Price1.ToString() + " TL";

            Button btnaddcart = new Button();
            btnaddcart.Size = new Size(100, 30);
            btnaddcart.BackColor = Color.WhiteSmoke;
            btnaddcart.FlatAppearance.BorderSize = 0;
            btnaddcart.FlatStyle = FlatStyle.Flat;
            btnaddcart.Font = new Font("Arial", 10f, System.Drawing.FontStyle.Bold);
            btnaddcart.Location = new System.Drawing.Point(35, 240);
            btnaddcart.Text = " ADD CART ";
            btnaddcart.Click += new EventHandler(AddCartClick);

            this.Controls.Add(picture);
            this.Controls.Add(lblname);
            this.Controls.Add(lblcategory);
            this.Controls.Add(lblprice);
            this.Controls.Add(btnaddcart);
        }
        public void AddCartClick(object sender, EventArgs e)
        {
            foreach (var it in Home.shopCart.ItemsToPurchase)
            {
                if (it.product == magazine)
                {
                    it.quantity = 1;
                    return;
                }
            }
            ItemToPurchase item = new ItemToPurchase();
            item.product = magazine;
            item.quantity++;
            Home.shopCart.ItemsToPurchase.Add(item);
            string buttonname = "MagazineAddCart";
            SaveLog.Savelog(buttonname);
        }
    }
}
