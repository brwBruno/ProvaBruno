using BrunoWagnerProva.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoWagnerProva.Dominio
{
    public class Livro : Entidade
    {
        public string Titulo { get; set; }
        public int AnoEdicao { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", Titulo, AnoEdicao, Autor, Volume);
        }

        public override void Valida()
        {
            if (Titulo.Length < 4)
                throw new Exception("O campo deve ter mais que 4 caracteres");
            if (Titulo.Length > 45)
                throw new Exception("O campo nao pode ter mais que 45 caracteres");
            if (AnoEdicao < 0)
                throw new Exception("O campo nao pode ser vazio");
            if (Autor.Length < 4)
                throw new Exception("O campo deve ter mais que 4 caracteres");
            if (Autor.Length > 45)
                throw new Exception("O campo nao pode ter mais que 45 caracteres");
            if (Volume < 0)
                throw new Exception("O campo nao pode ser vazio");
        }
    }
}
