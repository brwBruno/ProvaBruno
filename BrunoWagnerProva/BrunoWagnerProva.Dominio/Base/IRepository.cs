using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoWagnerProva.Dominio.Base
{
    public interface IRepository<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Editar(T entidade);
        void Excluir(T entidade);
        List<T> SelecionarTodos();
        T SelecionarPorId(T entidade);
    }
}
