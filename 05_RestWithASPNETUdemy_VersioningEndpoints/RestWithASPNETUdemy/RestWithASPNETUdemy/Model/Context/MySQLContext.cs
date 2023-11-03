using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
            
        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}

        //todas as tabelas que precisarmos acessar, sempre devemos dicionar um dbSet 
        //que faz a ligação com o contexto do banco de dados 
        public DbSet<Person> Persons { get; set; }
    }
}
