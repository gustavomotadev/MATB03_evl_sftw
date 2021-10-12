using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeed.DAL
{
  public class EmpresaRepository : GenericRepository<Empresa>
  {
    public EmpresaRepository(BugFeedContext context)
      : base(context) { }

  }
}
