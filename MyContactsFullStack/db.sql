
CREATE TABLE [dbo].[Person](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Person] ([Id], [Name], [Email]) VALUES (N'bfd35aa9-971e-4f5a-9dc9-44e2fb2affc5', N'dfsds', N'dfsssdas')
GO
INSERT [dbo].[Person] ([Id], [Name], [Email]) VALUES (N'898647a3-2a93-456d-91b8-8c64b83ba3f3', N'Terje', N'terje@gdsf')

