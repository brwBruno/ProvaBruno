using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunoWagnerProva.Dominio;
using System.Data;
using BrunoWagnerProva.Dominio.Interfaces;

namespace BrunoWagnerProva.Infra.Datra
{
    public class LivroRepository : ILivroRepository
    {
        #region SQL

        private const string insertLivro = @"INSERT INTO TBLivro (Titulo,
                                                    Ano_Edicao,
                                                    Autor,
                                                    Volume)
                                             VALUES ({0}Titulo,
                                                    {0}Ano_Edicao,
                                                    {0}Autor,
                                                    {0}Volume)";
        private const string updateLivro = @"UPDATE TBLivro 
                                             SET Titulo = {0}Titulo,
                                                 Ano_Edicao = {0}Ano_Edicao,
                                                 Autor = {0}Autor,
                                                 Volume = {0}Volume
                                             WHERE Id = {0}Id";
        private const string deleteLivro = @"DELETE FROM TBLivro WHERE Id = {0}Id";
        private const string selectAllLivro = @"SELECT Id,
                                                Titulo,
                                                Ano_Edicao,
                                                Autor,
                                                Volume
                                             FROM TBLivro";

        private const string selectIdLivro = @"SELECT Id,
                                                Titulo,
                                                Ano_Edicao,
                                                Autor,
                                                Volume
                                             FROM TBLivro WHWRE Id = {0}Id";

        #endregion SQL

        public Livro Adicionar(Livro entidade)
        {
            entidade.Id = Db.Adicionar(insertLivro, Pegar(entidade));

            return entidade;
        }

        public Livro Editar(Livro entidade)
        {
            Db.Atualizar(updateLivro, Pegar(entidade));

            return entidade;
        }

        public void Excluir(Livro entidade)
        {
            Db.Deletar(deleteLivro, Pegar(entidade));
        }

        public Livro SelecionarPorId(Livro entidade)
        {
            var parms = new Dictionary<string, object> { { "Id", entidade.Id } };

            return Db.Selecionar(selectIdLivro, Converter, parms);
        }

        public List<Livro> SelecionarTodos()
        {
            return Db.SelecionarTodos(selectAllLivro, Converter);
        }

        private Dictionary<string, object> Pegar(Livro entidade)
        {
            return new Dictionary<string, object>
            {
                { "Id", entidade.Id },
                { "Titulo", entidade.Titulo },
                { "Ano_Edicao", entidade.AnoEdicao },
                { "Autor", entidade.Autor },
                { "Volume", entidade.Volume }
            };
        }

        private static Func<IDataReader, Livro> Converter = reader =>
          new Livro
          {
              Id = Convert.ToInt32(reader["Id"]),
              Titulo = Convert.ToString(reader["Titulo"]),
              AnoEdicao = Convert.ToInt32(reader["Ano_Edicao"]),
              Autor = Convert.ToString(reader["Autor"]),
              Volume = Convert.ToInt32(reader["Volume"])
          };
    }
}
