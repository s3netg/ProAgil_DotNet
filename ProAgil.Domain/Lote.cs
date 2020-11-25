using System;
namespace ProAgil.Domain
{
    public class Lote
    {
        public int Id  { get; set; }
        public string NOme { get; set; }
        public int  preco { get; set; } 
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId  { get; set; }
        public Evento Evento { get;  }

    }
}