using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    //Criando Função BancoContext para contexto do Banco de Dados
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        //Classe de Chamado Get Set das tabelas Cargos e Funcionarios na Banco de Dados
        public DbSet<CargosModel> Cargos { get; set; }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }

    }
}
