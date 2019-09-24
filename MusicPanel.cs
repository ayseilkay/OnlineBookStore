using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    class MusicPanel : Panel
    {
        Music music;
        public void create(Music propertiesofmusic)
        {
            music = propertiesofmusic;
            this.Size = new Size(165, 280);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.FixedSingle;

            PictureBox picture = new PictureBox();
            picture.Size = new Size(110, 110);
            picture.Image = propertiesofmusic.Image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(27, 5);

            Label lblalbum = new Label();
            lblalbum.AutoSize = false;
            lblalbum.Size = new Size(165, 20);
            lblalbum.TextAlign = ContentAlignment.MiddleCenter;
            lblalbum.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold);
            lblalbum.Location = new System.Drawing.Point(0, 140);
            lblalbum.Text = propertiesofmusic.MusicAlbum1;

            Label lblartist = new Label();
            lblartist.AutoSize = false;
            lblartist.Size = new Size(165, 15);
            lblartist.TextAlign = ContentAlignment.MiddleCenter;
            lblartist.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular);
            lblartist.Location = new System.Drawing.Point(0, 160);
            lblartist.Text = propertiesofmusic.Name1;

            Label lblprice = new Label();
            lblprice.AutoSize = false;
            lblprice.Size = new Size(165, 15);
            lblprice.TextAlign = ContentAlignment.MiddleCenter;
            lblprice.Font = new System.Drawing.Font("Arial", 10f, System.Drawing.FontStyle.Regular);
            lblprice.Location = new System.Drawing.Point(0, 210);
            lblprice.Text = propertiesofmusic.Price1.ToString() + " TL";

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
            this.Controls.Add(lblartist);
            this.Controls.Add(lblalbum);
            this.Controls.Add(lblprice);
            this.Controls.Add(btnaddcart);
        }

        public void AddCartClick(object sender, EventArgs e)
        {
            foreach (var it in Home.shopCart.ItemsToPurchase)
            {
                if (it.product == music)
                {
                    it.quantity = 1;
                    return;
                }
            }
            ItemToPurchase item = new ItemToPurchase();
            item.product = music;
            item.quantity++;
            Home.shopCart.ItemsToPurchase.Add(item);
            string buttonname = "MusicAddCart";
            SaveLog.Savelog(buttonname);
        }

        public void ListenSong(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer snd = new SoundPlayer(music.MusicSong1);
                snd.Play();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

    }
}
