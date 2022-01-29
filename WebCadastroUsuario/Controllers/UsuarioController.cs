using Microsoft.AspNetCore.Mvc;
using WebCadastroUsuario.Models;

namespace WebCadastroUsuario.Controllers
{
    public class UsuarioController : Controller
    {
        HttpClient httpClient = new HttpClient();

        // GET: Listar usuários
        public async Task<ActionResult> Index()
        {
            var usuarios = await httpClient.GetFromJsonAsync<List<ExibirUsuario>>("http://localhost:5012/api/Usuarios/lista-de-usuarios");

            //var usuariosAtivos = usuarios.Where(x => x.Ativo).ToList();

            return View(usuarios);
        }

        // GET: Obter usuário
        public async Task<ActionResult> Details(int id)
        {
            var usuario = await httpClient.GetFromJsonAsync<AlterarUsuario>("http://localhost:5012/api/Usuarios/buscar-usuario/" + id);
            return View(usuario);
        }

        // GET: Obter novo usuário
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inserir novo usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NovoUsuario novoUsuario)
        {
            var response = await httpClient.PostAsJsonAsync("http://localhost:5012/api/Usuarios/novo-usuario", novoUsuario);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(novoUsuario);
        }

        // GET: Obter usuario pelo id
        public async Task<ActionResult> Edit(int id)
        {
            var usuario = await httpClient.GetFromJsonAsync<AlterarUsuario>("http://localhost:5012/api/Usuarios/buscar-usuario/" + id);
            return View(usuario);
        }

        // POST: Editar usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AlterarUsuario alterarUsuario)
        {
            var response = await httpClient.PutAsJsonAsync("http://localhost:5012/api/Usuarios/alterar-usuario", alterarUsuario);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(alterarUsuario);
        }

        // GET: Obter usuario
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await httpClient.GetFromJsonAsync<AlterarUsuario>("http://localhost:5012/api/Usuarios/buscar-usuario/" + id);
            return View(usuario);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AlterarUsuario usuario)
        {
            var response = await httpClient.DeleteAsync("http://localhost:5012/api/Usuarios/excluir-usuario/" + usuario.Id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
