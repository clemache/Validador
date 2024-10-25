using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
namespace Validador
{
    public partial class Validador : Form
    {
        public Validador()
        {
            InitializeComponent();
        }

        private readonly List<string> requiredColumns = new List<string>
        {
            "Nro de la Solicitud", "Descripción Tipo de Solicitud", "Observación de Solicitud", "No Orden",
            "Descripción de Tipo de Orden", "Estado Orden", "Comentario", "Comentario Creación Ot","Número Actividad Orden",
            "Descripción de Actividad", "Nombre de Cliente", "Teléfono Cliente", "Diámetro guia",
            "Número de medidor", "Número Contrato", "Número de Servicio", "Número de Producto",
            "Descripción de Categoria", "Estado corte", "Sector Operativo", "Descripción de Unidad de Trabajo",
            "Fecha Generación de Orden", "Fecha asignación de Orden", "Fecha de Legalización de Orden",
            "Fecha estimada de Ejecución de Orden", "Descripción de Causal de Orden", "Dirección de OT",
            "No Ot relacionada", "Tarea de Orden Relacionada", "Saldo Adeudado por Producto",
            "Facturas Adeudadas por Producto", "ID Ruta", "Identificación del Cliente",
            "Direccion Respuesta", "Id Direccion Producto", "Comentario Rec","Fecha Lectura Anterior","Lectura Anterior",
            "Fecha Lectura Actual","Lectura Actual"
        };

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

                // validacion de columnas
                IRow headerRow = sheet.GetRow(0);
                foreach (var columnName in requiredColumns)
                {
                    bool columnExists = false;
                    for (int cellNum = 0; cellNum < headerRow.LastCellNum; cellNum++)
                    {
                        ICell cell = headerRow.GetCell(cellNum);
                        if (cell != null && cell.ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        {
                            columnExists = true;
                            break;
                        }
                    }

                    if (!columnExists)
                    {
                        MessageBox.Show($"Falta la columna: {columnName}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    IRow currentRow = sheet.GetRow(row);
                    if (currentRow == null) continue;

                    //Validacion de Nro de la Solicitud 
                    ICell solicitudCell = currentRow.GetCell(0);
                    
                    if (!string.IsNullOrWhiteSpace(solicitudCell.ToString()))
                    {
                        if (!int.TryParse(solicitudCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row+1}, 'Nro de la Solicitud' = '"+solicitudCell.ToString()+"' no es un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Validacion de No orden
                    ICell NroOrden = currentRow.GetCell(3);
                    if (!string.IsNullOrWhiteSpace(NroOrden.ToString()))
                    {
                        if (!int.TryParse(NroOrden.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Nro Orden' = '"+NroOrden.ToString()+"' no es un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Numero actividad Orden
                    ICell NroActividadOrden = currentRow.GetCell(8);
                    if (!string.IsNullOrWhiteSpace(NroActividadOrden.ToString()) || NroActividadOrden != null)
                    {
                        if (!int.TryParse(NroActividadOrden.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Número Actividad Orden' = '"+NroActividadOrden.ToString()+"' no es un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Numero actividad Orden
                    ICell NombreClienteCell = currentRow.GetCell(10);
                    if (!string.IsNullOrWhiteSpace(NombreClienteCell.ToString()))
                    {
                        string nombreCliente = NombreClienteCell.ToString();

                        if (!soloTexto(nombreCliente))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Nombre de Cliente' = '"+nombreCliente+"' no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Telefono del cliente
                    ICell telefonoCell = currentRow.GetCell(11);
                    if (!string.IsNullOrWhiteSpace(telefonoCell.ToString()))
                    {
                        if (!ValidarTelefonos(telefonoCell.ToString()))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Teléfono Cliente' = '" + telefonoCell.ToString() + "' no es un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    //Numero Contrato
                    ICell numeroContratoCell = currentRow.GetCell(14);
                    if (!string.IsNullOrWhiteSpace(numeroContratoCell.ToString()))
                    {
                        if (!int.TryParse(numeroContratoCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Número Contrato' ='"+numeroContratoCell.ToString()+"' no es un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Numero de Servicio
                    ICell numeroServicioCell = currentRow.GetCell(15);
                    if (!string.IsNullOrWhiteSpace(numeroServicioCell.ToString()))
                    {
                        if (!int.TryParse(numeroServicioCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Número de Servicio' = '"+numeroServicioCell.ToString()+"' no es un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Numero de Producto
                    ICell numeroProductoCell = currentRow.GetCell(16);
                    if (!string.IsNullOrWhiteSpace(numeroProductoCell.ToString()))
                    {
                        if (!int.TryParse(numeroProductoCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Número de Producto' = '"+numeroProductoCell.ToString()+"' no es un número válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Validar que la Fecha Generación de Orden sea una fecha válida
                    ICell fechaGeneracionOrdenCell = currentRow.GetCell(21);
                    if (!string.IsNullOrWhiteSpace(fechaGeneracionOrdenCell.ToString()))
                    {
                        string fechaGeneracionOrden = fechaGeneracionOrdenCell.ToString();

                        if (!ValidarFecha(fechaGeneracionOrden))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Fecha Generación de Orden' ='"+fechaGeneracionOrden.ToString()+"' no es una fecha válida. Debe estar en el formato 'dd/MM/yyyy HH:mm:ss'.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Validar que la Fecha asignación de orden sea una fecha válida
                    ICell fechaAsignacionOrdenCell = currentRow.GetCell(22);
                    if (!string.IsNullOrWhiteSpace(fechaAsignacionOrdenCell.ToString()))
                    {
                        string fechaAsignacionOrden = fechaAsignacionOrdenCell.ToString();

                        if (!ValidarFecha(fechaAsignacionOrden))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Fecha asignación de orden' ='"+fechaAsignacionOrden+"' no es una fecha válida. Debe estar en el formato 'dd/MM/yyyy HH:mm:ss'.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    // Validar que la Fecha legalización de orden sea una fecha válida
                    ICell fechaLegalizacionOrdenCell = currentRow.GetCell(23);
                    if (!string.IsNullOrWhiteSpace(fechaLegalizacionOrdenCell.ToString()))
                    {
                        string fechaLegalizacionOrden = fechaLegalizacionOrdenCell.ToString();

                        if (!ValidarFecha(fechaLegalizacionOrden))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Fecha de Legalización de orden' = '" +fechaLegalizacionOrden+"' no es una fecha válida. Debe estar en el formato 'dd/MM/yyyy HH:mm:ss'.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Validar que la Fecha estimada de Ejecución de orden sea una fecha válida
                    ICell fechaEstimadaEjecucionCell = currentRow.GetCell(24);
                    if (!string.IsNullOrWhiteSpace(fechaEstimadaEjecucionCell.ToString()))
                    {
                        string fechaEstimadaEjecucion = fechaEstimadaEjecucionCell.ToString();

                        if (!ValidarFecha(fechaEstimadaEjecucion))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Fecha estimada de Ejecución de orden' ='" +fechaEstimadaEjecucion+"' no es una fecha válida. Debe estar en el formato 'dd/MM/yyyy HH:mm:ss'.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Validar que la Saldo Adeudado por producto sea una fecha válida
                    ICell saldoAdeudadoProductoCell = currentRow.GetCell(29);
                    if (!string.IsNullOrWhiteSpace(saldoAdeudadoProductoCell.ToString()))
                    {
                        string saldoAdeudadoProducto = saldoAdeudadoProductoCell.ToString();

                        if (!ValidarNumero(saldoAdeudadoProducto))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Saldo Adeudado por Producto' = '" +saldoAdeudadoProducto+"'  es un valor incorrecto.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Facturas adeudadas por Producto
                    ICell facturasAdeudasCell = currentRow.GetCell(30);
                    if (!string.IsNullOrWhiteSpace(facturasAdeudasCell.ToString()))
                    {
                        if (!int.TryParse(facturasAdeudasCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Facturas Adeudadas por Producto' ='" +facturasAdeudasCell.ToString()+"' no es un valor válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Validar que la identificacion (columna 32) sea una cedula valida
                    ICell identificacionCell = currentRow.GetCell(32);
                    if (!string.IsNullOrWhiteSpace(identificacionCell.ToString()))
                    {
                        //string identificacion = identificacionCell.ToString();

                        if (!long.TryParse(identificacionCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'La Identificación del Cliente' = '" +identificacionCell.ToString()+"' es una cédula no válida.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    // Id direccion Producto
                    ICell IdDirProductoCell = currentRow.GetCell(34);
                    if (!string.IsNullOrWhiteSpace(IdDirProductoCell.ToString()))
                    {
                        if (!int.TryParse(IdDirProductoCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Id Dirección Producto' ='" +IdDirProductoCell.ToString()+"' no es un valor válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Validar que la "Fecha lectura anterior" (columna 22) sea una fecha válida
                    ICell fechaLecturaAnteriorCell = currentRow.GetCell(36);
                    if (!string.IsNullOrWhiteSpace(fechaLecturaAnteriorCell.ToString()))
                    {
                        string fechaLecturaAnterior = fechaLecturaAnteriorCell.ToString();

                        if (!ValidarFecha(fechaLecturaAnterior))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Fecha Lectura Anterior' ='" +fechaLecturaAnterior+"' no es una fecha válida. Debe estar en el formato 'dd/MM/yyyy HH:mm:ss'.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Lectura Anterior
                    ICell LecturaAnteriorCell = currentRow.GetCell(37);
                    if (!string.IsNullOrWhiteSpace(LecturaAnteriorCell.ToString()))
                    {
                        if (!int.TryParse(LecturaAnteriorCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Lectura Anterior' ='" +LecturaAnteriorCell.ToString()+"' no es un valor válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Validar que la "Fecha lectura anterior" (columna 22) sea una fecha válida
                    ICell fechaLecturaActualCell = currentRow.GetCell(38);
                    if (!string.IsNullOrWhiteSpace(fechaLecturaActualCell.ToString()))
                    {
                        string fechaLecturaActual = fechaLecturaActualCell.ToString();

                        if (!ValidarFecha(fechaLecturaActual))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Fecha Lectura Actual' ='" +fechaLecturaActual+"' no es una fecha válida. Debe estar en el formato 'dd/MM/yyyy HH:mm:ss'.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Lectura Actual
                    ICell LecturaActualCell = currentRow.GetCell(39);
                    if (!string.IsNullOrWhiteSpace(LecturaActualCell.ToString()))
                    {
                        if (!int.TryParse(LecturaActualCell.ToString(), out _))
                        {
                            MessageBox.Show($"Error en la fila #{row + 1}, 'Lectura Actual' ='" +LecturaActualCell.ToString()+"' no es un valor válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                }



                MessageBox.Show("El archivo es válido.", "Validación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool soloTexto(string texto)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z0-9\s\-\.'""ÑñáéíóúÁÉÍÓÚ()]+$");
        }





        public bool EsFechaValida(string fechaTexto)
        {
            return DateTime.TryParseExact(fechaTexto, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        }

        public bool ValidarFecha(string fecha)
        {
            string formato = "d/M/yyyy HH:mm:ss";

            return DateTime.TryParseExact(fecha, formato,
                                          System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out _);
        }

        public bool ValidarNumero(string numero)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(numero, @"^0|[1-9]\d*(\,\d{1,2})?$");
        }
        public bool ValidarTelefonos(string telefonos)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(telefonos, @"^(\+?\d[\d\s\-\/,\.]*)+$");
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


    }
}
