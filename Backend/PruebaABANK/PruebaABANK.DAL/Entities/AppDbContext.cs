using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
namespace PruebaABANK.DAL.Entities
{
    public class AppDbContext
    {
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySQLConnection")??"";
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
