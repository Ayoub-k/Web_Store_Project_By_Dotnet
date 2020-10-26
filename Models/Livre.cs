using System;

namespace Finalproject.Models
{
    public class Livre
    {
        public int    Id{ get; set; }
        public string Nom{ get; set; }
        public string autor{get; set; }
        public string nbrpage{get; set; }
        public string langue{get; set; }
        public string prix{get; set; }
        public string anne{get; set; }
        public string path{get; set; }
        public string nomcatalogue{get; set; }

    }
}