using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Models;
using HeladeriaLouStars_API.Services.Interfaces;

namespace HeladeriaLouStars_API.Services
{
    public class EmpleadoService : ServiceBase<Empleado>, IService<Empleado>
    {
        public EmpleadoService(IRepository<Empleado> repository) : base(repository) { }

        public override async Task<(bool ok, string error)> CrearAsync(Empleado c)
        {
            // Validación 1: Campos obligatorios
            if (string.IsNullOrWhiteSpace(c.Nombre) || string.IsNullOrWhiteSpace(c.Apellido))
                return (false, "Nombre y apellido son obligatorios.");

            // Validación 2: Regla de negocio específica
            if (!string.IsNullOrWhiteSpace(c.Email) &&
                c.Email.EndsWith("@example.com", StringComparison.OrdinalIgnoreCase))
                return (false, "Dominios de correo no válidos para registro.");

            // Llamamos al método base para insertar
            return await base.CrearAsync(c);
        }

        public override async Task<IEnumerable<Empleado>> ListarAsync() => await base.ListarAsync();
        public override async Task<Empleado?> ObtenerPorIdAsync(int id) => await base.ObtenerPorIdAsync(id);
        public override async Task<(bool ok, string error)> ActualizarAsync(Empleado c) => await base.ActualizarAsync(c);
        public override async Task<(bool ok, string error)> EliminarAsync(int id) => await base.EliminarAsync(id);
    }
}
