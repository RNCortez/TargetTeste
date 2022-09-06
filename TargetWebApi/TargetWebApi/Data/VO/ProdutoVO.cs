using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Models.Base;

namespace TargetWebApi.Data.VO
{
    public class ProdutoVO
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string CodBarras { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public int EstoqueMaximo { get; set; }
        public int EstoqueMinimo { get; set; }
        public int ID_Fornecedor { get; set; }
    }
}
