using proje.classlar;
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

namespace proje.kullanicikontrol
{
    /// <summary>
    /// ucaiderskonulari.xaml etkileşim mantığı
    /// </summary>
    public partial class ucaiderskonulari : UserControl
    {
        public ucaiderskonulari()
        {
            InitializeComponent();
        }
        MainWindow gk = (MainWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        private void btn_dersekle_click(object sender, RoutedEventArgs e)
        {
            WinDersKonulari ekle = new WinDersKonulari();
            ekle.Owner = gk;
            gk.Opacity = 0.3;
            ekle.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DBislemci.GridDoldur(dtg_DersListesi);
        }
    }
}
