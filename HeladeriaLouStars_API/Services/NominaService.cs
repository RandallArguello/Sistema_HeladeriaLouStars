using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Models;
using HeladeriaLouStars_API.Services.Interfaces;

namespace HeladeriaLouStars_API.Services
{
    public class NominaService : ServiceBase<Nomina>, IService<Nomina>
    {
        public NominaService(IRepository<Nomina> repository) : base(repository) { }

        public override async Task<(bool ok, string error)> CrearAsync(Nomina c)
        {
    

            // Llamamos al método base para insertar
            return await base.CrearAsync(c);
        }

        public override async Task<IEnumerable<Nomina>> ListarAsync() => await base.ListarAsync();
        public override async Task<Nomina?> ObtenerPorIdAsync(int id) => await base.ObtenerPorIdAsync(id);
        public override async Task<(bool ok, string error)> ActualizarAsync(Nomina c) => await base.ActualizarAsync(c);
        public override async Task<(bool ok, string error)> EliminarAsync(int id) => await base.EliminarAsync(id);
    }
}
