using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Controllers;

namespace project_PBO.View
{
    public partial class auth_form : Form
    {
        public auth_form()
        {
            InitializeComponent();
        }

        private void auth_form_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginTittleLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var user = AuthController.Login(username, password);
            if (user != null)
            {
                if (user.Role == "admin")
                {
                    MessageBox.Show("Admin berhasil login!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (user.Role == "user")
                {
                    MessageBox.Show("User berhasil login!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Hide(); // Sembunyikan form login kalau mau
                             // atau lanjut ke menu lain nanti di sini
            }
            else
            {
                MessageBox.Show("Login gagal! Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
