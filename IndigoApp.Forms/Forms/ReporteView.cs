using IndigoApp.Domain.Entities;
using IndigoApp.Forms.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IndigoApp.Forms.Forms
{
    public partial class ReportsView : Form
    {
        private readonly SaleService _saleService;
        private readonly AuthService _authService;

        public ReportsView(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            _saleService = new SaleService(_authService.GetApiClient());
            this.Load += ReportsView_Load;
        }

        private void ReportsView_Load(object sender, EventArgs e)
        {
            // Establecer fechas por defecto (último mes)
            DateFechaInicial.Value = DateTime.Now.AddMonths(-1);
            DateFechaFinal.Value = DateTime.Now;

            LoadAllSales();
        }

        private async void LoadAllSales()
        {
            var sales = await _saleService.GetAllSalesAsync();
            if (sales != null)
            {
                var salesList = sales.ToList();
                if (gridHistorico.InvokeRequired)
                {
                    gridHistorico.Invoke(new Action(() =>
                    {
                        gridHistorico.DataSource = null;
                        gridHistorico.DataSource = salesList;
                        ConfigureGrid();
                    }));
                }
                else
                {
                    gridHistorico.DataSource = null;
                    gridHistorico.DataSource = salesList;
                    ConfigureGrid();
                }
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            var startDate = DateFechaInicial.Value.Date;
            var endDate = DateFechaFinal.Value.Date.AddDays(1).AddSeconds(-1); // Incluir todo el día final

            if (startDate > endDate)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final",
                    "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sales = await _saleService.GetSalesByDateRangeAsync(startDate, endDate);
            if (sales != null)
            {
                var salesList = sales.ToList();
                gridHistorico.DataSource = null;
                gridHistorico.DataSource = salesList;
                ConfigureGrid();
            }
        }

        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            LoadAllSales();
        }

        private void ConfigureGrid()
        {
            if (gridHistorico.Columns.Count > 0)
            {
                // Ocultar columnas innecesarias
                if (gridHistorico.Columns.Contains("User"))
                    gridHistorico.Columns["User"].Visible = false;
                if (gridHistorico.Columns.Contains("SaleDetails"))
                    gridHistorico.Columns["SaleDetails"].Visible = false;

                // Configurar formato de columnas
                if (gridHistorico.Columns.Contains("Id"))
                {
                    gridReportes.Columns["Id"].HeaderText = "ID Venta";
                    gridHistorico.Columns["Id"].Width = 80;
                }
                if (gridHistorico.Columns.Contains("UserId"))
                {
                    gridHistorico.Columns["UserId"].HeaderText = "ID Usuario";
                    gridHistorico.Columns["UserId"].Width = 100;
                }
                if (gridHistorico.Columns.Contains("SaleDate"))
                {
                    gridHistorico.Columns["SaleDate"].HeaderText = "Fecha";
                    gridHistorico.Columns["SaleDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    gridHistorico.Columns["SaleDate"].Width = 150;
                }
                if (gridHistorico.Columns.Contains("Total"))
                {
                    gridHistorico.Columns["Total"].HeaderText = "Total";
                    gridHistorico.Columns["Total"].DefaultCellStyle.Format = "C2";
                    gridHistorico.Columns["Total"].Width = 120;
                }
            }
        }

        private void gridReportes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var sale = (Sale)gridHistorico.Rows[e.RowIndex].DataBoundItem;
            var details = string.Join("\n", sale.SaleDetails.Select(sd =>
                $"- {sd.Product.Name}: {sd.Quantity} x ${sd.UnitPrice:N2} = ${sd.Subtotal:N2}"));

            MessageBox.Show(
                $"Venta ID: {sale.Id}\n" +
                $"Fecha: {sale.SaleDate:dd/MM/yyyy HH:mm}\n" +
                $"Usuario ID: {sale.UserId}\n\n" +
                $"Detalles:\n{details}\n\n" +
                $"Total: ${sale.Total:N2}",
                "Detalle de Venta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}