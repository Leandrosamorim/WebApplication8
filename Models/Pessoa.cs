using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Nome { get; set; }
        [Required, StringLength(80)]
        public string Sobrenome { get; set; }
        public DateTime Aniversario { get; set; }


        public int DiasParaAniversario()
        {
            DateTime today = DateTime.Today;
            DateTime next = Aniversario.AddYears(today.Year - Aniversario.Year);

            if (next < today)
                next = next.AddYears(1);

            int numDays = (next - today).Days;
            return numDays;
        }
    }
}
