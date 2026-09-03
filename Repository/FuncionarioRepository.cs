using ProjetoCadastroMVC.Data;
using ProjetoCadastroMVC.Models;

namespace ProjetoCadastroMVC.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DatabaseContext dbContext;

        public FuncionarioRepository(DatabaseContext contexto)
        {
            dbContext = contexto;
        }

        public List<Funcionario> BuscarTodos()
        {
            return dbContext.Funcionarios.ToList();
        }

        public Funcionario Adicionar(Funcionario funcionario)
        {
            dbContext.Funcionarios.Add(funcionario);
            dbContext.SaveChanges();
            return funcionario;
        }

        public Funcionario BuscarPorId(int id)
        {   
            return dbContext.Funcionarios.FirstOrDefault(x => x.Id == id);
        }

        public Funcionario Atualizar(Funcionario funcionario) 
        {
            Funcionario funcionarioBuscado = BuscarPorId(funcionario.Id);

            if (funcionarioBuscado == null)
            {
                throw new Exception("Houve um problema ao atualizar!");
            }

            funcionarioBuscado.Nome = funcionario.Nome;
            funcionarioBuscado.Cargo = funcionario.Cargo;
            funcionarioBuscado.CPF = funcionario.CPF;
            funcionarioBuscado.Departamento = funcionario.Departamento;
            funcionarioBuscado.Salario = funcionario.Salario;

            dbContext.Funcionarios.Update(funcionarioBuscado);
            dbContext.SaveChanges();
            return funcionarioBuscado;
        }
    }
}