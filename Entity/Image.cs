using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
