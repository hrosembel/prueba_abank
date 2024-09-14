using PruebaABANK.BLL.Interfaces;
using PruebaABANK.BLL.Models;
using PruebaABANK.DAL.Entities;
using PruebaABANK.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaABANK.BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<int> Add(UsuarioDto usuario)
        {
            Usuario entity = new Usuario
            {
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                Direccion = usuario.Direccion,
                Password = usuario.Password,
                Telefono = usuario.Telefono,
                Email = usuario.Email
            };
            return await _usuarioRepository.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _usuarioRepository.Delete(id);
        }

        public async Task<bool> Edit(UsuarioDto usuario)
        {
            var entity = new Usuario
            {
                id = usuario.id,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                Direccion = usuario.Direccion,
                Password = usuario.Password,
                Telefono = usuario.Telefono,
                Email = usuario.Email
            };
            return await _usuarioRepository.Edit(entity);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            List<Usuario> usuarios = await _usuarioRepository.GetAll();
            return usuarios.Select(usuario => new UsuarioDto
            {
                id = usuario.id,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                Direccion = usuario.Direccion,
                Password = usuario.Password,
                Telefono = usuario.Telefono,
                Email = usuario.Email
            });
        }

        public async Task<UsuarioDto?> GetByCredentials(LoginDto loginDto)
        {
            var usuario = await _usuarioRepository.GetByCredentials(
                new LoginEntity 
                { 
                    Password = loginDto.Password,
                    UserName = loginDto.UserName
                });

            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                id = usuario.id,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                Direccion = usuario.Direccion,
                Password = usuario.Password,
                Telefono = usuario.Telefono,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioDto?> GetById(int id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            if (usuario == null)
                return null;
            return new UsuarioDto
            {
                id = usuario.id,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                Direccion = usuario.Direccion,
                Password = usuario.Password,
                Telefono = usuario.Telefono,
                Email = usuario.Email
            };
        }
    }
}
