using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Models.Base;

namespace TargetWebApi.Models
{
    [Table("produtos")]
    public class Produto : BaseEntity
    {
        [Column("PROD_ID")]
        public override int ID { get; set; }
        [Column("PROD_DESCRICAO")]
        public string Descricao { get; set; }
        [Column("PROD_COD")]
        public string CodBarras { get; set; }
        [Column("PROD_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
        [Column("PROD_VALOR_COMPRA")]
        public decimal ValorCompra { get; set; }
        [Column("PROD_VALOR_VENDA")]
        public decimal ValorVenda { get; set; }
        [Column("PROD_ESTOQUE_MAX")]
        public int EstoqueMaximo { get; set; }
        [Column("PROD_ESTOQUE_MIN")]
        public int EstoqueMinimo { get; set; }
        [Column("PROD_FK_FORN_ID")]
        public int ID_Fornecedor { get; set; }
    }
}
