using BrunoWagnerProva.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoWagnerProva.Dominio.Interfaces
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        Editora AdicionarEditoraLivro(Editora editora);
        Editora AdicionarLivrosEditora(Editora editora);
        List<Livro> SelecionarLivrosEditora(Editora editora);
    }
}
