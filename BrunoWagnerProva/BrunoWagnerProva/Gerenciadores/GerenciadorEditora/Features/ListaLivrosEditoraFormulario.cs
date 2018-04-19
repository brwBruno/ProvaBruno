using BrunoWagnerProva.Dominio;
using BrunoWagnerProva.Gerenciadores.Principal;
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
    public partial class ListaLivrosEditoraFormulario : Form
    {
        public Editora _editora;
        public ListaLivrosEditoraFormulario(Editora editora)
        {
            InitializeComponent();

            _editora = editora;

            CarregarListaEditoraLivros(_editora);

            lblEditoraSelecionada.Text = _editora.Nome;
        }

        public void CarregarListaEditoraLivros(Editora _editora)
        {
            listBox1.Items.Clear();
            foreach (var item in _editora.Livros)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
