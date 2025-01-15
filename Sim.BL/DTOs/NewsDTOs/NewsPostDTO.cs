using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.BL.DTOs.NewsDTOs
{
    public class NewsPostDTO
    {
        public string Title { get; set; }

        public int CategoryId {  get; set; }
        public IFormFile Image { get; set; }
    }
}
