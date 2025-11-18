using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Models;
using HeladeriaLouStars_API.Services.Interfaces;

namespace HeladeriaLouStars_API.Services
{
    public class TurnoService : ServiceBase<Turno>, IService<Turno>
    {
        public TurnoService(IRepository<Turno> repository) : base(repository) { }

        public override async Task<(bool ok, string error)> CrearAsync(Turno c)
        {


            // Llamamos al método base para insertar
            return await base.CrearAsync(c);
        }

        public override async Task<IEnumerable<Turno>> ListarAsync() => await base.ListarAsync();
        public override async Task<Turno?> ObtenerPorIdAsync(int id) => await base.ObtenerPorIdAsync(id);
        public override async Task<(bool ok, string error)> ActualizarAsync(Turno c) => await base.ActualizarAsync(c);
        public override async Task<(bool ok, string error)> EliminarAsync(int id) => await base.EliminarAsync(id);
    }
}
