using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    //Modelo do Banco de dados de Cargos e suas requisições Get Set das Variaveis Cadastradas,
    //foi utilizado esse dados para Criar o banco de dados utilizando o Pacote Nuget SQL Entity Framework com Função Migration
    public class CargosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Cargo")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Digite a Descrição do Cargo")]
        public string? Descrição { get; set; }
        [Required(ErrorMessage = "Digite o Sálario do Cargo")]
        public string? Salario { get; set; }

    }
}
