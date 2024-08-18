using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Projem.Pages
{
    public class GirisBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }
        public List<string> TCList { get; set; } = new List<string>();
        public List<string> passwordList { get; set; } = new List<string>();
        public string TC { get; set; }
        public string password { get; set; }

        public string error { get; set; }
     static string connectionString = ("Server=localhost;Database=Veteriner_Data;Encrypt=False;Integrated Security=SSPI; Trusted_Connection=True;");

        static SqlConnection conn = new SqlConnection(connectionString);
        static string sql = "select TC,password from Kullanici_Table";
        static SqlDataAdapter daps = new SqlDataAdapter(sql, conn);
        SqlCommandBuilder cb = new SqlCommandBuilder(daps);
        DataSet dataSet = new DataSet();
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        adapter.Fill(dataSet);

                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            List<string> TCList = new List<string>();
                    List<string> passwordList = new List<string>();

                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        TCList.Add(row["TC"].ToString());
                        passwordList.Add(row["password"].ToString());
                    }
                    

                            if (LocalStorage != null)
                            {
                                await LocalStorage.SetAsync("TCList", TCList);
                                await LocalStorage.SetAsync("passwordList", passwordList);
                            }
                        }
                    }
                    else
                    {
                        error = "Veritabanı bağlantısı başarısız.";
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Bir hata oluştu: " + ex.Message;
            }
        }

 
protected async Task CikisYap()
{
    

    // Kullanıcıyı giriş sayfasına yönlendir
    Navigation.NavigateTo("/");
}

        public async Task GirisYap()
        {
            Console.WriteLine("Deneme");
            DataRowCollection itemColumns = dataSet.Tables[0].Rows;
            for(int i=0;i<dataSet.Tables[0].Rows.Count;i++){
                if(dataSet.Tables[0].Rows[i]["TC"].ToString()==TC &&dataSet.Tables[0].Rows[i]["password"].ToString()==password){

                    Navigation.NavigateTo("/Anasayfa");
                }
                else{
                     await JSRuntime.InvokeVoidAsync("alert", "Geçerli kullanıcı bulunamadı!");
                }
            }
            
        }
    }
}




