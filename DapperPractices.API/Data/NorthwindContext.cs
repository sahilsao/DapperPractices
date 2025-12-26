using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperPractices.API.Data
{
    public class NorthwindContext
    {
        private readonly IConfiguration _config;

        public NorthwindContext(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_config.GetConnectionString("NorthwindConnection"));
    }
}
