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
    public partial class FormEmpleados : Form
    {
        private readonly ApiEmpleado _apiClient;
        public FormEmpleados(ApiEmpleado apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void FormEmpleados_Load(object sender, EventArgs e)
        {
            await LoadEmpleadosAsync();
        }
        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var students = await _apiClient.Empleados.GetAllAsync();
                dgvEmpleados.DataSource = students.ToList();

                if (dgvEmpleados.Columns["Fecha Ingreso"] != null)
                    dgvEmpleados.Columns["Fecha Ingreso"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvEmpleados.Columns["Fecha Nacimiento"] != null)
                    dgvEmpleados.Columns["Fecha Nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AgregarEmpleado(_apiClient, LoadEmpleadosAsync))
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
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                var selectedStudent = (EmpleadoDto)dgvEmpleados.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"¿Está seguro de que desea eliminar el " +
                    $"empleado '{selectedStudent.Nombre}'?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sucess =
                            await _apiClient.Empleados.DeleteAsync(selectedStudent.IdEmpleado);

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

        private async void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para editar.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var empleadoSeleccionado = (EmpleadoDto)dgvEmpleados.SelectedRows[0].DataBoundItem;

            using (var form = new AgregarEmpleado(_apiClient, LoadEmpleadosAsync, empleadoSeleccionado))
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
