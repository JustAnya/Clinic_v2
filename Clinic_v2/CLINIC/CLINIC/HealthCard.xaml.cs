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
using CLINIC.Models;

namespace CLINIC
{
    /// <summary>
    /// Логика взаимодействия для HealthCard.xaml
    /// </summary>
    public partial class HealthCard : Window
    {
       // int Hei = 0;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        //int id_user = 0;
        //Card card_user = new Card();
        public HealthCard()
        {
            InitializeComponent();
            //FillAge();
            FillName();
            FillSurname();
            // FillHeight();
            // FillWeight();
            FillChonic_disease();
            FillTest_result();
            FillDiagnosis();
            FillTreatment();


            if (Models.MY.access == 2)
            {

                btnSave.Visibility = Visibility.Collapsed;
                //height.IsEnabled = false;
                // weight.IsEnabled = false;
                Chronic.IsEnabled = false;
                Result.IsEnabled = false;
                Diag.IsEnabled = false;
                Treatment.IsEnabled = false;
                btnSave.IsEnabled = false;

            }
            else { }
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (Models.MY.access == 1)
            {
                ListPatients ll = new ListPatients();
                ll.Show();
                this.Close();
            }
            else
            {
                Menu2 ll = new Menu2();
                ll.Show();
                this.Close();
            }
        }

        //public int showAge()
        //{
        //    int Age = 0;
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        //        conn.Open();
        //        SqlCommand command = new SqlCommand("Loading_Age", conn);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        if (Models.MY.access == 2)
        //            command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
        //        else
        //        {
        //            command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
        //        }
        //        var resn = command.ExecuteReader();
        //        if (resn.HasRows)
        //        {
        //            while (resn.Read())
        //            {

        //                   Age = Convert.ToInt32(resn.GetString(0));
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //      return Age;
        //}
        //public void FillAge()
        //{
        //    try
        //    {
        //        int Age = showAge();
        //        txt_age.Content = (now.Year - Age.Year);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public string showName()
        {
            string namee = "";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Name", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (Models.MY.access == 2)
                {
                    command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                }
                else
                {
                    command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
                }
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {

                        namee = resn.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return namee;
        }
        public void FillName()
        {
            try
            {
                txtSurname.Content = showName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string showSurname()
        {
            String sur = "";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Surname", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (Models.MY.access == 2)
                {
                    command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                }
                else
                {
                    command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
                }
                var ressur = command.ExecuteReader();
                if (ressur.HasRows)
                {
                    while (ressur.Read())
                    {
                        sur = ressur.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sur;
        }
        public void FillSurname()
        {
            try
            {
                txtName.Content = showSurname();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   // }
        //public int showHeight()
        //{
        //    int Hei = 0;
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        //        conn.Open();
        //        SqlCommand command = new SqlCommand("Loading_Height", conn);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        if (Models.MY.access == 2)
        //            command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
        //        else
        //        {
        //            command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
        //        }
        //        var resn = command.ExecuteReader();
        //        if (resn.HasRows)
        //        {
        //            while (resn.Read())
        //            {

        //                Hei = Convert.ToInt32(resn.GetString(0));
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return Hei;
        //}
        //public void FillHeight()
        //{
        //    try
        //    {
        //        int Hei = showHeight();
        //        height.Text = Convert.ToString(Hei);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //public int showWeight()
        //{
        //    int Weig = 0;
        //    try
        //    {
        //        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        //        conn.Open();
        //        SqlCommand command = new SqlCommand("Loading_Weight", conn);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        if (Models.MY.access == 2)
        //            command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
        //        else
        //        {
        //            command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
        //        }
        //        var resn = command.ExecuteReader();
        //        if (resn.HasRows)
        //        {
        //            while (resn.Read())
        //            {

        //                Weig = Convert.ToInt32(resn.GetString(0));
        //            }
        //        }
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return Weig;
        //}
        //public void FillWeight()
        //{
        //    try
        //    {
        //        int Weig = showHeight();
        //        weight.Text = Convert.ToString(Hei);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public string showChronic_disease()
        {
            string CD = " ";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Chronic_disease", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (Models.MY.access == 2)
                    command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                else
                {
                    command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
                }
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {

                        CD = resn.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return CD;
        }
        public void FillChonic_disease()
        {
            try
            {
                Chronic.Text = showChronic_disease();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string showTest_result()
        {
            string TS = " ";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Test_Result", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (Models.MY.access == 2)
                    command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                else
                {
                    command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
                }
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {

                        TS = resn.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return TS;
        }
        public void FillTest_result()
        {
            try
            {
                Result.Text = showTest_result();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string showDiagnosis() 
        {
            string Diag = " ";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Diagnosis", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (Models.MY.access == 2)
                    command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                else
                {
                    command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
                }
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {

                        Diag = resn.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Diag;
        }
        public void FillDiagnosis()
        {
            try
            {
                Diag.Text = showDiagnosis();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string showTreatment()
        {
            string Treat = " ";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Treatment", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (Models.MY.access == 2)
                    command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                else
                {
                    command.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
                }
                var resn = command.ExecuteReader();
                if (resn.HasRows)
                {
                    while (resn.Read())
                    {

                        Treat = resn.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Treat;
        }
        public void FillTreatment()
        {
            try
            {
                Treatment.Text = showTreatment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public HealthCard(int id)
        //{
        //    InitializeComponent();

        //    id_user = id;
        //    card_user = Card.GetCardByIdUser(id);
        //    Profile pr = User.GetProfileByIdUser(id);
        //    txtID.Content = card_user.Id_card;
        //    txtName.Content = pr.Name;
        //    txtSurname.Content = pr.Surname;
        //    txt_age.Content = Convert.ToString(-pr.Birth.Year+DateTime.Now.Year);
        //    height.Text = Convert.ToString(card_user.Height);
        //    weight.Text = Convert.ToString(card_user.Weight);
        //    Chronic.Text = card_user.Chronic_dis;
        //    Result.Text = card_user.Test_results;
        //    Diag.Text = card_user.Diagnosis;
        //    Treatment.Text = card_user.Treatment;

        // if(Models.MY. ==1)
        //    {

        //    }
        //    else
        //    {
        //        height.IsEnabled = false;
        //        weight.IsEnabled = false;
        //        Chronic.IsEnabled = false;
        //        Result.IsEnabled = false;
        //        Diag.IsEnabled = false;
        //        Treatment.IsEnabled = false;
        //        btnSave.IsEnabled = false;
        // }
        // }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                using (SqlCommand uiihc = new SqlCommand("Update_Information_In_Health_Card", conn))
                {
                    uiihc.CommandType = System.Data.CommandType.StoredProcedure;
                    // uiihc.Parameters.AddWithValue("@Height", (Convert.ToInt32(height.Text))); Models.PROF.id_us
                    // uiihc.Parameters.AddWithValue("@Weight", (Convert.ToInt32(weight.Text)));
                    uiihc.Parameters.AddWithValue("@id_us", Models.PROF.id_us);
                    uiihc.Parameters.AddWithValue("@Chronic_disease", Chronic.Text);
                    uiihc.Parameters.AddWithValue("@Test_results", Result.Text);
                    uiihc.Parameters.AddWithValue("@Diagnosis", Diag.Text);
                    uiihc.Parameters.AddWithValue("@Treatment", Treatment.Text);
                    uiihc.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show("Выполнено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Card.UpdateByIdCard(card_user.Id_card, Convert.ToInt32(height.Text), Convert.ToInt32(weight.Text), Chronic.Text, Result.Text, Diag.Text, Treatment.Text);
            //ListPatients ll = new ListPatients();
            //ll.Show();
            //this.Close();
        }
    }
}