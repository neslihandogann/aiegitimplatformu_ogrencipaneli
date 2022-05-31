using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.classlar
{
    public class DBbaglanti
    {
        public static string DBadres = @"Data Source=" + Environment.CurrentDirectory + "\\DB\\ders.db;Version=3;New=False;Compress=True;Read Only=False;";
        public static string BagDurum;
        public static void BagTest()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DBadres))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                        BagDurum = "veritabanına bağlanıldı...";
                    }
                    catch (Exception)
                    {
                        BagDurum = "veritabanı bağlantı hatası...";
                    }
                }
                else
                {
                    BagDurum = "veritabanına bağlanıldı...";
                }
            }
        }
    
    } 

}
