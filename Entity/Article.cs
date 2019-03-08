using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Update { get; set; }
        public virtual List<Image> Images { get; set; }

        public Article()
        {
            Update = DateTime.Now.Date;
        }
    }
}
