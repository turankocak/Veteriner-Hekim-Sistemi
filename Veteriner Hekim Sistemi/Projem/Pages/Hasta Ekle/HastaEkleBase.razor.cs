using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.JSInterop;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;
using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;

namespace Projem.Pages
{
    public class HastaEkleBase : ComponentBase
    {
        public string Hastanin_Turu { get; set; }
        public string Hastanin_Cinsi { get; set; }
        public string Mikrocip_No { get; set; }
        public string Cinsiyeti { get; set; }
        public int Yasi { get; set; }
        public DateTime Dogum_Tarihi { get; set; } = new DateTime(2023, 1, 1);
        public string Sahibinin_ismi { get; set; }
        public string Sahibinin_soyismi { get; set; }
        public string Telefon_No { get; set; }
     
         
        static string connectionString = "Server=localhost;Database=Veteriner_Data;Integrated Security=SSPI;TrustServerCertificate=true;";

        static string insertQuery = "INSERT INTO Hasta_Kayit_Table (Hastanin_Turu,Hastanin_Cinsi,Mikrocip_No,Cinsiyeti,Yasi,Dogum_Tarihi,Sahibinin_ismi,Sahibinin_soyismi,Telefon_No) VALUES (@Hastanin_Turu,@Hastanin_Cinsi, @Mikrocip_No, @Cinsiyeti,@Yasi,@Dogum_Tarihi, @Sahibinin_ismi, @Sahibinin_soyismi, @Telefon_No)";
        static SqlConnection conn = new SqlConnection(connectionString);

        public async Task Kayıt()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Hastanin_Turu", Hastanin_Turu);
                        cmd.Parameters.AddWithValue("@Hastanin_Cinsi",Hastanin_Cinsi);
                        cmd.Parameters.AddWithValue("@Mikrocip_No",Mikrocip_No);
                        cmd.Parameters.AddWithValue("@Cinsiyeti",Cinsiyeti);
                        cmd.Parameters.AddWithValue("@Yasi",Yasi);
                        cmd.Parameters.AddWithValue("@Dogum_Tarihi",Dogum_Tarihi);
                        cmd.Parameters.AddWithValue("@Sahibinin_ismi", Sahibinin_ismi);
                        cmd.Parameters.AddWithValue("@Sahibinin_soyismi", Sahibinin_soyismi);
                        cmd.Parameters.AddWithValue("@Telefon_No", Telefon_No);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                Temizle();
                await Yenile();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veritabanı işlem hatası: " + ex.Message);
            }
        }

        private void Temizle()
        {
            Hastanin_Turu = "";
            Hastanin_Cinsi = "";
            Mikrocip_No = "";
            Cinsiyeti = "";
            Yasi= 0;
            Dogum_Tarihi = DateTime.Now;
            Sahibinin_ismi = "";
            Sahibinin_soyismi = "";
            Telefon_No = "";
            
        }

        private async Task Yenile()
        {
            await InvokeAsync(StateHasChanged);
        }
    }
}
