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
                                                    Endereço,
                                                    Telefone)
                                             VALUES ({0}Nome,
                                                    {0}Endereço,
                                                    {0}Telefone)";
        private const string updateEditora = @"UPDATE TBEditora 
                                             SET Nome = {0}Nome,
                                                 Endereço = {0}Endereço,
                                                 Telefone = {0}Telefone
                                             WHERE Id = {0}Id";
        private const string deleteEditora = @"DELETE FROM TBEditora WHERE Id = {0}Id";
        private const string selectAllEditora = @"SELECT Id,
                                                Nome,
                                                Endereço,
                                                Telefone
                                             FROM TBEditora";
        private const string selectIdEditora = @"SELECT Id,
                                                Nome,
                                                Endereço,
                                                Telefone
                                             FROM TBEditora WHWRE Id = {0}Id";

        #endregion SQL

        public Editora Adicionar(Editora entidade)
        {
            entidade.Id = Db.Adicionar(insertEditora, Pegar(entidade));

            return entidade;
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

        private Dictionary<string, object> Pegar(Editora entidade)
        {
            return new Dictionary<string, object>
            {
                { "Id", entidade.Id },
                { "Nome", entidade.Nome },
                { "Endereço", entidade.Endereco },
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
    }
}
}
