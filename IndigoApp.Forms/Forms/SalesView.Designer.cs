namespace IndigoApp.Forms.Forms
{
    partial class SalesView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView gridSales;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            gridSales = new DataGridView();
            lblTotal = new Label();
            lblTitle = new Label();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            btnAtras = new Button();
            ((System.ComponentModel.ISupportInitialize)gridSales).BeginInit();
            SuspendLayout();
            // 
            // gridSales
            // 
            gridSales.AllowUserToAddRows = false;
            gridSales.AllowUserToDeleteRows = false;
            gridSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSales.Location = new Point(42, 72);
            gridSales.Name = "gridSales";
            gridSales.Size = new Size(747, 296);
            gridSales.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(455, 379);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(90, 21);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: $0.00";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(42, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(153, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Servicio de ventas";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(599, 379);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(99, 23);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(699, 379);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardarVenta_Click;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(742, 12);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(92, 23);
            btnAtras.TabIndex = 7;
            btnAtras.Text = "Atrás";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // SalesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 415);
            Controls.Add(btnAtras);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            Controls.Add(lblTotal);
            Controls.Add(gridSales);
            Controls.Add(lblTitle);
            MaximizeBox = false;
            Name = "SalesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)gridSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnLimpiar;
        private Button btnGuardar;
        private Button btnAtras;
    }
}