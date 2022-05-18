using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace işyeri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=gorselprogram;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from musterikabul", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into musterikabul(Musterino,İsim,Soyisim,Telno,Dogumtarih,Ucret)" +
                " values(@m1,@m2,@m3,@m4,@m5,@m6)  ",baglanti);
            ekle.Parameters.AddWithValue("@m1", textBox1.Text);
            ekle.Parameters.AddWithValue("@m2", textBox2.Text);
            ekle.Parameters.AddWithValue("@m3", textBox3.Text);
            ekle.Parameters.AddWithValue("@m4", textBox4.Text);
            ekle.Parameters.AddWithValue("@m5", textBox5.Text);
            ekle.Parameters.AddWithValue("@m6", textBox6.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete from musterikabul where İsim=@isim", baglanti);
            sil.Parameters.AddWithValue("@isim", textBox2.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            
        }
        

    }
}
