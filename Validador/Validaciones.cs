using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validador.Modelos;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Validador
{
    public partial class Validaciones : Form
    {
        private string filePath;
        List<ColumnValidation> validaciones = new List<ColumnValidation>();
        public Validaciones(string pathValidations)
        {
            InitializeComponent();
            this.filePath = pathValidations;
            
        }

        public void configInit() {
            var jsonData = File.ReadAllText(filePath);

            validaciones = JsonConvert.DeserializeObject<List<ColumnValidation>>(jsonData);

            dataGVValidaciones.AutoGenerateColumns = false;
            dataGVValidaciones.Rows.Clear();

            if (dataGVValidaciones.Columns["Accion"] is DataGridViewButtonColumn accionColumn)
            {
                accionColumn.Text = "Editar";
                accionColumn.UseColumnTextForButtonValue = true;
            }

            foreach (var validacion in validaciones)
            {
                dataGVValidaciones.Rows.Add(
                    validacion.NumColum,
                    validacion.ColumnName,
                    validacion.Type,
                    validacion.MaxLength,
                    validacion.IsRequired
                );
            }

        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Validador validador = new Validador(filePath);
            validador.Show();
        }

        private void Validaciones_Load(object sender, EventArgs e)
        {
            configInit();

        }

        private void dataGVValidaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGVValidaciones.Columns["Accion"].Index && e.RowIndex >= 0)
            {
                var numeroColumna = int.Parse(dataGVValidaciones.Rows[e.RowIndex].Cells["numColumna"].Value.ToString());
                var configuracionValidaciones = new ConfiguracionValidaciones(numeroColumna, validaciones,this,filePath);
                configuracionValidaciones.ShowDialog(); 
            }
        }
    }
}
