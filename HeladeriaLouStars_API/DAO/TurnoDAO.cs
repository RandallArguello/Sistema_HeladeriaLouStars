using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Data;
using HeladeriaLouStars_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HeladeriaLouStars_API.DAO
{
    public class TurnoDAO : RepositoryBase<Turno>, IRepository<Turno>
    {
        public TurnoDAO(ConexionDB conexion) : base(conexion) { }

        public override async Task<IEnumerable<Turno>> GetAllAsync()
        {
            var lista = new List<Turno>();

            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_LISTAR_TURNOS, cn)
            { CommandType = CommandType.StoredProcedure };

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var c = new Turno
                {
                   
                    IdTurno = Convert.ToInt32(reader["ID_Turno"]),
                    IdEmpleado = Convert.ToInt32(reader["ID_Empleado"]),
                    Descripcion = reader["Descripción"] == DBNull.Value ? null : Convert.ToString(reader["Descripción"]),
                    HorasTrabajadas = reader["Horas_Trabajadas"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Horas_Trabajadas"]),
                    TipoJornada = reader["Tipo_Jornada"] == DBNull.Value ? null : Convert.ToString(reader["Tipo_Jornada"]), 
                };
                if (reader.GetSchemaTable()?.Columns.Contains("Hora_Inicio") == true && reader["Hora_Inicio"] != DBNull.Value)
                    c.HoraInicio = Convert.ToDateTime(reader["Hora_Inicio"]);
                lista.Add(c);
                if (reader.GetSchemaTable()?.Columns.Contains("Hora_Fin") == true && reader["Hora_Fin"] != DBNull.Value)
                    c.HoraFin = Convert.ToDateTime(reader["Hora_Fin"]);
                lista.Add(c);

            }

            return lista;
        }

        public override async Task<Turno?> GetByIdAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_OBTENER_TURNO_POR_ID, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Turno", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var turno = new Turno
                {
                    IdTurno = Convert.ToInt32(reader["ID_Turno"]),
                    IdEmpleado = Convert.ToInt32(reader["ID_Empleado"]),
                    Descripcion = reader["Descripción"] == DBNull.Value ? null : Convert.ToString(reader["Descripción"]),
                    HorasTrabajadas = reader["Horas_Trabajadas"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Horas_Trabajadas"]),
                    TipoJornada = reader["Tipo_Jornada"] == DBNull.Value ? null : Convert.ToString(reader["Tipo_Jornada"]),
                };

                if (reader.GetSchemaTable()?.Columns.Contains("Hora_Inicio") == true && reader["Hora_Inicio"] != DBNull.Value)
                    turno.HoraInicio = Convert.ToDateTime(reader["Hora_Inicio"]);

                if (reader.GetSchemaTable()?.Columns.Contains("Hora_Fin") == true && reader["Hora_Fin"] != DBNull.Value)
                    turno.HoraFin = Convert.ToDateTime(reader["Hora_Fin"]);

                return turno;
            }

            return null; // Cliente no encontrado
        }

        public override async Task<int> CreateAsync(Turno c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_INSERTAR_TURNOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Empleado", c.IdEmpleado);
            cmd.Parameters.AddWithValue("@Hora_Inicio", c.HoraInicio);
            cmd.Parameters.AddWithValue("@Hora_Fin", c.HoraFin);
            cmd.Parameters.AddWithValue("@Descripción", c.Descripcion);
            cmd.Parameters.AddWithValue("@Horas_Trabajadas", c.HorasTrabajadas);
            cmd.Parameters.AddWithValue("@Tipo_Jornada", c.TipoJornada);



            // Si tu stored procedure devuelve el ID nuevo, usa ExecuteScalarAsync
            var result = await cmd.ExecuteScalarAsync();

            // Asignar el ID a la entidad Cliente
            if (result != null)
            {
                c.IdTurno = Convert.ToInt32(result);
                return c.IdTurno;
            }

            return 0;
        }

        public override async Task<bool> UpdateAsync(Turno c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ACTUALIZAR_TURNOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Turno", c.IdTurno);
            cmd.Parameters.AddWithValue("@ID_Empleado", c.IdEmpleado);
            cmd.Parameters.AddWithValue("@Hora_Inicio", c.HoraInicio);
            cmd.Parameters.AddWithValue("@Hora_Fin", c.HoraFin);
            cmd.Parameters.AddWithValue("@Descripción", c.Descripcion);
            cmd.Parameters.AddWithValue("@Horas_Trabajadas", c.HorasTrabajadas);
            cmd.Parameters.AddWithValue("@Tipo_Jornada", c.TipoJornada);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ELIMINAR_TURNOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Turno", id);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }
    }
}
