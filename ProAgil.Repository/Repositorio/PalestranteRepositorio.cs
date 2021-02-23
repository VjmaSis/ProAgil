using Microsoft.EntityFrameworkCore;
using ProAgil.Domen.ModelBD;
using ProAgil.Repository.Contexto;
using ProAgil.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository.Repositorio
{
    public class PalestranteRepositorio : BaseRepositorio.RepositorioBase, IPalestranteRepositorio
    {
        private readonly ProAgilContext _context;

        public PalestranteRepositorio(ProAgilContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Palestrante>> GetAllPalestranteAsync(bool incluirEvento = false)
        {
            IQueryable<Palestrante> palestrantes = _context.Palestrantes.Include(p => p.RedeSociais);
            if (incluirEvento)
            {
                palestrantes = palestrantes.Include(p => p.Eventos);
            }

            return await palestrantes.ToListAsync();
        }

        public async Task<List<Palestrante>> GetAllPalestranteByNameAsync(string nome, bool incluirEvento = false)
        {
            IQueryable<Palestrante> palestrantes = _context.Palestrantes.Include(p => p.RedeSociais).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            if (incluirEvento)
            {
                palestrantes = palestrantes.Include(p => p.Eventos);
            }

            return await palestrantes.ToListAsync();
        }

        public async Task<Palestrante> GetPalestranteAsyncById(int id, bool incluirEvento = false)
        {
            return await _context.Palestrantes.FirstOrDefaultAsync(p => p.ID.Equals(id));
        }
    }
}
