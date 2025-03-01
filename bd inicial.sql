USE [Examen]
GO
/****** Object:  Table [dbo].[C_Categoria]    Script Date: 28/02/2025 05:58:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_Categoria](
	[NIdCategoria] [smallint] NOT NULL,
	[VCategoria] [varchar](50) NOT NULL,
	[BActivo] [bit] NULL,
 CONSTRAINT [PK_C_Categoria] PRIMARY KEY CLUSTERED 
(
	[NIdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C_Prioridad]    Script Date: 28/02/2025 05:58:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_Prioridad](
	[NIdPrioridad] [smallint] NOT NULL,
	[VPrioridad] [varchar](50) NOT NULL,
	[BActivo] [bit] NULL,
 CONSTRAINT [PK_C_Prioridad] PRIMARY KEY CLUSTERED 
(
	[NIdPrioridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C_Tarea]    Script Date: 28/02/2025 05:58:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_Tarea](
	[NIdTarea] [int] NOT NULL,
	[VTarea] [varchar](50) NOT NULL,
	[NIdCategoria] [smallint] NULL,
	[NIdPrioridad] [smallint] NULL,
	[BActivo] [bit] NULL,
 CONSTRAINT [PK_C_Tarea] PRIMARY KEY CLUSTERED 
(
	[NIdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[C_Tarea]  WITH CHECK ADD  CONSTRAINT [FK_C_Tarea_C_Categoria] FOREIGN KEY([NIdCategoria])
REFERENCES [dbo].[C_Categoria] ([NIdCategoria])
GO
ALTER TABLE [dbo].[C_Tarea] CHECK CONSTRAINT [FK_C_Tarea_C_Categoria]
GO
ALTER TABLE [dbo].[C_Tarea]  WITH CHECK ADD  CONSTRAINT [FK_C_Tarea_C_Prioridad] FOREIGN KEY([NIdPrioridad])
REFERENCES [dbo].[C_Prioridad] ([NIdPrioridad])
GO
ALTER TABLE [dbo].[C_Tarea] CHECK CONSTRAINT [FK_C_Tarea_C_Prioridad]
GO
