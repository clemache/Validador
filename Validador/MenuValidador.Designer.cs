namespace Validador
{
    partial class MenuValidador
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
            cmbArchivoConfig = new ComboBox();
            btnAceptar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(186, 27);
            label1.Name = "label1";
            label1.Size = new Size(187, 25);
            label1.TabIndex = 0;
            label1.Text = "Configuración Inicial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 73);
            label2.Name = "label2";
            label2.Size = new Size(253, 20);
            label2.TabIndex = 1;
            label2.Text = "Selecionar archivo de configuración :";
            // 
            // cmbArchivoConfig
            // 
            cmbArchivoConfig.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbArchivoConfig.FormattingEnabled = true;
            cmbArchivoConfig.Items.AddRange(new object[] { "Archivo Config ", "Archivo Config FES" });
            cmbArchivoConfig.Location = new Point(75, 121);
            cmbArchivoConfig.Name = "cmbArchivoConfig";
            cmbArchivoConfig.Size = new Size(358, 29);
            cmbArchivoConfig.TabIndex = 2;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(75, 182);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(153, 34);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(280, 182);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(153, 34);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuValidador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 267);
            Controls.Add(btnSalir);
            Controls.Add(btnAceptar);
            Controls.Add(cmbArchivoConfig);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "MenuValidador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuValidador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbArchivoConfig;
        private Button btnAceptar;
        private Button btnSalir;
    }
}