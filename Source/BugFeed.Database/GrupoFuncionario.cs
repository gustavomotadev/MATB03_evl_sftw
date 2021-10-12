using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class GrupoFuncionarios
  {
    public int GrupoFuncionariosId { get; set; }

    public string Nome { get; set; }

    public virtual List<Permissao> Permissoes { get; set; }
    
    public virtual List<Funcionario> Funcionarios { get; set; }

    [Required]
    public virtual Empresa Empresa { get; set; }
  }
}
