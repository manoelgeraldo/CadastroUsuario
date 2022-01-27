using Domain;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContexto db;

        public UsuarioRepository(DbContexto db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Usuario>> BuscarTodosUsuariosAsync()
        {
            return await db.Usuarios.AsNoTracking()
                                    .ToListAsync()
                                    .ConfigureAwait(false);
        }

        public async Task<Usuario> BuscarUsuarioPorIdAsync(int id)
        {
            return await db.Usuarios.AsNoTracking()
                                    .SingleOrDefaultAsync(x => x.Id == id)
                                    .ConfigureAwait(false);
        }

        public async Task<Usuario> AdicionarUsuarioAsync(Usuario usuario)
        {
            var verificaUsuario = await VerificaUsuarioAsync(usuario);

            if (verificaUsuario is null)
            {
                await db.Usuarios.AddAsync(usuario).ConfigureAwait(false);
                await db.SaveChangesAsync().ConfigureAwait(false);
                return usuario;
            }

            return null;
        }

        private async Task<Usuario> VerificaUsuarioAsync(Usuario novoUsuario)
        {
            var listaUsuarios = await BuscarTodosUsuariosAsync();

            var usuarioVerificado = listaUsuarios.Single(x => x.Nome == novoUsuario.Nome ||
                                                              x.DataNascimento == novoUsuario.DataNascimento ||
                                                              x.Email == novoUsuario.Email);

            if (usuarioVerificado != null)
            {
                return novoUsuario;
            }

            return null;
        }

        public async Task<Usuario> AlterarUsuarioAsync(Usuario usuario)
        {
            var usuarioConsultado = await db.Usuarios.FindAsync(usuario.Id).ConfigureAwait(false);
            if (usuarioConsultado is null)
            {
                return null;
            }
            db.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
            await db.SaveChangesAsync().ConfigureAwait(false);

            return usuarioConsultado;
        }

        public async Task<Usuario> ExcluirUsuarioAsync(int id)
        {
            var usuarioConsultado = await db.Usuarios.FindAsync(id).ConfigureAwait(false);

            if (usuarioConsultado != null)
            {
                var usuarioExcluido = db.Usuarios.Remove(usuarioConsultado);
                await db.SaveChangesAsync().ConfigureAwait(false);
                return usuarioExcluido.Entity;
            }
            return null;
        }
    }
}
