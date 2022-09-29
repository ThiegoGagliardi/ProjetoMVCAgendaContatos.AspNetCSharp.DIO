using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Models;

namespace ProjetoMVC.Context
{
    public class AgendaContext: DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }        
    }
}