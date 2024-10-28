namespace Validador
{
    partial class ConfiguracionValidaciones
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
            label5 = new Label();
            txtNombreColumna = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            cmbTipoDato = new ComboBox();
            longitudCampo = new NumericUpDown();
            checkObligatorio = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)longitudCampo).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 29);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre Columna:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 63);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 2;
            label3.Text = "Tipo de dato:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 96);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "Longitud: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 127);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 4;
            label5.Text = "Obligatorio:";
            // 
            // txtNombreColumna
            // 
            txtNombreColumna.Location = new Point(148, 26);
            txtNombreColumna.Name = "txtNombreColumna";
            txtNombreColumna.Size = new Size(235, 23);
            txtNombreColumna.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(74, 175);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(113, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(239, 175);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(113, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbTipoDato
            // 
            cmbTipoDato.FormattingEnabled = true;
            cmbTipoDato.Items.AddRange(new object[] { "string", "int", "double", "date" });
            cmbTipoDato.Location = new Point(148, 60);
            cmbTipoDato.Name = "cmbTipoDato";
            cmbTipoDato.Size = new Size(235, 23);
            cmbTipoDato.TabIndex = 8;
            // 
            // longitudCampo
            // 
            longitudCampo.Location = new Point(148, 94);
            longitudCampo.Name = "longitudCampo";
            longitudCampo.Size = new Size(235, 23);
            longitudCampo.TabIndex = 9;
            // 
            // checkObligatorio
            // 
            checkObligatorio.AutoSize = true;
            checkObligatorio.Location = new Point(148, 128);
            checkObligatorio.Name = "checkObligatorio";
            checkObligatorio.Size = new Size(15, 14);
            checkObligatorio.TabIndex = 10;
            checkObligatorio.UseVisualStyleBackColor = true;
            // 
            // ConfiguracionValidaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 218);
            Controls.Add(checkObligatorio);
            Controls.Add(longitudCampo);
            Controls.Add(cmbTipoDato);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombreColumna);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ConfiguracionValidaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar Validación";
            ((System.ComponentModel.ISupportInitialize)longitudCampo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombreColumna;
        private Button btnGuardar;
        private Button btnCancelar;
        private ComboBox cmbTipoDato;
        private NumericUpDown longitudCampo;
        private CheckBox checkBox1;
        private CheckBox checkObligatorio;
    }
}