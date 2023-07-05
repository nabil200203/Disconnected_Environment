using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Environment
{
    public partial class Form4 : Form
    {
        private string stringConnection = "data source=DESKTOP-QB0MM9G;" + "database=disconnectedenvironment;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        } 

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
