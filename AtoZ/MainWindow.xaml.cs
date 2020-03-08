using AtoZLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace AtoZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBase.CreateDB(); //delete methods inside after finish building
            ListBoxPopulate();
        }

        private void ListBoxPopulate()
        {
            var productList = ProductDB.GetAllVendorProducts();
            var collection = new ObservableCollection<Product>(productList);
            var source = new Binding();
            ProductsListBox.DataContext = collection;
            ProductsListBox.SetBinding(ListBox.ItemsSourceProperty, source);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = (ListBox)sender;
            Product current = (Product)list.SelectedItem;
            SetProductInfo(current);
            SetVendorProducts(current);

            #region CartGrid
            //var CartProduct = new List<>();
            #endregion
        }

        public void SetProductInfo(Product current)
        {
            var productFields = new List<Field>();
            productFields.AddRange(new List<Field> {
                new Field() {
                    Name = "Name",
                    Value = current.Name,
                },
                new Field() {
                    Name = "Description",
                    Value = current.Description,
                },
                new Field() {
                    Name = "MSRP",
                    Value = current.MSRP.ToString(),
                }
            });
            var collection = new ObservableCollection<Field>(productFields);
            var source = new Binding();
            ProductInfoGrid.DataContext = collection;
            ProductInfoGrid.ItemsSource = collection;
            ProductInfoGrid.SetBinding(ItemsControl.ItemsSourceProperty, source);
        }

        public void SetVendorProducts(Product current)
        {
            var vendorProducts = current.VendorProducts;
            var collection = new ObservableCollection<VendorProductDetails>(vendorProducts.Select(p => p.Details()));
            var source = new Binding();
            VendorsGrid.DataContext = collection;
            VendorsGrid.ItemsSource = collection;
            VendorsGrid.SetBinding(ItemsControl.ItemsSourceProperty, source);
        }
    }

    class Field
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }


}
