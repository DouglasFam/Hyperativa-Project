using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperativa.Business.Models
{
    public class Card : Entity
    {
        public string Identifier { get; set; }
        public string Lote { get; set; }
        public string CardNumber { get; set; }
       
    }
}
