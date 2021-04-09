
using Newtonsoft.Json.Linq;
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
    public partial class fLogin : Form
    {        
        public fLogin()
        {
            InitializeComponent();
        }
        public async void login()
        {
            try
            {
                string username = txtusername.Text;
                string password = txtpassword.Text;
                Session s = new Session();
                s.username = username;
                s.password = password;

                var response2 = await RestClient.PostLogin(username, password);

                if (response2 != "[]")
                {
                    //TKB f = new TKB(s);
                    ThoiKhoaBieu f = new ThoiKhoaBieu(s);

                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("username or password invalid");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
           
        }
        public void L()
        {
            try
            {
                string username = txtusername.Text;
                string password = txtpassword.Text;
                Session s = new Session();
                s.username = username;
                s.password = password;
                string strUrl = String.Format("https://localhost:44375/api/AccountSecret/" +username+"/"+password );
                WebRequest request = WebRequest.Create(strUrl);
                //request.Method = "GET";                
                request.Headers.Add("APIKey", "MySecureAPIKey");
                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    
                    StreamReader reader = new StreamReader(dataStream);
                   
                    string responseFromServer = reader.ReadToEnd();
                    if (responseFromServer != "[]")
                    {
                        //TKB f = new TKB(s);
                        ThoiKhoaBieu f = new ThoiKhoaBieu(s);

                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("username or password invalid");
                    }

                }
                response.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            L();
            
        }
        


        private void btndangky_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            this.Hide();
            r.ShowDialog();
            this.Show();
        }
    }
}
