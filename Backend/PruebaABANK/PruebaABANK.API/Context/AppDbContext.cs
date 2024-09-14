using Dapper.ORM;
namespace PruebaABANK.API.Context
{
    public class AppDbContext : DapperContext
    {
        public AppDbContext(IConfiguration configuration) : 
            base(configuration.GetConnectionString("MySQLConnection"), 
                DatabaseServer.MySQL)
        {
        }
    }
}
