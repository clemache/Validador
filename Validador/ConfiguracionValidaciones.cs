using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validador.Modelos;

namespace Validador
{
    public partial class ConfiguracionValidaciones : Form
    {
        
        private int numeroColumna;
        private List<ColumnValidation> validaciones;
        private Validaciones _validacionesForm;
        private string _configFilePath;
        public ConfiguracionValidaciones(int numeroColumna, List<ColumnValidation> validaciones, Validaciones validacionesForm,string fileConfigPath)
        {
            InitializeComponent();
            this.numeroColumna = numeroColumna;
            this.validaciones = validaciones;
            this._validacionesForm = validacionesForm;
            this._configFilePath = fileConfigPath;
            FiltrarValidacionesPorColumna();
        }

        private void FiltrarValidacionesPorColumna()
        {
            var validacionesFiltradas = validaciones
                .Where(v => v.NumColum == numeroColumna) 
                .ToList();

            if (validacionesFiltradas.Any())
            {

                txtNombreColumna.Text = string.Join(", ", validacionesFiltradas.Select(v => v.ColumnName));
                var tipoDatoSeleccionado = string.Join(", ", validacionesFiltradas.Select(v => v.Type));

                if (cmbTipoDato.Items.Contains(tipoDatoSeleccionado))
                {
                    cmbTipoDato.SelectedItem = tipoDatoSeleccionado;
                }
                else
                {
                    cmbTipoDato.SelectedIndex = -1;
                }

                longitudCampo.Value = int.Parse(string.Join(", ", validacionesFiltradas.Select(v => v.MaxLength)));

                checkObligatorio.Checked = bool.Parse(string.Join(", ", validacionesFiltradas.Select(v => v.IsRequired)));
            }
            else
            {
                MessageBox.Show($"No hay validaciones para esta columna.", "Error al obtener las validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarEdicion()
        {
            var validacionFiltrada = validaciones.FirstOrDefault(v => v.NumColum == numeroColumna);

            if (validacionFiltrada != null)
            {
                validacionFiltrada.ColumnName = txtNombreColumna.Text;
                validacionFiltrada.Type = cmbTipoDato.SelectedItem?.ToString();
                validacionFiltrada.MaxLength = (int)longitudCampo.Value;
                validacionFiltrada.IsRequired = checkObligatorio.Checked;

                var jsonData = JsonConvert.SerializeObject(validaciones, Formatting.Indented);
                //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuracion", "ConfigValidations.json");
                try
                {
                    File.WriteAllText(_configFilePath, jsonData);
                    MessageBox.Show("Los cambios se han guardado correctamente.","Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    _validacionesForm.configInit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo: {ex.Message}","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la validación para la columna seleccionada.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarEdicion();
        }
    }
}
