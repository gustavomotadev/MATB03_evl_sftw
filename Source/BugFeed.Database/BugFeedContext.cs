using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class BugFeedContext : IdentityDbContext
  {
    public BugFeedContext() : base("BugFeed")
    { }
    
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Formacao> Formacoes { get; set; }
    public DbSet<ProgramaRecompensas> ProgramasRecompensas { get; set; }
    public DbSet<RelatorioBug> RelatoriosBug { get; set; }
    public DbSet<GrupoFuncionarios> GruposFuncionarios { get; set; }
    public DbSet<Permissao> Permissoes { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Pesquisador> Pesquisadores { get; set; }
    public DbSet<Recompensa> Recompensas { get; set; }
  }
}
