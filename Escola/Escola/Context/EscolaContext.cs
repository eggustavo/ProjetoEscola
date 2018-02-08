using System.Data.Entity;
using Escola.Domain;

namespace Escola.Context
{
    public class EscolaContext : DbContext
    {
        public EscolaContext()
            : base("EscolaConexao")
        {
        }

        public DbSet<Curso> CursoSet { get; set; }
        public DbSet<Aluno> AlunoSet { get; set; }
    }
}