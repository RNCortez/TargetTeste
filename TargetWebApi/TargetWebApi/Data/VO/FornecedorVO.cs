using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Models.Base;

namespace TargetWebApi.Data.VO
{
    public class FornecedorVO
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
    }
}
