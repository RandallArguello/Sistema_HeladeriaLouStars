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
    public partial class AgregarNomina : Form
    {
        private int? _nominaId;
        private readonly ApiEmpleado _apiClient;
        private readonly Func<Task> _recargarListaNominas;

        private readonly NominaDto _nominaExistente;
        private readonly bool _modoEdicion;
        public AgregarNomina(ApiEmpleado apiClient, Func<Task> recargarListaNominas, NominaDto nominaExistente = null)
        {
            InitializeComponent();
            _nominaExistente = nominaExistente;
            _apiClient = apiClient;
            _recargarListaNominas = recargarListaNominas;

            _modoEdicion = nominaExistente != null;

            this.Text = _modoEdicion ? "Editar Nomina" : "Agregar Nomina";

            // Si estamos en modo edición, cargar los datos
            if (_modoEdicion && nominaExistente != null)
            {
                _nominaId = nominaExistente.NominaID;
                CargarDatosNomina(nominaExistente);
            }
        }
        private void CargarDatosNomina(NominaDto nominaExistente)
        {
            txtEmpleadoID.Text = _nominaExistente.EmpleadoID.ToString();
            txtAdminId.Text = _nominaExistente.AdministradorID.ToString();
            txtBonificaciones.Text = _nominaExistente.Bonificaciones.ToString();
            if (nominaExistente.Periodo > DateTime.MinValue)
            {
                DtPeriodo.Value = nominaExistente.Periodo;
            }
            else
            {
                DtPeriodo.Value = DateTime.Today; // Valor por defecto
            }
            txtHorasExtra.Text = _nominaExistente.HorasExtra.ToString();
            txtAntiguedad.Text = _nominaExistente.Antiguedad.ToString();
            txtSalarioMensual.Text = _nominaExistente.SalarioDevengado.ToString();
        }
        private void AgregarNomina_Load(object sender, EventArgs e)
        {

        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtAdminId.Text) ||
                string.IsNullOrWhiteSpace(txtBonificaciones.Text) ||
                string.IsNullOrWhiteSpace(txtEmpleadoID.Text) ||
                string.IsNullOrWhiteSpace(txtHorasExtra.Text) ||
                string.IsNullOrWhiteSpace(DtPeriodo.Text) ||
                string.IsNullOrWhiteSpace(txtSalarioMensual.Text) ||
                string.IsNullOrWhiteSpace(txtAntiguedad.Text))

            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.",
                              "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtSalarioMensual.Text.Trim(), out decimal salario) || salario < 0)
            {
                MessageBox.Show("Salario mensual debe ser un número decimal positivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            if (!decimal.TryParse(txtHorasExtra.Text.Trim(), out decimal horasExtra) || horasExtra < 0)
            {

                MessageBox.Show("Horas extra debe ser un número decimal positivo o cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            if (!decimal.TryParse(txtAntiguedad.Text.Trim(), out decimal antiguedad) || antiguedad < 0)
            {
                MessageBox.Show("Antigüedad debe ser un número entero positivo o cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            return true;
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
                    await ActualizarNomina();
                }
                else
                {
                    await CrearNomina();

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
            txtAdminId.Clear();
            txtEmpleadoID.Clear();
            txtBonificaciones.Clear();
            DtPeriodo.Enabled = false;
            txtHorasExtra.Clear();
            txtAntiguedad.Clear();
            txtSalarioMensual.Clear();
        }

        private async Task CrearNomina()
        {
            var nuevaNomina = new NominaCreateDto
            {
                AdministradorID = Convert.ToInt32(txtAdminId.Text),
                EmpleadoID = Convert.ToInt32(txtEmpleadoID.Text),
                Bonificaciones = Convert.ToDecimal(txtBonificaciones.Text),
                Periodo = DateTime.Now,
                HorasExtra = Convert.ToDecimal(txtHorasExtra.Text),
                Antiguedad = Convert.ToDecimal(txtAntiguedad.Text),
                SalarioDevengado = Convert.ToDecimal(txtSalarioMensual.Text),
            };

            var resultado = await _apiClient.Nominas.CreateAsync(nuevaNomina);

            if (resultado != null)
            {
                await _recargarListaNominas();
                MessageBox.Show("Nomina creado exitosamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo crear la nomina.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarNomina()
        {
            var nominaActualizada = new NominaUpdateDto
            {
                AdministradorID = Convert.ToInt32(txtAdminId.Text),
                NominaID = _modoEdicion ? _nominaId.Value : 0,
                EmpleadoID = Convert.ToInt32(txtEmpleadoID.Text),
                Bonificaciones = Convert.ToDecimal(txtBonificaciones.Text),
                Periodo = DateTime.Now,
                HorasExtra = Convert.ToDecimal(txtHorasExtra.Text),
                Antiguedad = Convert.ToDecimal(txtAntiguedad.Text),
                SalarioDevengado = Convert.ToDecimal(txtSalarioMensual.Text),
            };
            var success = await _apiClient.Nominas.UpdateAsync(_nominaExistente.NominaID, nominaActualizada);

            if (success)
            {
                await _recargarListaNominas();
                MessageBox.Show("Nomina actualizada exitosamente", "Éxito",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la nomina.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
