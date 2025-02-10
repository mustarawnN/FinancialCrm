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
    public partial class FrmBankaHareketleri : Form
    {
        public FrmBankaHareketleri()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void lblBankProcess1_Click(object sender, EventArgs e)
        {

        }

        private void FrmBankaHareketleri_Load(object sender, EventArgs e)
        {

            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcesss1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcesss2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcesss3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcesss4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcesss5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;

            var bankProcess6 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(6).Skip(5).FirstOrDefault();
            lblBankProcesss6.Text = bankProcess6.Description + " " + bankProcess6.Amount + " " + bankProcess6.ProcessDate;

            var bankProcess7 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(7).Skip(6).FirstOrDefault();
            lblBankProcesss7.Text = bankProcess7.Description + " " + bankProcess7.Amount + " " + bankProcess7.ProcessDate;

            var bankProcess8 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(8).Skip(7).FirstOrDefault();
            lblBankProcesss8.Text = bankProcess8.Description + " " + bankProcess8.Amount + " " + bankProcess8.ProcessDate;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmAyarlar frm = new FrmAyarlar();
            frm.Show();
            this.Hide();
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

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmGiderler frm = new FrmGiderler();
            frm.Show();
            this.Hide();
        }
    }

}


