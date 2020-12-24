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
using System.Data.SqlClient;

namespace CLINIC
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search1 : Window
    {
       // public List<Models.CLINICSpecialty> Docs = new List<Models.CLINICSpecialty>();

        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);

        public Search1()
        {
            InitializeComponent();
        }

        public List<string> showListTD()
        {

            List<string> show = new List<string>();
            try
            {
             show.Clear();
                list.ItemsSource = null;
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("SearchDoc", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", name.Text);
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {
                        show.Add(resn.GetString(0));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return show;
        }
        public void FillListTimeDoc()
        {
            try
            {
                list.ItemsSource = null;
                foreach (var a in showListTD())
                    list.Items.Add(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtomSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text == "") { MessageBox.Show("Введите название теста"); }
                else
                {
                    FillListTimeDoc();
                    name.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Menu2 ll = new Menu2();
            ll.Show();
            this.Close();
        }
    }
}
