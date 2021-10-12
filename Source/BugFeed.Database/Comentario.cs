using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public abstract class Comentario
  {
    public int ComentarioId { get; set; }

    [Required]
    public string Conteudo { get; set; }
    
    [Required]
    public DateTime DataHora { get; set; }

    [Required]
    public virtual Usuario Usuario { get; set; }

    [Required]
    public bool Apagado { get; set; }

    [Required]
    public DateTime Data { get; set; }

    [Required]
    public DateTime UltimaRevisao { get; set; }

  }

  public class ComentarioPrograma : Comentario
  {
    public virtual ProgramaRecompensas Programa { get; set; }
  }

  public class ComentarioRelatorio : Comentario
  {
    public virtual RelatorioBug Relatorio { get; set; }
  }
}
