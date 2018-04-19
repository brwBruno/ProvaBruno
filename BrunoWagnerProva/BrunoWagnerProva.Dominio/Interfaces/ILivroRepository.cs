using BrunoWagnerProva.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoWagnerProva.Dominio.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        bool ExisteFk(Livro livro);
    }
}
