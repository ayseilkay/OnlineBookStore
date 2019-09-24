using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore
{
    public class CreateProduct
    {
        static public Product FactoryObjeYarat(string Secim)
        {
            Product Selectedproduct = null;
            if (Secim == "Book")
            {
                Selectedproduct = new Book();
            }
            if (Secim == "Music")
            {
                Selectedproduct = new Music();
            }
            if (Secim == "Magazine")
            {
                Selectedproduct = new Magazine();
            }
            return Selectedproduct;
        }
    }
}