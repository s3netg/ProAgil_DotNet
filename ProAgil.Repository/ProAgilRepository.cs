using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilContext _context { get; }

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }


        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);
            
           
            query = query.OrderByDescending(c => c.DataEvento);
           
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes=false)
        {
             IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);
           if (includePalestrantes)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.OrderByDescending(c => c.DataEvento)
                .Where(c=>c.Tema.Contains(tema));

            return await query.ToArrayAsync();
        }


        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
             IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);
          
            query = query.OrderByDescending(c => c.DataEvento)
                         .Where(c =>c.id == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(bool includeEventos =false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
             .Include(c => c.RedesSociais);
           if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(e =>e.Evento);
            }
            query = query.OrderBy(c => c.nome);
            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestrantesAsyncById(int id, bool includeEventos =false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
             .Include(c => c.RedesSociais);
           if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(e =>e.Evento);
            }
            query = query.OrderBy(c => c.nome)
                    .Where(c=>c.id== id);
            return await query.FirstOrDefaultAsync();
        }

    }
}