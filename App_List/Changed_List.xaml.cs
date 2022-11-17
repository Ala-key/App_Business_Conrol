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
    /// Логика взаимодействия для Changed_List.xaml
    /// </summary>
    public partial class Changed_List : Window
    {
        ShopdbEntities  shopdb { get; set; }

        int id;
        public Changed_List(int id)
        {
            InitializeComponent();
            shopdb = new ShopdbEntities();
            this.id = id;


        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            shopdb = new ShopdbEntities();

            var foo = (from m in shopdb.Main_Shop
                       where m.id == id
                       select m).Single();
            foo.Документ = c1.Text;
            foo.Номер_заказа = int.Parse(c2.Text);
            foo.Номер_детали = c3.Text;
            foo.Количество = int.Parse(t1.Text);
            foo.Машинное_время = t2.Text;
            foo.Дата = dgr2.DisplayDate;
            foo.Комментарий = t3.Text;
            shopdb.SaveChanges();

            

            MainWindow mainWindow = new MainWindow();

            mainWindow.ShowDialog();

            this.Close();

        }
    }
}
