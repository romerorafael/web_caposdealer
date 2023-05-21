using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CD.Web.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string NmCliente { get; set; }
        public string NmCidade { get; set; }
    }
}
