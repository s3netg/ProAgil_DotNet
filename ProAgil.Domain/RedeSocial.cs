namespace ProAgil.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string URL   { get; set; }
        public int? EventoId { get; set; }
        public int? PalestranteId { get; set; }
        public Evento Evento { get;  }
        public Palestrante Palestrantes { get; }

    }
}