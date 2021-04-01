using DevExpress.XtraBars;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace GetAPI
{
    public partial class TKB : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       
        private Session sess;       
        Session Sess
        {
            get { return sess; }
            set { sess = value; }
        }
        public TKB(Session sess)
        {
            InitializeComponent();
            this.sess = sess;            
            loadData();            
        }
      
        public void loadData()
        {
            string id = sess.id;
            string baseUrl = "https://localhost:44375/api/CongViec/"+id ;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(baseUrl);
                var data = JsonConvert.DeserializeObject<List<ModelLich>>(json);
            
                dtgvTKB.DataSource = data;               

            }            
        }
        public void Them(string day, string thoigian, string viec, string id)
        {
            ModelLich lich = new ModelLich();
            string userID = sess.id;
            // User Id da dang nhap
            lich.id = id;
            lich.user_id = userID;
            lich.day = day;
            lich.thoigian = thoigian;
            lich.viec = viec;            
            string postData = JsonConvert.SerializeObject(lich);
            string strUrl = String.Format("https://localhost:44375/api/CongViec");
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
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
        public void Sua(string id, string day, string thoigian, string viec)
        {
            ModelLich lich = new ModelLich();
            lich.id = id;
            lich.day = day;
            lich.thoigian = thoigian;
            lich.viec = viec;
            lich.user_id = sess.id;
            string putData = JsonConvert.SerializeObject(lich);
            string strUrl = String.Format("https://localhost:44375/api/CongViec/"+id);
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "PUT";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(putData);
                streamWriter.Flush();
                streamWriter.Close();
                var reponse = request.GetResponse();
                using(var streamReader=new StreamReader(reponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();                    
                }
            }
        }
        //public void SuaAccount( string pass)
        //{
        //    string id = sess.id;
        //    sess.password = pass;
        //    string putData = JsonConvert.SerializeObject(sess);
        //    string strUrl = String.Format("https://localhost:44375/api/Account/" + id);
        //    WebRequest request = WebRequest.Create(strUrl);
        //    request.Method = "PUT";
        //    request.ContentType = "application/json";
        //    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        //    {
        //        streamWriter.Write(putData);
        //        streamWriter.Flush();
        //        streamWriter.Close();
        //        var reponse = request.GetResponse();
        //        using (var streamReader = new StreamReader(reponse.GetResponseStream()))
        //        {
        //            var result = streamReader.ReadToEnd();
        //        }
        //    }
        //}
        private async void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            string id, day, time, job;
            string userid = sess.id;
            
            for(int i=0;i<dtgvTKB.Rows.Count;i++)
            {

                id = dtgvTKB.Rows[i].Cells[0].Value.ToString();
                day = dtgvTKB.Rows[i].Cells[2].Value.ToString();
                time = dtgvTKB.Rows[i].Cells[3].Value.ToString();
                job = dtgvTKB.Rows[i].Cells[4].Value.ToString();
                
               
                
                var response = await RestClient.getidTKB(userid, id);

                if (response == "[]")
                {
                    Them(day, time, job, id);
                }
                else
                {
                    Sua(id, day, time, job);
                }
                
            }
            MessageBox.Show("Save success");
        }

       
        public void Xoa(string id)
        {
            ModelLich lich = new ModelLich();
            lich.id = id;            
            string putData = JsonConvert.SerializeObject(lich);
            string strUrl = String.Format("https://localhost:44375/api/CongViec/"+id);
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(putData);
                streamWriter.Flush();
                streamWriter.Close();
                var reponse = request.GetResponse();
                using (var streamReader = new StreamReader(reponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
        }
       

        private void TKB_Load(object sender, EventArgs e)
        {
           
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            fInfo f = new fInfo(sess);
            
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void dtgvTKB_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //string id = dtgvTKB.Rows[e.RowIndex].Cells[0].Value.ToString();
            //MessageBox.Show(id);
        }

        private void dtgvTKB_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //string id = dtgvTKB.Rows[e.RowIndex].Cells[0].Value.ToString();
            //string user_id= dtgvTKB.Rows[e.RowIndex].Cells[1].Value.ToString();
            //string day= dtgvTKB.Rows[e.RowIndex].Cells[2].Value.ToString();
            //string time= dtgvTKB.Rows[e.RowIndex].Cells[3].Value.ToString();
            //string job= dtgvTKB.Rows[e.RowIndex].Cells[4].Value.ToString();


        }

        private void dtgvTKB_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dtgvTKB_KeyDown(object sender, KeyEventArgs e)
        {
           
           

            if (e.KeyData==Keys.Enter)
            {
                
                ModelLich lich = new ModelLich();
                string id = dtgvTKB.Rows[dtgvTKB.CurrentRow.Index].Cells[0].Value.ToString();
                int idNhap = Int32.Parse(id) + 1;
                lich.id = idNhap.ToString();
                lich.user_id = "";
                lich.thoigian = "";
                lich.viec = "";
                lich.day = "";
                Them(lich.day, lich.thoigian, lich.viec, lich.id);
                loadData();






            }
            if(e.KeyData==Keys.Delete)
            {
                string id = dtgvTKB.Rows[dtgvTKB.CurrentRow.Index].Cells[0].Value.ToString();
                Xoa(id);
                loadData();
            }    
           
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Random r = new Random();
          
            int i = r.Next(100, 10000);
            ModelLich lich = new ModelLich();
            lich.id = i.ToString();
            lich.user_id = "";
            lich.thoigian = "";
            lich.viec = "";
            lich.day = "";
            Them(lich.day, lich.thoigian, lich.viec, lich.id);
            loadData(); 

        }
    }
}