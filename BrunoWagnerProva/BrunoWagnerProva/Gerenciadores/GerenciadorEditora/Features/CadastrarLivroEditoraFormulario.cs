using BrunoWagnerProva.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrunoWagnerProva.Gerenciadores.GerenciadorEditora.Features
{
    public partial class CadastrarLivroEditoraFormulario : Form
    {
        private Editora _editoraLivros;
        private Livro _livroEditora;
        private List<Livro> _livros;

        public CadastrarLivroEditoraFormulario()
        {
            InitializeComponent();
        }

        public CadastrarLivroEditoraFormulario(Editora editoraSelecionadaLivros, List<Livro> livros)
        {
            InitializeComponent();

            editoraLivros = editoraSelecionadaLivros;

            _livros = livros;

            PopularCmbLivrosEditora(editoraLivros);
        }

        public Editora editoraLivros
        {
            get { return _editoraLivros; }
            set
            {
                _editoraLivros = value;
            }
        }

        public void PopularCmbLivrosEditora(Editora editora)
        {
            cmbLivros.Items.Clear();

            foreach (var item in _livros)
            {
                if (!editora.Livros.Any(l => l.Id == item.Id))
                {
                    cmbLivros.Items.Add(item);
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (_editoraLivros == null)
                _editoraLivros = new Editora();

            List<Livro> livro = new List<Livro>();
            _livroEditora = (Livro)cmbLivros.SelectedItem;
            livro.Add(_livroEditora);
            _editoraLivros.Livros = livro;

            try
            {
                _editoraLivros.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
