using KGNGorceryStore.ModelClasses;
using KGNGorceryStore.OtherClasses;
using KGNGroceryStore;
using KGNGroceryStore.ModelClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KGNGorceryStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

         static ObservableCollection<Product> products = new ObservableCollection<Product>();
         static ObservableCollection<ProductInBasket> productInBaskets = new ObservableCollection<ProductInBasket>();
        double totalPrice = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
        }
      //  List<Product> products = new List<Product>();
        public void LoadProducts()
        {

            //LoadDatatoXML();
            products = XMLdataHelper.ReadXml<ObservableCollection<Product>>("products.xml");
            itemlistbox.ItemsSource = products;

            BasketTotalText.Text = "Total: 0";
        }

        public void ChangeAnimation(int width)
        {
            DoubleAnimation animation = new DoubleAnimation(20, TimeSpan.FromSeconds(1));
            animation.To = width;
            SlidingMenu.BeginAnimation(Grid.WidthProperty, animation);
        }


        private void SlidingMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeAnimation(200);
        }

        private void SlidingMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeAnimation(20);
        }

        private void Filter_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = Filter_textBox.Text.ToLower();
            var result = products.Select(a => a).Where(p => p.productName.ToLower().Contains(filter)).ToList();
            itemlistbox.ItemsSource = result;
        }

        private void AddToBasket_btn_Click(object sender, RoutedEventArgs e)
        {
           // ObservableCollection<ProductInBasket> productInBaskets = new ObservableCollection<ProductInBasket>();
            Product tempProduct = (Product)itemlistbox.SelectedItem;
            productInBaskets.Add(Product.GetProductInBasket(tempProduct));
            itemcollectionbox.ItemsSource = productInBaskets;
            UpdateBasketTotal();
        }



        private void quantityTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Listbox selection code
            TextBox myTextBox = sender as TextBox;
            DependencyObject parent = VisualTreeHelper.GetParent(myTextBox);
            while (!(parent is ListBoxItem))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            ListBoxItem myListBoxItem = parent as ListBoxItem;
            myListBoxItem.IsSelected = true;
            //Listbox selection code

            var lst = (ProductInBasket)itemcollectionbox.SelectedItem;

            ProductInBasket selectedproductInBasket = lst;


            if (!String.IsNullOrEmpty(myTextBox.Text))
            {
                if (Convert.ToInt32(myTextBox.Text) > selectedproductInBasket.quantity || Convert.ToInt32(myTextBox.Text) <= 0)
                {
                    MessageBox.Show("Please enter Valid Quantity");
                    myTextBox.Text = "1";                    
                }
            }
            else
            {
                MessageBox.Show("Please enter Valid Quantity");
                myTextBox.Text = "1";
            }

            double subTotal = Convert.ToDouble(Convert.ToInt32(myTextBox.Text) * selectedproductInBasket.price);
            selectedproductInBasket.quantityInBasket = Convert.ToInt32(myTextBox.Text);
            selectedproductInBasket.subTotal = subTotal;
            productInBaskets.Select(a => a).Where(p => p == selectedproductInBasket).ToList().ForEach(p => p = selectedproductInBasket);
            itemcollectionbox.ItemsSource = null;
            itemcollectionbox.ItemsSource = productInBaskets;
            UpdateBasketTotal();


        }

        private void DeleteBasketItem_Click(object sender, RoutedEventArgs e)
        {
            var lst = (ProductInBasket)itemcollectionbox.SelectedItem;
            ProductInBasket selectedproductInBasket = lst;
            productInBaskets.Remove(selectedproductInBasket);
            itemcollectionbox.ItemsSource = null;
            itemcollectionbox.ItemsSource = productInBaskets;
            UpdateBasketTotal();
        }

        public void UpdateBasketTotal()
        {
            totalPrice = productInBaskets.Sum(p => p.subTotal);
            BasketTotalText.Text = $"Total: €{totalPrice}";
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            string message = totalPrice > 0 ? $"Order Placed Successfully! \n Order Total: €{totalPrice}" : "Please add some Items to the Basket to place the Order!!";
            if (totalPrice > 0)
            {
                UpdateQuantity();
            }
            MessageBox.Show(message);
            BasketTotalText.Text = "Total: 0";
        }

        public void UpdateQuantity()
        {
            foreach(var basketItem in productInBaskets)
            {
                products.Select(a => a).Where(p => p.productID == basketItem.productID).ToList().ForEach(p => p.quantity = (basketItem.quantity - basketItem.quantityInBasket));
            }
            XMLdataHelper.WriteXml(products,"products.xml");
            itemcollectionbox.ItemsSource = null;
            itemlistbox.ItemsSource = null;
            productInBaskets = new ObservableCollection<ProductInBasket>();
            itemlistbox.ItemsSource = products;
        }

       


        public void LoadDatatoXML()
        {

            products.Add(new Product { productID = 1, image = "Salt.jpg", productName = "abc", price = 21.00, quantity = 100 });
            products.Add(new Product { productID = 2, image = "menuicon.jpg", productName = "abc", price = 21.00, quantity = 100 });
            products.Add(new Product { productID = 3, image = "menuicon.jpg", productName = "def", price = 21.00, quantity = 100 });
            products.Add(new Product { productID = 4, image = "menuicon.jpg", productName = "ghi", price = 21.00, quantity = 100 });
            products.Add(new Product { productID = 5, image = "", productName = "jkl", price = 21.00, quantity = 4 });

             XMLdataHelper.WriteXml(products, "products.xml");
        }


        private void outofstock_Click(object sender, RoutedEventArgs e)
        {
            var window = new OutOfStockWindow();
            window.Show();
        }

        private void managestock_Click(object sender, RoutedEventArgs e)
        {
            var window = new StockWindow();
            window.Show();
        }
    }
}
