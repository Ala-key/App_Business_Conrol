using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace App_List
{
    /// <summary>
    /// Логика взаимодействия для Deletes_Form.xaml
    /// </summary>
    public partial class Deletes_Form : Window
    {
        ShopdbEntities db;

        public Deletes_Form()
        {
            db = new ShopdbEntities();
            InitializeComponent();
            dgr.ItemsSource = db.Deletes_Shop.ToList();

            txtsearch.KeyDown += Txtsearch_KeyDown;
        }
        public Deletes_Form(Main_Shop main_Shop)
        {
            InitializeComponent();

            db = new ShopdbEntities();

            List<Deletes_Shop> deletes_Shops = new List<Deletes_Shop>();

            deletes_Shops.Add(new Deletes_Shop { Документ = main_Shop.Документ, Номер_заказа = main_Shop.Номер_заказа, Номер_детали = main_Shop.Номер_детали, Количество = main_Shop.Количество, Машинное_время = main_Shop.Машинное_время, Дата = main_Shop.Дата, Дата_удаления = DateTime.Now, Комментарий = main_Shop.Комментарий });

            db.Deletes_Shop.AddRange(deletes_Shops);

            db.SaveChanges();

            Main_Shop shop = db.Main_Shop.Find(main_Shop.id);

            db.Main_Shop.Remove(shop);

            db.SaveChanges();

            dgr.ItemsSource = db.Deletes_Shop.ToList();


            txtsearch.KeyDown += Txtsearch_KeyDown1;




        }

        private void Txtsearch_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txtsearch.Text != null)
                {
                   





                    dgr.ItemsSource = db.Deletes_Shop.Where(x => x.Номер_детали.Contains(txtsearch.Text)).ToList();
                }
                if (txtsearch.Text.Equals(String.Empty))
                {
                    db = new ShopdbEntities();

                    dgr.ItemsSource = db.Deletes_Shop.ToList();
                }
            }
        }

        private void Txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txtsearch.Text != null)
                {



                    dgr.ItemsSource = db.Deletes_Shop.Where(x => x.Номер_детали.Contains(txtsearch.Text)).ToList();



                }
                if (txtsearch.Text.Equals(String.Empty))
                {
                    db = new ShopdbEntities();

                    dgr.ItemsSource = db.Deletes_Shop.ToList();
                }
            }
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            var ret = dgr.SelectedItem as Deletes_Shop;

            MainWindow mainWindow = new MainWindow(ret);

            mainWindow.Show();

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();

            this.Close();
        }

        private void Close_Del_Form(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
