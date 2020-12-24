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
    /// Логика взаимодействия для AddDocInfo.xaml
    /// </summary>
    public partial class AddDoc : Window
    {
       public int day = Models.TimeDoc.day;
       public int spec = Models.Spec.id_spec_doc;
       public int spec_doc_now = Models.DOC.id_spec;
       public int id_doc = Models.DOC.id_doc;
     
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        private void list_Work(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (list_spec.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Выберите день недели");
                }
                else
                {
                    switch (list_spec.SelectedIndex)
                    {
                        case 0:
                            Models.TimeDoc.day =1;
                            break;
                        case 1:
                            Models.TimeDoc.day = 2;
                            break;
                        case 2:
                            Models.TimeDoc.day = 3;
                            break;
                        case 3:
                            Models.TimeDoc.day = 4;
                            break;
                        case 4:
                            Models.TimeDoc.day = 5;
                            break;
                        case 5:
                            Models.TimeDoc.day = 6;
                            break;
                    }

                    MessageBox.Show("Выполнено !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
        private void list_Specialty(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (list_spec.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Выберите свою специальность");
                }
                else
                {
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
                        case 6:
                            Models.Spec.id_spec_doc = 7;
                            break;
                        case 7:
                            Models.Spec.id_spec_doc = 8;
                            break;
                        case 8:
                            Models.Spec.id_spec_doc = 9;
                            break;
                        case 9:
                            Models.Spec.id_spec_doc = 10;
                            break;
                        case 10:
                            Models.Spec.id_spec_doc = 11;
                            break;
                        case 11:
                            Models.Spec.id_spec_doc = 12;
                            break;
                    }

                    MessageBox.Show("Выполнено !!!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        //public void InsertInfAboutDoc()
        //{
        //    conn.Open();
        //    using (SqlCommand iiad = new SqlCommand("Add_Information_In_Health_Card", conn))
        //    {
        //        iiad.CommandType = System.Data.CommandType.StoredProcedure;
        //        iiad.Parameters.AddWithValue("@About_doctor",ab_d.Text);

        //        iiad.ExecuteNonQuery();
        //    }
        //    conn.Close();
        //}

        //Doctor doc = new Doctor();
        //List<Speciality> list_s = new List<Speciality>();
        //List<TimeDoctor> list_a_t = new List<TimeDoctor>();
        //List<string> list_s_s = new List<string>();
        //List<string> list_d_s = new List<string>();
        //List<string> list_a_t_s = new List<string>();

        //public AddDocInfo()
        //{
        //    InitializeComponent();

        //    list_s = Speciality.
        //  ListSpeciality();
        //    doc = Doctor.GetDoctorByIdUser(User.Id_user);
        //    ab_d.Text = doc.About_doctor;

        //    foreach (Speciality s in list_s)
        //    {
        //        list_s_s.Add(s.Name_specialty);
        //    }
        //    list_spec.ItemsSource = list_s_s;

        //    for (int i=1; i<=7; i++)
        //    {
        //        list_d_s.Add(Convert.ToString(i));
        //    }
        //    list_day.ItemsSource = list_d_s;

        //    FillListTime();          

        //    for (int i = 0; i < list_s.Count; i++)
        //    {
        //        if (list_s[i].Name_specialty == Speciality.GetNameSpecialityByIDSpeciality(doc.Id_specialty))
        //        {
        //            list_spec.SelectedIndex = i;
        //            break;
        //        }
        //    }
        //}

        public void FillListTime()
        {
            //list_all_time.ItemsSource = null;
            //list_a_t_s.Clear();
            //list_a_t.Clear();
            //list_a_t = TimeDoctor.GetUniqByIdDoctor(doc.Id_doctor); 
            //foreach (var t in list_a_t)
            //{
            //    list_a_t_s.Add(t.Day + " " + TimeUser.GetTimeById(t.id_time_user).AllTime);
            //}
            //list_all_time.ItemsSource = list_a_t_s;
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtomReg_Click(object sender, RoutedEventArgs e)
        {
            //if (list_day.SelectedItem != null)
            //{
            //    if ((bool)sm1.IsChecked)
            //    {
            //        if (TimeDoctor.isContainByDayByDoctorId((list_day.SelectedIndex + 1), doc.Id_doctor))
            //        {
            //            MessageBox.Show("Этот день уже есть в расписании.");
            //        }
            //        else
            //        {
            //            var list_time = TimeUser.GetListTimeByAllTime((string)sm1.Content);
            //            foreach (var l in list_time)
            //            {
            //                TimeDoctor.SetTime(l.id, (list_day.SelectedIndex + 1), doc.Id_doctor);
            //            }
            //            FillListTime();
            //        }
            //    }
            //    else if ((bool)sm2.IsChecked)
            //    {
            //        if (TimeDoctor.isContainByDayByDoctorId((list_day.SelectedIndex + 1), doc.Id_doctor))
            //        {
            //            MessageBox.Show("Этот день уже есть в расписании.");
            //        }
            //        else
            //        {
            //            var list_time = TimeUser.GetListTimeByAllTime((string)sm2.Content);
            //            foreach (var l in list_time)
            //            {
            //                TimeDoctor.SetTime(l.id, (list_day.SelectedIndex + 1), doc.Id_doctor);
            //            }
            //            FillListTime();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Выберите день недели.");
            //}
        }
        

        private void Butt(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                using (SqlCommand iiad = new SqlCommand("Add_Information_About_Doctor", conn))
                {
                    iiad.CommandType = System.Data.CommandType.StoredProcedure;
                    iiad.Parameters.AddWithValue("@About_doctor", ab_d.Text);
                    iiad.Parameters.AddWithValue("@Id_specialty", Models.Spec.id_spec_doc);

                    iiad.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show("Выполнено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Doctor.UpdateByAboutBySpec(ab_d.Text, Speciality.GetIdSpecialityByNameSpeciality(Convert.ToString(list_spec.SelectedItem))); 
            //MessageBox.Show("Сохранено");
            //Close();
        }

        private void Butt2(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                using (SqlCommand uiad = new SqlCommand("Update_Information_About_Doctor", conn))
                {
                    uiad.CommandType = System.Data.CommandType.StoredProcedure;
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
        private void ButtomR_Click(object sender, RoutedEventArgs e)
        {
        //    if (list_all_time.SelectedItem!=null)
        //    {
        //        foreach(var t in list_a_t)
        //        {
        //            string s = t.Day + " " + TimeUser.GetTimeById(t.id_time_user).AllTime;
        //            if ((string)list_all_time.SelectedItem==s)
        //            {
        //                TimeDoctor.DeleteTimeByIdDoctorByDay(Doctor.GetDoctorByIdUser(User.Id_user).Id_doctor, t.Day); 
        //            }
        //        }
        //        FillListTime();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Выберите время из списка.");
        //    }
       }
    }
}
