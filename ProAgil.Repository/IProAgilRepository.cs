using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
         void Add<T>(T Entity) where T:class;
         void Update<T>(T Entity) where T:class;
         void Delete<T>(T Entity) where T:class;
         Task<bool> SaveChangesAsync();
         public void DeleteRange<T>(T[] entityArray) where T : class;
      
         Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
         Task<Evento> GetEventoAsyncById(int EventoId,bool includePalestrantes);

        Task<Palestrante[]> GetAllPalestrantesAsyncByName(bool includeEventos);
        Task<Palestrante> GetPalestrantesAsyncById(int id, bool IncludeEventos);
    }
}