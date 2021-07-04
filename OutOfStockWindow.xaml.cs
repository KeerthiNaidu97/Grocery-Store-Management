using KGNGorceryStore.ModelClasses;
using KGNGorceryStore.OtherClasses;
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
using System.Windows.Shapes;

namespace KGNGroceryStore
{
    /// <summary>
    /// Interaction logic for OutOfStockWindow.xaml
    /// </summary>
    public partial class OutOfStockWindow : Window
    {
        public OutOfStockWindow()
        {
            InitializeComponent();
            LoadProducts();
        }
        static ObservableCollection<Product> products = new ObservableCollection<Product>();
        
        static ObservableCollection<ProductInBasket> productInBaskets = new ObservableCollection<ProductInBasket>();

        public void LoadProducts()
        {
            products = XMLdataHelper.ReadXml<ObservableCollection<Product>>("products.xml");
            itemlistbox.ItemsSource = products.Select(a => a).Where(p => p.quantity < 5).ToList();
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
            var result = products.Select(a => a).Where(p => p.quantity < 5 && p.productName.ToLower().Contains(filter)).ToList();
            itemlistbox.ItemsSource = result;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //Listbox selection code
            Button myButton = sender as Button;
            DependencyObject parent = VisualTreeHelper.GetParent(myButton);
            while (!(parent is ListBoxItem))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            ListBoxItem myListBoxItem = parent as ListBoxItem;
            myListBoxItem.IsSelected = true;
            //Listbox selection code


            Product tempProduct = (Product)itemlistbox.SelectedItem;
            var window = new StockWindow(tempProduct);
            window.Show();
            this.Close();
        }
    }
}
