using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeed.Objects.Extensions
{
  public static class EstadoRecompensaExtensions
  {
    public static string GetTextClass(this EstadoRecompensa estado)
    {
      switch (estado)
      {
        default:
        case EstadoRecompensa.ARetirar:
          return "";
        case EstadoRecompensa.Processando:
          return "text-warning";
        case EstadoRecompensa.Processada:
          return "text-success";
      }
    }
  }
}
