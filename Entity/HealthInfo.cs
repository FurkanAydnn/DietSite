using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HealthInfo : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<HealthInfoResult> HealthInfoResults { get; set; }
    }
}
