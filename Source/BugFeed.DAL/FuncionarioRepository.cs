using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeed.DAL
{
  public class FuncionarioRepository : GenericRepository<Funcionario>
  {
    public FuncionarioRepository(BugFeedContext context)
      : base(context) { }

    public Funcionario FindByUsername(string aoUsername)
    {
      return context.Funcionarios.Where(i => i.Usuario.UserName.Equals(aoUsername)).FirstOrDefault();
    }
  }
}


