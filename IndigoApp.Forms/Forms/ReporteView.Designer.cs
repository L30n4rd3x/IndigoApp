namespace IndigoApp.Forms.Forms
{
    partial class ReportsView
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
            gridHistorico = new DataGridView();
            DateFechaInicial = new DateTimePicker();
            DateFechaFinal = new DateTimePicker();
            label1 = new Label();
            btnConsultar = new Button();
            label2 = new Label();
            label3 = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)gridHistorico).BeginInit();
            SuspendLayout();
            // 
            // gridHistorico
            // 
            gridHistorico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHistorico.Location = new Point(41, 128);
            gridHistorico.Name = "gridHistorico";
            gridHistorico.Size = new Size(710, 256);
            gridHistorico.TabIndex = 0;
            // 
            // DateFechaInicial
            // 
            DateFechaInicial.Location = new Point(162, 86);
            DateFechaInicial.Name = "DateFechaInicial";
            DateFechaInicial.Size = new Size(200, 23);
            DateFechaInicial.TabIndex = 1;
            // 
            // DateFechaFinal
            // 
            DateFechaFinal.Location = new Point(516, 88);
            DateFechaFinal.Name = "DateFechaFinal";
            DateFechaFinal.Size = new Size(200, 23);
            DateFechaFinal.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 32);
            label1.Name = "label1";
            label1.Size = new Size(198, 30);
            label1.TabIndex = 3;
            label1.Text = "Reporte de ventas";
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(345, 400);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(87, 23);
            btnConsultar.TabIndex = 4;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(37, 86);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 5;
            label2.Text = "Fecha inicial";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(399, 88);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 6;
            label3.Text = "Fecha final";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(701, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(87, 23);
            btnBack.TabIndex = 7;
            btnBack.Text = "Atrás";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ReportsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnConsultar);
            Controls.Add(label1);
            Controls.Add(DateFechaFinal);
            Controls.Add(DateFechaInicial);
            Controls.Add(gridHistorico);
            MaximizeBox = false;
            Name = "ReportsView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte";
            ((System.ComponentModel.ISupportInitialize)gridHistorico).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridHistorico;
        private DateTimePicker DateFechaInicial;
        private DateTimePicker DateFechaFinal;
        private Label label1;
        private Button btnConsultar;
        private Label label2;
        private Label label3;
        private Button btnBack;
    }
}