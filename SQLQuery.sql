CREATE TABLE [dbo].[Categories](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Products](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[links](
	[id_category] [int] NOT NULL,
	[id_product] [int] NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Categories]
           ([id]
           ,[name])
     VALUES
           (1, 'male'),
		   (2, 'female'),
		   (3, 'kids')
GO

INSERT INTO [dbo].[Products]
           ([id]
           ,[name])
     VALUES
			(1, 'pants'),
			(2, 'shorts'),
			(3, 't-shirt'),
			(4, 'belt'),
			(5, 'socks'),
			(6, 'skirt')
GO

INSERT INTO [dbo].[links]
           ([id_category]
           ,[id_product])
     VALUES
           (1, 1),
		   (1, 2),
		   (2, 4),
		   (2, 6),
		   (3, 4)
GO

SELECT Products.name as Pname, Categories.name as Cname
  FROM Products LEFT JOIN links ON id_product = Products.id LEFT JOIN Categories ON id_category = Categories.id

GO
