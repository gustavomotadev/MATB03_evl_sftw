using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class Formacao
  {
    public int FormacaoId { get; set; }

    [Required]
    public TipoFormacao TipoFormacao { get; set; }

    [Required]
    public string Descricao { get; set; }
  }

  public enum TipoFormacao
  {
    Bacharelado,
    Licenciatura,
    [Description("Tecnológico")]
    Tecnologico,
    Sequencial,
    [Description("GraduaçãoModulada")]
    GraduacaoModulada,
    EAD
  }
}
