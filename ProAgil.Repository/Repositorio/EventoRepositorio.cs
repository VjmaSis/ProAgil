using ProAgil.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProAgil.Domen.ModelBD;
using ProAgil.Repository.Contexto;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository.Repositorio.BaseRepositorio;

namespace ProAgil.Repository.Repositorio
{
    public class EventoRepositorio : RepositorioBase, IEventoRepositorio
    {
        private readonly ProAgilContext _context;

        public EventoRepositorio(ProAgilContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Evento>> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            IQueryable<Evento> eventos = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais);
            if (incluirPalestrante)
            {
                eventos =  eventos.Include(e => e.Palestrantes);
            }

            return await eventos.AsNoTracking().ToListAsync();
        }

        public async Task<List<Evento>> GetAllEventosAsyncBtTema(string tema, bool incluirPalestrante = false)
        {
            IQueryable<Evento> eventos = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedeSociais).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            if (incluirPalestrante)
            {
                eventos = eventos.Include(e => e.Palestrantes);
            }

            return await eventos.AsNoTracking().OrderByDescending(e => e.DataEvento).ToListAsync();
        }

        public async Task<Evento> GetEventoAsyncById(int id, bool incluirPalestrante = false)
        {
            return await _context.Eventos.AsNoTracking().Include(e => e.Lotes).Include(e => e.RedeSociais).FirstOrDefaultAsync(e => e.ID.Equals(id));
        }
    }
}
