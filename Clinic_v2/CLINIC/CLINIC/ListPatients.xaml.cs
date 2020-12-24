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
    
    ///<summary>
    /// Логика взаимодействия для ListPatients.xaml
    /// </summary>
    public partial class ListPatients : Window
    {
        public int us = 1051;
        List<string> list_p = new List<string>();
        public ListPatients()
        {
            InitializeComponent();
            FillList();
          //  FillСomboBoxInitPatient();
            FillСomboBoxInitPat();

            SqlConnection sqlCon = new SqlConnection(SqlConn.CurrentConnectionString);
            SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);

            
        }

        public void FillList()
        {
          list_patient.ItemsSource = null;//обнуляем старый список
         list_p.Clear();
        //    var l_s = TimeTable.GetListInitPatientByIdDoctor(Doctor.GetDoctorByIdUser(User.Id_user).Id_doctor);//взяли нашу айдишку и вывели пациентом
        //    foreach (var s in l_s)
        //    {
        //        list_p.Add(s);
        //    }
        //    list_patient.ItemsSource = list_p;
        }

        public List<string> showListInitDoc()
        {

            List<string> show = new List<string>();
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Get_users_for_doctor", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_doc", Models.DOC.id_doc);
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

        public void FillСomboBoxInitPatient()
        {
            try
            {
                foreach (var a in showListInitDoc())
                    list_patient.Items.Add(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtomLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //закрыть
        {
            Menu1 ll = new Menu1();
            ll.Show();
            this.Close();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e) //сворачиваем
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)//назад
        {
            Menu1 ll = new Menu1();
            ll.Show();
            this.Close();
        }

        private void list_patient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(list_patient==null)
            {
                MessageBox.Show("Выберите пациента");
            }
            else
            {
                Models.PROF.init=((string)(list_patient.SelectedItem));
                try
                {
                    SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                    string stringid = "select CLINIC.dbo.Get_Id_us_by_Init_us('" + Models.PROF.init + "');";
                    conn.Open();
                    SqlCommand command_id = new SqlCommand(stringid, conn);
                    int id = Convert.ToInt32(command_id.ExecuteScalar());
                    Models.PROF.id_us = id;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                HealthCard d = new HealthCard();
                d.Show();
                this.Close();
            }
        }
        public List<string> showListInit()
        {

            List<string> showus = new List<string>();
            try
            {
                int us = 1051;
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Use", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_us", us);
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {
                        showus.Add(resn.GetString(0));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return showus;
        }

        public void FillСomboBoxInitPat()
        {
            try
            {
                foreach (var a in showListInit())
                    list_patient.Items.Add(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
