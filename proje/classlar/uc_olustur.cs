using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Controls;

namespace proje.classlar
{
    public class uc_olustur
    {


        public static void Uc_ekle(Grid grd, System.Windows.Controls.UserControl uc)

        {
            if (grd.Children.Count > 0)
            {
                grd.Children.Clear();
                grd.Children.Add(uc);

            }
            else { grd.Children.Add(uc); }
        }

      
    }
}
