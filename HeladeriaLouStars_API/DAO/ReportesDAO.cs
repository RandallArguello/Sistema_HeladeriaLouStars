using HeladeriaLouStars_API.Data;
using HeladeriaLouStars_API.Dto;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HeladeriaLouStars_API.DAO
{
    public class ReportesDAO
    {
        private readonly ConexionDB _conexion;

        public ReportesDAO(ConexionDB conexion)
        {
            _conexion = conexion;
        }

        public async Task<IEnumerable<ReporteEmpleadoDto>> ReporteEmpleadosAsync(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var lista = new List<ReporteEmpleadoDto>();

            using var cn = _conexion.ObtenerConexion();
            await cn.OpenAsync();

            using var cmd = new SqlCommand(Procedimientos.SP_REPORTE_EMPLEADOS, cn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@fechaInicio", (object?)fechaInicio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@fechaFin", (object?)fechaFin ?? DBNull.Value);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lista.Add(new ReporteEmpleadoDto
                {
                    IdEmpleado = Convert.ToInt32(reader["ID_Empleado"]),
                    Nombre = reader["Nombre"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    Telefono = reader["telefono"].ToString() ?? "",
                    CantidadNominas = Convert.ToInt32(reader["CantidadNominas"]),
                    TotalPagado = reader["TotalPagado"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalPagado"])
                });
            }

            return lista;
        }
    }
}
