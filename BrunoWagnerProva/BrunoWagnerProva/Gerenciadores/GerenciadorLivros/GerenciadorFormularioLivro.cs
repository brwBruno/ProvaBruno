using BrunoWagnerProva.Aplicacao;
using BrunoWagnerProva.Gerenciadores.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrunoWagnerProva.Botoes;
using BrunoWagnerProva.Dominio;

namespace BrunoWagnerProva.Gerenciadores.GerenciadorLivros
{
    public class GerenciadorFormularioLivro : GerenciadorFormulario
    {
        private LivroService _livroService;
        private LivrosControle _livroControle;


        public GerenciadorFormularioLivro(LivroService livroService)
        {
            _livroService = livroService;
        }

        public override void Adicionar()
        {
            LivroFormulario dialogo = new LivroFormulario();

            DialogResult resultado = dialogo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                _livroService.Adicionar(dialogo.livro);
                MessageBox.Show("Cadastrado com sucesso");
            }
            AtualizarLista();
        }

        public override void AtualizarLista()
        {
            try
            {
                
                IList<Livro> livros = _livroService.SelecionarTodos();
                _livroControle.CarregarListaLivros(livros);
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public override UserControl CarregarListagem()
        {
            if (_livroControle == null)
                _livroControle = new LivrosControle();

            return _livroControle;
        }

        public override void Editar()
        {
            Livro livroSelecionado = _livroControle.ObtemLivroSelecionado();

            if (livroSelecionado != null)
            {
                LivroFormulario dialogo = new LivroFormulario(livroSelecionado);
                DialogResult resultado = dialogo.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _livroService.Editar(livroSelecionado);
                }

                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Selecione uma disciplina!");
            }
        }

        public override void Excluir()
        {
            Livro livroSelecionado = _livroControle.ObtemLivroSelecionado();

            if(livroSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o Livro "
                    + livroSelecionado.Titulo,"Excluir Livro",MessageBoxButtons.OKCancel);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _livroService.Excluir(livroSelecionado);
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
                MessageBox.Show("Selecione uma disciplina!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro Livro";
        }

        public override NomeBotoes PegaNomeBotoes()
        {
            return new NomeBotoes
            {
                Cadastrar = "Cadastrar Livro",
                Editar = "Editar Livro",
                Excluir = "Excluir Livro"
            };
        }

        public override EstadoBotoes PegarEstadoBotoes()
        {
            return new EstadoBotoes
            {
                Cadastrar = true,
                Editar = true,
                Excluir = true
            };
        }
    }
}
