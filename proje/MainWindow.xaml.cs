using proje.classlar;
using proje.kullanicikontrol;
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

namespace proje
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBoxItem_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void btn_kapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sag_ust_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

     

        private void menubuton_derskonulari_click(object sender, RoutedEventArgs e)
        {
            uc_olustur.Uc_ekle(Content_icerik, new ucaiderskonulari());
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            uc_olustur.Uc_ekle(Content_icerik, new ucaiderskonulari());
            DBbaglanti.BagTest();
            versiyon.Content = DBbaglanti.BagDurum;        }

        
    }
}
