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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Disconnected_Environment
{
    public partial class Form2 : Form       
    {
        private string stringConnection = "data source=DESKTOP-QB0MM9G;" + "database=disconnectedenvironment;User ID=sa;Password=123";
        private SqlConnection koneksi;

            private void refreshform()
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            public Form2()
            {
                InitializeComponent();
                koneksi = new SqlConnection(stringConnection);
                refreshform();
            }

            private void button3_Click(object sender, EventArgs e)
            {
                string nmProdi = textBox1.Text;
                string idProdi = textBox2.Text;


                if (nmProdi == "")
                {
                    MessageBox.Show("Masukkan Nama Prodi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    koneksi.Open();
                    string str = "insert into dbo.prodi (id_prodi, nama_prodi)" + "values(@id_prodi, @nama_prodi)";
                    SqlCommand cmd = new SqlCommand(str, koneksi);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("nama_prodi", nmProdi));
                    cmd.Parameters.Add(new SqlParameter("id_prodi", idProdi));
                    cmd.ExecuteNonQuery();

                    koneksi.Close();
                    MessageBox.Show("Data berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView();   
                    refreshform();
                }
            }

        private void dataGridView()
            {
                koneksi.Open();
                string str = "select id_prodi, nama_prodi from dbo.prodi";
                SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                koneksi.Close();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                dataGridView();
                button1.Enabled = false;
            }

            private void button2_Click(object sender, EventArgs e)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }

            private void button4_Click(object sender, EventArgs e)
            {
                refreshform();
            }

            private void Form2_FormClosed(object sender, EventArgs e)
            {
                Form1 hu = new Form1();
                hu.Show();
                this.Hide();
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
            {

            }
        
    }
}
