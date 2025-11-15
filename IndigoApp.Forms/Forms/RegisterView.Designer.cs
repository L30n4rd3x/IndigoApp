namespace IndigoApp.Forms.Forms
{
    partial class RegisterView
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtRegUsuario = new TextBox();
            txtRegPass = new TextBox();
            btnRegistrar = new Button();
            label4 = new Label();
            txtRegConfPass = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 109);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(87, 157);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(87, 205);
            label3.Name = "label3";
            label3.Size = new Size(143, 21);
            label3.TabIndex = 2;
            label3.Text = "Repetir contraseña:";
            // 
            // txtRegUsuario
            // 
            txtRegUsuario.Location = new Point(236, 109);
            txtRegUsuario.MaxLength = 100;
            txtRegUsuario.Name = "txtRegUsuario";
            txtRegUsuario.Size = new Size(168, 23);
            txtRegUsuario.TabIndex = 3;
            // 
            // txtRegPass
            // 
            txtRegPass.Location = new Point(236, 157);
            txtRegPass.MaxLength = 20;
            txtRegPass.Name = "txtRegPass";
            txtRegPass.Size = new Size(168, 23);
            txtRegPass.TabIndex = 4;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(207, 258);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(90, 23);
            btnRegistrar.TabIndex = 5;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(148, 54);
            label4.Name = "label4";
            label4.Size = new Size(211, 30);
            label4.TabIndex = 6;
            label4.Text = "Registro de usuario";
            // 
            // txtRegConfPass
            // 
            txtRegConfPass.Location = new Point(236, 205);
            txtRegConfPass.MaxLength = 20;
            txtRegConfPass.Name = "txtRegConfPass";
            txtRegConfPass.Size = new Size(168, 23);
            txtRegConfPass.TabIndex = 7;
            // 
            // RegisterView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 393);
            Controls.Add(txtRegConfPass);
            Controls.Add(label4);
            Controls.Add(btnRegistrar);
            Controls.Add(txtRegPass);
            Controls.Add(txtRegUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterView";
            Text = "Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtRegUsuario;
        private TextBox txtRegPass;
        private Button btnRegistrar;
        private Label label4;
        private TextBox txtRegConfPass;
    }
}