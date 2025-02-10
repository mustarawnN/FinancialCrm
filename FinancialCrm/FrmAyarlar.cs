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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnSifreGuncelle_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullanici.Text;  // Kullanıcı adı, txtKullanici metin kutusundan alınır
            string eskiSifre = txtEskiSifre.Text;
            string yeniSifre = txtYeniSifre.Text;
            string yeniSifreTekrar = txtYeniSifreTekrar.Text;

            // Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(eskiSifre) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(yeniSifreTekrar))
            {
                MessageBox.Show("Tüm alanları doldurduğunuzdan emin olun.");
                return;
            }

            // Kullanıcıyı, kullanıcı adı ve eski şifre ile veri tabanında sorgula
            var kullanici = db.Users.FirstOrDefault(u => u.Username == kullaniciAdi && u.Password == eskiSifre);

            if (kullanici != null)
            {
                // Eski şifre doğruysa ve yeni şifreler eşleşiyorsa
                if (yeniSifre == yeniSifreTekrar)
                {
                    // Yeni şifreyi güncelle
                    kullanici.Password = yeniSifre;
                    db.SaveChanges();
                    MessageBox.Show("Şifreniz başarıyla güncellenmiştir.");
                }
                else
                {
                    // Yeni şifreler uyuşmuyor
                    MessageBox.Show("Yeni şifreler uyuşmuyor. Lütfen tekrar deneyin.");
                }
            }
            else
            {
                // Kullanıcı adı veya eski şifre hatalı
                MessageBox.Show("Kullanıcı adı veya eski şifre hatalı.");
            }
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
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

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGiderler frm = new FrmGiderler();
            frm.Show();
            this.Hide();
        }
    }
}
