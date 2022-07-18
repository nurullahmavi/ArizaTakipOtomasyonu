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
using ArizaTakip.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace ArizaTakipOtomasyonu
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        SqlConnection con = csConnection.SqlCon();

        // <SHA256> Password Converter Method();
        private class Sha256Converter
        {
            public static string ComputeSha256Hash(string rawData)
            {
                // Create a SHA256   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }

        /// </SHA256>

        public static string _tc;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "T.C.")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.isPassword = false;
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Şifre";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "T.C.";
                txtUser.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Şifre")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
            txtPassword.isPassword = true;
        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand LoginCommand = new SqlCommand("select * from T_Yonetim where Tc=@UserName and Sifre=@Password ", con);
            string Converted_Password = Sha256Converter.ComputeSha256Hash(txtPassword.Text);
            LoginCommand.Parameters.AddWithValue("@UserName", txtUser.Text);
            LoginCommand.Parameters.AddWithValue("@Password", Converted_Password);

            SqlDataAdapter adap = new SqlDataAdapter(LoginCommand);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            _tc = txtUser.Text;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["YetkiID"].ToString() == "1")
                {
                    frmSuperUserMain superAdmin = new frmSuperUserMain();

                    this.Hide();
                    superAdmin.Show();

                }
                else if (dt.Rows[0]["YetkiID"].ToString() == "2")
                {
                    frmMudur mudur = new frmMudur();
                    mudur.Show();
                    this.Hide();

                }
                else if (dt.Rows[0]["YetkiID"].ToString() == "3")
                {
                    frmUzman uzman = new frmUzman();

                    this.Hide();
                    uzman.Show();
                }

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı!");
                txtUser.Text = "T.C.";
                txtPassword.Text = "Şifre";
            }
        }

        private void cBoxPassword_OnChange(object sender, EventArgs e)
        {
            if (cBoxPassword.Checked == true)
            {
                txtPassword.isPassword = false;
            }
            else
            {
                txtPassword.isPassword = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz", "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
