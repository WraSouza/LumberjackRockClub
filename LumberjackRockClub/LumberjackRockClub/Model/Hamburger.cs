using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LumberjackRockClub.Model
{
    public class Hamburger
    {
        public string NomeHamburger { get; set; }
        public string Preco { get; set; }
        public string Ingredientes { get; set; }
        public string CaminhoImagem { get; set; }
        public bool Promocao { get; set; }
    }
}
