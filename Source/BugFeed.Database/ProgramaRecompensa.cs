using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class ProgramaRecompensas
  {
    public int ProgramaRecompensasId { get; set; }

    [Required]
    public virtual Empresa Empresa { get; set; }

    [Required]
    public EstadoProgramaRecompensa Estado { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public decimal Orcamento { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; }

    public DateTime? UltimaRevisao { get; set; }

    public virtual List<RelatorioBug> Relatorios { get; set; }

    public virtual List<ComentarioPrograma> Comentarios { get; set; }
    
  }

  public enum EstadoProgramaRecompensa
  {
    Ativo,
    Pausado,
    Finalizado
  }
}
