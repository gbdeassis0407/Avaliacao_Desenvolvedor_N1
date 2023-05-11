using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositorio;
namespace WebApplication2.Controllers
{
    public class FuncionarioController : Controller
    {
        // Extraido para uma Varial para a Classe em Formato Privado
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        // Injetando meu Ifuncionario em  Uma variavel Auxiliar no FuncionarioController
        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        // Classe Principal Index com Listagem de Busca de Funcioanrios
        public IActionResult Index()
        {
            List<FuncionarioModel> funcionarios = _funcionarioRepositorio.BuscarTodos();

            return View(funcionarios);
        }

        // Classe Cadastro de Funcionarios com Listagem de e Busca de Funcioanrios
        public IActionResult Cadastrar()
        {
            return View();
        }

        // Classe Editar/Alterar de Funcionarios
        public IActionResult Alterar(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }

        // Classe para chamar Confirmação de Deletar Funcionario
        public IActionResult DeletarConfirmacao(int id)
        {
            FuncionarioModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }

        // Classe Chama função no Repositorio e tratativa para Deletar Funcionario
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado =  _funcionarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Funcionario Apagado com Sucesso!";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Erro ao Apagar Funcionario, Por Favor Tente Novamente";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao Excluir Funcionario: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Classe Chama função no Repositorio e tratativa para Cadastra Funcionario
        [HttpPost]
        public IActionResult Cadastrar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepositorio.Adicionar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionario Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(funcionario);
            }

            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao Cadastrar Funcionario: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Classe Chama função no Repositorio e tratativa para Editar/Alterar Dados de Funcionario
        [HttpPost]
        public IActionResult Alterar(FuncionarioModel funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepositorio.Atualizar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionario Atualizado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(funcionario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao Atualizar o Funcionario: {erro.Message}";
                return RedirectToAction("Index");

            } 
        }
    }
}
