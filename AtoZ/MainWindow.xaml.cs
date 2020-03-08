using AtoZLib;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            #region ProductsGrid
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
            ProductInfoGrid.SetBinding(DataGrid.ItemsSourceProperty, source);
            #endregion

            #region CartGrid
            //var CartProduct = new List<>();
            #endregion
        }
    }

    class Field
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
