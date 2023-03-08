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

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSI;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.tblDers' table. You can move, or remove it, as needed.
            this.tblDersTableAdapter.Fill(this.dbNotKayitDataSet.tblDers);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblDers (OgrNumara,OgrAd,OgrSoyad) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1", MskNumara.Text);
            komut.Parameters.AddWithValue("@p2", TxtAd.Text);
            komut.Parameters.AddWithValue("@p3", TxtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi.");
            this.tblDersTableAdapter.Fill(this.dbNotKayitDataSet.tblDers);

        }
    }
}
