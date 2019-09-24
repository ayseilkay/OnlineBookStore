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
    class Magazine : Product
    {
        public ArrayList allmagazinerecord = new ArrayList();
        private string MagazinePublisher;
        public override ArrayList GetData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Windows.Forms.Application.StartupPath + @"\\MagazineList.xml");
            XmlNodeList nodelist = xmlDoc.SelectNodes("/ArrayOfMagazine/Magazine");
            foreach (XmlNode item in nodelist)
            {
                CreateProduct prdct = new CreateProduct();
                Magazine my_magazine = (Magazine)CreateProduct.FactoryObjeYarat("Magazine");
                my_magazine.Name1 = item.SelectSingleNode("MagazineName").InnerText;
                my_magazine.Category1 = item.SelectSingleNode("MagazineCategory").InnerText;
                my_magazine.ImageName1 = item.SelectSingleNode("MagazineImage").InnerText;
                my_magazine.MagazinePublisher1 = item.SelectSingleNode("MagazinePublisher").InnerText;
                my_magazine.Price1 = float.Parse(item.SelectSingleNode("MagazinePrice").InnerText);
                my_magazine.Image = Properties.Resources.ResourceManager.GetObject(my_magazine.ImageName1) as Image;
                allmagazinerecord.Add(my_magazine);
            }
            return allmagazinerecord;
        }
        public string MagazinePublisher1
        {
            get { return MagazinePublisher; }
            set { MagazinePublisher = value; }
        }
    }
}
