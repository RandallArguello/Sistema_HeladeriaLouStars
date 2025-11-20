using ClosedXML.Excel;
using HeladeriaLouStarsApp.Controllers;
using HeladeriaLouStarsApp.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeladeriaLouStarsApp.Views
{
    public partial class ReporteEmpleadoForm : Form
    {
        private readonly ApiEmpleado _apiClient;
        public ReporteEmpleadoForm(ApiEmpleado apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void ReporteEmpleadoForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaInicio = dtpFechaInicio.Checked ? dtpFechaInicio.Value : (DateTime?)null;
                DateTime? fechaFin = dtpFechaFin.Checked ? dtpFechaFin.Value : (DateTime?)null;

                Console.WriteLine($"📅 Fechas seleccionadas: Inicio={fechaInicio}, Fin={fechaFin}"); // DEBUG

                // Mostrar loading
                Cursor = Cursors.WaitCursor;
                btnBuscar.Enabled = false;

                var datos = await _apiClient.Reportes.ObtenerReporteEmpleados(fechaInicio, fechaFin);

                Console.WriteLine($"📊 Datos recibidos del repository: {datos?.Count() ?? 0} registros"); // DEBUG

                if (datos == null)
                {
                    MessageBox.Show("❌ No se recibieron datos del servidor (null)");
                    return;
                }

                var datosLista = datos.ToList();
                Console.WriteLine($"📋 Datos convertidos a lista: {datosLista.Count} registros"); // DEBUG

                if (!datosLista.Any())
                {
                    MessageBox.Show("ℹ️ No hay datos para mostrar en el período seleccionado",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReporte.DataSource = null;
                    LimpiarGrafico();
                    return;
                }

                // DEBUG: Mostrar primeros 3 registros en consola
                Console.WriteLine("🔍 Primeros 3 registros:");
                for (int i = 0; i < Math.Min(3, datosLista.Count); i++)
                {
                    var item = datosLista[i];
                    Console.WriteLine($"   [{i}] IdEmpleado: {item.IdEmpleado}, Nombre: {item.Nombre}, Total: {item.TotalPagado}");
                }

                dgvReporte.DataSource = datosLista;
                GenerarGrafico(datosLista);

                MessageBox.Show($"✅ Se cargaron {datosLista.Count} registros correctamente",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Error en btnBuscar: {ex}"); // DEBUG
                MessageBox.Show($"Error al obtener datos: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnBuscar.Enabled = true;
            }
        }
        
        private void LimpiarGrafico()
        {
            var plt = formsPlot1.Plot;
            plt.Clear();
            plt.Title("No hay datos para mostrar", size: 14, color: Color.Gray);
            plt.XLabel("Seleccione un período con datos válidos");
            formsPlot1.Refresh();
        }

        private void GenerarGrafico(List<ReporteEmpleadoDto> datos, string tipo = "Barra")
        {
            var plt = formsPlot1.Plot;
            plt.Clear();

            var empleados = datos.Select(x => x.IdEmpleado.ToString()).ToArray();
            var valores = datos.Select(x => (double)x.TotalPagado).ToArray();

            if (!valores.Any()) return;

            if (tipo.Equals("Barra", StringComparison.OrdinalIgnoreCase))
            {
                // Dibujar barras
                plt.AddBar(valores);

                // Configurar etiquetas del eje X
                plt.XTicks(Enumerable.Range(0, empleados.Length).Select(i => (double)i).ToArray(), empleados);

                plt.Title("Total de compras por cliente");
                plt.YLabel("Total Comprado");
            }
            else if (tipo.Equals("Torta", StringComparison.OrdinalIgnoreCase))
            {
                plt.AddPie(valores).ShowLabels = true;
                plt.Title("Distribución de compras por cliente");
            }

            formsPlot1.Refresh();
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivo Excel|*.xlsx";
                    saveFileDialog.Title = "Guardar reporte Excel";
                    saveFileDialog.FileName = $"Reporte_Clientes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportarDataGridViewAExcel(dgvReporte, saveFileDialog.FileName);
                        MessageBox.Show("Reporte exportado exitosamente", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportarDataGridViewAExcel(DataGridView dataGridView, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte");

                // Encabezados
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // Datos
                for (int row = 0; row < dataGridView.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        var value = dataGridView.Rows[row].Cells[col].Value;
                        worksheet.Cell(row + 2, col + 1).Value = value?.ToString() ?? "";
                    }
                }

                // Autoajustar columnas
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }
    }
}
