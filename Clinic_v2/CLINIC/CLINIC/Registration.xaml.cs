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
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CLINIC
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        Byte[] Data = null;
        public Registration()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
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

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            MainWindow l = new MainWindow();
            l.Show();
            this.Close();
        }
        
        private void ButtomReg_Click(object sender, RoutedEventArgs e)
        {
            if ((login.Text).Length > 2 && (password.Text).Length < 20 && login.Text != "" && (comboBox.Text).CompareTo("") != 0 )
            {
               
                SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.Constr);
                try
                {
                    string sqlExpression = null;
                    if (Models.MY.access == 2)
                    {
                         sqlExpression = @"exec CLINIC.dbo.InsertUser
                @login='" + login.Text + "',@password ='" + password.Text + "',@access='" + Models.MY.access + "'";
                    }
                    else
                    {
                        sqlExpression = @"exec CLINIC.dbo.InsertDoc
                @login='" + login.Text + "',@password ='" + password.Text + "',@access='" + Models.MY.access + "'";
                    }
                        string isEmpty = "select CLINIC.dbo.IfEmpty('" + login.Text + "');";
                        using (SqlConnection connection = new SqlConnection(SqlConn.CurrentConnectionString))
                        {
                            connection.Open();
                            SqlCommand command_is_empty = new SqlCommand(isEmpty, connection);
                            int is_empty = Convert.ToInt32(command_is_empty.ExecuteScalar());
                            if (is_empty == 0)
                            {

                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                int number = command.ExecuteNonQuery();
                            int id_us = Id_user();
                            Models.MY.id_us = id_us;
                            MessageBox.Show("Complete");
                            Profile1 Mw = new Profile1();//ПРОБЛЕМА
                            Mw.Show();
                            this.Close();
                            //MainWindow Mw = new MainWindow();
                            //Mw.Show();
                            //this.Close();
                        }
                            else if (is_empty == 1)
                            {
                                MessageBox.Show("This name is used by another user");
                                login.Clear();
                            }
                        }
                    }
                
              
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            else
            {
                try
                {
                    MessageBox.Show("Password langht should be < 20 and > 2 and login can not be empty");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //sqlCon.Close();
                }
            }
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void doctor_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void pation_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           switch (comboBox.SelectedIndex)
                {
                    case 0:
                        Models.MY.access = 1;
                        break;
                    case 1:
                        Models.MY.access = 2;
                        break;

                }
            
            }
            }
    }