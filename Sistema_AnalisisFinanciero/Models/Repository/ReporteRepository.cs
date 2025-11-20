using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ClosedXML.Excel;
using HeladeriaLouStars_API.Services.Interfaces;
using HeladeriaLouStarsApp.Models.Dto;

namespace HeladeriaLouStarsApp.Models.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly HttpClient _httpEmployee;
        private readonly string _endpoint;
        private readonly bool _usarModoPrueba;

        public ReporteRepository(HttpClient httpEmployee, string endpoint)
        {
            _httpEmployee = httpEmployee;
            _endpoint = endpoint;
            _usarModoPrueba = true; // Cambiar a false cuando el backend esté listo
        }

        public async Task<IEnumerable<ReporteEmpleadoDto>> ObtenerReporteEmpleados(DateTime? inicio, DateTime? fin)
        {
            if (_usarModoPrueba)
            {
                Console.WriteLine("🔧 MODO PRUEBA: Usando datos de prueba (Backend con error)");
                return await GenerarDatosPruebaConFechas(inicio, fin);
            }

            try
            {
                var url = _endpoint;

                var queryParams = new List<string>();
                if (inicio.HasValue)
                    queryParams.Add($"fechaInicio={inicio.Value:yyyy-MM-dd}");
                if (fin.HasValue)
                    queryParams.Add($"fechaFin={fin.Value:yyyy-MM-dd}");

                if (queryParams.Any())
                    url += "?" + string.Join("&", queryParams);

                var response = await _httpEmployee.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error del servidor: {response.StatusCode} - {errorContent}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<ReporteEmpleadoDto>>(json);

                return items ?? Enumerable.Empty<ReporteEmpleadoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error conectando al backend: {ex.Message}");
                return await GenerarDatosPruebaConFechas(inicio, fin);
            }
        }

        private async Task<List<ReporteEmpleadoDto>> GenerarDatosPruebaConFechas(DateTime? inicio, DateTime? fin)
        {
                await Task.Delay(300);

            var datos = new List<ReporteEmpleadoDto>
        {
            new ReporteEmpleadoDto
            {
                IdContrato = 1,
                IdEmpleado = 101,
                Nombre = "Juan Pérez",
                Telefono = "123-456-7890",
                Email = "juan@email.com",
                Cedula = "12345678A",
                Nacionalidad = "Mexicana",
                CantidadNominas = 5,
                TotalPagado = 15000.50m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 2,
                IdEmpleado = 102,
                Nombre = "María García",
                Telefono = "234-567-8901",
                Email = "maria@email.com",
                Cedula = "23456789B",
                Nacionalidad = "Española",
                CantidadNominas = 8,
                TotalPagado = 22000.75m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 3,
                IdEmpleado = 103,
                Nombre = "Carlos López",
                Telefono = "345-678-9012",
                Email = "carlos@email.com",
                Cedula = "34567890C",
                Nacionalidad = "Colombiana",
                CantidadNominas = 12,
                TotalPagado = 32000.25m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 4,
                IdEmpleado = 104,
                Nombre = "Ana Martínez",
                Telefono = "456-789-0123",
                Email = "ana@email.com",
                Cedula = "45678901D",
                Nacionalidad = "Argentina",
                CantidadNominas = 6,
                TotalPagado = 18000.80m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 5,
                IdEmpleado = 105,
                Nombre = "Pedro Rodríguez",
                Telefono = "567-890-1234",
                Email = "pedro@email.com",
                Cedula = "56789012E",
                Nacionalidad = "Chilena",
                CantidadNominas = 15,
                TotalPagado = 41000.35m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 6,
                IdEmpleado = 106,
                Nombre = "Laura Hernández",
                Telefono = "678-901-2345",
                Email = "laura@email.com",
                Cedula = "67890123F",
                Nacionalidad = "Peruana",
                CantidadNominas = 9,
                TotalPagado = 25000.60m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 7,
                IdEmpleado = 107,
                Nombre = "Miguel Torres",
                Telefono = "789-012-3456",
                Email = "miguel@email.com",
                Cedula = "78901234G",
                Nacionalidad = "Venezolana",
                CantidadNominas = 18,
                TotalPagado = 48500.90m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 8,
                IdEmpleado = 108,
                Nombre = "Elena Díaz",
                Telefono = "890-123-4567",
                Email = "elena@email.com",
                Cedula = "89012345H",
                Nacionalidad = "Ecuatoriana",
                CantidadNominas = 7,
                TotalPagado = 19500.45m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 9,
                IdEmpleado = 109,
                Nombre = "Roberto Silva",
                Telefono = "901-234-5678",
                Email = "roberto@email.com",
                Cedula = "90123456I",
                Nacionalidad = "Uruguaya",
                CantidadNominas = 11,
                TotalPagado = 29800.20m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 10,
                IdEmpleado = 110,
                Nombre = "Carmen Vargas",
                Telefono = "012-345-6789",
                Email = "carmen@email.com",
                Cedula = "01234567J",
                Nacionalidad = "Paraguaya",
                CantidadNominas = 14,
                TotalPagado = 37500.75m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 11,
                IdEmpleado = 111,
                Nombre = "Fernando Castro",
                Telefono = "123-987-6543",
                Email = "fernando@email.com",
                Cedula = "98765432K",
                Nacionalidad = "Boliviana",
                CantidadNominas = 4,
                TotalPagado = 12000.40m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 12,
                IdEmpleado = 112,
                Nombre = "Patricia Morales",
                Telefono = "234-876-5432",
                Email = "patricia@email.com",
                Cedula = "87654321L",
                Nacionalidad = "Costarricense",
                CantidadNominas = 10,
                TotalPagado = 26500.85m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 13,
                IdEmpleado = 113,
                Nombre = "Javier Ríos",
                Telefono = "345-765-4321",
                Email = "javier@email.com",
                Cedula = "76543210M",
                Nacionalidad = "Panameña",
                CantidadNominas = 16,
                TotalPagado = 43200.95m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 14,
                IdEmpleado = 114,
                Nombre = "Sofía Núñez",
                Telefono = "456-654-3210",
                Email = "sofia@email.com",
                Cedula = "65432109N",
                Nacionalidad = "Dominicana",
                CantidadNominas = 8,
                TotalPagado = 21500.30m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 15,
                IdEmpleado = 115,
                Nombre = "Ricardo Peña",
                Telefono = "567-543-2109",
                Email = "ricardo@email.com",
                Cedula = "54321098O",
                Nacionalidad = "Guatemalteca",
                CantidadNominas = 13,
                TotalPagado = 34800.65m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 16,
                IdEmpleado = 116,
                Nombre = "Gabriela Soto",
                Telefono = "678-432-1098",
                Email = "gabriela@email.com",
                Cedula = "43210987P",
                Nacionalidad = "Salvadoreña",
                CantidadNominas = 17,
                TotalPagado = 45800.10m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 17,
                IdEmpleado = 117,
                Nombre = "Diego Reyes",
                Telefono = "789-321-0987",
                Email = "diego@email.com",
                Cedula = "32109876Q",
                Nacionalidad = "Hondureña",
                CantidadNominas = 6,
                TotalPagado = 16800.80m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 18,
                IdEmpleado = 118,
                Nombre = "Adriana Mendoza",
                Telefono = "890-210-9876",
                Email = "adriana@email.com",
                Cedula = "21098765R",
                Nacionalidad = "Nicaragüense",
                CantidadNominas = 19,
                TotalPagado = 51200.55m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 19,
                IdEmpleado = 119,
                Nombre = "Oscar Guerrero",
                Telefono = "901-109-8765",
                Email = "oscar@email.com",
                Cedula = "10987654S",
                Nacionalidad = "Puertorriqueña",
                CantidadNominas = 9,
                TotalPagado = 24200.25m
            },
            new ReporteEmpleadoDto
            {
                IdContrato = 20,
                IdEmpleado = 120,
                Nombre = "Isabel Cordero",
                Telefono = "012-098-7654",
                Email = "isabel@email.com",
                Cedula = "09876543T",
                Nacionalidad = "Cubana",
                CantidadNominas = 21,
                TotalPagado = 56800.70m
            }
        };

            Console.WriteLine($"🔧 Datos de prueba generados: {datos.Count} registros");

                Console.WriteLine("📊 Resumen de datos de prueba:");
            Console.WriteLine($"   • Total pagado máximo: {datos.Max(d => d.TotalPagado):C}");
            Console.WriteLine($"   • Total pagado mínimo: {datos.Min(d => d.TotalPagado):C}");
            Console.WriteLine($"   • Promedio nóminas: {datos.Average(d => d.CantidadNominas):F1}");
            Console.WriteLine($"   • Nacionalidades: {datos.Select(d => d.Nacionalidad).Distinct().Count()}");

            return datos;
        }
    }
}