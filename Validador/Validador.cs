using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using Newtonsoft.Json;
using Validador.Modelos;
using System.Diagnostics;
namespace Validador
{
    public partial class Validador : Form
    {
        List<string> validationLogs = new List<string>();
        List<ColumnValidation> validaciones = new List<ColumnValidation>();
        Dictionary<int, List<string>> erroresPorFila = new Dictionary<int, List<string>>();
        private string pathFileConfig; 
        public Validador(string pathConfig)
        {
            InitializeComponent();
            this.pathFileConfig = pathConfig;
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ValidateExcelFile(filePath);
            }
        }

        private void ValidateExcelFile(string filePath)
        {

            //string filePathValidations = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuracion", "ConfigValidations.json");
            var jsonData = File.ReadAllText(pathFileConfig);
            validaciones = JsonConvert.DeserializeObject<List<ColumnValidation>>(jsonData);

            try
            {
                IWorkbook workbook;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (Path.GetExtension(filePath).Equals(".xls"))
                    {
                        workbook = new HSSFWorkbook(fileStream); // .xls
                    }
                    else
                    {
                        workbook = new XSSFWorkbook(fileStream); // .xlsx
                    }
                }

                ISheet sheet = workbook.GetSheetAt(0); //first Page

                // Validación de columnas
                IRow headerRow = sheet.GetRow(0);
                foreach (var columnValidation in validaciones)
                {
                    bool columnExists = false;
                    for (int cellNum = 0; cellNum < headerRow.LastCellNum; cellNum++)
                    {
                        ICell cell = headerRow.GetCell(cellNum);
                        if (cell != null && cell.ToString().Equals(columnValidation.ColumnName, StringComparison.OrdinalIgnoreCase))
                        {
                            columnExists = true;
                            break;
                        }
                    }

                    if (!columnExists)
                    {
                        MessageBox.Show($"Falta la columna: {columnValidation.ColumnName}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Validacion de datos
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    listBoxLogsValidaciones.Items.Add("Validando... Fila N° " + (row + 1));
                    IRow currentRow = sheet.GetRow(row);
                    if (currentRow == null) continue;

                    foreach (var columnValidation in validaciones)
                    {
                        ICell cell = currentRow.GetCell(columnValidation.NumColum - 1);
                        string cellValue = cell?.ToString();
                        // Debug.WriteLine("| Nombre de la columna= "+columnValidation.ColumnName+" | num fila= "+row+"  | valor enviado a analizar= "+cellValue);
                        ValidateCell(cellValue, columnValidation, row);
                    }
                }

                //Formato logs
                erroresPorFila = new Dictionary<int, List<string>>();

                foreach (var log in validationLogs)
                {

                    int fila;
                    if (log.StartsWith("Fila") && int.TryParse(log.Split(' ')[1].TrimEnd(':'), out fila))
                    {

                        if (!erroresPorFila.ContainsKey(fila))
                        {
                            erroresPorFila[fila] = new List<string>();
                        }

                        erroresPorFila[fila].Add(log.Substring(log.IndexOf(':') + 2));
                    }
                }

                listBoxLogsValidaciones.Items.Clear();

                foreach (var fila in erroresPorFila.Keys)
                {
                    listBoxLogsValidaciones.Items.Add($"Fila {fila}:");

                    foreach (var error in erroresPorFila[fila])
                    {
                        listBoxLogsValidaciones.Items.Add($"- {error}");
                    }

                    listBoxLogsValidaciones.Items.Add("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ValidateCell(string cellValue, ColumnValidation columnValidation, int row)
        {
            if (columnValidation.IsRequired)
            {
                if (string.IsNullOrWhiteSpace(cellValue))
                {
                    validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' es requerida y no puede estar vacía.");
                    return;
                }
                else
                {
                    if (cellValue.Length > columnValidation.MaxLength)
                    {
                        validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' excede la longitud máxima de {columnValidation.MaxLength} caracteres.");
                    }

                    if (columnValidation.Type.Equals("int", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!int.TryParse(cellValue, out _))
                        {
                            validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' debe ser un número entero válido.");
                        }
                    }
                    else if (columnValidation.Type.Equals("double", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!double.TryParse(cellValue, out _))
                        {
                            validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' debe ser un número decimal válido.");
                        }
                    }
                    else if (columnValidation.Type.Equals("date", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!ValidarFecha(cellValue))
                        {
                            validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' debe ser una fecha válida en el formato dd/MM/yyyy HH:mm:ss.");
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(cellValue))
                {
                    if (cellValue.Length > columnValidation.MaxLength)
                    {
                        validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' excede la longitud máxima de {columnValidation.MaxLength} caracteres.");
                    }

                    if (columnValidation.Type.Equals("int", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!int.TryParse(cellValue, out _))
                        {
                            validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' debe ser un número entero válido.");
                        }
                    }
                    else if (columnValidation.Type.Equals("double", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!double.TryParse(cellValue, out _))
                        {
                            validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' debe ser un número decimal válido.");
                        }
                    }
                    else if (columnValidation.Type.Equals("date", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!ValidarFecha(cellValue))
                        {
                            validationLogs.Add($"Fila {row + 1}: La columna '{columnValidation.ColumnName}' debe ser una fecha válida en el formato dd/MM/yyyy HH:mm:ss.");
                        }
                    }
                }
            }
        }

        public bool ValidarFecha(string fecha)
        {
            string formato = "d/M/yyyy HH:mm:ss";

            return DateTime.TryParseExact(
                fecha,
                formato,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _
            );
        }

        public void saveTxtLogsValidations()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt";
                saveFileDialog.Title = "Guardar archivo de errores de validación";
                saveFileDialog.FileName = "ErroresValidacion.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(rutaArchivo))
                    {
                        foreach (var fila in erroresPorFila.Keys)
                        {
                            writer.WriteLine($"Fila {fila}:");

                            foreach (var error in erroresPorFila[fila])
                            {
                                writer.WriteLine($"- {error}");
                            }

                            writer.WriteLine();
                        }
                    }
                    MessageBox.Show("Archivo .txt generado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        public bool ValidarCedula(string cedula)
        {
            if (cedula.Length != 10 || !long.TryParse(cedula, out _))
            {
                return false;
            }

            int provincia = int.Parse(cedula.Substring(0, 2));

            if (provincia < 1 || provincia > 24)
            {
                return false;
            }
            int digitoVerificador = int.Parse(cedula.Substring(9, 1));

            int suma = 0;
            for (int i = 0; i < 9; i++)
            {
                int digito = int.Parse(cedula[i].ToString());
                if (i % 2 == 0)
                {
                    digito *= 2;
                    if (digito > 9)
                    {
                        digito -= 9;
                    }
                }
                suma += digito;
            }

            int digitoCalculado = 10 - (suma % 10);
            if (digitoCalculado == 10)
            {
                digitoCalculado = 0;
            }

            return digitoCalculado == digitoVerificador;
        }

        private void configValidaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            Validaciones validaciones = new Validaciones(pathFileConfig);
            validaciones.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (erroresPorFila.Count > 0)
            {
                saveTxtLogsValidations();
            }
            else
            {
                MessageBox.Show("Primero debe generar la validación del documento", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuValidador validador = new MenuValidador();
            validador.Show();
        }
    }
}
