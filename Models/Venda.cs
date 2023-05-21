using System.ComponentModel.DataAnnotations.Schema;

namespace CD.Web.Models
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public float VlrUnitario { get; set; }
        public int QtdVenda { get; set; }
        public DateTime DthVenda { get; set; }
        public float VlrUnitarioVenda { get; set; }
        [NotMapped]
        public string nmCliente { get; set; }
        [NotMapped]
        public string dscProduto { get; set; }
    }
}
