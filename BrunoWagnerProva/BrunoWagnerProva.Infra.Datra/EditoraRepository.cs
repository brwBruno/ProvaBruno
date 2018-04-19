using BrunoWagnerProva.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunoWagnerProva.Dominio;
using System.Data;

namespace BrunoWagnerProva.Infra.Datra
{
    public class EditoraRepository : IEditoraRepository
    {
        #region SQL

        private const string insertEditora = @"INSERT INTO TBEditora (Nome,
                                                    Endereco,
                                                    Telefone)
                                             VALUES ({0}Nome,
                                                    {0}Endereco,
                                                    {0}Telefone)";
        private const string insertEditoraLivro = @"INSERT INTO TBEditora_Livros
                                                    (Id_Editora,
                                                     Id_Livro)
                                                    VALUES 
                                                    ({0}Id_Editora,
                                                     {0}Id_Livro)";
        private const string updateEditora = @"UPDATE TBEditora 
                                             SET Nome = {0}Nome,
                                                 Endereco = {0}Endereco,
                                                 Telefone = {0}Telefone
                                             WHERE Id = {0}Id";
        private const string deleteEditora = @"DELETE FROM TBEditora_Livros WHERE Id_Editora = {0}Id
                                               DELETE FROM TBEditora WHERE Id = {0}Id";
        private const string selectAllEditora = @"SELECT Id,
                                                Nome,
                                                Endereco,
                                                Telefone
                                             FROM TBEditora";
        private const string selectIdEditora = @"SELECT Id,
                                                Nome,
                                                Endereco,
                                                Telefone
                                             FROM TBEditora WHWRE Id = {0}Id";
        private const string selectLivrosEditora = @"SELECT l.Id,
                                                            l.Titulo,
                                                            l.Ano_edicao,
                                                            l.Autor,
                                                            l.Volume
                                                     FROM TBLivro AS l
                                                     INNER JOIN TBEditora_Livros AS el
                                                     ON l.Id = el.Id_livro
                                                     WHERE el.Id_Editora = {0}Id";

        #endregion SQL

        public Editora AdicionarEditoraLivro(Editora editora)
        {
            editora.Id = Db.Adicionar(insertEditora, Pegar(editora));

            foreach (Livro livro in editora.Livros)
            {
                Db.Adicionar(insertEditoraLivro, PegarEditoraLivro(editora, livro), false);
            }
            return editora;
        }

        public Editora AdicionarLivrosEditora(Editora editora)
        {
            foreach (Livro livro in editora.Livros)
            {
                Db.Adicionar(insertEditoraLivro, PegarEditoraLivro(editora, livro), false);
            }
            return editora;
        }

        public Editora Adicionar(Editora entidade)
        {
            throw new NotImplementedException();
        }

        public Editora Editar(Editora entidade)
        {
            Db.Atualizar(updateEditora, Pegar(entidade));

            return entidade;
        }

        public void Excluir(Editora entidade)
        {
            Db.Deletar(deleteEditora, Pegar(entidade));
        }

        public Editora SelecionarPorId(Editora entidade)
        {
            var parms = new Dictionary<string, object> { { "Id", entidade.Id } };

            return Db.Selecionar(selectIdEditora, Converter, parms);
        }

        public List<Editora> SelecionarTodos()
        {
            return Db.SelecionarTodos(selectAllEditora, Converter);
        }

        public List<Livro> SelecionarLivrosEditora(Editora entidade)
        {
            var parms = new Dictionary<string, object> { { "Id", entidade.Id } };

            return Db.SelecionarTodos<Livro>(selectLivrosEditora, ConverterLivros, parms);
        }

        private Dictionary<string, object> Pegar(Editora entidade)
        {
            return new Dictionary<string, object>
            {
                { "Id", entidade.Id },
                { "Nome", entidade.Nome },
                { "Endereco", entidade.Endereco },
                { "Telefone", entidade.Telefone }
            };
        }

        private static Func<IDataReader, Editora> Converter = reader =>
          new Editora
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"]),
              Endereco = Convert.ToString(reader["Endereco"]),
              Telefone = Convert.ToInt32(reader["Telefone"])
          };

        private static Func<IDataReader, Livro> ConverterLivros = reader =>
          new Livro
          {
              Id = Convert.ToInt32(reader["Id"]),
              Titulo = Convert.ToString(reader["Titulo"]),
              AnoEdicao = Convert.ToInt32(reader["Ano_Edicao"]),
              Autor = Convert.ToString(reader["Autor"]),
              Volume = Convert.ToInt32(reader["Volume"])
          };

        private Dictionary<string, object> PegarEditoraLivro(Editora editora, Livro livro)
        {
            return new Dictionary<string, object>
            {
                { "Id_Editora", editora.Id },
                { "Id_Livro", livro.Id }
            };
        }
    }
}
