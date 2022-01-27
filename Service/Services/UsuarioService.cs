using AutoMapper;
using Domain;
using Infra.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using Shared.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ExibirUsuario>> BuscarTodosUsuariosAsync()
        {
            return mapper.Map<IEnumerable<Usuario>, IEnumerable<ExibirUsuario>>(await repository.BuscarTodosUsuariosAsync().ConfigureAwait(false));
        }

        public async Task<ExibirUsuario> BuscarUsuarioPorIdAsync(int id)
        {
            return mapper.Map<ExibirUsuario>(await repository.BuscarUsuarioPorIdAsync(id).ConfigureAwait(false));
        }

        public async Task<ExibirUsuario> AdicionarUsuarioAsync(NovoUsuario novoUsuario)
        {
            var usuario = mapper.Map<Usuario>(novoUsuario);
            ConverteSenhaEmHash(usuario);
            return mapper.Map<ExibirUsuario>(await repository.AdicionarUsuarioAsync(usuario).ConfigureAwait(false));
        }

        private static void ConverteSenhaEmHash(Usuario usuario)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
        }

        public async Task<ExibirUsuario> AlterarUsuarioAsync(AlterarUsuario alterarUsuario)
        {
            var usuarioAlterado = mapper.Map<Usuario>(alterarUsuario);

            if (usuarioAlterado.Senha is null)
            {
                var usuario = await repository.BuscarUsuarioPorIdAsync(usuarioAlterado.Id).ConfigureAwait(false);
                usuarioAlterado.Senha = usuario.Senha;
            }
            ConverteSenhaEmHash(usuarioAlterado);
            return mapper.Map<ExibirUsuario>(await repository.AlterarUsuarioAsync(usuarioAlterado).ConfigureAwait(false));
        }

        public async Task<ExibirUsuario> ExcluirUsuario(int id)
        {
            var usuario = await repository.BuscarUsuarioPorIdAsync(id).ConfigureAwait(false);
            usuario.Ativo = false;
            return mapper.Map<ExibirUsuario>(await repository.AlterarUsuarioAsync(usuario).ConfigureAwait(false));
        }
    }
}
