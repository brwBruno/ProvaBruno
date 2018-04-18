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
        public EditoraFormulario()
        {
            InitializeComponent();
        }

        public EditoraFormulario(Editora editoraSelecionada)
        {
            InitializeComponent();

            editora = editoraSelecionada;
        }

        private Editora _editora;

        public Editora editora
        {
            get { return _editora; }
            set
            {
                _editora = value;
                txtNome.Text = _editora.Nome;
                foreach (var item in _editora.Livros)
                {
                    cmbLivros.Items.Add(item);
                }
                txtEndereco.Text = _editora.Endereco;
                mskTelefone.Text = Convert.ToString(_editora.Telefone);
            }
        }
    }
}
