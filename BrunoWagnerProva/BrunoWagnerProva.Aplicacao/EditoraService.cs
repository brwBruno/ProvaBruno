using BrunoWagnerProva.Dominio;
using BrunoWagnerProva.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoWagnerProva.Aplicacao
{
    public class EditoraService
    {
        private IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public void Adicionar(Editora entidade)
        {
            entidade.Valida();
            _editoraRepository.AdicionarEditoraLivro(entidade);
        }

        public void AdicionarLivrosEditora(Editora entidade)
        {
            entidade.Valida();
            _editoraRepository.AdicionarLivrosEditora(entidade);
        }

        public void Editar(Editora entidade)
        {
            entidade.Valida();
            _editoraRepository.Editar(entidade);
        }

        public void Excluir(Editora entidade)
        {
            entidade.Valida();
            _editoraRepository.Excluir(entidade);
        }

        public Editora SelecionarPorId(Editora entidade)
        {
            return _editoraRepository.SelecionarPorId(entidade);
        }

        public List<Editora> SelecionarTodos()
        {
            return _editoraRepository.SelecionarTodos();
        }

        public List<Livro> SelecionarLivrosEditora(Editora entidade)
        {
            return _editoraRepository.SelecionarLivrosEditora(entidade);
        }
    }
}
