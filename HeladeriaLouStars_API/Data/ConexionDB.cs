using Microsoft.Data.SqlClient;

namespace HeladeriaLouStars_API.Data
{
    public class ConexionDB
    {
        private readonly string _cadenaSQL;

        public ConexionDB(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("CadenaSQL")!;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaSQL);
        }
    }
}
