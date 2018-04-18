using BrunoWagnerProva.Dominio;
using BrunoWagnerProva.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoWagnerProva.Aplicacao
{
    public class LivroService
    {
        private ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Adicionar(Livro entidade)
        {
            entidade.Valida();
            _livroRepository.Adicionar(entidade);
        }

        public void Editar(Livro entidade)
        {
            entidade.Valida();
            _livroRepository.Editar(entidade);
        }

        public void Excluir(Livro entidade)
        {
            entidade.Valida();
            _livroRepository.Excluir(entidade);
        }

        public Livro SelecionarPorId(Livro entidade)
        {
            return _livroRepository.SelecionarPorId(entidade);
        }

        public List<Livro> SelecionarTodos()
        {
            return _livroRepository.SelecionarTodos();
        }
    }
}
