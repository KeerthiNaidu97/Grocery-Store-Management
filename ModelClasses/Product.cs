using KGNGroceryStore.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KGNGorceryStore.ModelClasses
{
     public class Product: IProduct
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public DateTime expiryDate { get; set; }
        public string image { get; set; }
        public ImageSource imageSource { get { return new BitmapImage(new Uri($"assets/{image}", UriKind.Relative)); ; } }


        public static  ProductInBasket GetProductInBasket(Product product)
        {
            ProductInBasket productInBasket = new ProductInBasket();
            productInBasket.price = product.price;
            productInBasket.productName = product.productName;
            productInBasket.productID = product.productID;
            productInBasket.quantity = product.quantity;
            productInBasket.subTotal = product.price;
            productInBasket.quantityInBasket = 1;
            return productInBasket;
        }
    }
}
