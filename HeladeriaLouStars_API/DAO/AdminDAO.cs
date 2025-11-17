using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Data;
using HeladeriaLouStars_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HeladeriaLouStars_API.DAO
{
    public class AdminDAO : RepositoryBase<Administrador>, IRepository<Administrador>
    {
        public AdminDAO(ConexionDB conexion) : base(conexion) { }

        public override async Task<IEnumerable<Administrador>> GetAllAsync()
        {
            var lista = new List<Administrador>();

            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_LISTAR_ADMINISTRADORES, cn)
            { CommandType = CommandType.StoredProcedure };

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var c = new Administrador
                {
                    IdAdministrador = Convert.ToInt32(reader["ID_Administrador"]),
                    NombreUsuario = reader["Nombre_Usuario"].ToString() ?? "",
                    Correo = reader["Correo"].ToString() ?? "",
                    Contraseña = reader["Contraseña"].ToString() ?? "",
                };
            }

            return lista;
        }

        public override async Task<Administrador?> GetByIdAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_OBTENER_ADMINISTRADOR_POR_ID, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Administrador", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var administrador = new Administrador
                {
                    IdAdministrador = Convert.ToInt32(reader["ID_Administrador"]),
                    NombreUsuario = reader["Nombre_Usuario"].ToString() ?? "",
                    Correo = reader["Correo"].ToString() ?? "",
                    Contraseña = reader["Contraseña"].ToString() ?? "",
                };

                return administrador;
            }

            return null; // Cliente no encontrado
        }

        public override async Task<int> CreateAsync(Administrador c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_INSERTAR_ADMINISTRADOR, cn)
            { CommandType = CommandType.StoredProcedure };


            cmd.Parameters.AddWithValue("@Nombre_Usuario", c.NombreUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", c.Contraseña);
            cmd.Parameters.AddWithValue("@Correo", c.Correo);

            // Si tu stored procedure devuelve el ID nuevo, usa ExecuteScalarAsync
            var result = await cmd.ExecuteScalarAsync();

            // Asignar el ID a la entidad Cliente
            if (result != null)
            {
                c.IdAdministrador = Convert.ToInt32(result);
                return c.IdAdministrador;
            }

            return 0;
        }

        public override async Task<bool> UpdateAsync(Administrador c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ACTUALIZAR_ADMINISTRADORES, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Nombre_Usuario", c.NombreUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", c.Contraseña);
            cmd.Parameters.AddWithValue("@Correo", c.Correo);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ELIMINAR_ADMINISTRADORES, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Administrador", id);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }
    }
}
