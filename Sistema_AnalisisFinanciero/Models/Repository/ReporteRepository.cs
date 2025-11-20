using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HeladeriaLouStars_API.Services.Interfaces;
using HeladeriaLouStarsApp.Models.Dto;

namespace HeladeriaLouStarsApp.Models.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly HttpClient _httpEmployee;
        private readonly string _endpoint;

        public ReporteRepository(HttpClient httpEmployee, string endpoint)
        {
            _httpEmployee = httpEmployee;
            _endpoint = endpoint;
        }

        public async Task<IEnumerable<ReporteEmpleadoDto>> ObtenerReporteEmpleados(DateTime? inicio, DateTime? fin)
        {
            var url = _endpoint;

            var queryParams = new List<string>();
            if (inicio.HasValue)
                queryParams.Add($"fechaInicio={inicio.Value:yyyy-MM-dd}");
            if (fin.HasValue)
                queryParams.Add($"fechaFin={fin.Value:yyyy-MM-dd}");

            if (queryParams.Any())
                url += "?" + string.Join("&", queryParams);

            // Realiza la solicitud HTTP GET
            var response = await _httpEmployee.GetAsync(url);

            if (inicio.HasValue && fin.HasValue && inicio > fin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }

            // Leer contenido y deserializar usando Newtonsoft.Json
            var json = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<ReporteEmpleadoDto>(json);
            return item != null ? new List<ReporteEmpleadoDto> { item } : Enumerable.Empty<ReporteEmpleadoDto>();

        }

   

    }
}
