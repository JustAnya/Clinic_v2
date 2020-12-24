using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
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

namespace CLINIC
{
    public partial class Profile1 : Window
    {
        public int id_us = Models.MY.id_us;
        public string name = Models.PROF.name;
        public string surname = Models.PROF.surname;
        public int age = Models.PROF.age;
        public string init_doc = Models.DOC.init_doc;

        SqlConnection sqlCon = new SqlConnection(SqlConn.CurrentConnectionString);
        //Byte[] ava;
      static  string path = "";

        public Profile1()
        {
            try
            {
                InitializeComponent();
                
                FillName();
                FillSurname();
                FillPhone_number();
                FillAddress();
                FillImage();
             //   GETID

            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }

            if (Models.MY.access == 2)
            {
                addinfo.Visibility = Visibility.Collapsed;
            }
        }
            public string showName()
            {
            string namee = "";
                try
                {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Name", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
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
                Name.Text = showName();
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
                command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
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
                Surname.Text = showSurname();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string showPhone_number()
        {
            string ph_n = " ";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Phone", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                var resph = command.ExecuteReader();
                if (resph.HasRows)
                {
                    while (resph.Read())
                    {
                        var Q = resph.GetType();
                        ph_n = resph.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ph_n;
        }
        public void FillPhone_number()
        {
            try
            {
                Phone.Text = showPhone_number();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string showAddress()
        {
            string addr = "";
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Address", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                var resad = command.ExecuteReader();
                if (resad.HasRows)
                {
                    while (resad.Read())
                    {
                        var a = resad.GetString(0);
                        addr = resad.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return addr;
        }
        public void FillAddress()
        {
            try
            {
                Address.Text = showAddress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string showImage()
        {
            string ph="";
            try
            {
                
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("Loading_Image", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                var res = command.ExecuteReader();
               if(res.HasRows)
                {
                    while(res.Read())
                    {
                        ph = res.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ph;
        }
        public void FillImage()
        {
            try
            {

                Photo.Source = new BitmapImage(new Uri(showImage()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtomSave1_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Surname.Text == "" || dateevent.Text == "" || Phone.Text == "" || Address.Text == "")
            {
                MessageBox.Show("не всё заполнено");
            }
            else
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("Update_Profile", sqlCon))

                    {
                        sqlCon.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                        cmd.Parameters.AddWithValue("@Name", Name.Text);
                        cmd.Parameters.AddWithValue("@Surname", Surname.Text);
                        cmd.Parameters.AddWithValue("@Age", dateevent.Text);
                        cmd.Parameters.AddWithValue("@Phone_number", Phone.Text);
                        cmd.Parameters.AddWithValue("@Image", path);
                        cmd.Parameters.AddWithValue("@Address", Address.Text);
                        cmd.Parameters.AddWithValue("@Init", ((Surname.Text + " " + Name.Text)));
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                    if (Models.MY.access == 1)
                    {
                        Models.DOC.init_doc = (Surname.Text + " " + Name.Text);
                        Models.PROF.name = Name.Text;
                        Models.PROF.surname = Surname.Text;
                        //Models.PROF.age = ((DateTime)dateevent.SelectedDate);
                        using (SqlCommand cmd1 = new SqlCommand("Add_Doc's_Init", sqlCon))//добавляем инициалы доктора 
                        {
                            sqlCon.Open();
                            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@id_us", Models.MY.id_us);
                            cmd1.Parameters.AddWithValue("@Init", ((Surname.Text + " " + Name.Text)));
                            cmd1.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                    }
                    else
                    {
                        Models.PROF.init = (Surname.Text + " " + Name.Text);
                        Models.PROF.name = Name.Text;
                        Models.PROF.surname = Surname.Text;
                        //Models.PROF.age = ((DateTime)dateevent.SelectedDate);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("выполнено");
                    sqlCon.Close();
                }
            }
        }
        
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { 
       if(Name.Text == "" || Surname.Text == "" || Phone.Text == "" || Address.Text == "")
            { MessageBox.Show("обязательно введите всю информацию для обратной связи"); }
            else {
                Close();
        }
}

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (Name.Text == "" || Surname.Text == "" || Phone.Text == "" || Address.Text == "")
            { MessageBox.Show("обязательно введите всю информацию для обратной связи"); }
            else
            {
                if (Models.MY.access == 2)
                {
                    Menu2 ll = new Menu2();
                    ll.Show();
                    this.Close();
                }
                else
                {
                    Menu1 lll = new Menu1();
                    lll.Show();
                    this.Close();
                }
            }
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog img = new OpenFileDialog();

                //BitmapImage bm1 = new BitmapImage();
                img.ShowDialog();
                path = img.FileName;
                Photo.Source = new BitmapImage(new Uri(path));
                //FileStream fs = new FileStream(img.FileName, FileMode.Open);
                //ava = new Byte[fs.Length];
                //int read = (int)fs.Length;
                //fs.Read(ava, 0, read);
                //fs.Close();

                //bm1.BeginInit();
                //bm1.UriSource = new Uri(img.FileName, UriKind.Relative);
                //bm1.CacheOption = BitmapCacheOption.OnLoad;
                //bm1.EndInit();

                //Photo.Source = bm1;

            }
            catch
            {
                MessageBox.Show("open error");
            }
        }

        private void Image_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {

        }
        public static BitmapImage byteArrayToBMP(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            MemoryStream ms2 = new MemoryStream();
            image.Save(ms2, ImageFormat.Png);
            BitmapImage bm1 = new BitmapImage();
            bm1.BeginInit();
            bm1.StreamSource = ms2;
            bm1.EndInit();
            return bm1;
        }

        //private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        //{
        //    //Menu1 lll = new Menu1();
        //    //lll.Show();
        //    //this.Close();
        //   // if (Models.MY.access == 1)
        //   // {
        //        AddDoc d = new AddDoc();
        //        d.Show();
        //        this.Close();
        //  //  }
        //   // else { }
        //}

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
            
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            DocInfo ad = new DocInfo();
            ad.Show();
            this.Close();
        }
    }
}
