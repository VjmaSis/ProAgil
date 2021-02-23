using ProAgil.Domen.ModelBD;
using ProAgil.Repository.Interfaces.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository.Interfaces
{
    public interface IEventoRepositorio : IRepositorioBase
    {
        Task<List<Evento>> GetAllEventosAsyncBtTema(string tema, bool incluirPalestrante);
        Task<List<Evento>> GetAllEventosAsync(bool incluirPalestrante);
        Task<Evento> GetEventoAsyncById(int id, bool incluirPalestrante);
    }
}
