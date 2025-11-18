using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Models;
using HeladeriaLouStars_API.Services.Interfaces;

namespace HeladeriaLouStars_API.Services
{
    public class AdminService : ServiceBase<Administrador>, IService<Administrador>
    {
        public AdminService(IRepository<Administrador> repository) : base(repository) { }

        public override async Task<(bool ok, string error)> CrearAsync(Administrador c)
        {


            // Llamamos al método base para insertar
            return await base.CrearAsync(c);
        }

        public override async Task<IEnumerable<Administrador>> ListarAsync() => await base.ListarAsync();
        public override async Task<Administrador?> ObtenerPorIdAsync(int id) => await base.ObtenerPorIdAsync(id);
        public override async Task<(bool ok, string error)> ActualizarAsync(Administrador c) => await base.ActualizarAsync(c);
        public override async Task<(bool ok, string error)> EliminarAsync(int id) => await base.EliminarAsync(id);
    }
}
