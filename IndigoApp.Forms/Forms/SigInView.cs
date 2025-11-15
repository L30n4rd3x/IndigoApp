using IndigoApp.Forms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndigoApp.Forms.Forms
{
    public partial class SigInView : Form
    {
        private readonly AuthService _authService;
        public SigInView()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var frm = new RegisterView();
            frm.ShowDialog();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var response = await _authService.LoginAsync(txtUser.Text, txtPass.Text);

            if (response != null || !string.IsNullOrEmpty(response.Token))
            {
                MessageBox.Show($"Bienvenido {txtUser.Text}!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var Menuform = new MenuView(_authService);
                Menuform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
