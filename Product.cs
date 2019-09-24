using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Media;

namespace OnlineBookStore
{
    public abstract class Product
    {
        private float Price;
        private string Category;
        private string Name;
        public Image Image;

        private string ImageName;
        public float Price1
        {
            get { return Price; }
            set { Price = value; }
        }
        public string Name1
        {
            get { return Name; }
            set { Name = value; }
        }
        public string Category1
        {
            get { return Category; }
            set { Category = value; }
        }
        public string ImageName1
        {
            get { return ImageName; }
            set { ImageName = value; }
        }
        public abstract ArrayList GetData();
    }
}
