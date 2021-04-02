using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task button1_ClickAsync(object sender, EventArgs e)
        {

            //var resource=await RestClient.get();
            //txtReply.Text = resource;
            
            



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //var resource = await RestClient.get();
            //txtReply.Text = RestClient.makeJson(resource);
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            //string id = txtid.Text;
            //var resource = await RestClient.getid(id);
            //txtReply.Text = resource;
        }

        private async void btnpost_Click(object sender, EventArgs e)
        {

            //var response = await RestClient.PostLogin( txtusername.Text, txtpassword.Text);
            //txtReply.Text = response.ToString();

        }

        private async void btnput_Click(object sender, EventArgs e)
        {
            //var response = await RestClient.Put(Int32.Parse(id.Text), txtusername.Text, txtpassword.Text);
            //txtReply.Text = response;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var response = await Delete(txtid.Text);
            txtReply.Text = response;
        }
        public static async Task<string> Delete(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync("https://localhost:44375/api/Account/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        MessageBox.Show(res.StatusCode.ToString());
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        //public void postdata()
        //{
        //    HttpWebRequest webRequest;

        //    string requestParams = "{\"id\":4,\"username\":\"huudang21\",\"password\":\"abc2\"}"; 

        //    webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44375/api/Account");

        //    webRequest.Method = "POST";
        //    webRequest.ContentType = "application/json";


        //    byte[] byteArray = Encoding.UTF8.GetBytes(requestParams);
        //    webRequest.ContentLength = byteArray.Length;
        //    using (Stream requestStream = webRequest.GetRequestStream())
        //    {
        //        requestStream.Write(byteArray, 0, byteArray.Length);
        //    }



        //}

    }
}
