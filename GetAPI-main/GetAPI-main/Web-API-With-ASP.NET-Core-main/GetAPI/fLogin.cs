
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
        
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            login();
            
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
