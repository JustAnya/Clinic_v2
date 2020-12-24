//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using System.Data.SqlClient;

//namespace CLINIC
//{
//    /// <summary>
//    /// Логика взаимодействия для Search.xaml
//    /// </summary>
//    public partial class Search : Window
//    {
//        public List<Models.CLINICDoctor> Docs = new List<Models.CLINICDoctor>();

//        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);

//        public Search()
//        {
//            InitializeComponent();
//        }

//        public void SearchNameDoctor()
//        {
//            try
//            {
//                list.ItemsSource = null;
//                Docs.Clear();
//                SqlCommand command = new SqlCommand("Search_Doc_ByInit", conn);        
//                command.Parameters.AddWithValue("@init_doc", name.Text);
//                command.CommandType = System.Data.CommandType.StoredProcedure;
//                conn.Open();
//                SqlDataReader result = command.ExecuteReader();
//                while (result.Read())
//                {
//                    Models.CLINICDoctor name_doc = new Models.CLINICDoctor(
//                        result["Initial_doc"].ToString()
//                        );
//                    Docs.Add(name_doc);
//                }

//                if (Docs.Count > 0)
//                {
//                    list.ItemsSource = Docs;
//                }
//                else { MessageBox.Show("Совпадений не найдено"); }
//                conn.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        private void ButtomSearch_Click(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                if (name.Text == "") { MessageBox.Show("Введите название теста"); }
//                else
//                {

//                    SearchNameDoctor();
//                    name.Clear();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }

//        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//        {

//        }

//        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
//        {

//        }

//        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
//        {

//        }
//    }
//}
