using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class Permissao
  {
    public int PermissaoId { get; set; }
    public Perfil Perfil { get; set; }
  }

  public enum Perfil
  {
    Admin,
    Reward,
    Report,
    Program
  }
}
