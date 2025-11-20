using Newtonsoft.Json;

namespace HeladeriaLouStarsApp.Models.Dto
{
    public class ReporteEmpleadoDto
    {
        [JsonProperty("idContrato")]
        public int IdContrato { get; set; }

        [JsonProperty("idEmpleado")]
        public int IdEmpleado { get; set; }

        // PRUEBA: Diferentes nombres posibles para el campo Nombre
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Nombre")]
        public string NombreMayuscula { get; set; }

        [JsonProperty("NOMBRE")]
        public string NombreTodoMayuscula { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("empleadoNombre")]
        public string EmpleadoNombre { get; set; }

        [JsonProperty("nombreEmpleado")]
        public string NombreEmpleado { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cedula")]
        public string Cedula { get; set; }

        [JsonProperty("nacionalidad")]
        public string Nacionalidad { get; set; }

        [JsonProperty("cantidadNominas")]
        public int CantidadNominas { get; set; }

        [JsonProperty("totalPagado")]
        public decimal TotalPagado { get; set; }

        // Propiedad computada para usar el nombre correcto
        public string NombreCompleto
        {
            get
            {
                return Nombre ?? NombreMayuscula ?? NombreTodoMayuscula ??
                       Name ?? EmpleadoNombre ?? NombreEmpleado ?? "Sin nombre";
            }
        }
    }
}
