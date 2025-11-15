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
    public partial class MenuView : Form
    {
        private readonly AuthService _authService;

        public MenuView(AuthService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            var SalesView = new SalesView(_authService);
            SalesView.Show();
            this.Hide();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            var ReporteForm = new ReportsView(_authService);
            ReporteForm.Show();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            var ProductsForm = new ProductsView(_authService);
            ProductsForm.Show();
            this.Hide();
        }
    }
}
