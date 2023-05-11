using WebApplication2.Models;

namespace WebApplication2.Repositorio
{
    public interface IFuncionarioRepositorio
    {
        //Funções Criadas para gerar interfaçe na Classe Repositorio Funcionarios
        //Buscar ID Funcionarios
        FuncionarioModel ListarPorId(int id);

        //Listar todos no BD
        List<FuncionarioModel> BuscarTodos();

        //Adicionar Funcionarios
        FuncionarioModel Adicionar(FuncionarioModel funcionario);

        //Editar Funcionarios
        FuncionarioModel Atualizar(FuncionarioModel funcionario);   

        //Apagar Funcionarios
        bool Apagar(int id);
    }
}
