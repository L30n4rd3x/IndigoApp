using IndigoApp.Domain.Entities;
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
using System.Xml.Linq;

namespace IndigoApp.Forms.Forms
{
    public partial class ProductsView : Form
    {
        private readonly ProductService _prodService;
        private readonly AuthService _authService;
        private Product? _selectedProduct;
        private string? _selectedImagePath;

        public ProductsView(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            _prodService = new ProductService(_authService.GetApiClient());
            this.Load += ProductsView_Load;
        }

        private async void ProductsView_Load(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var products = await _prodService.GetAllProductsAsync();
            if (products != null)
            {
                gridProductos.DataSource = products;
                ConfigureGrid();
            }
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            var prod = new Product
            {
                Name = txtNombre.Text,
                Price = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Image = _selectedImagePath
            };

            if (await _prodService.AddProductAsync(prod))
            {
                MessageBox.Show("Producto creado exitosamente");
                await LoadProducts();
                ClearForm();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null) return;

            _selectedProduct.Name = txtNombre.Text;
            _selectedProduct.Price = decimal.Parse(txtPrecio.Text);
            _selectedProduct.Stock = int.Parse(txtStock.Text);
            if (!string.IsNullOrEmpty(_selectedImagePath))
            {
                _selectedProduct.Image = _selectedImagePath;
            }

            if (await _prodService.UpdateProductAsync(_selectedProduct))
            {
                MessageBox.Show("Producto actualizado exitosamente");
                await LoadProducts();
                ClearForm();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null) return;

            if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _prodService.DeleteProductAsync(_selectedProduct.Id))
                {
                    MessageBox.Show("Producto eliminado exitosamente");
                    await LoadProducts();
                    ClearForm();
                }
            }
        }

        private void gridProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridProductos.CurrentRow != null)
            {
                _selectedProduct = (Product)gridProductos.CurrentRow.DataBoundItem;
                txtNombre.Text = _selectedProduct.Name;
                txtPrecio.Text = _selectedProduct.Price.ToString();
                txtStock.Text = _selectedProduct.Stock.ToString();

                if (!string.IsNullOrEmpty(_selectedProduct.Image))
                {
                    lblImagen.Text = _selectedProduct.Image;
                }
            }
        }

        private async void btnAddImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    lblImagen.Text = ofd.FileName;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtNombre.Clear();
            txtPrecio.Value = 0;
            txtStock.Value = 0;
            lblImagen.Text = "Sin imagen";
            _selectedImagePath = null;
            _selectedProduct = null;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            var MenuView = new MenuView(_authService);
            MenuView.Show();
            this.Hide();
        }

        private void ConfigureGrid()
        {
            if (gridProductos.Columns.Count > 0)
            {
                // Ocultar columnas innecesarias
                if (gridProductos.Columns.Contains("Id"))
                    gridProductos.Columns["Id"].Visible = false;
                if (gridProductos.Columns.Contains("SaleDetails"))
                    gridProductos.Columns["SaleDetails"].Visible = false;
                    gridProductos.Columns["SaleDetails"].ReadOnly = false;
                if (gridProductos.Columns.Contains("Name"))
                    gridProductos.Columns["Name"].HeaderText = "Nombre";
                    gridProductos.Columns["Name"].Visible = true;
                if (gridProductos.Columns.Contains("Price"))
                    gridProductos.Columns["Price"].HeaderText = "Precio";
                    gridProductos.Columns["Price"].Visible = true;
                if (gridProductos.Columns.Contains("Stock"))
                    gridProductos.Columns["Stock"].HeaderText = "Disponible";
                    gridProductos.Columns["Stock"].Visible = true;
            }
        }
    }
}
