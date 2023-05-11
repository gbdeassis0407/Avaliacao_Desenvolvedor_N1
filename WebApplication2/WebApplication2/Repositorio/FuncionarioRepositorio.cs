using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        // Fazendo a Leitura e alocando a Variavel de BancoContext do Banco de dados
        private readonly BancoContext _bancoContext;

        // Injetando meu BancoContext em Uma variavel Auxiliar no FuncionarioRepositorio
        public FuncionarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        //Função para Chamada do ID e Identificação de Funcionarios no BD(Banco de Dados)
        public FuncionarioModel ListarPorId(int id)
        {
            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return _bancoContext.Funcionarios.FirstOrDefault(x => x.Id == id);
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        //Função Listagem de Funcionarios e Chamado de dados do BD
        public List<FuncionarioModel> BuscarTodos()
        {
            return _bancoContext.Funcionarios.ToList(); 
        }

        //Função para Adicionar Funcionarios no BD
        public FuncionarioModel Adicionar(FuncionarioModel funcionario)
        {
            _bancoContext.Funcionarios.Add(funcionario);
            _bancoContext.SaveChanges();
            return funcionario;
        }

        //Função para Editar/Alterar Funcionarios no BD
        public FuncionarioModel Atualizar(FuncionarioModel funcionario)
        {
            FuncionarioModel funcionarioDB = ListarPorId(funcionario.Id);

            if (funcionarioDB == null) throw new Exception("Houve um Erro na Atualização de Funcionario");

            funcionarioDB.Matricula = funcionario.Matricula;
            funcionarioDB.CPF = funcionario.CPF;
            funcionarioDB.Nome = funcionario.Nome;
            funcionarioDB.Cargo = funcionario.Cargo;

            _bancoContext.Funcionarios.Update(funcionarioDB);
            _bancoContext.SaveChanges();

            return funcionarioDB;

        }

        //Função para Apagar Funcionarios no BD
        public bool Apagar(int id)
        {
            FuncionarioModel funcionarioDB = ListarPorId(id);

            if (funcionarioDB == null) throw new Exception("Houve um Erro ao Deletar o Funcionario!");

            _bancoContext.Funcionarios.Remove(funcionarioDB);
            _bancoContext.SaveChanges();    

            return true;
        }
    }
}
