using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HealthInfoResult
    {
        public int Id { get; set; }
        public double Result { get; set; }
        public int HealthInfoId { get; set; }
        public virtual HealthInfo HealthInfo { get; set; }
        public int OnlineDietFormId { get; set; }
        public virtual OnlineDietForm OnlineDietForm { get; set; }
    }
}
