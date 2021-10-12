using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugFeed.Database
{
  public class Endereco
  {
    public int EnderecoId { get; set; }

    [Required]
    public string Destinatario { get; set; }

    public string Organizacao { get; set; }

    [Required]
    public string Linha1 { get; set; }
    public string Linha2 { get; set; }
    public string Linha3 { get; set; }

    [Required]
    [MaxLength(50)]
    public string Cidade { get; set; }

    [Required]
    [MaxLength(30)]
    public string Bairro { get; set; }

    [DataType(DataType.PostalCode)]
    public int CEP { get; set; }

    [Required]
    [MaxLength(50)]
    public string Estado { get; set; }

    [Required]
    [MaxLength(2)]
    public string Pais { get; set; }
  }
}
