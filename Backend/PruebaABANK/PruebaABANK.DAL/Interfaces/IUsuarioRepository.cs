using PruebaABANK.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaABANK.DAL.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario?> GetById(int id);
        Task<Usuario?> GetByCredentials(LoginEntity model);
        Task<int> Add(Usuario usuario);
        Task<bool> Edit(Usuario usuario);
        Task<bool> Delete(int id);
    }
}
