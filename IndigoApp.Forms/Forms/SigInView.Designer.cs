namespace IndigoApp.Forms.Forms
{
    partial class SigInView
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
            label4 = new Label();
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnSignIn = new Button();
            btnSignUp = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(205, 95);
            label1.Name = "label1";
            label1.Size = new Size(194, 40);
            label1.TabIndex = 0;
            label1.Text = "Iniciar sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(211, 314);
            label2.Name = "label2";
            label2.Size = new Size(180, 15);
            label2.TabIndex = 1;
            label2.Text = "¿No tiene una cuenta? Registrese";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(258, 218);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(270, 169);
            label4.Name = "label4";
            label4.Size = new Size(64, 21);
            label4.TabIndex = 3;
            label4.Text = "Usuario";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(211, 192);
            txtUser.MaxLength = 100;
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(180, 23);
            txtUser.TabIndex = 4;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(211, 243);
            txtPass.MaxLength = 20;
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(180, 23);
            txtPass.TabIndex = 5;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(264, 276);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(78, 23);
            btnSignIn.TabIndex = 6;
            btnSignIn.Text = "Acceder";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(509, 390);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(78, 23);
            btnSignUp.TabIndex = 7;
            btnSignUp.Text = "Registrar";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // SigInView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 434);
            Controls.Add(btnSignUp);
            Controls.Add(btnSignIn);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "SigInView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnSignIn;
        private Button btnSignUp;
    }
}