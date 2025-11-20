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
    public partial class FormAdmins : Form
    {
        private readonly ApiEmpleado _apiClient;
        public FormAdmins(ApiEmpleado apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void FormAdmins_Load(object sender, EventArgs e)
        {
           await LoadEmpleadosAsync();
        }
        private async Task LoadEmpleadosAsync()
        {
            try
            {
                var students = await _apiClient.Administradores.GetAllAsync();
                dgvAdministradores.DataSource = students.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AgregarAdmin(_apiClient, LoadEmpleadosAsync))
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
            if (dgvAdministradores.SelectedRows.Count > 0)
            {
                var selectedStudent = (AdministradorDto)dgvAdministradores.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"¿Está seguro de que desea eliminar el " +
                    $"admin '{selectedStudent.IdAdministrador}'?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sucess =
                            await _apiClient.Administradores.DeleteAsync(selectedStudent.IdAdministrador);

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
            if (dgvAdministradores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para editar.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var empleadoSeleccionado = (AdministradorDto)dgvAdministradores.SelectedRows[0].DataBoundItem;

            using (var form = new AgregarAdmin(_apiClient, LoadEmpleadosAsync, empleadoSeleccionado))
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
