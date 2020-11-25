
using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Palestrante
    {
        public int id { get; set; } 
        public string nome { get; set; }
        public string  MiniCurriculo { get; set; }
        public string  ImagemUrl { get; set; }
        public string  Telefone { get; set; }   
        public string email { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestranteEventos { get; set; }
        
        
    }
}