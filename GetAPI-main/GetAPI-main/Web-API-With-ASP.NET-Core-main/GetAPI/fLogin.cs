
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
        string baseUrl = "https://localhost:44375/api/Account";
        public fLogin()
        {
            InitializeComponent();
        }
        public async void login()
        {
            int id = Int32.Parse( txtid.Text);
            string username = txtusername.Text;
            string password = txtpassword.Text;
            Session s = new Session();
            s.id = txtid.Text;
            s.username = username;
            s.password = password;

            var response2 = await RestClient.PostLogin2( username, password,id);
            
            if (response2 != "[]")
            {
                TKB f = new TKB(s);
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
