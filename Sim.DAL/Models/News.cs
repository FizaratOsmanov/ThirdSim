using Sim.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL.Models
{
    public class News : AuditableEntity
    {
        public string ImgPath { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
