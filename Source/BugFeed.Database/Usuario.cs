using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class Usuario : IdentityUser
  {

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Sobrenome { get; set; }

    [Required]
    public bool Ativo { get; set; }

    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    public virtual Funcionario Funcionario { get; set; }

    public virtual Pesquisador Pesquisador { get; set; }
  }

}




