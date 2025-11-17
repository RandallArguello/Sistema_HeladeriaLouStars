using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Data;
using HeladeriaLouStars_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HeladeriaLouStars_API.DAO
{
    public class EmpleadoDAO : RepositoryBase<Empleado>, IRepository<Empleado>
    {
        public EmpleadoDAO(ConexionDB conexion) : base(conexion) { }

        public override async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            var lista = new List<Empleado>();

            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_LISTAR_EMPLEADOS, cn)
            { CommandType = CommandType.StoredProcedure };

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var c = new Empleado
                {
                    IdEmpleado = Convert.ToInt32(reader["ID_Empleado"]),
                    IdContrato = Convert.ToInt32(reader["ID_Contrato"]),
                    Nombre = reader["Nombre"].ToString() ?? "",
                    Apellido = reader["Apellido"].ToString() ?? "",
                    Cedula = reader["Cédula"].ToString() ?? "",
                    Genero = reader["Género"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    Direccion = reader["Direccion"].ToString() ?? "",
                    Nacionalidad = reader["Nacionalidad"].ToString() ?? "",
                    Telefono = reader["Teléfono"] == DBNull.Value ? null : reader["Teléfono"].ToString(),
                };
                if (reader.GetSchemaTable()?.Columns.Contains("fecha_nacimiento") == true && reader["fecha_nacimiento"] != DBNull.Value)
                    c.FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]);
                lista.Add(c);
                if (reader.GetSchemaTable()?.Columns.Contains("fecha_ingreso") == true && reader["fecha_ingreso"] != DBNull.Value)
                    c.FechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]);
                lista.Add(c);
            }

            return lista;
        }

        public override async Task<Empleado?> GetByIdAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_OBTENER_EMPLEADO_POR_ID, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Empleado", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var empleado = new Empleado
                {
                   IdEmpleado = Convert.ToInt32(reader["ID_Empleado"]),
                    IdContrato = Convert.ToInt32(reader["ID_Contrato"]),
                    Nombre = reader["Nombre"].ToString() ?? "",
                    Apellido = reader["Apellido"].ToString() ?? "",
                    Cedula = reader["Cédula"].ToString() ?? "",
                    Genero = reader["Género"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    Direccion = reader["Direccion"].ToString() ?? "",
                    Nacionalidad= reader["Nacionalidad"].ToString() ?? "",
                    Telefono = reader["Teléfono"] == DBNull.Value ? null : reader["Teléfono"].ToString(),
                };

                if (reader.GetSchemaTable()?.Columns.Contains("fecha_nacimiento") == true && reader["fecha_nacimiento"] != DBNull.Value)
                    empleado.FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]);

                return empleado;
            }

            return null; // Cliente no encontrado
        }

        public override async Task<int> CreateAsync(Empleado c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_INSERTAR_EMPLEADOS, cn)
            { CommandType = CommandType.StoredProcedure };


            cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
            cmd.Parameters.AddWithValue("@Cédula", c.Cedula);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Género", c.Genero);
            cmd.Parameters.AddWithValue("@Nacionalidad", c.Nacionalidad);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", (object?)c.FechaNacimiento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@fecha_ingreso", c.FechaIngreso);
            cmd.Parameters.AddWithValue("@Teléfono", (object?)c.Telefono ?? DBNull.Value);

            // Si tu stored procedure devuelve el ID nuevo, usa ExecuteScalarAsync
            var result = await cmd.ExecuteScalarAsync();

            // Asignar el ID a la entidad Cliente
            if (result != null)
            {
                c.IdEmpleado = Convert.ToInt32(result);
                return c.IdEmpleado;
            }

            return 0;
        }

        public override async Task<bool> UpdateAsync(Empleado c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ACTUALIZAR_EMPLEADOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
            cmd.Parameters.AddWithValue("@Cédula", c.Cedula);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.Parameters.AddWithValue("@Género", c.Genero);
            cmd.Parameters.AddWithValue("@Nacionalidad", c.Nacionalidad);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", (object?)c.FechaNacimiento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@fecha_ingreso", c.FechaIngreso);
            cmd.Parameters.AddWithValue("@Teléfono", (object?)c.Telefono ?? DBNull.Value);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ELIMINAR_EMPLEADOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Empleado", id);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }
    }
}

