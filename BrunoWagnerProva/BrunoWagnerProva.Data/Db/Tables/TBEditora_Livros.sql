CREATE TABLE [dbo].[TBEditora_Livros]
(
	[Id_Editora] INT NOT NULL , 
    [Id_Livro] INT NOT NULL, 
    CONSTRAINT [FK_TBEditora] FOREIGN KEY ([Id_Editora]) REFERENCES [dbo].[TBEditora]([Id]), 
    CONSTRAINT [FK_TBLivro] FOREIGN KEY (Id_Livro) REFERENCES [dbo].[TBLivro]([Id])
)
