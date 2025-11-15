using IndigoApp.Forms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndigoApp.Forms.Forms
{
    public partial class RegisterView : Form
    {
        private readonly AuthService _authService;
        public RegisterView()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtRegPass.Text.Trim() == txtRegConfPass.Text.Trim())            
            {
                var data = new
                {
                    username = txtRegUsuario.Text.Trim(),
                    password = txtRegPass.Text.Trim()
                };

                try
                {
                    var response = _authService.RegisterAsync(txtRegUsuario.Text, txtRegPass.Text);
                    if (response != null && response.IsCompleted)
                    {
                        MessageBox.Show($"Usuario creado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        var SignInView = new SigInView();
                        SignInView.Show();
                    }               
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar usuario:\n{ex.Message}", "Registro fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show($"Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
