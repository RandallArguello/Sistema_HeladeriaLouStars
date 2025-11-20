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
    public partial class FormTurnos : Form
    {
        private readonly ApiEmpleado _apiClient;
        public FormTurnos(ApiEmpleado apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void FormTurnos_Load(object sender, EventArgs e)
        {
            await LoadEmpleadosAsync();
        }
        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var students = await _apiClient.Turnos.GetAllAsync();
                dgvTurnos.DataSource = students.ToList();
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
                using (var form = new AgregarTurno(_apiClient, LoadEmpleadosAsync))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await LoadEmpleadosAsync();
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
            if (dgvTurnos.SelectedRows.Count > 0)
            {
                var selectedStudent = (TurnoDto)dgvTurnos.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"¿Está seguro de que desea eliminar el " +
                    $"turno '{selectedStudent.IdTurno}'?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sucess =
                            await _apiClient.Turnos.DeleteAsync(selectedStudent.IdTurno);

                        if (sucess)
                        {
                            MessageBox.Show("¡Empleado eliminado exitosamente!", "¡Éxito!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadEmpleadosAsync();
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
            if (dgvTurnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para editar.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var empleadoSeleccionado = (TurnoDto)dgvTurnos.SelectedRows[0].DataBoundItem;

            using (var form = new AgregarTurno(_apiClient, LoadEmpleadosAsync, empleadoSeleccionado))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Opcional: recargar empleados si fue editado
                    await LoadEmpleadosAsync();
                }
            }
        }
    }
}
