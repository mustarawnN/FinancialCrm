using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi", " Ödeme & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);
            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;

        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValue = db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemden Silindi", " Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var value = db.Bills.ToList();
            dataGridView1.DataSource = value;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;
            int id = int.Parse(txtBillId.Text);

            var values = db.Bills.Find(id);

           
            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sistemde Güncellendi", " Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values2 = db.Bills.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmAyarlar frm = new FrmAyarlar();
            frm.Show();
            this.Hide();
        }

        private void txtBillPeriod_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBankaHareketleri frm = new FrmBankaHareketleri();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGiderler frm = new FrmGiderler();
            frm.Show();
            this.Hide();
        }
    }
}
