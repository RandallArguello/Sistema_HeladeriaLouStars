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
    public partial class FormNominas : Form
    {
        private readonly ApiEmpleado _apiClient;
        public FormNominas(ApiEmpleado apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }
        private async Task LoadNominasAsync()
        {
            try
            {
                var nominas = await _apiClient.Nominas.GetAllAsync();
                dgvNominas.DataSource = nominas.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar nominas: {ex.ToString()}",
       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void FormNominas_Load(object sender, EventArgs e)
        {
            await LoadNominasAsync();
        }

        private void btnAgregarNomina_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AgregarNomina(_apiClient, LoadNominasAsync))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear una orden: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvNominas.SelectedRows.Count > 0)
            {
                var selectedStudent = (NominaDto)dgvNominas.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"¿Está seguro de que desea eliminar la " +
                    $"nomina con ID '{selectedStudent.NominaID}'?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sucess =
                            await _apiClient.Nominas.DeleteAsync(selectedStudent.NominaID);

                        if (sucess)
                        {
                            MessageBox.Show("¡Nómina eliminada exitosamente!", "¡Éxito!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadNominasAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Error al eliminar nomina.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar nomina: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvNominas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una nomina para editar.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nominaSeleccionada = (NominaDto)dgvNominas.SelectedRows[0].DataBoundItem;

            using (var form = new AgregarNomina(_apiClient, LoadNominasAsync, nominaSeleccionada))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                    await LoadNominasAsync();
                }
            }
        }
    }
}
