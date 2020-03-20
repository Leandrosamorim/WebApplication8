using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class AniversariantesViewModel
    {
        public IEnumerable<Pessoa> AniversariantesDoDia { get; set; }
        public IEnumerable<Pessoa> AniversariantesProximos { get; set; }
    }
}
