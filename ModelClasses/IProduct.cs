using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KGNGroceryStore.ModelClasses
{
    interface IProduct
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public DateTime expiryDate { get; set; }
        public string image { get; set; }
    }
}
