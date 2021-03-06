    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GetAPI
{
    
    public static class RestClient
    {
        private static readonly string baseURL= "https://localhost:44375/api/AccountSecret";
        // lay toan bo du lieu cua account
        public static async Task<string> get()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<String> getSchedule()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync("https://localhost:44375/api/CongViec"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        // Kiem tra account da ton tai hay chua
        public static async Task<string> getid(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return makeJson(data);
                    }
                }
            }
            return string.Empty;

        }
        
        // Kiem tra cong viec da ton tai hay chua
        public static async Task<string> getidTKB(string userid,string id)
        {
            #region a
            //var inputData = new Dictionary<string, string>
            //    {

            //        {"user_id",userid},
            //        {"id",id }
            //    };

            //var input = new FormUrlEncodedContent(inputData);
            #endregion
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync("https://localhost:44375/api/CongViec" + "/" + id + "?userid=" + userid))
                {

                    res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        // Dang nhap 
        public static async Task<String> PostLogin( string username,string password)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "/" + username + "/" + password))
                {
                    res.Headers.Add("APIKey", "MySecureAPIKey");
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;

        }
        public static async Task<String> PostLogin2( string username, string password,int id)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL+ "/" + username + "/" + password + "/" + id ))
                {

                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;

        }



        public static string makeJson(string json)
        {
            JToken parseJson = JToken.Parse(json);
            return parseJson.ToString(Formatting.Indented);
        }


    }
}
