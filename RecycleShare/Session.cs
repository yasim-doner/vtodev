using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleShare
{
    // Bu sınıf giriş yapan kişinin bilgilerini program kapanana kadar hafızada tutar
    public static class Session
    {
        public static int UserId { get; set; }
        public static string UserEmail { get; set; }

        // Veritabanındaki rol adı (admin_role, user_role, toplayici_role)
        public static string DbRoleName { get; set; }

        public static void Reset()
        {
            UserId = 0;
            UserEmail = null;

            // BURASI KRİTİK: Rolü null yapıyoruz ki, 
            // DatabaseHelper bir sonraki bağlantıda SET ROLE komutunu çalıştırmasın.
            // Böylece bağlantı varsayılan (postgres) haline döner.
            DbRoleName = "admin_role";
        }
    }
}
