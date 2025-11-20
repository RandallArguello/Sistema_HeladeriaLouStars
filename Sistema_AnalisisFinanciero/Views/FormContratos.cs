using HeladeriaLouStarsApp.Controllers;
using HeladeriaLouStarsApp.Models.Dto;
using HeladeriaLouStarsApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_AnalisisFinanciero
{
    public partial class FormContratos : Form
    {
        private readonly ApiEmpleado _apiClient;
        public FormContratos(ApiEmpleado apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        

        private async void FormContratos_Load(object sender, EventArgs e)
        {
            await LoadContratosAsync();
        }
        private async Task LoadContratosAsync()
        {
            try
            {
                var students = await _apiClient.Contratos.GetAllAsync();
                dgvContratos.DataSource = students.ToList();

                if (dgvContratos.Columns["FechaInicio"] != null)
                    dgvContratos.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvContratos.Columns["FechaFin"] != null)
                    dgvContratos.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar contratos: {ex.Message}\n\nDetalles: {ex.InnerException?.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AgregarContrato(_apiClient, LoadContratosAsync))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await LoadContratosAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear una orden: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContratos.SelectedRows.Count > 0)
            {
                var selectedStudent = (ContratoDto)dgvContratos.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"¿Está seguro de que desea eliminar el " +
                    $"contrato '{selectedStudent.IdContrato}'?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sucess =
                            await _apiClient.Contratos.DeleteAsync(selectedStudent.IdContrato);

                        if (sucess)
                        {
                            MessageBox.Show("¡Empleado eliminado exitosamente!", "¡Éxito!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadContratosAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Error al eliminar empleado.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar empleado: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvContratos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un contrato para editar.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var empleadoSeleccionado = (ContratoDto)dgvContratos.SelectedRows[0].DataBoundItem;

            using (var form = new AgregarContrato(_apiClient, LoadContratosAsync, empleadoSeleccionado))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Opcional: recargar empleados si fue editado
                    await LoadContratosAsync();
                }
            }
        }
    }
}
