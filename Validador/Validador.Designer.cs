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
            groupBox1 = new GroupBox();
            listBoxLogsValidaciones = new ListBox();
            btnDescargarErroresTxt = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(403, 9);
            label1.Name = "label1";
            label1.Size = new Size(128, 30);
            label1.TabIndex = 0;
            label1.Text = "VALIDADOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 47);
            label2.Name = "label2";
            label2.Size = new Size(184, 25);
            label2.TabIndex = 1;
            label2.Text = "Selecione el archivo:";
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCargarArchivo.Location = new Point(235, 45);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(223, 30);
            btnCargarArchivo.TabIndex = 3;
            btnCargarArchivo.Text = "Cargar";
            btnCargarArchivo.UseVisualStyleBackColor = true;
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            // 
            // configValidaciones
            // 
            configValidaciones.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            configValidaciones.Location = new Point(698, 45);
            configValidaciones.Name = "configValidaciones";
            configValidaciones.Size = new Size(211, 30);
            configValidaciones.TabIndex = 4;
            configValidaciones.Text = "Configuración - Validaciones";
            configValidaciones.UseVisualStyleBackColor = true;
            configValidaciones.Click += configValidaciones_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxLogsValidaciones);
            groupBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(31, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(878, 530);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Logs";
            // 
            // listBoxLogsValidaciones
            // 
            listBoxLogsValidaciones.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxLogsValidaciones.FormattingEnabled = true;
            listBoxLogsValidaciones.ItemHeight = 17;
            listBoxLogsValidaciones.Location = new Point(17, 31);
            listBoxLogsValidaciones.Name = "listBoxLogsValidaciones";
            listBoxLogsValidaciones.Size = new Size(842, 480);
            listBoxLogsValidaciones.TabIndex = 0;
            // 
            // btnDescargarErroresTxt
            // 
            btnDescargarErroresTxt.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDescargarErroresTxt.Location = new Point(48, 617);
            btnDescargarErroresTxt.Name = "btnDescargarErroresTxt";
            btnDescargarErroresTxt.Size = new Size(179, 30);
            btnDescargarErroresTxt.TabIndex = 6;
            btnDescargarErroresTxt.Text = "Descargar Logs (.txt)";
            btnDescargarErroresTxt.UseVisualStyleBackColor = true;
            btnDescargarErroresTxt.Click += button1_Click;
            // 
            // Validador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 659);
            Controls.Add(btnDescargarErroresTxt);
            Controls.Add(groupBox1);
            Controls.Add(configValidaciones);
            Controls.Add(btnCargarArchivo);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Validador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Validador";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnCargarArchivo;
        private Button configValidaciones;
        private GroupBox groupBox1;
        private ListBox listBoxLogsValidaciones;
        private Button btnDescargarErroresTxt;
    }
}
