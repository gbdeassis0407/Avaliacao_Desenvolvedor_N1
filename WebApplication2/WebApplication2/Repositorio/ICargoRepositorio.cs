using WebApplication2.Models;

namespace WebApplication2.Repositorio
{
    public interface ICargoRepositorio
    {
        //Funções Criadas para gerar interfaçe na Classe Repositorio Cargos
        //Buscar ID Cargos
        CargosModel ListarPorId(int id);

        //Listar todos no BD
        List<CargosModel> BuscarTodos();

        //Adicionar Cargos
        CargosModel Adicionar(CargosModel cargos);

        //Editar Cargos
        CargosModel Atualizar(CargosModel cargos);

        //Apagar Cargos
        bool Apagar(int id);
    }
}
