using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.Xml;
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
    /// Логика взаимодействия для List_Add.xaml
    /// </summary>
    public partial class List_Add : Window
    {
        
       ShopdbEntities shopdbEntities { get; set; }
       

        public List_Add()
        {
            InitializeComponent();

            shopdbEntities = new ShopdbEntities();

            //bindCombo();







        }

        //private List<Table_User> Tables { get; set; }


       //public void bindCombo()
       // {
       //     var context = new ApplicationContext();


       //     var item = context.Table_Users.ToList();

       //     Tables = item;

       //     DataContext = Tables;

       // }






        private void Save_Click(object sender, RoutedEventArgs e)
        {


            



            


                if (c1.Text == "")
                {
                    b1.BorderBrush = new SolidColorBrush(Colors.Red);


                    erorr1.Foreground = new SolidColorBrush(Colors.Red);
                    erorr1.Content = "Это поле не может быть пустым";
                }
            if (c2.Text == "")
            {
                b2.BorderBrush = new SolidColorBrush(Colors.Red);

                error2.Foreground = new SolidColorBrush(Colors.Red);
                error2.Content = "Это поле не может быть пустым";

            }

            if (c3.Text == "")
            {
                b3.BorderBrush = new SolidColorBrush(Colors.Red);
                error3.Foreground = new SolidColorBrush(Colors.Red);
                error3.Content = "Это поле не может быть пустым";
            }













            try
            {
                var foo = shopdbEntities.Main_Shop;
                var ter = shopdbEntities.Details_Shop.Select(x => x.Номер_детали).ToList();

                if (!ter.Contains(c3.Text))
                {


                    shopdbEntities.Details_Shop.Add(new Details_Shop { id = 5, Документ = c1.Text, Номер_заказа = int.Parse(c2.Text), Номер_детали = c3.Text, Машинное_время = t2.Text });
                    shopdbEntities.SaveChanges();

                }

                foo.Add(new Main_Shop { Документ = c1.Text, Номер_заказа = int.Parse(c2.Text), Номер_детали = c3.Text, Количество = int.Parse(t1.Text), Машинное_время = t2.Text, Дата = dp1.DisplayDate, Комментарий = t3.Text });

                shopdbEntities.SaveChanges();
            }
            catch(SqlException ex)
            {
                MessageBox.Show($"{ex}");
            }

           























        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
