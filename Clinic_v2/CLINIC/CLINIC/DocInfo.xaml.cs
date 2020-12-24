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
    /// Логика взаимодействия для DocInfo.xaml
    /// </summary>
    public partial class DocInfo : Window
    {
        public List<String> Time = new List<String>();
        List<int> LI = new List<int>();
        public int flag;
        public int day = Models.TimeDoc.day;
        public int spec = Models.Spec.id_spec_doc;
        public int spec_doc_now = Models.DOC.id_spec;
        public int id_us = Models.MY.id_us;
        public string alltime = Models.TU.alltime;

        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        public DocInfo()
        {
            try
            { 
            InitializeComponent();
            for (int y = 1; y <= 6; y++) { LI.Add(y); }
            list_day.ItemsSource = LI;
            GetIdDoctor(Models.MY.id_us);
                FillSpecialty();
                FillAbout();
                FillListTimeDoc();
  

            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }
        public void GetIdDoctor(int id_us)
        {
            try
            {
                string stringid = "select CLINIC.dbo.Get_IdDoc('" + Models.MY.id_us + "');";
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                int id = Convert.ToInt32(command_id.ExecuteScalar());
                Models.DOC.id_doc = id;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string showSpec()
        {
            string spec = "";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_specialty", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {
                        spec = resn.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return spec;
        }
        public void FillSpecialty()
        {
            try
            {
                list_spec.Text = showSpec();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<string> showListTD()
        {

            List<string> show = new List<string>();
            try
            {
               SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Get_work_time", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_doc", Models.DOC.id_doc);
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {
                        show.Add(resn.GetString(0) + " " + resn.GetInt32(1));
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
                foreach (var a in showListTD())
                    list_all_time.Items.Add(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string showAbout()
        {
            string about = "";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_AboutDoc", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {
                        about = resn.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return about;
        }
        public void FillAbout()
        {
            try
            {
                ab_d.Text = showAbout();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void list_Specialty(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //if (list_spec.Text.CompareTo("") == 0)
               // {
                    switch (list_spec.SelectedIndex)
                    {
                        case 0:
                            Models.Spec.id_spec_doc = 1;
                            break;
                        case 1:
                            Models.Spec.id_spec_doc = 2;
                            break;
                        case 2:
                            Models.Spec.id_spec_doc = 3;
                            break;
                        case 3:
                            Models.Spec.id_spec_doc = 4;
                            break;
                        case 4:
                            Models.Spec.id_spec_doc = 5;
                            break;
                        case 5:
                            Models.Spec.id_spec_doc = 6;
                            break;
                    }
               // }

                //else
                //{
                //    MessageBox.Show("Выберите свою специальность");
                //}
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtomReg_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if ((bool)sm1.IsChecked == true)
                {
                    Models.TU.alltime = "8:00 - 14:00";
                    flag = 1;
                }
                else
                {
                    Models.TU.alltime = "14:00 - 20:00";
                    flag = 2;
                }
                if (list_day.SelectedItem == null) { MessageBox.Show("choose day"); }
                else
                {
                    {
                        switch (list_day.SelectedIndex)
                        {
                            case 0:
                                Models.TimeDoc.day = 1;
                                Models.TU.day = 1;
                                break;
                            case 1:
                                Models.TimeDoc.day = 2;
                                Models.TU.day = 2;
                                break;
                            case 2:
                                Models.TimeDoc.day = 3;
                                Models.TU.day = 3;
                                break;
                            case 3:
                                Models.TimeDoc.day = 4;
                                Models.TU.day = 4;
                                break;
                            case 4:
                                Models.TimeDoc.day = 5;
                                Models.TU.day = 5;
                                break;
                            case 5:
                                Models.TimeDoc.day = 6;
                                Models.TU.day = 6;
                                break;
                                //case 6:
                                //    Models.TimeDoc.day = 7;
                                //    break;
                        }
                    }
                }
                  // list_all_time.ItemsSource = null;
                    conn.Open();
                    SqlCommand command1 = new SqlCommand("iitd", conn);
                    command1.CommandType = System.Data.CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@id_doc", Models.DOC.id_doc);
                    command1.Parameters.AddWithValue("@day", Models.TimeDoc.day);
                    command1.ExecuteNonQuery();
                    conn.Close();
                    Time.Add(Models.TimeDoc.day +" "+ Models.TU.alltime);
                // list_all_time.ItemsSource.Clear();
                list_all_time.Items.Clear();
               // list_all_time.ItemsSource = Time;
                FillListTimeDoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void ButtomR_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
            conn.Open();
            
            SqlCommand command = new SqlCommand("DeletTimeDoctor_by_day", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_doc", Models.DOC.id_doc);
            command.Parameters.AddWithValue("@day", Convert.ToInt32(list_all_time.SelectedItem.ToString().Split(' ')[3]));
            var resn = command.ExecuteReader();
            list_all_time.Items.Clear();
            FillListTimeDoc();
            conn.Close();
        }


        private void list_Work(object sender, SelectionChangedEventArgs e)
        {
            try
            {
             //   if (list_day.Text.CompareTo("") == 0)
              //  {
                    switch (list_day.SelectedIndex)
                    {
                        case 0:
                            Models.TimeDoc.day = 1;
                            Models.TU.day = 1;
                            break;
                        case 1:
                            Models.TimeDoc.day = 2;
                            Models.TU.day = 2;
                            break;
                        case 2:
                            Models.TimeDoc.day = 3;
                            Models.TU.day = 3;
                            break;
                        case 3:
                            Models.TimeDoc.day = 4;
                            Models.TU.day = 4;
                            break;
                        case 4:
                            Models.TimeDoc.day = 5;
                            Models.TU.day = 5;
                            break;
                        case 5:
                            Models.TimeDoc.day = 6;
                            Models.TU.day = 6;
                            break;
                            //case 6:
                            //    Models.TimeDoc.day = 7;
                            //    break;
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Выберите день недели");
                //}
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Butt(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                using (SqlCommand uiad = new SqlCommand("Update_Information_About_Doctor", conn))
                {
                    uiad.CommandType = System.Data.CommandType.StoredProcedure;
                    uiad.Parameters.AddWithValue("@Id_us", Models.MY.id_us);
                    uiad.Parameters.AddWithValue("@About_doctor", ab_d.Text);
                    uiad.Parameters.AddWithValue("@Id_specialty", Models.Spec.id_spec_doc);
                    uiad.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show("Выполнено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
   
//private void Butt2(object sender, RoutedEventArgs e)
//{

//}

private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Profile1 l = new Profile1 ();
            l.Show();
            this.Close();
        }

        private void CheckedChanged1(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if ((bool)sm1.IsChecked == true)
            {
                Models.TU.alltime = "8:00 - 14:00";
                flag = 1;
            }
            else 
            {
                Models.TU.alltime = "14:00 - 20:00";
                flag = 2;
            }
        }

        private void list_day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Models.TimeDoc.day = (int)list_day.SelectedItem;

        }
    }
}
