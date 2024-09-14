using PruebaABANK.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaABANK.BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAll();
        Task<UsuarioDto?> GetById(int id);
        Task<UsuarioDto?> GetByCredentials(LoginDto loginDto);
        Task<int> Add(UsuarioDto usuario);
        Task<bool> Edit(UsuarioDto usuario);
        Task<bool> Delete(int id);
    }
}
