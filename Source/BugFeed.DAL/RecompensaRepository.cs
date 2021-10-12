using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeed.DAL
{
  public class RecompensaRepository : GenericRepository<Recompensa>
  {
    public RecompensaRepository(BugFeedContext context) : base(context)
    {
    }
  }
}
