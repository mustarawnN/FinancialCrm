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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();


        private void btnKayit_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Username= txtKullaniciGirisi.Text;
            users.Password= txtSifre.Text;
            db.Users.Add(users);
            db.SaveChanges();
            MessageBox.Show("Üye başarılı bir şekilde eklendi .");
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciGirisi.Text;
            string sifre = txtSifre.Text;

            var kullanici = db.Users.FirstOrDefault(u => u.Username == kullaniciAdi && u.Password == sifre);

            if (kullanici != null)
            {
               
                MessageBox.Show("Giriş başarılı!");
                
                FrmBanks frm = new FrmBanks();
                frm.Show();
                this.Hide();
            }
            else
            {
               
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }
    }
}
