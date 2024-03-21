using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptApp
{
    internal class Location
    {
        private string location;
        private Retailer retailer;
        private Dictionary<uint, int> productPrice;

        public Location()
        {

        }

        public void AddProduct(uint id, int price) { productPrice.Add(id, price); }
        public void AddProduct(Product product, int price) { productPrice.Add(product.ProductID, price); }
    }
}
