using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Data;
using HeladeriaLouStars_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HeladeriaLouStars_API.DAO
{
    public class NominaDAO : RepositoryBase<Nomina>, IRepository<Nomina>
    {
        public NominaDAO(ConexionDB conexion) : base(conexion) { }

        public override async Task<IEnumerable<Nomina>> GetAllAsync()
        {
            var lista = new List<Nomina>();

            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_LISTAR_NOMINAS, cn)
            { CommandType = CommandType.StoredProcedure };

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var c = new Nomina
                {
                    AdministradorID = Convert.ToInt32(reader["ID_Administrador"]),
                    EmpleadoID = Convert.ToInt32(reader["ID_Empleado"]),
                    NominaID = Convert.ToInt32(reader["ID_Nomina"]),
                    HorasExtra = reader["Horas_Extra"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Horas_Extra"]),
                    Antiguedad = reader["Antiguedad"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Antiguedad"]),
                    Deducciones = reader["Deducciones"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Deducciones"]),
                    SalarioDevengado = reader["Salario_Devengado"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Salario_Devengado"]),
                    Bonificaciones = reader["Bonificaciones"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Bonificaciones"]),
                };
                if (reader.GetSchemaTable()?.Columns.Contains("Periodo") == true && reader["Periodo"] != DBNull.Value)
                    c.Periodo = Convert.ToDateTime(reader["Periodo"]);
                lista.Add(c);
                
            }

            return lista;
        }

        public override async Task<Nomina?> GetByIdAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_OBTENER_NOMINA_POR_ID, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Nomina", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var nomina = new Nomina
                {
                    AdministradorID = Convert.ToInt32(reader["ID_Administrador"]),
                    EmpleadoID = Convert.ToInt32(reader["ID_Empleado"]),
                    NominaID = Convert.ToInt32(reader["ID_Nomina"]),
                    HorasExtra = reader["Horas_Extra"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Horas_Extra"]),
                    Antiguedad = reader["Antiguedad"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Antiguedad"]),
                    Deducciones = reader["Deducciones"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Deducciones"]),
                    SalarioDevengado = reader["Salario_Devengado"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Salario_Devengado"]),
                    Bonificaciones = reader["Bonificaciones"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Bonificaciones"]),
                };

                if (reader.GetSchemaTable()?.Columns.Contains("Periodo") == true && reader["Periodo"] != DBNull.Value)
                    nomina.Periodo = Convert.ToDateTime(reader["Periodo"]);

                return nomina;
            }

            return null; // Cliente no encontrado
        }

        public override async Task<int> CreateAsync(Nomina c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_INSERTAR_NOMINAS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Administrador", c.AdministradorID);
            cmd.Parameters.AddWithValue("@ID_Empleado", c.EmpleadoID);
            cmd.Parameters.AddWithValue("@Periodo", c.Periodo);
            cmd.Parameters.AddWithValue("@Horas_Extra", c.HorasExtra);
            cmd.Parameters.AddWithValue("@Antiguedad", c.Antiguedad);
            cmd.Parameters.AddWithValue("@Deducciones", c.Deducciones);
            cmd.Parameters.AddWithValue("@Salario_Devengado", c.SalarioDevengado);
            cmd.Parameters.AddWithValue("@Bonificaciones", c.Bonificaciones);
           

            // Si tu stored procedure devuelve el ID nuevo, usa ExecuteScalarAsync
            var result = await cmd.ExecuteScalarAsync();

            // Asignar el ID a la entidad Cliente
            if (result != null)
            {
                c.NominaID = Convert.ToInt32(result);
                return c.NominaID;
            }

            return 0;
        }

        public override async Task<bool> UpdateAsync(Nomina c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ACTUALIZAR_NOMINAS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Nomina", c.NominaID);
            cmd.Parameters.AddWithValue("@ID_Administrador", c.AdministradorID);
            cmd.Parameters.AddWithValue("@ID_Empleado", c.EmpleadoID);
            cmd.Parameters.AddWithValue("@Periodo", c.Periodo);
            cmd.Parameters.AddWithValue("@Horas_Extra", c.HorasExtra);
            cmd.Parameters.AddWithValue("@Antiguedad", c.Antiguedad);
            cmd.Parameters.AddWithValue("@Deducciones", c.Deducciones);
            cmd.Parameters.AddWithValue("@Salario_Devengado", c.SalarioDevengado);
            cmd.Parameters.AddWithValue("@Bonificaciones", c.Bonificaciones);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ELIMINAR_NOMINAS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Nomina", id);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }
    }
}
