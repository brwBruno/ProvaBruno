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

namespace BrunoWagnerProva.Gerenciadores.GerenciadorEditora
{
    public partial class EditoraFormulario : Form
    {
        private Editora _editora;
        private Livro _livroEditora;
        public Editora editora
        {
            get { return _editora; }
            set
            {
                _editora = value;
                txtNome.Text = _editora.Nome;
                foreach (Livro item in _editora.Livros)
                {
                    cmbLivros.Items.Add(item);
                }
                txtEndereco.Text = _editora.Endereco;
                mskTelefone.Text = Convert.ToString(_editora.Telefone);
            }
        }

        public EditoraFormulario()
        {
            InitializeComponent();
        }

        public EditoraFormulario(Editora editoraSelecionada)
        {
            InitializeComponent();

            editora = editoraSelecionada;
        }

        public EditoraFormulario(IList<Livro> livros)
        {
            InitializeComponent();

            PopulaCmbLivros(livros);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_editora == null)
                _editora = new Editora();


            List<Livro> livro = new List<Livro>();
            _editora.Nome = txtNome.Text;
            _livroEditora = (Livro)cmbLivros.SelectedItem;
            livro.Add(_livroEditora);
            _editora.Livros = livro;
            _editora.Endereco = txtEndereco.Text;
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            _editora.Telefone = Convert.ToInt32(mskTelefone.Text);

            try
            {
                _editora.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulaCmbLivros(IList<Livro> livros)
        {
            cmbLivros.Items.Clear();

            foreach (var item in livros)
            {
                cmbLivros.Items.Add(item);
            }
        }
    }
}
