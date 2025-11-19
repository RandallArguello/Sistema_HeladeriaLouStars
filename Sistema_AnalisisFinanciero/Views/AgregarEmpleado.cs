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
    public partial class AgregarEmpleado : Form
    {
        private int? _empleadoId;
        private readonly ApiEmpleado _apiLouStars;
        private readonly Func<Task> _recargarListaEmpleados;

        private readonly EmpleadoDto _empleadoExistente;
        private readonly bool _modoEdicion;
        public AgregarEmpleado(ApiEmpleado apiLouStars, Func<Task> recargarListaEmpleados, EmpleadoDto empleadoExistente = null)
        {
            InitializeComponent();

            _empleadoExistente = empleadoExistente;
            _apiLouStars = apiLouStars;
            _recargarListaEmpleados = recargarListaEmpleados;
            _modoEdicion = empleadoExistente != null;

            this.Text = _modoEdicion ? "Editar Empleado" : "Nuevo Empleado";

            // Si estamos en modo edición, cargar los datos
            if (_modoEdicion && empleadoExistente != null)
            {
                _empleadoId = empleadoExistente.IdEmpleado;
                CargarDatosEmpleado(empleadoExistente);
            }
        }
        private void CargarDatosEmpleado(EmpleadoDto empleado)
        {
            txtIdContrato.Text = _empleadoExistente.IdContrato.ToString();
            txtNombre.Text = _empleadoExistente.Nombre;
            txtApellido.Text = _empleadoExistente.Apellido;
            txtDireccion.Text = _empleadoExistente.Direccion;
            txtEmail.Text = _empleadoExistente.Email;
            txtNacionalidad.Text = _empleadoExistente.Nacionalidad;
            txtTelefono.Text = _empleadoExistente.Telefono;
            cbxGenero.SelectedItem = _empleadoExistente.Genero;
            txtCedula.Text = _empleadoExistente.Cedula;
            DtFechaNacimiento.Value = _empleadoExistente.FechaNacimiento ?? DateTime.Now;
            SetDatePickerValue(DtFechaIngreso, _empleadoExistente.FechaIngreso);
        }
        private void AgregarEmpleado_Load(object sender, EventArgs e)
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
                    await ActualizarEmpleado();
                }
                else
                {
                    await CrearEmpleado();

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
            txtIdContrato.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtNacionalidad?.Clear();
            txtTelefono.Clear();
            cbxGenero.Enabled = false;
            txtCedula.Enabled = false;
            DtFechaNacimiento.Enabled = false;
            DtFechaIngreso.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdContrato.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNacionalidad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                 string.IsNullOrWhiteSpace(txtCedula.Text) ||
                cbxGenero.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Por favor, ingrese un email válido.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async Task CrearEmpleado()
        {
            var nuevoEmpleado = new EmpleadoCreateDto
            {
                IdContrato = Convert.ToInt32(txtIdContrato.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                Nacionalidad = txtNacionalidad.Text,
                Telefono = txtTelefono.Text,
                Genero = cbxGenero.Text,
                Cedula = txtCedula.Text,
                FechaNacimiento = DtFechaNacimiento.Value,
                FechaIngreso = DtFechaIngreso.Value
            };

            var resultado = await _apiLouStars.Empleados.CreateAsync(nuevoEmpleado);

            if (resultado != null)
            {
                await _recargarListaEmpleados();
                MessageBox.Show("Empleado creado exitosamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo crear el empleado.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarEmpleado()
        {
            var empleadoActualizado = new EmpleadoUpdateDto
            {

                IdEmpleado = _modoEdicion ? _empleadoId.Value : 0,
                IdContrato = Convert.ToInt32(txtIdContrato.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                Nacionalidad = txtNacionalidad.Text,
                Telefono = txtTelefono.Text,
                Genero = cbxGenero.Text,
                Cedula = txtCedula.Text,
                FechaNacimiento = DtFechaNacimiento.Value,
                FechaIngreso = DtFechaIngreso.Value
            };
            var success = await _apiLouStars.Empleados.UpdateAsync(_empleadoExistente.IdEmpleado, empleadoActualizado);

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

        private void SetDatePickerValue(DateTimePicker picker, DateTime? value)
        {
            if (value.HasValue && value.Value >= picker.MinDate && value.Value <= picker.MaxDate)
                picker.Value = value.Value;
            else
                picker.Value = DateTime.Now; // o picker.Enabled = false;
        }
    }
}
