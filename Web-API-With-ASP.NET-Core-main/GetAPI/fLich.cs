using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Ubiety.Dns.Core;
using System.IO;
using System.Net;
using System.Net.Http;

namespace GetAPI
{
   
    public partial class fLich : Form
    {
        BindingSource list = new BindingSource();
        BindingSource list3 = new BindingSource();
        BindingSource list4 = new BindingSource();
        BindingSource list5 = new BindingSource();
        BindingSource list6 = new BindingSource();
        BindingSource list7 = new BindingSource();
        BindingSource listcn = new BindingSource();
        private Session sess;
        Session Sess
        {
            get { return sess; }
            set { sess = value; }
        }
        public fLich(Session s)
        {
            InitializeComponent();
            this.sess = s;
            loadAllData();
        }
        public void loadAllData()
        {
            loadData();
            //binding();
        }
         void binding()
        {

            txtday2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "day"));
            txttime2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "thoigian"));
            txtjob2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "viec"));
            txtid2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday3.DataBindings.Add(new Binding("Text", dtgv3.DataSource, "day"));
            txttime3.DataBindings.Add(new Binding("Text", dtgv3.DataSource, "thoigian"));
            txtjob3.DataBindings.Add(new Binding("Text", dtgv3.DataSource, "viec"));
            txtid3.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday4.DataBindings.Add(new Binding("Text", dtgv4.DataSource, "day"));
            txttime4.DataBindings.Add(new Binding("Text", dtgv4.DataSource, "thoigian"));
            txtjob4.DataBindings.Add(new Binding("Text", dtgv4.DataSource, "viec"));
            txtday4.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));


            txtday5.DataBindings.Add(new Binding("Text", dtgv5.DataSource, "day"));
            txttime5.DataBindings.Add(new Binding("Text", dtgv5.DataSource, "thoigian"));
            txtjob5.DataBindings.Add(new Binding("Text", dtgv5.DataSource, "viec"));
            txtid5.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday6.DataBindings.Add(new Binding("Text", dtgv6.DataSource, "day"));
            txttime6.DataBindings.Add(new Binding("Text", dtgv6.DataSource, "thoigian"));
            txtjob6.DataBindings.Add(new Binding("Text", dtgv6.DataSource, "viec"));
            txtid6.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday7.DataBindings.Add(new Binding("Text", dtgv7.DataSource, "day"));
            txttime7.DataBindings.Add(new Binding("Text", dtgv7.DataSource, "thoigian"));
            txtjob7.DataBindings.Add(new Binding("Text", dtgv7.DataSource, "viec"));
            txtid7.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtdaycn.DataBindings.Add(new Binding("Text", dtgvcn.DataSource, "day"));
            txttimecn.DataBindings.Add(new Binding("Text", dtgvcn.DataSource, "thoigian"));
            txtjobcn.DataBindings.Add(new Binding("Text", dtgvcn.DataSource, "viec"));
            txtidcn.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));


        }




        async void loadData()

        {
            #region 1
            //var response= await Lich.getid("2", "3", "8gio");
            //txtsang3.Text = response;


            //HttpClient clint = new HttpClient();
            //clint.BaseAddress = new Uri("https://localhost:44375/api/");
            //HttpResponseMessage response = clint.GetAsync("CongViec/2/3/8gio").Result;

            //var emp = response.Content.ReadAsAsync<IEnumerable<ModelLich>>().Result;
            //dataGridView1.DataSource = emp;
            #endregion
            string id = sess.id;
            string baseUrl = "https://localhost:44375/api/CongViec/"+id +"/2";


            // convert json to datagridview
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(baseUrl);
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv2.DataSource = user;
                list.DataSource = user;
            }


            #region a


             using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/"+id + "/3");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv3.DataSource = user;
                list3.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/"+id + "/4");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv4.DataSource = user;
                list4.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/"+id + "/5");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv5.DataSource = user;
                list5.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/"+id + "/6");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv6.DataSource = user;
                list6.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/"+id + "/7");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv7.DataSource = user;
                list7.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/"+id + "/cn");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgvcn.DataSource = user;
                listcn.DataSource = user;
            }
            #endregion

        }

        private void dtgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //public void Them(string day, string thoigian, string viec,string id)
        //{

        //    ModelLich lich = new ModelLich();
        //    string userID = sess.id;
        //    lich.id = id;

        //    lich.user_id = userID;
        //    lich.day = day;
        //    lich.thoigian = thoigian;
        //    lich.viec = viec;

        //    string postData = JsonConvert.SerializeObject(lich);

        //    string strUrl = String.Format("https://localhost:44375/api/CongViec");
        //    WebRequest request = WebRequest.Create(strUrl);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";


        //    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        //    {
        //        streamWriter.Write(postData);
        //        streamWriter.Flush();
        //        streamWriter.Close();
        //        var response = request.GetResponse();
        //        using (var streamReader = new StreamReader(response.GetResponseStream()))
        //        {
        //            var result = streamReader.ReadToEnd();

        //        }
        //    }

        //}

        public void Sua(string day,string thoigian,string viec)
        {
            string strUrl = String.Format("https://localhost:44375/api/Account/11");
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "PUT";
            request.ContentType = "application/json";
            ModelLich lich = new ModelLich();
            string userID = sess.id;


            lich.user_id = userID;
            lich.day = day;
            lich.thoigian = thoigian;
            lich.viec = viec;

            
            string postData = JsonConvert.SerializeObject(lich);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();
                var response = request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                }
            }
        }

        private  void btnthem_Click(object sender, EventArgs e)
        {



            //Them("2", "4", "aaaac","34");


        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            //int id = 2;
            //RestClient.Delete(id);
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

