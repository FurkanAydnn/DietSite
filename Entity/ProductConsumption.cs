using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductConsumption
    {
        public int Id { get; set; }
        public bool IsConsumed { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OnlineDietFormId { get; set; }
        public virtual OnlineDietForm OnlineDietForm { get; set; }
    }
}
