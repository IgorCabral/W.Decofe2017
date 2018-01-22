using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Decofe2017.Models;

namespace Decofe2017.Context
{
    public class DecofeContext : DbContext
    {
        public DecofeContext() : base("DecofeContext")
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Avaliador> Avaliadores { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>().ToTable("Avaliacoes");
            modelBuilder.Entity<Avaliador>().ToTable("Avaliadores");
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}