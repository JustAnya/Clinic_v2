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
    

    public partial class DoctorRegistration : Window
    {
        static int day = 0;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);


        public int spec = Models.Spec.id_spec_doc;
        public string ab = Models.Spec.about_spec;
        public string init_d = Models.DOC.init_doc;
    
        public DoctorRegistration()
        {
        InitializeComponent();
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

        private void ButtomSave_Click(object sender, RoutedEventArgs e)
        {
            if (combo_time.SelectedItem != null)
            {
                try
                {
                    Models.TU.time = combo_time.SelectedValue.ToString();
                    SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                    conn.Open();
                    using (SqlCommand ttfu = new SqlCommand("GetTalonDoctor", conn))
                    {
                        ttfu.CommandType = System.Data.CommandType.StoredProcedure;
                        ttfu.Parameters.AddWithValue("@id_user", Models.MY.id_us);
                        ttfu.Parameters.AddWithValue("@time_doctor", Models.TU.time);
                        ttfu.ExecuteNonQuery();
                    }
                    MessageBox.Show("Выполнено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
               MessageBox.Show("Выберите время");
            }
         }
        
        public List<string> showListTimeDoc()
        {

            List<string> showtime = new List<string>();
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command3 = new SqlCommand("GetTimeDoctor", conn);
                command3.CommandType = System.Data.CommandType.StoredProcedure;
                command3.Parameters.AddWithValue("@date_doctor", day);
                command3.Parameters.AddWithValue("@id_doctor", Models.DOC.id_doc);
                var resn = command3.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {
                        showtime.Add(resn.GetString(0));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return showtime;
        }

        public void FillСomboTimeDoc()
        {
            try
            {
                foreach (var a in showListTimeDoc())
                    combo_time.Items.Add(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<string> showListInitDoc()
        {

            List<string> show = new List<string>();
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Get_doc_by_idspec", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_spec", Models.Spec.id_spec_doc);
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

        public void FillСomboBoxInitDoc()
        {
            try
            {
                foreach (var a in showListInitDoc())
                    combo_doc.Items.Add(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void text_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void text_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void combo_spec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                switch (combo_spec.SelectedIndex)
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

                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                string stringid = "select CLINIC.dbo. Get_About_Specilty_byId('" + Models.Spec.id_spec_doc + "');";
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                string ab = Convert.ToString(command_id.ExecuteScalar());
                label_info.Text = ab;
                conn.Close();
                FillСomboBoxInitDoc();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void calend_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime ddd = new DateTime();
            if (((DateTime)calend.SelectedDate).Day <= 25)
            {
                DateTime dd = new DateTime(((DateTime)calend.SelectedDate).Year, ((DateTime)calend.SelectedDate).Month, ((DateTime)calend.SelectedDate).Day + 7);
                ddd = dd;
            }
            else
            {
                DateTime dd = new DateTime(((DateTime)calend.SelectedDate).Year, ((DateTime)calend.SelectedDate).Month + 1, 1);
                ddd = dd;
            }

            //TimeD ttt = new TimeD();
            combo_time.ItemsSource = null;
            //l_t.Clear();
            if (calend.SelectedDate <= DateTime.Now /*|| calend.SelectedDate>=ddd*/)
            {
                MessageBox.Show("Выберите корректную дату");
            }
           else
            {
                    if (((DateTime)calend.SelectedDate).DayOfWeek == DayOfWeek.Monday)
                    {
                        day = 1;
                 
                }
                    else if (((DateTime)calend.SelectedDate).DayOfWeek == DayOfWeek.Tuesday)
                    {
                    day = 2;
             
                }
                    else if (((DateTime)calend.SelectedDate).DayOfWeek == DayOfWeek.Wednesday)
                    {
                    day = 3;
                 
                }
                    else if (((DateTime)calend.SelectedDate).DayOfWeek == DayOfWeek.Thursday)
                    {
                    day = 4;
                   
                }
                    else if (((DateTime)calend.SelectedDate).DayOfWeek == DayOfWeek.Friday)
                    {
                    day = 5;
              
                }
                    else if (((DateTime)calend.SelectedDate).DayOfWeek == DayOfWeek.Saturday)
                    {
                    day = 6;
                }
                    else if (((DateTime)calend.SelectedDate).DayOfWeek == DayOfWeek.Sunday)
                    {
                    
                        MessageBox.Show("Воскресенье - выходной. Вызывайте скорую.");
                    }
                }
            FillСomboTimeDoc();
        }

            private void combo_doc_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
           
                Models.TU.time = combo_time.SelectedValue.ToString();
               
        }
    
        private void combo_doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Models.DOC.init_doc = combo_doc.SelectedValue.ToString();
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                string stringid = "select CLINIC.dbo.Get_AboutDoc_by_Init_doc('" + Models.DOC.init_doc + "');";
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                string abd = Convert.ToString(command_id.ExecuteScalar());
                label_info2.Text = abd;
                conn.Close();
                GetIdDocByInitDoc();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetIdDocByInitDoc()
        {
            try
            {
                Models.DOC.init_doc = combo_doc.SelectedValue.ToString();
                SqlConnection conn1 = new SqlConnection(SqlConn.ConnectionString.defaultString);
                string stringid1 = "select CLINIC.dbo.Get_Id_doc_by_Init_doc('" + Models.DOC.init_doc + "');";
                conn.Open();
                SqlCommand command_id_doc = new SqlCommand(stringid1, conn);
                int id_doc = Convert.ToInt32(command_id_doc.ExecuteScalar());
                Models.DOC.id_doc = id_doc;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
 

  