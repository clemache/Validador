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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Validador
{
    public partial class MenuValidador : Form
    {
        string filePath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuracion", "ConfigValidations.json");
        string filePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuracion", "ConfigValidationsFES.json");
        public MenuValidador()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string fileSelectPath = "";
            if (cmbArchivoConfig.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un elemento del combo.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cmbArchivoConfig.SelectedIndex == 0)
                {
                    fileSelectPath = filePath1;
                }
                else {
                    fileSelectPath = filePath2;
                }
                this.Hide();
                Validador validador = new Validador(fileSelectPath);
                validador.Show();
            }



        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
