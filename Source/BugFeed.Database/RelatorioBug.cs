using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class RelatorioBug
  {
    public int RelatorioBugId { get; set; }

    [Required]
    public virtual Pesquisador Pesquisador { get; set; }

    [Required]
    public virtual ProgramaRecompensas Programa { get; set; }

    [Required]
    [MaxLength(150)]
    public string Titulo { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public string Impacto { get; set; }

    [Required]
    public DateTime Data { get; set; }

    public virtual Recompensa Recompensa { get; set; }

    [Required]
    public EstadoRelatorioBug Estado { get; set; }

    public virtual List<ComentarioRelatorio> Comentarios { get; set; }
  }

  public enum EstadoRelatorioBug
  {
    [Description("Em Análise")]
    EmAnalise,
    [Description("Recusado")]
    Recusado,
    [Description("Concluído")]
    Concluido
  }
}
