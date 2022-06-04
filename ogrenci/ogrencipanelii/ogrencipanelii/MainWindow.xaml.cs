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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace ogrencipanelii
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KRELND0\SQLEXPRESS03;Initial Catalog=newDB;Integrated Security=True");
      

        public void cleardata()
        {
            adsoyad_txt.Clear();
            age_txt.Clear();
            gender_txt.Clear();
            city_txt.Clear();
            search_txt.Clear();

        }

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select *from firstable", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataGrid.ItemsSource = dt.DefaultView;
        }

        
        private void ClearData_btn_Click(object sender, RoutedEventArgs e)
        {
            cleardata();
        }

        public bool isValid()
        {
            if (adsoyad_txt.Text == string.Empty)
            {
                MessageBox.Show("name is reguired", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (age_txt.Text == string.Empty)
            {
                MessageBox.Show("name is reguired", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (gender_txt.Text == string.Empty)
            {
                MessageBox.Show("name is reguired", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (city_txt.Text == string.Empty)
            {
                MessageBox.Show("name is reguired", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void Insert_btn_Click(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO firstable VALUES (@AdSoyad,@Yaş,@Cinsiyet,@YaşadığıŞehir)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AdSoyad", adsoyad_txt.Text);
                    cmd.Parameters.AddWithValue("@Yaş", age_txt.Text);
                    cmd.Parameters.AddWithValue("@Cinsiyet", gender_txt.Text);
                    cmd.Parameters.AddWithValue("@YaşadığıŞehir", city_txt.Text);
                    con.Open();
                     cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("succesfully registered", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    cleardata();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Upadate_btn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update firstable set AdSoyad='"+ adsoyad_txt.Text + "',Yaş='"+ age_txt.Text + "',Cinsiyet='" + gender_txt.Text + "',YaşadığıŞehir='" + city_txt.Text + "' WHERE ID='"+ search_txt.Text+"' ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been updated succesfully", "updated", MessageBoxButton.OK, MessageBoxImage.Information);

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                cleardata();
                LoadGrid();
            }
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from firstable where ID =" + search_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been deleted", "deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                cleardata();
                LoadGrid();
                con.Close();

            }
            catch(SqlException ex)
            {
                MessageBox.Show("silinemedi" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
