using BrunoWagnerProva.Aplicacao;
using BrunoWagnerProva.Dominio.Interfaces;
using BrunoWagnerProva.Gerenciadores.GerenciadorEditora;
using BrunoWagnerProva.Gerenciadores.GerenciadorLivros;
using BrunoWagnerProva.Gerenciadores.Principal;
using BrunoWagnerProva.Infra.Datra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrunoWagnerProva
{
    public partial class Principal : Form
    {
        private static ILivroRepository _livroRepository = new LivroRepository();
        private static IEditoraRepository _editoraRepository = new EditoraRepository();

        private LivroService _livroService = new LivroService(_livroRepository);
        private EditoraService _editoraService = new EditoraService(_editoraRepository);
        private GerenciadorFormulario _gerenciador;

        GerenciadorFormularioLivro _livroGerenciador;
        GerenciadorFormularioEditora _editoraGerenciador;


        public Principal()
        {
            InitializeComponent();
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            lblStatus.Text = _gerenciador.ObtemTipoCadastro();

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panel.Controls.Clear();

            panel.Controls.Add(listagem);

            _gerenciador.AtualizarLista();

            toolStrip1.Enabled = true;

            MenuBotoes();
        }

        private void MenuBotoes()
        {
            var estado = _gerenciador.PegarEstadoBotoes();
            btnCadastrar.Enabled = estado.Cadastrar;
            btnEditar.Enabled = estado.Editar;
            btnExcluir.Enabled = estado.Excluir;
            btnListLivroEdi.Visible = estado.ListarLivro;
            btnCadLivroEdi.Visible = estado.CadastrarLivro;

            var nome = _gerenciador.PegaNomeBotoes();
            btnCadastrar.Text = nome.Cadastrar;
            btnEditar.Text = nome.Editar;
            btnExcluir.Text = nome.Excluir;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Adicionar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Adicionar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Editar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Editar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            _gerenciador.Excluir();
        }

        private void livroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_livroGerenciador == null)
                _livroGerenciador = new GerenciadorFormularioLivro(_livroService);

            CarregarCadastro(_livroGerenciador);
        }

        private void editoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_editoraGerenciador == null)
                _editoraGerenciador = new GerenciadorFormularioEditora(_editoraService, _livroService);

            btnCadLivroEdi.Visible = true;
            btnListLivroEdi.Visible = true;

            CarregarCadastro(_editoraGerenciador);
        }

        private void btnCadLivroEdi_Click(object sender, EventArgs e)
        {
            _gerenciador.AdicionarLivrosEditora();
        }

        private void btnListLivroEdi_Click(object sender, EventArgs e)
        {
            _gerenciador.CarregarListagemEditora();
        }
    }
}
