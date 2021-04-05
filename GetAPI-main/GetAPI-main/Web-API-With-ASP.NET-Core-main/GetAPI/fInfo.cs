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

namespace GetAPI
{
    public partial class fInfo : Form
    {
        private Session sess;

        Session Sess
        {
            get { return sess; }
            set { sess = value; }
        }
       
        public fInfo(Session sess)
        {
            InitializeComponent();
            this.sess = sess;            

        }
        
        public void SuaAccount(string pass)
        {
            
           
            string strUrl = String.Format("https://localhost:44375/api/Account?username=" + sess.username + "&password=" + pass);
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "PUT";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {               
                var reponse = request.GetResponse();
                using (var streamReader = new StreamReader(reponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string curpass = txtCurpass.Text;
            string pass = txtpass.Text;
            string pass2 = txtpass2.Text;
            var check = await RestClient.PostLogin(sess.username, curpass);
            if (check != "[]")
            {
                if (pass != pass2)
                    MessageBox.Show("Password must = confirm password");
                else
                {
                    SuaAccount(pass);
                    MessageBox.Show("Edit sucess");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Plz confirm your current password");
            }


        }
    }
}
