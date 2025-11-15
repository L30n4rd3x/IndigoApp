namespace IndigoApp.Forms.Forms
{
    partial class ProductsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtStock = new NumericUpDown();
            txtPrecio = new NumericUpDown();
            txtNombre = new TextBox();
            gridProductos = new DataGridView();
            btnCrear = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnAddImagen = new Button();
            lblImagen = new Label();
            btnLimpiar = new Button();
            btnAtras = new Button();
            ((System.ComponentModel.ISupportInitialize)txtStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridProductos).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 190);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Stock:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 61);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 127);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Precio:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(140, 188);
            txtStock.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(220, 23);
            txtStock.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(140, 125);
            txtPrecio.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(220, 23);
            txtPrecio.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 58);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 23);
            txtNombre.TabIndex = 6;
            // 
            // gridProductos
            // 
            gridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProductos.Location = new Point(46, 262);
            gridProductos.Name = "gridProductos";
            gridProductos.Size = new Size(629, 163);
            gridProductos.TabIndex = 8;
            gridProductos.SelectionChanged += gridProductos_SelectionChanged;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(576, 56);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(99, 23);
            btnCrear.TabIndex = 10;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(576, 102);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(99, 23);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(576, 147);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(99, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAddImagen
            // 
            btnAddImagen.Location = new Point(426, 157);
            btnAddImagen.Name = "btnAddImagen";
            btnAddImagen.Size = new Size(99, 23);
            btnAddImagen.TabIndex = 13;
            btnAddImagen.Text = "Añadir imagen";
            btnAddImagen.UseVisualStyleBackColor = true;
            btnAddImagen.Click += btnAddImagen_Click;
            // 
            // lblImagen
            // 
            lblImagen.AutoSize = true;
            lblImagen.Location = new Point(399, 125);
            lblImagen.MinimumSize = new Size(150, 0);
            lblImagen.Name = "lblImagen";
            lblImagen.Size = new Size(150, 15);
            lblImagen.TabIndex = 15;
            lblImagen.Text = "Sin imagen";
            lblImagen.TextAlign = ContentAlignment.MiddleCenter;
            lblImagen.Visible = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(576, 191);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(99, 23);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(628, 12);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(81, 23);
            btnAtras.TabIndex = 17;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // ProductsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 454);
            Controls.Add(btnAtras);
            Controls.Add(btnLimpiar);
            Controls.Add(lblImagen);
            Controls.Add(btnAddImagen);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnCrear);
            Controls.Add(gridProductos);
            Controls.Add(txtNombre);
            Controls.Add(txtPrecio);
            Controls.Add(txtStock);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            MaximizeBox = false;
            Name = "ProductsView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            ((System.ComponentModel.ISupportInitialize)txtStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown txtStock;
        private NumericUpDown txtPrecio;
        private TextBox txtNombre;
        private DataGridView gridProductos;
        private Button btnCrear;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnAddImagen;
        private Label lblImagen;
        private Button btnLimpiar;
        private Button btnAtras;
    }
}