using KGNGorceryStore.ModelClasses;
using KGNGorceryStore.OtherClasses;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Shapes;

namespace KGNGroceryStore
{
    /// <summary>
    /// Interaction logic for StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        static ObservableCollection<Product> products = new ObservableCollection<Product>();
        static Product newProduct = new Product();
        string fileName = String.Empty, targetPath = @"assets\", destination = string.Empty;

        public StockWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        public StockWindow(Product product)
        {
            InitializeComponent();
            LoadProducts();
            newProduct = product;
            PreviewImage.Source = newProduct.imageSource;
            ProductNameTextBox.Text = newProduct.productName;
            QuantityTextBox.Text = newProduct.quantity.ToString();
            PriceTextBox.Text = newProduct.price.ToString();
            ExpiryDatePicker.SelectedDate = newProduct.expiryDate;
        }

       
       

        public void LoadProducts()
        {
            products = XMLdataHelper.ReadXml<ObservableCollection<Product>>("products.xml");
            itemlistbox.ItemsSource = products.Select(a => a).ToList();
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

       

     

        private void Uploadbutton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a picture";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (dialog.ShowDialog() == true)
            {
                PreviewImage.Source = new BitmapImage(new Uri(dialog.FileName));
            }
            string destFile = string.Empty;
            fileName = System.IO.Path.GetFullPath(dialog.FileName);
            string appFolderPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace("bin\\","");
            string resourcesFolderPath = System.IO.Path.Combine(Directory.GetParent(appFolderPath).Parent.FullName, "assets");

            destination = System.IO.Path.Combine(resourcesFolderPath, System.IO.Path.GetFileName(dialog.FileName));
           
        }

        private void Editbutton_Click(object sender, RoutedEventArgs e)
        {
            newProduct = (Product)itemlistbox.SelectedItem;

            PreviewImage.Source = newProduct.imageSource; 
            ProductNameTextBox.Text = newProduct.productName;
            QuantityTextBox.Text = newProduct.quantity.ToString();
            PriceTextBox.Text = newProduct.price.ToString();           
            ExpiryDatePicker.SelectedDate = newProduct.expiryDate;
        }

        private void Deletebutton_Click(object sender, RoutedEventArgs e)
        {
            Product tempProduct = (Product)itemlistbox.SelectedItem;
            products.Remove(tempProduct);
            XMLdataHelper.WriteXml(products, "products.xml");
            itemlistbox.ItemsSource = null;
            itemlistbox.ItemsSource = products;

        }

        private void outofstock_Click(object sender, RoutedEventArgs e)
        {
            var window = new OutOfStockWindow();
            window.Show();
        }

        private void AddProductbutton_Click(object sender, RoutedEventArgs e)
        {
            //Copy File only on confirmation
            if (!String.IsNullOrEmpty(fileName))
            {
                System.IO.File.Copy(fileName, destination, true);
                newProduct.image = fileName.Split("\\").Last();
            }

            newProduct.productName = ProductNameTextBox.Text;
            newProduct.quantity = Convert.ToInt32(QuantityTextBox.Text);
            newProduct.price = Convert.ToDouble(PriceTextBox.Text);
            newProduct.expiryDate = (DateTime)ExpiryDatePicker.SelectedDate;
           

            if (newProduct.productID <= 0)
            {
                //Create New Product ID and add the new product to the list
                int newID = products.OrderByDescending( p => p.productID).FirstOrDefault().productID + 1;
                newProduct.productID = newID;
                products.Add(newProduct);
            }
            else
            {
                //Replace the existing product
                products.Select(a => a).Where(p => p.productID == newProduct.productID).ToList().ForEach(p => p.price = newProduct.price);
                products.Select(a => a).Where(p => p.productID == newProduct.productID).ToList().ForEach(p => p.image = newProduct.image);
                products.Select(a => a).Where(p => p.productID == newProduct.productID).ToList().ForEach(p => p.productName = newProduct.productName);
                products.Select(a => a).Where(p => p.productID == newProduct.productID).ToList().ForEach(p => p.expiryDate  = newProduct.expiryDate);
                products.Select(a => a).Where(p => p.productID == newProduct.productID).ToList().ForEach(p => p.quantity = newProduct.quantity);
            }
            XMLdataHelper.WriteXml(products, "products.xml");            
            itemlistbox.ItemsSource = null;
            itemlistbox.ItemsSource = products;


            newProduct = new Product();
            PreviewImage.Source = newProduct.imageSource;
            ProductNameTextBox.Text = newProduct.productName;
            QuantityTextBox.Text = newProduct.quantity.ToString();
            PriceTextBox.Text = newProduct.price.ToString();
            ExpiryDatePicker.SelectedDate = newProduct.expiryDate;
        }

    }
}
