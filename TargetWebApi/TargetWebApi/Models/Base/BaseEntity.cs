using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetWebApi.Models.Base
{
    public class BaseEntity
    {
        protected int _ID;

        public virtual int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
    }
}
