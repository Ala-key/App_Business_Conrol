using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShopdbEntities ShopdbEntities { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            ShopdbEntities = new ShopdbEntities();

            

            dgr.ItemsSource = ShopdbEntities.Main_Shop.ToList();



            txtsearch.KeyDown += Txtsearch_KeyDown;

            
           
            
           

           
        }

       

        private void Txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txtsearch.Text != null)
                {
                    string keyword = txtsearch.Text;

                   
                    


                    dgr.ItemsSource = ShopdbEntities.Main_Shop.Where(x => x.Документ.Contains(keyword)).ToList();
                }
                if (txtsearch.Text.Equals(String.Empty))
                {
                    using (ShopdbEntities shopdb = new ShopdbEntities())
                    {
                        shopdb.Main_Shop.ToList();
                    }

                }
                




            }
        }

        public MainWindow(Deletes_Shop main_Shop)
        {
            InitializeComponent();

            ShopdbEntities = new ShopdbEntities();



            List<Main_Shop> people1 = new List<Main_Shop>();

            people1.Add(new Main_Shop() { Документ = main_Shop.Документ, Номер_заказа = main_Shop.Номер_заказа, Номер_детали = main_Shop.Номер_детали, Количество = main_Shop.Количество, Машинное_время = main_Shop.Машинное_время, Дата = main_Shop.Дата, Комментарий = main_Shop.Комментарий });

            ShopdbEntities.Main_Shop.AddRange(people1);
            ShopdbEntities.SaveChanges();

            dgr.ItemsSource = ShopdbEntities.Main_Shop.ToList();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FilterList filterList = new FilterList();
            filterList.Show();
        }

       

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = (dgr.SelectedItem as Main_Shop).id;

            Changed_List changed_List = new Changed_List(item);

            changed_List.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (dgr.SelectedItem as Main_Shop).id;

            var deletemember = ShopdbEntities.Main_Shop.Where(x => x.id == id).Single();

            ShopdbEntities.Main_Shop.Remove(deletemember);

            ShopdbEntities.SaveChanges();

            dgr.ItemsSource = ShopdbEntities.Main_Shop.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //var item = dg1.SelectedItem as Person;


            //Left_Form left_Form = new Left_Form(item);

            //left_Form.Show();

            //this.Close();

            //var item = dgr.SelectedItem as Main_Shop;

            var item = dgr.SelectedItem as Main_Shop;

            Deletes_Form deletes_Form = new Deletes_Form(item);

            deletes_Form.Show();

            this.Close();

            


            
            
        }


        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string keyword = txtsearch.Text;

            dgr.ItemsSource = ShopdbEntities.Main_Shop.Where(x => x.Документ.Contains(keyword)).ToList();
        }

        private void dgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Deletes_Form deletes_Form = new Deletes_Form();

            deletes_Form.Show();

            this.Close();
        }

        private void Added_Click(object sender, RoutedEventArgs e)
        {
            List_Add list_Add = new List_Add();
            list_Add.Show();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FilterList filterList = new FilterList();

            filterList.Show();

            
        }
    }
}
