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
    public partial class AgregarTurno : Form
    {
        private int? _turnoId;
        private readonly ApiEmpleado _apiClient;
        private readonly Func<Task> _recargarListaEmpleados;

        private readonly TurnoDto _empleadoExistente;
        private readonly bool _modoEdicion;
        public AgregarTurno(ApiEmpleado apiLouStars, Func<Task> recargarListaEmpleados, TurnoDto empleadoExistente = null)
        {
            InitializeComponent();
            _empleadoExistente = empleadoExistente;
            _apiClient = apiLouStars;
            _recargarListaEmpleados = recargarListaEmpleados;
            _modoEdicion = empleadoExistente != null;

            this.Text = _modoEdicion ? "Editar turno" : "Nuevo turno";

            // Si estamos en modo edición, cargar los datos
            if (_modoEdicion && empleadoExistente != null)
            {
                _turnoId = empleadoExistente.IdEmpleado;
                CargarDatosEmpleado(empleadoExistente);
            }
        }
        private void CargarDatosEmpleado(TurnoDto empleado)
        {

            txtIdEmpleado.Text = _empleadoExistente.IdEmpleado.ToString();
            txtHTrabajadas.Text = _empleadoExistente.HorasTrabajadas.ToString();
            txtDescripcion.Text = _empleadoExistente.Descripcion;
            cbxTipoJornada.SelectedItem = _empleadoExistente.TipoJornada;
            if (_empleadoExistente.HoraInicio.Year > 1900)
            {
                DtHoraInicio.Value = _empleadoExistente.HoraInicio;
            }
            else
            {
                DtHoraInicio.Value = DateTime.Now;
            }
            if (_empleadoExistente.HoraFin.Year > 1900)
            {
                DtHoraFin.Value = _empleadoExistente.HoraFin;
            }
            else
            {
               DtHoraFin.Value = DateTime.Now;
            }
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
            txtDescripcion.Clear();
            txtHTrabajadas.Clear();
            txtIdEmpleado.Clear();
            cbxTipoJornada.Enabled = false;
            DtHoraInicio.Enabled = false;
            DtHoraFin.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text) ||
                string.IsNullOrWhiteSpace(txtHTrabajadas.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||

                cbxTipoJornada.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task CrearContrato()
        {
            var nuevoContrato = new TurnoCreateDto
            {
                IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text),
                TipoJornada = cbxTipoJornada.Text,
                HorasTrabajadas = Convert.ToDecimal(txtHTrabajadas.Text),
                Descripcion = txtDescripcion.Text,
                HoraInicio = DateTime.Now,
                HoraFin = DateTime.Now
            };

            var resultado = await _apiClient.Turnos.CreateAsync(nuevoContrato);

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
            var contratoActualizado = new TurnoUpdateDto
            {
                IdTurno = _modoEdicion ? _turnoId.Value : 0,
                IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text),
                TipoJornada = cbxTipoJornada.Text,
                HorasTrabajadas = Convert.ToInt32(txtHTrabajadas.Text),
                Descripcion = txtDescripcion.Text,
                HoraInicio = DateTime.Now,
                HoraFin = DateTime.Now
            };
            var success = await _apiClient.Turnos.UpdateAsync(_empleadoExistente.IdTurno, contratoActualizado);

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
