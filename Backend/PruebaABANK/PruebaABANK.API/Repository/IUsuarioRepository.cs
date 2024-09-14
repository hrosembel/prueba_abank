using PruebaABANK.API.Models;

namespace PruebaABANK.API.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<int> Add(Usuario usuario);
        Task<bool> Edit(Usuario usuario);
        Task<bool> Delete(int id);
    }
}
