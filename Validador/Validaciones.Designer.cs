namespace Validador
{
    partial class Validaciones
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
            dataGVValidaciones = new DataGridView();
            numColumna = new DataGridViewTextBoxColumn();
            nomColumna = new DataGridViewTextBoxColumn();
            tipoDato = new DataGridViewTextBoxColumn();
            longitud = new DataGridViewTextBoxColumn();
            obligatorio = new DataGridViewCheckBoxColumn();
            accion = new DataGridViewButtonColumn();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGVValidaciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(303, 44);
            label1.Name = "label1";
            label1.Size = new Size(258, 25);
            label1.TabIndex = 0;
            label1.Text = "Validaciones de las columnas";
            // 
            // dataGVValidaciones
            // 
            dataGVValidaciones.AllowUserToOrderColumns = true;
            dataGVValidaciones.BackgroundColor = SystemColors.Window;
            dataGVValidaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVValidaciones.Columns.AddRange(new DataGridViewColumn[] { numColumna, nomColumna, tipoDato, longitud, obligatorio, accion });
            dataGVValidaciones.Location = new Point(25, 93);
            dataGVValidaciones.Name = "dataGVValidaciones";
            dataGVValidaciones.Size = new Size(880, 581);
            dataGVValidaciones.TabIndex = 2;
            dataGVValidaciones.CellContentClick += dataGVValidaciones_CellContentClick;
            // 
            // numColumna
            // 
            numColumna.HeaderText = "N° Columna";
            numColumna.Name = "numColumna";
            numColumna.ReadOnly = true;
            numColumna.Width = 80;
            // 
            // nomColumna
            // 
            nomColumna.HeaderText = "Nombre ";
            nomColumna.Name = "nomColumna";
            nomColumna.ReadOnly = true;
            nomColumna.Width = 300;
            // 
            // tipoDato
            // 
            tipoDato.HeaderText = "Tipo de dato";
            tipoDato.Name = "tipoDato";
            tipoDato.ReadOnly = true;
            tipoDato.Width = 160;
            // 
            // longitud
            // 
            longitud.HeaderText = "Longitud";
            longitud.Name = "longitud";
            longitud.ReadOnly = true;
            longitud.Width = 90;
            // 
            // obligatorio
            // 
            obligatorio.HeaderText = "Obligatorio";
            obligatorio.Name = "obligatorio";
            obligatorio.ReadOnly = true;
            obligatorio.Resizable = DataGridViewTriState.True;
            obligatorio.SortMode = DataGridViewColumnSortMode.Automatic;
            obligatorio.Width = 85;
            // 
            // accion
            // 
            accion.HeaderText = "Acción";
            accion.Name = "accion";
            accion.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(809, 35);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(96, 34);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "<- VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // Validaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 709);
            Controls.Add(btnVolver);
            Controls.Add(dataGVValidaciones);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Validaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Validaciones";
            Load += Validaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dataGVValidaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button btnVolver;
        private DataGridView dataGVValidaciones;
        private DataGridViewTextBoxColumn numColumna;
        private DataGridViewTextBoxColumn nomColumna;
        private DataGridViewTextBoxColumn tipoDato;
        private DataGridViewTextBoxColumn longitud;
        private DataGridViewCheckBoxColumn obligatorio;
        private DataGridViewButtonColumn accion;
    }
}