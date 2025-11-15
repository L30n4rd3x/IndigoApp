using IndigoApp.Domain.DTOs;
using IndigoApp.Domain.Entities;
using IndigoApp.Forms.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IndigoApp.Forms.Forms
{
    public partial class SalesView : Form
    {
        private readonly ProductService _productService;
        private readonly SaleService _saleService;
        private readonly AuthService _authService;
        private DataTable _salesTable;

        public SalesView(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            _productService = new ProductService(_authService.GetApiClient());
            _saleService = new SaleService(_authService.GetApiClient());
            InitializeSalesTable();
            this.Load += SalesView_Load;
        }

        private void SalesView_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void InitializeSalesTable()
        {
            _salesTable = new DataTable();
            _salesTable.Columns.Add("ProductId", typeof(int));
            _salesTable.Columns.Add("Nombre", typeof(string));
            _salesTable.Columns.Add("Precio", typeof(decimal));
            _salesTable.Columns.Add("Stock", typeof(int));
            _salesTable.Columns.Add("Cantidad", typeof(int));
            _salesTable.Columns.Add("Subtotal", typeof(decimal));

            gridSales.DataSource = _salesTable;
            gridSales.Columns["ProductId"].Visible = false;
            gridSales.Columns["Nombre"].ReadOnly = true;
            gridSales.Columns["Precio"].ReadOnly = true;
            gridSales.Columns["Stock"].ReadOnly = true;
            gridSales.Columns["Subtotal"].ReadOnly = true;

            gridSales.CellValueChanged += GridSales_CellValueChanged;
        }

        private async void LoadProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            if (products != null)
            {
                _salesTable.Clear();
                foreach (var product in products)
                {
                    var row = _salesTable.NewRow();
                    row["ProductId"] = product.Id;
                    row["Nombre"] = product.Name;
                    row["Precio"] = product.Price;
                    row["Stock"] = product.Stock;
                    row["Cantidad"] = 0;
                    row["Subtotal"] = 0;
                    _salesTable.Rows.Add(row);
                }
                UpdateTotal();
            }
        }

        private void GridSales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (gridSales.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                var row = gridSales.Rows[e.RowIndex];
                var cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value ?? 0);
                var stock = Convert.ToInt32(row.Cells["Stock"].Value);
                var precio = Convert.ToDecimal(row.Cells["Precio"].Value);

                if (cantidad > stock)
                {
                    MessageBox.Show($"La cantidad no puede ser mayor al stock disponible ({stock})",
                        "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["Cantidad"].Value = 0;
                    row.Cells["Subtotal"].Value = 0;
                }
                else if (cantidad < 0)
                {
                    row.Cells["Cantidad"].Value = 0;
                    row.Cells["Subtotal"].Value = 0;
                }
                else
                {
                    row.Cells["Subtotal"].Value = cantidad * precio;
                }

                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in _salesTable.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            lblTotal.Text = $"Total: ${total:N2}";
        }

        private async void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            var details = new List<SaleDetailRequest>();

            foreach (DataRow row in _salesTable.Rows)
            {
                var cantidad = Convert.ToInt32(row["Cantidad"]);
                if (cantidad > 0)
                {
                    details.Add(new SaleDetailRequest
                    {
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Quantity = cantidad,
                        UnitPrice = Convert.ToDecimal(row["Precio"]),
                        Subtotal = Convert.ToDecimal(row["Subtotal"])
                    });
                }
            }

            if (!details.Any())
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta",
                    "Venta vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var request = new CreateSaleRequest
            {
                UserId = AuthService.CurrentUser?.UserId ?? 0,
                SaleDate = DateTime.Now,
                Total = details.Sum(d => d.Subtotal),
                SaleDetails = details
            };

            var sale = await _saleService.CreateSaleAsync(request);
            if (sale != null)
            {
                MessageBox.Show("Venta registrada exitosamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts(); // Recargar productos con stock actualizado
            }
            else
            {
                MessageBox.Show("Error al registrar la venta",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            var MenuView = new MenuView(_authService);
            MenuView.Show();
            this.Hide();
        }
    }
}