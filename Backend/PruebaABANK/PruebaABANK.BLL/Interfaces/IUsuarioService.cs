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
        Task<IEnumerable<UsuarioLecturaDto>> GetAll();
        Task<UsuarioLecturaDto?> GetById(int id);
        Task<UsuarioDto?> GetByCredentials(LoginDto loginDto);
        Task<int> Add(UsuarioEdicionDto usuario);
        Task<bool> Edit(int id, UsuarioEdicionDto usuario);
        Task<bool> Delete(int id);
    }
}
