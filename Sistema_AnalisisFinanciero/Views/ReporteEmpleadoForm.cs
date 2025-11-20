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
                DateTime? fechaInicio = dtpFechaInicio.Checked ? dtpFechaInicio.Value.Date : (DateTime?)null;
                DateTime? fechaFin = dtpFechaFin.Checked ? dtpFechaFin.Value.Date : (DateTime?)null;

                // Mostrar loading
                Cursor = Cursors.WaitCursor;
                btnBuscar.Enabled = false;

                // Obtener datos (usará modo prueba automáticamente)
                var datos = await _apiClient.Reportes.ObtenerReporteEmpleados(fechaInicio, fechaFin);
                var datosLista = datos.ToList();

                // Mostrar resultados
                dgvReporte.DataSource = datosLista;
                GenerarGrafico(datosLista);

                MessageBox.Show($"✅ Se cargaron {datosLista.Count} registros\n\n" +
                               "💡 Nota: Usando datos de prueba mientras el equipo de backend soluciona el error 'Nombre'",
                               "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnBuscar.Enabled = true;
            }
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
