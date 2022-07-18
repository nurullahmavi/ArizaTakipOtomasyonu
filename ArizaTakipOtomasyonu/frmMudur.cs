using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArizaTakip.Servis;

namespace ArizaTakipOtomasyonu
{
    public partial class frmMudur : Form
    {
        ArizaManager ariza = new ArizaManager();
        GenelIslemler genel = new GenelIslemler();
        YonetimManager yonetim = new YonetimManager();

        static int _isID = -1;
        public frmMudur()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
            bunifuFormDock1.SubscribeControlToDragEvents(panel2);
        }

        private void btnIsOlustur_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("AnaSayfa");
            txtAriza.Focus();
        }

        private void btnIsler_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("Isler");
            gridDoldur();
        }

        private void btnHesabım_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("Hesabim");
            txtHesapAdSoyad.Text = genel.calAdSoyad;
            txtHesapEmail.Text = genel.calEmail;
            txtHesapTc.Text = genel.calTc;
            txtHesapTelefon.Text = genel.calTelefon;
        }
        void gridDoldur()
        {
            dtgIsler.DataSource = ariza.ArizaList();
        }
        void comboFill()
        {
            genel.ComboDoldur(cmbUzman, "AdiSoyadi", "Tc", "Sp_UzmanListele");
            genel.ComboDoldur(cmbBildiren, "perAdSoyad", "perID", "Sp_PersonelListele");
        }
        string[] ad = new string[100];
        private void frmMudur_Load(object sender, EventArgs e)
        {
            comboFill();
            genel.HesapBiligleri(frmLogin._tc);
            lblAdSoyad.Text = genel.calAdSoyad;
            DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();
            dgvBtn.HeaderText = "";
            dgvBtn.Text = "İptal Et";
            dgvBtn.UseColumnTextForButtonValue = true;
            dgvBtn.DefaultCellStyle.BackColor = Color.Maroon;
            dgvBtn.DefaultCellStyle.SelectionBackColor = Color.Red;
            dgvBtn.DefaultCellStyle.ForeColor = Color.White;
            dgvBtn.Width = 70;
            dtgIsler.Columns.Add(dgvBtn);
            txtAriza.Focus();
            TeknisyenListele();
        }

        void TeknisyenListele()
        {
            ad = new string[100];
            lboxTeknisyenler.Items.Clear();
            dtgTeknisyenler.DataSource = yonetim.TeknisyenList();

            for (int i = 0; i < dtgTeknisyenler.Rows.Count; i++)
            {
                for (int j = 0; j < dtgTeknisyenler.Rows[i].Cells.Count; j++)
                {
                    ad[i] += dtgTeknisyenler.Rows[i].Cells[j].Value;
                }
            }

            for (int i = 0; i <= dtgTeknisyenler.Rows.Count - 1; i++)
            {
                lboxTeknisyenler.Items.Add(ad[i]);
            }
        }

        private void dtgIsler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _isID = Convert.ToInt32(dtgIsler.CurrentRow.Cells[1].Value);
        }

        private void dtgIsler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (_isID == -1)
                {
                    MessageBox.Show("Herhangi Bir Kayıt Seçilmedi!");
                }

                else
                {

                    ariza.ID = _isID;

                    DialogResult secenek = MessageBox.Show("İptal Etmek İstediğinize Eminmisiniz", "İptal Et", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (secenek == DialogResult.Yes)
                    {
                        ariza.ArizaIptalEt();
                        gridDoldur();
                        MessageBox.Show("İptal Edildi");
                    }
                    _isID = -1;
                }

            }
        }

        private void txtTeknisyenAra_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lboxTeknisyenler.Items.Count; i++)
            {
                if (lboxTeknisyenler.Items[i].ToString().ToLower().Contains(txtTeknisyenAra.Text.ToLower()))
                {
                    lboxTeknisyenler.SetSelected(i, true);
                }
            }
        }

        private void btnIsGonder_Click(object sender, EventArgs e)
        {
            if (txtAriza.Text != "" && txtArizaYeri.Text!="")
            {
                ariza.ArizaDetay = txtAriza.Text;
                ariza.bilidirimZamani = Convert.ToDateTime(dtpBildirimZamani.Text);
                ariza.perID = Convert.ToInt32(cmbBildiren.SelectedValue);
                ariza.arizaYeri = txtArizaYeri.Text;
                ariza.teknisyenAta = lblTeknisyenler.Text;
                ariza.uzmanAta = Convert.ToString(cmbUzman.SelectedValue);
                
                ariza.ArizaEkle();
                txtAriza.Clear();
                lblTeknisyenler.Text = "";
                txtAriza.Focus();
                TeknisyenListele();
            }
            else
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurun");
            }
        }
        int sec;
        private void lboxTeknisyenler_SelectedIndexChanged(object sender, EventArgs e)
        {
            sec = lboxTeknisyenler.SelectedIndex;
        }
        private void btnTeknisyenEkle_Click(object sender, EventArgs e)
        {
            lblTeknisyenler.Text += lboxTeknisyenler.SelectedItem.ToString() + "\n";
            lboxTeknisyenler.Items.RemoveAt(sec);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış Yapmak İstediğinizden Emin Misiniz", "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
           
            if (txtHesapAdSoyad.Text != "" && txtHesapEmail.Text != "" && txtHesapTelefon.Text != "" && txtHesapSifre.Text != "")
            {

                if (txtHesapTelefon.Text.Length < 11 || txtHesapTelefon.Text.Length > 11)
                {
                    MessageBox.Show("Telefon Numarası 11 Karekterli Olmalıdır");
                }
                else
                {
                        yonetim.Tc = frmLogin._tc;
                        yonetim.Sifre = txtHesapSifre.Text;
                        yonetim.Telefon = txtHesapTelefon.Text;
                        yonetim.AdiSoyadi = txtHesapAdSoyad.Text;
                        yonetim.Email = txtHesapEmail.Text;

                        yonetim.BilgilerimiGuncelle();
                        MessageBox.Show("Bilgileriniz Güncellendi");
                        this.Refresh();
                }

            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            lblTeknisyenler.Text = "";
            TeknisyenListele();
        }
    }
}
