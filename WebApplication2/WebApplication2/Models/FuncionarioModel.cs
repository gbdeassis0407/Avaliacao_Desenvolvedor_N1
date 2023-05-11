using System;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    //Modelo do Banco de dados de Funcionario e suas requisições Get Set das Variaveis Cadastradas
    //foi utilizado esse dados para Criar o banco de dados utilizando o Pacote Nuget SQL Entity Framework com Função Migration
    public class FuncionarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Numero Da Matricula")]
        public string? Matricula { get; set; }
        [Required(ErrorMessage = "Digite o CPF")]
        public string? CPF { get; set; }
        [Required(ErrorMessage = "Digite o Nome da Pessoa")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do Cargo")]
        public string? Cargo { get; set; }
    }
}
