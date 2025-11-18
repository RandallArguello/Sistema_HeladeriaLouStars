using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Models;
using HeladeriaLouStars_API.Services.Interfaces;

namespace HeladeriaLouStars_API.Services
{
        public class ContratoService : ServiceBase<Contrato>, IService<Contrato>
        {
            public ContratoService(IRepository<Contrato> repository) : base(repository) { }

            public override async Task<(bool ok, string error)> CrearAsync(Contrato c)
            {


                // Llamamos al método base para insertar
                return await base.CrearAsync(c);
            }

            public override async Task<IEnumerable<Contrato>> ListarAsync() => await base.ListarAsync();
            public override async Task<Contrato?> ObtenerPorIdAsync(int id) => await base.ObtenerPorIdAsync(id);
            public override async Task<(bool ok, string error)> ActualizarAsync(Contrato     c) => await base.ActualizarAsync(c);
            public override async Task<(bool ok, string error)> EliminarAsync(int id) => await base.EliminarAsync(id);
        }
}
