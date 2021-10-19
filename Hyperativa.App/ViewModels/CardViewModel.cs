using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa.App.ViewModels
{
    public class CardViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "O campo {0} precisa contar 1 caracter")]
        public string Identifier { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracteres",MinimumLength = 1)]
        public string Lote { get; set; }

        [Required]
        [StringLength(19, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracteres", MinimumLength = 15)]
        public string CardNumber { get; set; }

       
    }
}
