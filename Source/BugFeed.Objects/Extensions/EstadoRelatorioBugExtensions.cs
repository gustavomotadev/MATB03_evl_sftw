using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeed.Objects.Extensions
{
  public static class EstadoRelatorioBugExtensions
  {
    public static string GetTextClass(this EstadoRelatorioBug estado)
    {
      switch (estado)
      {
        default:
        case EstadoRelatorioBug.EmAnalise:
          return "text-warning";
        case EstadoRelatorioBug.Recusado:
          return "text-danger";
        case EstadoRelatorioBug.Concluido:
          return "text-success";
      }
    }
  }
}
