using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace GetAPI
{
    public partial class test : Form
    {
       
        public test()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            dataGridView1.DataSource = RestClient.getSchedule();
          
        }
    }
}
