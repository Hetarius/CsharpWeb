
USE [Instituto]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 4/21/2020 7:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[DNI] [varchar](10) NULL,
	[Mail] [varchar](1000) NULL,
	[Telefono] [varchar](15) NULL,
	[Cuota] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 4/21/2020 7:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[FechaInicio] [datetime] NULL,
	[Hora] [varchar](5) NULL,
	[Precio] [numeric](18, 2) NULL,
	[IdProfesor] [int] NULL,
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursosAlumnos]    Script Date: 4/21/2020 7:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursosAlumnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NULL,
	[IdCurso] [int] NULL,
 CONSTRAINT [PK_CursosAlumnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 4/21/2020 7:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[DNI] [varchar](10) NULL,
	[Mail] [varchar](1000) NULL,
	[Telefono] [varchar](15) NULL,
	[Sueldo] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Profesores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 
GO
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [DNI], [Mail], [Telefono], [Cuota]) VALUES (1, N'Rodrigo', N'Moreiras', N'454545', N'juan@gmail.com', N'45454', CAST(1000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [DNI], [Mail], [Telefono], [Cuota]) VALUES (2, N'Rodrigo', N'Moreiras', N'45452369', N'mariano@mariano.com', N'61395497', CAST(1000.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Apellido], [DNI], [Mail], [Telefono], [Cuota]) VALUES (3, N'Juan', N'Perez', N'45454545', N'jejej@kkwkwk.com', N'44444', CAST(15.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[Cursos] ON 
GO
INSERT [dbo].[Cursos] ([Id], [Nombre], [FechaInicio], [Hora], [Precio], [IdProfesor]) VALUES (1, N'Programacion', CAST(N'2020-03-01T00:00:00.000' AS DateTime), N'19:00', CAST(1000.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[Cursos] ([Id], [Nombre], [FechaInicio], [Hora], [Precio], [IdProfesor]) VALUES (2, N'Intro programacion', CAST(N'2020-03-03T00:00:00.000' AS DateTime), N'19:00', CAST(5000.00 AS Numeric(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesores] ON 
GO
INSERT [dbo].[Profesores] ([Id], [Nombre], [Apellido], [DNI], [Mail], [Telefono], [Sueldo]) VALUES (1, N'Pedro', N'Rodriguez', N'5555666', N'pedro@gmail.com', N'4545-6969', CAST(1000.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Profesores] OFF
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Cursos_Profesores] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesores] ([Id])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Cursos_Profesores]
GO
ALTER TABLE [dbo].[CursosAlumnos]  WITH CHECK ADD  CONSTRAINT [FK_CursosAlumnos_Alumnos] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumnos] ([Id])
GO
ALTER TABLE [dbo].[CursosAlumnos] CHECK CONSTRAINT [FK_CursosAlumnos_Alumnos]
GO
ALTER TABLE [dbo].[CursosAlumnos]  WITH CHECK ADD  CONSTRAINT [FK_CursosAlumnos_Cursos] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Cursos] ([Id])
GO
ALTER TABLE [dbo].[CursosAlumnos] CHECK CONSTRAINT [FK_CursosAlumnos_Cursos]
GO
USE [master]
GO
ALTER DATABASE [Instituto3] SET  READ_WRITE 

