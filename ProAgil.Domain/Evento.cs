using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{

    public class Evento
    {
        public int id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string imagemUrl { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestranteEventos { get; set; }
    }
}
