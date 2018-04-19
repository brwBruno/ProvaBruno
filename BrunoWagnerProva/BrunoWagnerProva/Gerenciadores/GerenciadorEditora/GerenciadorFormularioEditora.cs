using BrunoWagnerProva.Gerenciadores.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunoWagnerProva.Botoes;
using System.Windows.Forms;
using BrunoWagnerProva.Aplicacao;
using BrunoWagnerProva.Dominio;
using BrunoWagnerProva.Gerenciadores.GerenciadorEditora.Features;

namespace BrunoWagnerProva.Gerenciadores.GerenciadorEditora
{
    public class GerenciadorFormularioEditora : GerenciadorFormulario
    {
        private EditoraService _editoraService;
        private LivroService _livroService;
        private EditoraControle _editoraControle;
        private List<Livro> livros;

        public GerenciadorFormularioEditora(EditoraService editoraService, LivroService livroService)
        {
            _editoraService = editoraService;
            _livroService = livroService;
        }

        public override void Adicionar()
        {
            AtualizaListaLivros();

            EditoraFormulario dialogo = new EditoraFormulario(livros);

            DialogResult resultado = dialogo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                _editoraService.Adicionar(dialogo.editora);
                MessageBox.Show("Cadastrado com sucesso");
            }
            AtualizarLista();
        }

        public override void AdicionarLivrosEditora()
        {
            AtualizaListaLivros();
            livros = new List<Livro>();

            Editora editoraSelecionado = _editoraControle.ObtemEditoraSelecionado();

            if (editoraSelecionado != null)
            {
                editoraSelecionado.Livros = _editoraService.SelecionarLivrosEditora(editoraSelecionado);
                livros = _livroService.SelecionarTodos();
                CadastrarLivroEditoraFormulario dialogo = new CadastrarLivroEditoraFormulario(editoraSelecionado, livros);

                DialogResult resultado = dialogo.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    _editoraService.AdicionarLivrosEditora(dialogo.editoraLivros);
                    MessageBox.Show("Cadastrado com sucesso");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Editora!");
            }
            
        }

        public override void AtualizarLista()
        {
            try
            {
                List<Editora> editoras = _editoraService.SelecionarTodos();
                _editoraControle.CarregarListaEditora(editoras);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public override UserControl CarregarListagem()
        {
            if (_editoraControle == null)
                _editoraControle = new EditoraControle();

            return _editoraControle;
        }

        public override void CarregarListagemEditora()
        {
            Editora editoraSelecionado = _editoraControle.ObtemEditoraSelecionado();
            if (editoraSelecionado != null)
            {
                editoraSelecionado.Livros = _editoraService.SelecionarLivrosEditora(editoraSelecionado);
                ListaLivrosEditoraFormulario listaLivrosEditoraFormulario = new ListaLivrosEditoraFormulario(editoraSelecionado);
                listaLivrosEditoraFormulario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma Editora!");
            }
        }

        public override void Editar()
        {
            AtualizaListaLivros();

            Editora editoraSelecionado = _editoraControle.ObtemEditoraSelecionado();

            if (editoraSelecionado != null)
            {
                editoraSelecionado.Livros = _editoraService.SelecionarLivrosEditora(editoraSelecionado);
                EditoraFormulario dialogo = new EditoraFormulario(editoraSelecionado);
                DialogResult resultado = dialogo.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _editoraService.Editar(editoraSelecionado);
                    MessageBox.Show("Editado com sucesso");
                }

                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Selecione uma Editora!");
            }
        }

        public override void Excluir()
        {
            Editora editoraSelecionado = _editoraControle.ObtemEditoraSelecionado();

            if (editoraSelecionado != null)
            {
                editoraSelecionado.Livros = _editoraService.SelecionarLivrosEditora(editoraSelecionado);
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir a Editora "
                    + editoraSelecionado.Nome, "Excluir Excluir", MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _editoraService.Excluir(editoraSelecionado);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    AtualizarLista();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Editora!");
            }
        }

        public override string ObtemObejto()
        {
            Editora editoraSelecionado = _editoraControle.ObtemEditoraSelecionado();
            if (editoraSelecionado != null)
                return Convert.ToString(editoraSelecionado.Nome);
            else
                return "";
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro Editora";
        }

        public override NomeBotoes PegaNomeBotoes()
        {
            return new NomeBotoes
            {
                Cadastrar = "Cadastrar Editora",
                Editar = "Editar Editora",
                Excluir = "Excluir Editora"
            };
        }

        public override EstadoBotoes PegarEstadoBotoes()
        {
            return new EstadoBotoes
            {
                Cadastrar = true,
                Editar = true,
                Excluir = true,
                CadastrarLivro = true,
                ListarLivro = true,
            };
        }

        private void AtualizaListaLivros()
        {
            livros = _livroService.SelecionarTodos();
        }
    }
}
