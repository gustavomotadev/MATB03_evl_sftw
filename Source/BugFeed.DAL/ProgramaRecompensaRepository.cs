using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugFeed.Database;

namespace BugFeed.DAL
{
  public class ProgramaRecompensaRepository : GenericRepository<ProgramaRecompensas>
  {
    public ProgramaRecompensaRepository(BugFeedContext context)
      : base(context) { }

    public List<ProgramaRecompensas> FindByEmpresa(Empresa empresa)
    {
      return context.ProgramasRecompensas.Where(p => p.Empresa.EmpresaId == empresa.EmpresaId).ToList();
    }
  }
}
