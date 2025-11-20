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
    public partial class AgregarContrato : Form
    {
        private int? _contratoId;
        private readonly ApiEmpleado _apiClient;
        private readonly Func<Task> _recargarListaEmpleados;

        private readonly ContratoDto _empleadoExistente;
        private readonly bool _modoEdicion;
        public AgregarContrato(ApiEmpleado apiClient, Func<Task> recargarListaEmpleados, ContratoDto empleadoExistente = null)
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
                _contratoId = empleadoExistente.IdContrato;
                CargarDatosEmpleado(empleadoExistente);
            }
        }
        private void CargarDatosEmpleado(ContratoDto empleado)
        {

            txtSalarioBase.Text = _empleadoExistente.SalarioBase.ToString();
            cbxTipoContrato.SelectedItem = _empleadoExistente.TipoContrato;
            cbxEstado.SelectedItem = _empleadoExistente.EstadoContrato;
            if (_empleadoExistente.FechaInicio.Year > 1900)
            {
                DtFechaInicio.Value = _empleadoExistente.FechaInicio;
            }
            else
            {
                DtFechaInicio.Value = DateTime.Today;
            }
            
            if (empleado.FechaFin > DateTime.MinValue)
            {
                DtFechaFin.Value = empleado.FechaFin;
            }
            else
            {
                DtFechaFin.Value = DateTime.Today; // Valor por defecto
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
            txtSalarioBase.Clear();
            cbxEstado.Enabled = false;
            cbxTipoContrato.Enabled = false;
            DtFechaInicio.Enabled = false;
            DtFechaFin.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtSalarioBase.Text) ||

                cbxTipoContrato.SelectedItem == null ||
                cbxEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private async Task CrearContrato()
        {
            var nuevoContrato = new ContratoCreateDto
            {
                SalarioBase = Convert.ToDecimal(txtSalarioBase.Text),
                TipoContrato = cbxTipoContrato.Text,
                EstadoContrato = cbxEstado.Text,
                FechaInicio = DtFechaInicio.Value,
                FechaFin = DtFechaFin.Value
            };

            var resultado = await _apiClient.Contratos.CreateAsync(nuevoContrato);

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
            var contratoActualizado = new ContratoUpdateDto
            {
                IdContrato = _modoEdicion ? _contratoId.Value : 0,
                SalarioBase = Convert.ToDecimal(txtSalarioBase.Text),
                TipoContrato = cbxTipoContrato.Text,
                EstadoContrato = cbxEstado.Text,
                FechaInicio = DtFechaInicio.Value,
                FechaFin = DtFechaFin.Value
            };
            var success = await _apiClient.Contratos.UpdateAsync(_empleadoExistente.IdContrato, contratoActualizado);

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

        private void AgregarContrato_Load(object sender, EventArgs e)
        {

        }
    }
}
