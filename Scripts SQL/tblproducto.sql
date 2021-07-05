USE [BD_SantaMesa]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 05/07/2021 8:57:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
DROP TABLE [dbo].[Productos]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 05/07/2021 8:57:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[id_Producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [char](30) NULL,
	[idioma] [char](10) NULL,
	[edad_player] [int] NULL,
	[descripcion] [text] NULL,
	[imagen] [varchar](400) NULL,
	[estado] [bit] NULL,
	[precio] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


