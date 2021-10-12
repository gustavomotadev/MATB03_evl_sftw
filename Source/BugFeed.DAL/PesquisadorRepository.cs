using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeed.DAL
{
  public class PesquisadorRepository : GenericRepository<Pesquisador>
  {
    public PesquisadorRepository(BugFeedContext context)
      : base(context) { }
  }
}
