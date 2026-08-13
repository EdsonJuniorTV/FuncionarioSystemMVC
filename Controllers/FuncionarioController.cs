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
    }
}
