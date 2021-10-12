using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class Empresa
  {
    public int EmpresaId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Site { get; set; }

    [Required]
    public string Nome { get; set; }

    public Endereco Endereco { get; set; }

    public string CNPJ { get; set; }

    public virtual List<ProgramaRecompensas> Programas { get; set; }

    public virtual List<GrupoFuncionarios> GrupoFuncionarios { get; set; }

    public bool Verificada { get; set; }
  }
}
