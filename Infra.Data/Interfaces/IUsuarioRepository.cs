﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscarTodosUsuariosAsync();

        Task<Usuario> BuscarUsuarioPorIdAsync(int id);

        Task<Usuario> AdicionarUsuarioAsync(Usuario usuario);

        Task<Usuario> AlterarUsuarioAsync(Usuario usuario);

        Task<Usuario> ExcluirUsuarioAsync(int id);
    }
}