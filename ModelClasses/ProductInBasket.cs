using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KGNGorceryStore.ModelClasses
{
    public class ProductInBasket: Product
    {
        public int quantityInBasket { get; set; }

        public double subTotal { get; set; }

       // public double pricePerQuantity => quantityInBasket * price;

    }
}
