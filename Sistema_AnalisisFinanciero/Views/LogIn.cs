using HeladeriaLouStarsApp.Controllers;
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
    public partial class LogIn : Form
    {
        private readonly ApiEmpleado _apiLouStars;
        public LogIn()
        {
            InitializeComponent();
            _apiLouStars = new ApiEmpleado();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private async Task LoginAsync()
        {
            string username = textUser.Text.Trim();
            string password = textPassword.Text.Trim();

            try
            {
                var token = await _apiLouStars.LoginUsers.ValidateCredentialsAsync(username, password);

                if (!string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Inicio de sesión exitoso.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Guardar el token en ApiClient para futuras solicitudes
                    _apiLouStars.SetAuthToken(token);

                    this.Hide();
                    Bienvenida bienvenida = new Bienvenida();
                    bienvenida.ShowDialog();
                    var mainForm = new FormHome(_apiLouStars);
                    mainForm.Show();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"No se pudo conectar con el servidor. Detalles: {ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("La solicitud al servidor tardó demasiado. Intente de nuevo más tarde.",
                    "Tiempo de espera agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión:\n{ex.Message}",
                    "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }
    }
}
