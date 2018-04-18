CREATE TABLE [dbo].[TBEditora]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NCHAR(10) NOT NULL, 
    [Endereco] VARCHAR(255) NOT NULL, 
    [Telefone] INT NOT NULL
)
