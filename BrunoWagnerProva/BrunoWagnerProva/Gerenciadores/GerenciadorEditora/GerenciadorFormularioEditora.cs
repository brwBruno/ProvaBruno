using BrunoWagnerProva.Gerenciadores.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunoWagnerProva.Botoes;
using System.Windows.Forms;
using BrunoWagnerProva.Aplicacao;

namespace BrunoWagnerProva.Gerenciadores.GerenciadorEditora
{
    public class GerenciadorFormularioEditora : GerenciadorFormulario
    {
        private EditoraService _editoraService;
        private EditoraControle _editoraControle;

        public GerenciadorFormularioEditora(EditoraService editoraService)
        {
            _editoraService = editoraService;
        }

        public override void Adicionar()
        {
            throw new NotImplementedException();
        }

        public override void AtualizarLista()
        {
            throw new NotImplementedException();
        }

        public override UserControl CarregarListagem()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override string ObtemTipoCadastro()
        {
            throw new NotImplementedException();
        }

        public override NomeBotoes PegaNomeBotoes()
        {
            throw new NotImplementedException();
        }

        public override EstadoBotoes PegarEstadoBotoes()
        {
            throw new NotImplementedException();
        }
    }
}
