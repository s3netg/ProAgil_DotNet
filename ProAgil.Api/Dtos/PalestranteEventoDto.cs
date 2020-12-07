namespace ProAgil.Api

{
    public class PalestranteEventoDto
    {
       public int PalestranteId { get; set; } 
       public PalestranteDto Palestrante { get;}
       public int EventoId { get; set; }
       public EventoDto Evento { get;set; }
    }
}