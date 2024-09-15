using PruebaABANK.DAL.Entities;
using PruebaABANK.DAL.Interfaces;
using Dapper;

namespace PruebaABANK.DAL.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        AppDbContext _dbContext;
        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> GetAll()
        {
            using (var connection = _dbContext.CreateConnection()) 
            {
                var usuarios = await connection.QueryAsync<Usuario>("SELECT * FROM usuarios");
                return usuarios.ToList();
            }

        }

        public async Task<Usuario?> GetById(int id)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var usuario = await connection.QuerySingleOrDefaultAsync<Usuario>("SELECT * FROM usuarios WHERE id=@Id", new { Id = id });
                return usuario;
            }
        }
        public async Task<int> Add(Usuario usuario)
        {
            // Consulta SQL para la inserción
            string sqlQuery = "INSERT INTO usuarios " +
                "(nombres, apellidos, fechanacimiento, direccion, password, telefono, email) " +
                "VALUES (@Nombres, @Apellidos, @FechaNacimiento, @Direccion, @Password, @Telefono, @Email);" +
                "SELECT LAST_INSERT_ID();";
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(sqlQuery, usuario);
            }
        }

        public async Task<bool> Edit(Usuario usuario)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                int rowAffected = await connection.ExecuteAsync("UPDATE usuarios " +
                "SET nombres=@Nombres, apellidos=@Apellidos, fechanacimiento=@FechaNacimiento, direccion=@Direccion, " +
                "password=@Password, telefono=@Telefono, email=@Email WHERE Id=@Id", usuario);

                //Validación para saber si la edición fue exitosa
                return rowAffected > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                int rowAffected = await connection.ExecuteAsync("DELETE FROM usuarios WHERE id=@Id", new { Id = id });

                //Validación para saber si la eliminación fue exitosa
                return rowAffected > 0;
            }
        }

        public async Task<Usuario?> GetByCredentials(LoginEntity login)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var usuario = await connection.QuerySingleOrDefaultAsync<Usuario>(
                "SELECT * FROM usuarios WHERE email=@Email and password=@Password", login);
                return usuario;
            }
        }
    }
}
