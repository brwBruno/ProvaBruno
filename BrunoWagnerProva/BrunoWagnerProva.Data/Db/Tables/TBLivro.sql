CREATE TABLE [dbo].[TBLivro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Titulo] VARCHAR(100) NOT NULL, 
    [Ano_Edicao] INT NOT NULL, 
    [Autor] VARCHAR(50) NOT NULL, 
    [Volume] INT NOT NULL
)
