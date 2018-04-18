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

namespace BrunoWagnerProva.Gerenciadores.GerenciadorLivros
{
    public partial class LivroFormulario : Form
    {
        public LivroFormulario()
        {
            InitializeComponent();
        }

        public LivroFormulario(Livro livroNovo)
        {
            InitializeComponent();

            livro = livroNovo;
        }

        private Livro _livro;

        public Livro livro
        {
            get{ return _livro; } 
            set
            {
                _livro = value;
                txtTitulo.Text = _livro.Titulo;
                numAno.Value = _livro.AnoEdicao;
                txtAutor.Text = _livro.Autor;
                numVolume.Value = _livro.Volume;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_livro == null)
            {
                _livro = new Livro();
            }
            _livro.Titulo = txtTitulo.Text;
            _livro.AnoEdicao = Convert.ToInt32(numAno.Value);
            _livro.Autor = txtAutor.Text;
            _livro.Volume = Convert.ToInt32(numVolume.Value);
            try
            {
                _livro.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
