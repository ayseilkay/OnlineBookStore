using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace OnlineBookStore
{
    class Book : Product
    {
        public ArrayList allbookrecord = new ArrayList();
        private string BookAuthor;
        private int BookPageNumber;
        private string BookDescription;
        public override ArrayList GetData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Windows.Forms.Application.StartupPath + @"\\BookList.xml");
            XmlNodeList nodelist = xmlDoc.SelectNodes("/ArrayOfBook/Book");
            foreach (XmlNode item in nodelist)
            {
                CreateProduct prdct = new CreateProduct();
                Book my_book = (Book)CreateProduct.FactoryObjeYarat("Book");
                my_book.Name1 = item.SelectSingleNode("BookName").InnerText;
                my_book.ImageName1 = item.SelectSingleNode("BookImage").InnerText;
                my_book.BookAuthor1 = item.SelectSingleNode("BookAuthor").InnerText;
                my_book.BookDescription1 = item.SelectSingleNode("BookDescription").InnerText;
                my_book.Category1 = item.SelectSingleNode("BookCategory").InnerText;
                my_book.BookPageNumber1 = int.Parse(item.SelectSingleNode("BookPageNumber").InnerText);
                my_book.Price1 = float.Parse(item.SelectSingleNode("BookPrice").InnerText);
                my_book.Image = Properties.Resources.ResourceManager.GetObject(my_book.ImageName1) as Image;
                allbookrecord.Add(my_book);
            }
            return allbookrecord;
        }
        public string BookAuthor1
        {
            get { return BookAuthor; }
            set { BookAuthor = value; }
        }
        public int BookPageNumber1
        {
            get { return BookPageNumber; }
            set { BookPageNumber = value; }
        }
        public string BookDescription1
        {
            get { return BookDescription; }
            set { BookDescription = value; }
        }
    }
}