using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.Data;
using HeladeriaLouStars_API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HeladeriaLouStars_API.DAO
{
    public class ContratoDAO : RepositoryBase<Contrato>, IRepository<Contrato>
    {
        public ContratoDAO(ConexionDB conexion) : base(conexion) { }

        public override async Task<IEnumerable<Contrato>> GetAllAsync()
        {
            var lista = new List<Contrato>();

            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_LISTAR_CONTRATOS, cn)
            { CommandType = CommandType.StoredProcedure };

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var c = new Contrato
                {
                    
                    IdContrato = Convert.ToInt32(reader["ID_Contrato"]),
                    SalarioBase = reader["Salario_Base"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Salario_Base"]),
                    TipoContrato = reader["Tipo_Contrato"] == DBNull.Value ? null : Convert.ToString(reader["Tipo_Contrato"]),
                    EstadoContrato = reader["Estado"] == DBNull.Value ? null : Convert.ToString(reader["Estado"]),
                };
                if (reader.GetSchemaTable()?.Columns.Contains("Fecha_Inicio") == true && reader["Fecha_Inicio"] != DBNull.Value)
                    c.FechaInicio = Convert.ToDateTime(reader["Fecha_Inicio"]);
                lista.Add(c);
                if (reader.GetSchemaTable()?.Columns.Contains("Fecha_Fin") == true && reader["Fecha_Fin"] != DBNull.Value)
                    c.FechaFin = Convert.ToDateTime(reader["Fecha_Fin"]);
                lista.Add(c);

            }

            return lista;
        }

        public override async Task<Contrato?> GetByIdAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_OBTENER_CONTRATO_POR_ID, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Contrato", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var contrato = new Contrato
                {
                    IdContrato = Convert.ToInt32(reader["ID_Contrato"]),
                    SalarioBase = reader["Salario_Base"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Salario_Base"]),
                    TipoContrato = reader["Tipo_Contrato"] == DBNull.Value ? null : Convert.ToString(reader["Tipo_Contrato"]),
                    EstadoContrato = reader["Estado"] == DBNull.Value ? null : Convert.ToString(reader["Estado"]),
                };

                if (reader.GetSchemaTable()?.Columns.Contains("Fecha_Inicio") == true && reader["Fecha_Inicio"] != DBNull.Value)
                    contrato.FechaInicio = Convert.ToDateTime(reader["Fecha_Inicio"]);

                if (reader.GetSchemaTable()?.Columns.Contains("Fecha_Fin") == true && reader["Fecha_Fin"] != DBNull.Value)
                    contrato.FechaFin = Convert.ToDateTime(reader["Fecha_Fin"]);

                return contrato;
            }

            return null; // Cliente no encontrado
        }

        public override async Task<int> CreateAsync(Contrato c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_INSERTAR_CONTRATOS, cn)
            { CommandType = CommandType.StoredProcedure };


            cmd.Parameters.AddWithValue("@Salario_Base", c.SalarioBase);
            cmd.Parameters.AddWithValue("@Tipo_Contrato", c.TipoContrato);
            cmd.Parameters.AddWithValue("@Fecha_Inicio", c.FechaInicio);
            cmd.Parameters.AddWithValue("@Fecha_Fin", c.FechaFin);
            cmd.Parameters.AddWithValue("@Estado", c.EstadoContrato);
          


            // Si tu stored procedure devuelve el ID nuevo, usa ExecuteScalarAsync
            var result = await cmd.ExecuteScalarAsync();

            // Asignar el ID a la entidad Cliente
            if (result != null)
            {
                c.IdContrato = Convert.ToInt32(result);
                return c.IdContrato;
            }

            return 0;
        }

        public override async Task<bool> UpdateAsync(Contrato c)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ACTUALIZAR_CONTRATOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Contrato", c.IdContrato);
            cmd.Parameters.AddWithValue("@Salario_Base", c.SalarioBase);
            cmd.Parameters.AddWithValue("@Tipo_Contrato", c.TipoContrato);
            cmd.Parameters.AddWithValue("@Fecha_Inicio", c.FechaInicio);
            cmd.Parameters.AddWithValue("@Fecha_Fin", c.FechaFin);
            cmd.Parameters.AddWithValue("@Estado", c.EstadoContrato);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            using var cn = await GetOpenConnectionAsync();
            using var cmd = new SqlCommand(Procedimientos.SP_ELIMINAR_CONTRATOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@ID_Contrato", id);

            var result = await cmd.ExecuteScalarAsync();
            return result != null && Convert.ToInt32(result) == 1;
        }
    }
}
