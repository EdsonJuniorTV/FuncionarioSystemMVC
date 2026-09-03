using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroMVC.Models;
using ProjetoCadastroMVC.Repository;

namespace ProjetoCadastroMVC.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepositoryNew)
        {
            funcionarioRepository = funcionarioRepositoryNew;
        }

        public IActionResult Index()
        {
            List<Funcionario> listaFuncionarios = funcionarioRepository.BuscarTodos();
            return View(listaFuncionarios);
        }

        public IActionResult Criar()
        {
            ViewBag.TipoTela = "Criar";
            return View("~/Views/Funcionario/CriarEditar.cshtml");
        }

        public IActionResult Editar(int id)
        {
            Funcionario funcionario = funcionarioRepository.BuscarPorId(id);
            ViewBag.TipoTela = "Editar";
            return View("~/Views/Funcionario/CriarEditar.cshtml", funcionario);
        }

        [HttpPost]
        public IActionResult Criar(Funcionario funcionario)
        {
            funcionarioRepository.Adicionar(funcionario);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Funcionario funcionario)
        {
            funcionarioRepository.Atualizar(funcionario);
            return RedirectToAction("Index");
        }
    }
}
