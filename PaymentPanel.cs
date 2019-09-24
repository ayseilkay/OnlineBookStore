using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    class PaymentPanel : Panel
    {
        ItemToPurchase item;
        public void create(ItemToPurchase item)
        {
            this.item = item;
            this.Size = new Size(180, 110);
            
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Visible = true;

            PictureBox picture = new PictureBox();
            picture.Size = new Size(40, 65);
            picture.Image = item.product.Image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(65, 10);

            Label lblname = new Label();
            lblname.Size = new Size(165, 20);
            lblname.Font = new System.Drawing.Font("Arial", 10f, System.Drawing.FontStyle.Regular);
            lblname.TextAlign = ContentAlignment.MiddleCenter;
            lblname.Text = item.product.Name1;
            lblname.Location = new System.Drawing.Point(0, 80);

            this.Controls.Add(picture);
            this.Controls.Add(lblname);
        }
    }
}
