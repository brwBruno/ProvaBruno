namespace BrunoWagnerProva.Gerenciadores.GerenciadorEditora.Features
{
    partial class ListaLivrosEditoraFormulario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEditoraSelecionada = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblEditoraSelecionada
            // 
            this.lblEditoraSelecionada.AutoSize = true;
            this.lblEditoraSelecionada.Location = new System.Drawing.Point(13, 13);
            this.lblEditoraSelecionada.Name = "lblEditoraSelecionada";
            this.lblEditoraSelecionada.Size = new System.Drawing.Size(66, 13);
            this.lblEditoraSelecionada.TabIndex = 1;
            this.lblEditoraSelecionada.Text = "Selecionada";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(259, 212);
            this.listBox1.TabIndex = 2;
            // 
            // ListaLivrosEditoraFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblEditoraSelecionada);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaLivrosEditoraFormulario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Livros Editora ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEditoraSelecionada;
        private System.Windows.Forms.ListBox listBox1;
    }
}