using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class Pesquisador
  {
    public int PesquisadorId { get; set; }

    public virtual List<Formacao> Formacoes { get; set; }

    public virtual Endereco Endereco { get; set; }

    public virtual List<DadosBancarios> DadosBancarios { get; set; }

    public virtual List<Retirada> Retiradas { get; set; }

    [Required]
    public virtual Usuario Usuario { get; set; }
  }
}
