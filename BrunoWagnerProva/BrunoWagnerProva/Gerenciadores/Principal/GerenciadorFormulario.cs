using BrunoWagnerProva.Botoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrunoWagnerProva.Gerenciadores.Principal
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();
        public abstract UserControl CarregarListagem();
        public abstract void Excluir();
        public abstract void Editar();
        public abstract string ObtemTipoCadastro();
        public abstract void AtualizarLista();

        public abstract EstadoBotoes PegarEstadoBotoes();
        public abstract NomeBotoes PegaNomeBotoes();
    }
}
