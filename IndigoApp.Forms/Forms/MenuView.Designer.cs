namespace IndigoApp.Forms.Forms
{
    partial class MenuView
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
            btnVentas = new Button();
            btnReporte = new Button();
            label1 = new Label();
            btnProductos = new Button();
            SuspendLayout();
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(81, 210);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(108, 63);
            btnVentas.TabIndex = 0;
            btnVentas.Text = "Ir a ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnReporte
            // 
            btnReporte.Location = new Point(343, 210);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(110, 63);
            btnReporte.TabIndex = 1;
            btnReporte.Text = "Ir a reporte";
            btnReporte.UseVisualStyleBackColor = true;
            btnReporte.Click += btnReporte_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(110, 131);
            label1.Name = "label1";
            label1.Size = new Size(311, 21);
            label1.TabIndex = 2;
            label1.Text = "Seleccione la opción de su preferencia";
            // 
            // btnProductos
            // 
            btnProductos.Location = new Point(211, 210);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(108, 63);
            btnProductos.TabIndex = 3;
            btnProductos.Text = "Ir a productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // MenuView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 413);
            Controls.Add(btnProductos);
            Controls.Add(label1);
            Controls.Add(btnReporte);
            Controls.Add(btnVentas);
            Name = "MenuView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVentas;
        private Button btnReporte;
        private Label label1;
        private Button btnProductos;
    }
}