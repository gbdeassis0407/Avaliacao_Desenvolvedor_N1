 using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositorio
{
    public class CargoRepositorio : ICargoRepositorio
    {
        // Fazendo a Leitura e alocando a Variavel de BancoContext do Banco de dados
        private readonly BancoContext _bancoContext;

        // Injetando meu BancoContext em Uma variavel Auxiliar no CargoRepositorio
        public CargoRepositorio(BancoContext bancoContext) 
        {
            this._bancoContext = bancoContext;
        }

        //Função para Chamada do ID e Identificação de Cargos no BD(Banco de Dados)
        public CargosModel ListarPorId(int id)
        {
        #pragma warning disable CS8603 // Possível retorno de referência nula.
            return _bancoContext.Cargos.FirstOrDefault(x => x.Id == id);
        #pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        //Função Listagem de Cargos e Chamado de dados do BD
        public List<CargosModel> BuscarTodos()
        {
            return _bancoContext.Cargos.ToList();   
        }

        //Função para Adicionar Cargos no BD
        public CargosModel Adicionar(CargosModel cargos)
        {
            _bancoContext.Cargos.Add(cargos);
            _bancoContext.SaveChanges();
            return cargos;
        }

        //Função para Editar/Alterar Cargos no BD
        public CargosModel Atualizar(CargosModel cargos)
        {
            CargosModel CargoDB = ListarPorId(cargos.Id);

            if (CargoDB == null) throw new System.Exception("Houve um Erro na Alteração de Cargo!");

            CargoDB.Nome = cargos.Nome;
            CargoDB.Salario = cargos.Salario;
            CargoDB.Descrição = cargos.Descrição;

            _bancoContext.Cargos.Update(CargoDB);
            _bancoContext.SaveChanges();

            return CargoDB;
        }

        //Função para Apagar Cargos no BD
        public bool Apagar(int id)
        {
            CargosModel CargoDB = ListarPorId(id);

            if (CargoDB == null) throw new System.Exception("Houve um Erro ao Deletar o Cargo!");

            _bancoContext.Cargos.Remove(CargoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
