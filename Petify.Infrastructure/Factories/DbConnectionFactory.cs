using System.Data;
using Microsoft.Data.SqlClient;

namespace Petify.Infrastructure.Factories
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);
    }
}
