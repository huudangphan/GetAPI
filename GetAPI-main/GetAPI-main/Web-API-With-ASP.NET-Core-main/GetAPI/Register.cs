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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        public void Them(string username,string password)
        {
            Session s = new Session();
          
            s.username = username;
            s.password = password;
            string postData = JsonConvert.SerializeObject(s);

            string strUrl = String.Format("https://localhost:44375/api/Account");
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
                    MessageBox.Show("Resgiter account success");
                }
            }
        }
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtpass.Text;
            string pass2 = txtpass2.Text;
            string id = txtid.Text;
            Them(user, pass);
            //var checkr = await RestClient.PostLogin2(Int32.Parse(id), user, pass);
            //if (pass!=pass2)
            //{
            //    MessageBox.Show("Confirm password false");
            //}
            //else
            //{
            //    if (checkr != "[]")
            //    {
            //        MessageBox.Show("Username already exist ");
            //    }

                
                    
            //        else
            //        {
            //            Them(id, user, pass);
            //             MessageBox.Show("Register success");
            //        }

                
            //}          
           
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (!int.TryParse(txtid.Text, out i))
            {
                MessageBox.Show("Plaese enter number");
            }
        }
    }
}
