using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebApplication2.Controllers
{
    public class CargosController : Controller
    {
        // Fazendo a releitura e alocando a Variavel de ICargoRepositorio
        private readonly ICargoRepositorio _cargoRepositorio;

        // Injetando meu ICargo em Uma variavel Auxiliar no CargoController
        public CargosController(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        // Classe Principal Index com Listagem de Busca de Cargos
        public IActionResult Index()
        {
            List<CargosModel> cargos = _cargoRepositorio.BuscarTodos();

            return View(cargos);
        }

        // Classe Cadastro de Funcionarios com Listagem de e Busca de Cargos
        public IActionResult Cadastrar()
        {
            return View();
        }

        // Classe Editar/Alterar de Cargos
        public IActionResult Alterar(int id)
        {
            CargosModel cargos = _cargoRepositorio.ListarPorId(id);
            return View(cargos);
        }
       
        // Classe para chamar Confirmação de Deletar Cargos
        public IActionResult DeletarConfirmacao(int id)
        {
            CargosModel cargos = _cargoRepositorio.ListarPorId(id);
            return View(cargos);
        }

        // Classe Chama função no Repositorio e tratativa para Deletar Cargos
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _cargoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cargo Deletado com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Problema ao Deletar o Cargo Escolhido";
                }

                return RedirectToAction("Index");
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao Deletar Cargo: {erro.Message}";
                return RedirectToAction("Index");

            }

        }

        // Classe Chama função no Repositorio e tratativa para Cadastra Cargos
        [HttpPost]
        public IActionResult Cadastrar(CargosModel cargos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cargoRepositorio.Adicionar(cargos);
                    TempData["MensagemSucesso"] = "Cargo Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(cargos);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao Cadastrar Cargo: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Classe Chama função no Repositorio e tratativa para Editar/Alterar Dados de Cargos
        [HttpPost]
        public IActionResult Alterar(CargosModel cargos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cargoRepositorio.Atualizar(cargos);
                    TempData["MensagemSucesso"] = "Cargo Alterado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View("Alterar", cargos);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao Alterar o Cargo Escolhido: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
