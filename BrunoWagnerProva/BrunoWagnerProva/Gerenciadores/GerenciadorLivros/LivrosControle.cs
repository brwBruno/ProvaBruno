using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrunoWagnerProva.Dominio;

namespace BrunoWagnerProva.Gerenciadores.GerenciadorLivros
{
    public partial class LivrosControle : UserControl
    {
        public LivrosControle()
        {
            InitializeComponent();
        }

        public void CarregarListaLivros(IList<Livro> livros)
        {
            listBox1.Items.Clear();
            foreach (var item in livros)
            {
                listBox1.Items.Add(item);
            }
        }

        public Livro ObtemLivroSelecionado() => listBox1.SelectedItem as Livro;
    }
}
