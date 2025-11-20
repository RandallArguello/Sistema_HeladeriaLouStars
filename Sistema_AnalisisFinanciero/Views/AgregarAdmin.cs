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
    public partial class AgregarAdmin : Form
    {
        private int? _adminId;
        private readonly ApiEmpleado _apiClient;
        private readonly Func<Task> _recargarListaEmpleados;

        private readonly AdministradorDto _empleadoExistente;
        private readonly bool _modoEdicion;
        public AgregarAdmin(ApiEmpleado apiClient, Func<Task> recargarListaEmpleados, AdministradorDto empleadoExistente = null)
        {
            InitializeComponent();
            _empleadoExistente = empleadoExistente;
            _apiClient = apiClient;
            _recargarListaEmpleados = recargarListaEmpleados;
            _modoEdicion = empleadoExistente != null;

            this.Text = _modoEdicion ? "Editar contrato" : "Nuevo contrato";

            // Si estamos en modo edición, cargar los datos
            if (_modoEdicion && empleadoExistente != null)
            {
                _adminId = empleadoExistente.IdAdministrador;
                CargarDatosEmpleado(empleadoExistente);
            }
        }
        private void CargarDatosEmpleado(AdministradorDto empleado)
        {

            txtNombreUsuario.Text = _empleadoExistente.NombreUsuario;
            txtContraseña.Text = _empleadoExistente.Contraseña;
            txtCorreo.Text = _empleadoExistente.Correo;
        }

        private void AgregarAdmin_Load(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                btnSave.Enabled = false;

                if (_modoEdicion)
                {
                    await ActualizarContrato();
                }
                else
                {
                    await CrearContrato();

                }
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        private void ClearInputFields()
        {
            txtContraseña.Clear();
            txtCorreo.Clear();
            txtNombreUsuario.Clear();   
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtNombreUsuario.Text))

            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private async Task CrearContrato()
        {
            var nuevoContrato = new AdminCreateDto
            {
                NombreUsuario= txtNombreUsuario.Text,
                Contraseña= txtContraseña.Text,
                Correo= txtCorreo.Text
            };

            var resultado = await _apiClient.Administradores.CreateAsync(nuevoContrato);

            if (resultado != null)
            {
                await _recargarListaEmpleados();
                MessageBox.Show("contrato creado exitosamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo crear el contrato.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task ActualizarContrato()
        {
            var contratoActualizado = new AdminUpdateDto
            {
                IdAdministrador = _modoEdicion ? _adminId.Value : 0,
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = txtContraseña.Text,
                Correo = txtCorreo.Text

            };
            var success = await _apiClient.Administradores.UpdateAsync(_empleadoExistente.IdAdministrador, contratoActualizado);

            if (success)
            {
                await _recargarListaEmpleados();
                MessageBox.Show("Empleado actualizado exitosamente", "Éxito",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el empleado.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
