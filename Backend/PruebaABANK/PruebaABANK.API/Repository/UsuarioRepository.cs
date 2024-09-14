using PruebaABANK.API.Context;
using PruebaABANK.API.Models;

namespace PruebaABANK.API.Repository
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
            var usuarios = await _dbContext.QueryAsync<Usuario>("SELECT * FROM usuarios");
            return usuarios.ToList();
        }

        public async Task<Usuario> GetById(int id)
        {
            var usuarios = await _dbContext.QuerySingleOrDefaultAsync<Usuario>("SELECT * FROM usuarios WHERE id=@Id", new { Id = id });
            return usuarios;
        }
        public async Task<int> Add(Usuario usuario)
        {
            // Consulta SQL para la inserción
            string sqlQuery = "INSERT INTO usuarios " +
                "(nombres, apellidos, fechanacimiento, direccion, password, telefono, email) " +
                "VALUES (@Nombres, @Apellidos, @FechaNacimiento, @Direccion, @Password, @Telefono, @Email);" +
                "SELECT LAST_INSERT_ID();";

            return await _dbContext.QuerySingleAsync<int>(sqlQuery, usuario);
        }

        public async Task<bool> Edit(Usuario usuario)
        {
            int rowAffected = await _dbContext.ExecuteAsync("UPDATE usuarios " +
                "SET nombres=@Nombres, apellidos=@Apellidos, fechanacimiento=@FechaNacimiento, direccion=@Direccion, " +
                "password=@Password, telefono=@Telefono, email=@Email WHERE Id=@Id", usuario);

            //Validación para saber si la edición fue exitosa
            return rowAffected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            int rowAffected = await _dbContext.ExecuteAsync("DELETE FROM usuarios WHERE id=@Id", new { Id = id });

            //Validación para saber si la eliminación fue exitosa
            return rowAffected > 0;
        }

    }
}
