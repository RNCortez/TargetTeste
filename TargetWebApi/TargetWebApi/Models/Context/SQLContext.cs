using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetWebApi.Models.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext()
        {

        }

        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
