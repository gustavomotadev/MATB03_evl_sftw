using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class DadosBancarios
  {
    public int DadosBancariosId { get; set; }

    [Required]
    public virtual Pesquisador Pesquisador { get; set; }

    [Required]
    public string CPF { get; set; }

    [Required]
    public int Agencia { get; set; }

    [Required]
    public int DigitoAgencia { get; set; }

    [Required]
    public int Conta { get; set; }

    [Required]
    public int DigitoConta { get; set; }

    [Required]
    public bool Confirmado { get; set; }
  }
}
