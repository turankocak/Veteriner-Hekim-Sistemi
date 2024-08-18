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
    public class MusteriEkleBase : ComponentBase
    {
      
        public string Musteri_ismi { get; set; }
        public string Musteri_soyismi { get; set; }
        public string Telefon_No { get; set; }
        public string E_Posta { get; set; }
        
         
        static string connectionString = "Server=localhost;Database=Veteriner_Data;Integrated Security=SSPI;TrustServerCertificate=true;";

        static string insertQuery = "INSERT INTO Musteri_Kayit_Table (Musteri_ismi,Sahibinin_soyismi,Telefon_No,E_Posta) VALUES ( @Musteri_ismi,@Musteri_soyismi,@Telefon_No,@E_Posta)";
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
                        cmd.Parameters.AddWithValue("@Musteri_ismi", Musteri_ismi);
                        cmd.Parameters.AddWithValue("@Musteri_soyismi", Musteri_soyismi);
                        cmd.Parameters.AddWithValue("@Telefon_No", Telefon_No);
                        cmd.Parameters.AddWithValue("@E_Posta", E_Posta);
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
            
            Musteri_ismi = "";
            Musteri_soyismi = "";
            Telefon_No = "";
            E_Posta = "";
            

        }

        private async Task Yenile()
        {
            await InvokeAsync(StateHasChanged);
        }
    }
}
