using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class Retirada
  {
    public int RetiradaId { get; set; }

    public virtual Pesquisador Pesquisador { get; set; }

    [Required]
    public virtual DadosBancarios DadosBancarios { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }

    [Required]
    public EstadoRetirada Estado { get; set; }
  }

  public enum EstadoRetirada
  {
    [Description("Em Progresso")]
    EmProgresso,
    [Description("Concluída")]
    Concluida,
    Indeferida
  }
}
