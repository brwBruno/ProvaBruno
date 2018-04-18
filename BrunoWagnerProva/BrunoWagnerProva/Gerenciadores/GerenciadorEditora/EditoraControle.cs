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

namespace BrunoWagnerProva.Gerenciadores.GerenciadorEditora
{
    public partial class EditoraControle : UserControl
    {
        public EditoraControle()
        {
            InitializeComponent();
        }

        public void CarregarListaEditora(IList<Editora> editoras)
        {
            listBox1.Items.Clear();
            foreach (var item in editoras)
            {
                listBox1.Items.Add(item);
            }
        }

        public Editora ObtemEditoraSelecionado() => listBox1.SelectedItem as Editora;
    }
}
}
