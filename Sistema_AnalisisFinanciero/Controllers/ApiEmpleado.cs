using HeladeriaLouStars_API.Services.Interfaces;
using HeladeriaLouStarsApp.Models.Dto;
using HeladeriaLouStarsApp.Models.Repository.Interfaces;
using HeladeriaLouStarsApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HeladeriaLouStarsApp.Controllers
{
    public class ApiEmpleado
    {
        private readonly HttpClient _httpEmployee;
        public IRepository<EmpleadoDto> Empleados { get; }
        public IRepository<NominaDto> Nominas { get; }
        public IRepository<ContratoDto> Contratos { get; }
        public IRepository<TurnoDto> Turnos { get; }
        public IRepository<AdministradorDto> Administradores { get; }
        public IUserRepository LoginUsers { get; }
        public IReporteRepository Reportes { get; }

        public ApiEmpleado()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]!;
            _httpEmployee = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl)
            };
            Empleados = new Repository<EmpleadoDto>(_httpEmployee, "Empleados");
            Nominas = new Repository<NominaDto>(_httpEmployee, "Nominas");
            Contratos = new Repository<ContratoDto>(_httpEmployee, "Contratos");
            Turnos = new Repository<TurnoDto>(_httpEmployee, "Turnos");
            Administradores = new Repository<AdministradorDto>(_httpEmployee, "Administradores");
            LoginUsers = new UserRepository(_httpEmployee, "Auth/login");
            Reportes = new ReporteRepository(_httpEmployee, "Reportes/EmpleadosJson");
        }

        internal void SetAuthToken(string token)
        {
            _httpEmployee.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
