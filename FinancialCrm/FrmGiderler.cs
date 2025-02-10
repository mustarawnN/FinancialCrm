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
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtGetById_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtGetById.Text);
            var values = db.Spendings.Where(x => x.CategoryId == id).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int removeId = int.Parse(txtGetById.Text);
            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-CHG0OT9\\SQLEXPRESS;initial Catalog=FinancialCrmDb;integrated security=true");
            connection.Open();
            SqlCommand command = new SqlCommand("Delete From Spendings Where SpendingId=@removeId", connection);
            command.Parameters.AddWithValue("@removeId", removeId);
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Silme İşlemi Yapıldı.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var eklencekBaslik = txtBaslik.Text;
            var eklencekTutar=txtHarcamaTutari.Text;
            var eklencekIslemTarihi= txtTarih.Text;
            var eklencekId = txtGetById.Text;
            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-CHG0OT9\\SQLEXPRESS;initial Catalog=FinancialCrmDb;integrated security=true");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Spendings (SpendingTitle,SpendingAmount,SpendingDate,CategoryId) values (@eklencekBaslik,@eklencekTutar,@eklencekIslemTarihi,@eklencekId)", connection);
            command.Parameters.AddWithValue("@eklencekBaslik", eklencekBaslik);
            command.Parameters.AddWithValue("@eklencekTutar",eklencekTutar);
            command.Parameters.AddWithValue("@eklencekIslemTarihi", eklencekIslemTarihi);
            command.Parameters.AddWithValue("@eklencekId", eklencekId);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ekleme Başarılı.");




        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri frm = new FrmBankaHareketleri();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmAyarlar frm = new FrmAyarlar();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
