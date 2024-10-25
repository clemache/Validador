namespace Validador
{
    partial class Validador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnCargarArchivo = new Button();
            configValidaciones = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(314, 9);
            label1.Name = "label1";
            label1.Size = new Size(146, 32);
            label1.TabIndex = 0;
            label1.Text = "VALIDADOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 51);
            label2.Name = "label2";
            label2.Size = new Size(184, 25);
            label2.TabIndex = 1;
            label2.Text = "Selecione el archivo:";
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCargarArchivo.Location = new Point(265, 49);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(223, 30);
            btnCargarArchivo.TabIndex = 3;
            btnCargarArchivo.Text = "Cargar";
            btnCargarArchivo.UseVisualStyleBackColor = true;
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            // 
            // configValidaciones
            // 
            configValidaciones.Location = new Point(516, 49);
            configValidaciones.Name = "configValidaciones";
            configValidaciones.Size = new Size(211, 30);
            configValidaciones.TabIndex = 4;
            configValidaciones.Text = "Configuración - Validaciones";
            configValidaciones.UseVisualStyleBackColor = true;
            // 
            // Validador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 421);
            Controls.Add(configValidaciones);
            Controls.Add(btnCargarArchivo);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Validador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Validador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnCargarArchivo;
        private Button configValidaciones;
    }
}
