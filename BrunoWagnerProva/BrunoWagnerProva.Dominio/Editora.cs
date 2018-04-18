using BrunoWagnerProva.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoWagnerProva.Dominio
{
    public class Editora : Entidade
    {
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }

        public override void Valida()
        {
            if (Nome.Length < 4)
                throw new Exception("O campo deve ter mais de 4 caracteres");
            if (Nome.Length > 45)
                throw new Exception("O campo nao pode ter mais que 45 caracteres");
            if (Endereco.Length < 10)
                throw new Exception("o campo deve ter mais que 10 caracteres");
            if (Endereco.Length > 245)
                throw new Exception("O campo nao pode ter mais que 245 caracteres");
            if (Telefone < 0)
                throw new Exception("O campo nao pode ser vazio");
        }
    }
}
