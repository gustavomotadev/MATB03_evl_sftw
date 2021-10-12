using BugFeed.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeed.DAL
{
  public class ComentarioRepository : GenericRepository<ComentarioRelatorio>
  {
    public ComentarioRepository(BugFeedContext context)
  : base(context) { }

  }
}
