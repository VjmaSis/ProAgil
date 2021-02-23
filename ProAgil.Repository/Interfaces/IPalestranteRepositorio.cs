using ProAgil.Domen.ModelBD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository.Interfaces
{
    public interface IPalestranteRepositorio
    {
        Task<List<Palestrante>> GetAllPalestranteAsync(bool incluirEvento);
        Task<Palestrante> GetPalestranteAsyncById(int id, bool incluirEvento);

        Task<List<Palestrante>> GetAllPalestranteByNameAsync(string nome, bool incluirEvento);
    }
}
