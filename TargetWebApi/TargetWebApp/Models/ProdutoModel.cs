using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TargetWebApp.Models.Base;

namespace TargetWebApp.Models
{
    public class ProdutoModel : BaseModel
    {
        public string Descricao { get; set; }
        public string CodBarras { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public int EstoqueMaximo { get; set; }
        public int EstoqueMinimo { get; set; }
        public int ID_Fornecedor { get; set; }
        public string ValorCompraVisualizacao { get; set; }
        public string ValorVendaVisualizacao{ get; set; }
    }
}