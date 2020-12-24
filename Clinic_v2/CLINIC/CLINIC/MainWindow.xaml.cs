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
using System.Security.Cryptography;
using System.Data;
using System.Configuration;
namespace CLINIC
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      //  #region navig
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        public static string Hash(string input)//хеширование пароля
        {
            byte[] hash = Encoding.ASCII.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string output = "";
            foreach (var b in hashenc)
            {
                output += b.ToString("x2");
            }
            return output;
        }
        public int Id_user() //по логину получаем айди юзера
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                string stringid = "select CLINIC.dbo.Take_iduser_byLog('" + login.Text + "');";
                conn.Open();
                SqlCommand command = new SqlCommand(stringid, conn);
                int id_us = Convert.ToInt32(command.ExecuteScalar());
                Models.MY.id_us = id_us;
                conn.Close();
                return id_us;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public int Take_access() //по логину получаем уровень доступа
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                string getting_access = "select CLINIC.dbo.Getting_Access('" + login.Text + "');";
                conn.Open();
                SqlCommand command = new SqlCommand(getting_access, conn);
                int access = Convert.ToInt32(command.ExecuteScalar());
                Models.MY.access = access;
                conn.Close();
                return access;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sqlExpression = "select CLINIC.dbo.SearchUser('" + login.Text + "', '" + password.Text + "');";
                // string getting_access = "select CLINIC.dbo.Getting_Access('" + login.Text + "');";
                using (SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString))
                {
                    SqlCommand command = new SqlCommand(sqlExpression, conn);
                    conn.Open();
                    Int32 number = Convert.ToInt32(command.ExecuteScalar());
                    if (number == 0)
                    {
                        MessageBox.Show("invalid Data");
                        login.Clear();
                        password.Clear();
                    }
                    else if (number == 1)
                    {
                        int access = Take_access();
                        Models.MY.access = access;
                        // SqlCommand take_id_ = new SqlCommand(getting_access, conn);
                        // getting_access = Models.MY.access;
                        // Int32 id = Convert.ToInt32(take_id_.ExecuteScalar());
                        SqlConnection conn1 = new SqlConnection(SqlConn.CurrentConnectionString);
                        SqlConnection conn2 = new SqlConnection(SqlConn.UserConnectionString);
                        if (Models.MY.access == 1)
                        {
                            SqlCommand comm = new SqlCommand(sqlExpression, conn1);
                            int number1 = command.ExecuteNonQuery();
                            MessageBox.Show("Complete");
                            int id_us = Id_user();
                            Models.MY.id_us = id_us;

                            Menu1 MenuAdmin = new Menu1();
                            MenuAdmin.Show();
                            this.Close();
                        }
                        else
                        {
                            SqlCommand comm = new SqlCommand(sqlExpression, conn2);
                            int number2 = command.ExecuteNonQuery();
                            MessageBox.Show("Complete");
                            int id_us = Id_user();
                            Models.MY.id_us = id_us;
                            Menu2 MenuUser = new Menu2();
                            MenuUser.Show();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }


            ///// <summary>
            ///// Логика взаимодействия для MainWindow.xaml
            ///// </summary>
            //public partial class MainWindow : Window
            //{
            //    public MainWindow()
            //    {
            //        InitializeComponent();
            //    }

//    private void btnLogin_Click(object sender, RoutedEventArgs e)
//    {
//        SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.Constr);
//        try
//        {
//            if (sqlCon.State == ConnectionState.Closed)
//                sqlCon.Open();
//            //ищем юзера по логину и паролю в бд
//            String querty = "SELECT COUNT(1) FROM [USER] WHERE LOGIN=@LOGIN AND PASSWORD=@PASSWORD";
//            SqlCommand sqlCmd = new SqlCommand(querty, sqlCon);
//            sqlCmd.CommandType = CommandType.Text;
//            sqlCmd.Parameters.AddWithValue("@LOGIN", login.Text);
//            sqlCmd.Parameters.AddWithValue("@PASSWORD", Hash((Convert.ToString(password.Text))));
//            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
//            DataTable table = new DataTable();

//            if (count == 1) //если нашли одного такого пользователя
//            {
//                SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP(1) * from [USER] where [LOGIN] like '" + login.Text + "'", sqlCon);
//                adapter.Fill(table);
//                int access = (int)table.Rows[0]["ACCESS"];
//                User.Login = login.Text;
//                User.Access = access;
//                User.Id_user = (int)table.Rows[0]["Id_user"];
//                if (access == 1)//если врач
//                {
//                    Menu1 aa = new Menu1();
//                    this.Close();
//                    aa.Show();
//                }
//                else //если пациент
//                {
//                    Menu2 bb = new Menu2();
//                    this.Close();
//                    bb.Show();
//                }
//            } 
//            else//если не нашли юзера
//            {
//                MessageBox.Show("Login or password is incorrect.");
//            }

//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            sqlCon.Close();
//        }
//    }

//    private void btnRegister_Click(object sender, RoutedEventArgs e)
//    {
//        Registration registration = new Registration();
//        registration.Show();
//        this.Close();
//    }

//    private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//    {
//        Close();
//    }

//    private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
//    {
//        this.WindowState = WindowState.Minimized;
//    }
//    public static string Hash(string input)//хеширование пароля
//    {
//        byte[] hash = Encoding.ASCII.GetBytes(input);
//        MD5 md5 = new MD5CryptoServiceProvider();
//        byte[] hashenc = md5.ComputeHash(hash);
//        string output = "";
//        foreach (var b in hashenc)
//        {
//            output += b.ToString("x2");
//        }
//        return output;
//    }
//}

