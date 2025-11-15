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

        public ProductsView()
        {
            InitializeComponent();
            _authService = new AuthService();
            _prodService = new ProductService(_authService.GetApiClient());
            LoadProducts();
        }

        private async void LoadProducts()
        {
            var products = await _prodService.GetAllProductsAsync();
            if (products != null)
            {
                gridProductos.DataSource = products;
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
                LoadProducts();
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
                LoadProducts();
                ClearForm();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

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

        private void btnAddImagen_Click(object sender, EventArgs e)
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
    }
}
