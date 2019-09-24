using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OnlineBookStore
{
    public partial class Home : Form
    {       
        public static ShoppingCartForm cart;
        public static ShoppingCart shopCart;
     
        public Home()
        {
            InitializeComponent();
            shopCart = new ShoppingCart();
        }
        public ArrayList allbookrecord;
        public ArrayList allmagazinerecord;
        public ArrayList allmusicrecord;
        Product bookproduct;
        Product musicproduct;
        Product magazineproduct;

        private void Home_Load(object sender, EventArgs e)
        {
            bookproduct = new Book();
            allbookrecord = bookproduct.GetData();
            musicproduct = new Music();
            allmusicrecord = musicproduct.GetData();
            magazineproduct = new Magazine();
            allmagazinerecord = magazineproduct.GetData();
            foreach (Book item in allbookrecord)
            {
                BookPanel bookpanel = new BookPanel();
                bookpanel.create(item);
                flowLayoutPanel1.Controls.Add(bookpanel);
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            cart = new ShoppingCartForm();
            cart.ShowDialog();
            string buttonname = "Cart";
            SaveLog.Savelog(buttonname);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            string buttonname = "Logout";
            SaveLog.Savelog(buttonname);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.ShowDialog();
            string buttonname = "Profile";
            SaveLog.Savelog(buttonname);
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Music item in allmusicrecord)
            {
                MusicPanel musicpanel = new MusicPanel();
                musicpanel.create(item);
                flowLayoutPanel1.Controls.Add(musicpanel);
            }
            string buttonname = "Music";
            SaveLog.Savelog(buttonname);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Book item in allbookrecord)
            {
                BookPanel bookpanel = new BookPanel();
                bookpanel.create(item);
                flowLayoutPanel1.Controls.Add(bookpanel);
            }
            string buttonname = "Book";
            SaveLog.Savelog(buttonname);
        }

        private void btnMagazine_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Magazine item in allmagazinerecord)
            {
                MagazinePanel magazinepanel = new MagazinePanel();
                magazinepanel.create(item);
                flowLayoutPanel1.Controls.Add(magazinepanel);
            }
            string buttonname = "Magazine";
            SaveLog.Savelog(buttonname);
        }    
    }
}
