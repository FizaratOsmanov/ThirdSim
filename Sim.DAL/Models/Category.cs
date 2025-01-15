using Sim.DAL.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL.Models
{
    public class Category:AuditableEntity
    {
        public string Name { get; set; }

        public ICollection<News> News { get; set; }
    }
}
