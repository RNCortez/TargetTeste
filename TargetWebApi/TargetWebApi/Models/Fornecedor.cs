using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Models.Base;

namespace TargetWebApi.Models
{
    [Table("fornecedores")]
    public class Fornecedor : BaseEntity
    {
        [Column("FORN_ID")]
        public override int ID { get; set; }
        [Column("FORN_DESCRICAO")]
        public string Descricao { get; set; }
    }
}
