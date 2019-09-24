using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
namespace OnlineBookStore
{
    class BookPanel : Panel
    {
        Book book;
        public void create(Book propertiesofbook)
        {
            book = propertiesofbook;
            this.Size = new Size(165, 280);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.FixedSingle;

            PictureBox picture = new PictureBox();
            picture.Size = new Size(80, 120);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(40, 5);
            picture.Image = propertiesofbook.Image;

            Label lblname = new Label();
            lblname.AutoSize = false;
            lblname.Size = new Size(165, 20);
            lblname.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold);
            lblname.Location = new System.Drawing.Point(0, 140);
            lblname.TextAlign = ContentAlignment.MiddleCenter;
            lblname.Text = propertiesofbook.Name1;

            Label lblauthor = new Label();
            lblauthor.AutoSize = false;
            lblauthor.Size = new Size(165, 15);
            lblauthor.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular);
            lblauthor.Location = new System.Drawing.Point(0, 160);
            lblauthor.TextAlign = ContentAlignment.MiddleCenter;
            lblauthor.Text = propertiesofbook.BookAuthor1;

            Label lblcategory = new Label();
            lblcategory.AutoSize = false;
            lblcategory.Size = new Size(165, 15);
            lblcategory.Location = new System.Drawing.Point(0, 190);
            lblcategory.TextAlign = ContentAlignment.MiddleCenter;
            lblcategory.Text = propertiesofbook.Category1;

            Label lblprice = new Label();
            lblprice.AutoSize = false;
            lblprice.Size = new Size(165, 15);
            lblprice.Font = new System.Drawing.Font("Arial", 10f, System.Drawing.FontStyle.Regular);
            lblprice.Location = new System.Drawing.Point(0, 210);
            lblprice.TextAlign = ContentAlignment.MiddleCenter;
            lblprice.Text = propertiesofbook.Price1.ToString() + " TL";

            Button btnaddcart = new Button();
            btnaddcart.Size = new Size(100, 30);
            btnaddcart.BackColor = Color.WhiteSmoke;
            btnaddcart.FlatAppearance.BorderSize = 0;
            btnaddcart.FlatStyle = FlatStyle.Flat;
            btnaddcart.Location = new System.Drawing.Point(15, 240);
            btnaddcart.Text = " ADD CART ";
            btnaddcart.Font = new Font("Arial", 10f, System.Drawing.FontStyle.Bold);
            btnaddcart.Click += new EventHandler(AddCartClick);

            Button btndescription = new Button();
            btndescription.Size = new Size(30, 30);
            btndescription.BackColor = Color.Transparent;
            btndescription.FlatStyle = FlatStyle.Flat;
            btndescription.FlatAppearance.BorderSize = 0;
            btndescription.Location = new System.Drawing.Point(120, 240);
            btndescription.Image = OnlineBookStore.Properties.Resources.open_book;
            btndescription.ImageAlign = ContentAlignment.MiddleCenter;
            btndescription.Click += new EventHandler(ShowDescription);

            this.Controls.Add(picture);
            this.Controls.Add(lblname);
            this.Controls.Add(lblauthor);
            this.Controls.Add(lblcategory);
            this.Controls.Add(lblprice);
            this.Controls.Add(btnaddcart);
            this.Controls.Add(btndescription);
        }
        public void AddCartClick(object sender, EventArgs e)
        {
            foreach (var it in Home.shopCart.ItemsToPurchase)
            {
                if (it.product == book)
                {
                    it.quantity = 1;
                    return;
                }
            }
            ItemToPurchase item = new ItemToPurchase();
            item.product = book;
            item.quantity++;
            Home.shopCart.ItemsToPurchase.Add(item);
            string buttonname = "AddCartClick";
            SaveLog.Savelog(buttonname);
        }
        public void ShowDescription(object sender, EventArgs e)
        {
            Description des = new Description();

            PictureBox picture = new PictureBox();
            picture.Size = new Size(80, 120);
            picture.Image = book.Image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(45, 70);
            des.Controls.Add(picture);

            Label lblname = new Label();
            lblname.Text = book.Name1;
            lblname.Size = new Size(400, 25);
            lblname.TextAlign = ContentAlignment.MiddleLeft;
            lblname.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold);
            lblname.Location = new System.Drawing.Point(42, 20);
            des.Controls.Add(lblname);

            Label lblauthor = new Label();
            lblauthor.Text = "Author : " + book.BookAuthor1;
            lblauthor.AutoSize = true;
            lblauthor.Size = new Size(320, 20);
            lblauthor.TextAlign = ContentAlignment.MiddleLeft;
            lblauthor.Font = new System.Drawing.Font("Arial", 10f, System.Drawing.FontStyle.Regular);
            lblauthor.Location = new System.Drawing.Point(150, 90);
            des.Controls.Add(lblauthor);

            Label lblpage = new Label();
            lblpage.Text = "Page : " + book.BookPageNumber1;
            lblpage.Size = new Size(320, 20);
            lblpage.TextAlign = ContentAlignment.MiddleLeft;
            lblpage.Font = new System.Drawing.Font("Arial", 10f, System.Drawing.FontStyle.Regular);
            lblpage.Location = new System.Drawing.Point(150, 110);
            des.Controls.Add(lblpage);

            Label lblcat = new Label();
            lblcat.Text = "Category : " + book.Category1;
            lblcat.Size = new Size(320, 20);
            lblcat.TextAlign = ContentAlignment.MiddleLeft;
            lblcat.Font = new System.Drawing.Font("Arial", 10f, System.Drawing.FontStyle.Regular);
            lblcat.Location = new System.Drawing.Point(150, 130);
            des.Controls.Add(lblcat);

            Label lbldes = new Label();
            lbldes.Text = book.BookDescription1;
            lbldes.Size = new Size(350, 300);
            lbldes.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular);
            lbldes.Location = new System.Drawing.Point(40, 220);
            des.Controls.Add(lbldes);
            des.ShowDialog();
            string buttonname = "ShowDescription";
            SaveLog.Savelog(buttonname);
        }
    }
}