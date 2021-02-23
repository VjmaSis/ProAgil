using ProAgil.Repository.Contexto;
using ProAgil.Repository.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository.Repositorio.BaseRepositorio
{
    public class RepositorioBase : IRepositorioBase, IDisposable
    {
        private readonly ProAgilContext _context;

        public RepositorioBase(ProAgilContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Dispose()
        {
            DisposeContext();
        }

        internal void DisposeContext()
        {
            if (_context is object)
            {
                _context.Dispose();
            }
        }
    }
}
