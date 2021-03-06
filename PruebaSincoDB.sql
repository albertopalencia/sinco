 
/****** Object:  Table [dbo].[Alumnos]    Script Date: 27/09/2021 12:00:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Edad] [smallint] NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignaturaProfesor]    Script Date: 27/09/2021 12:00:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignaturaProfesor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAsignatura] [int] NOT NULL,
	[IdProfesor] [int] NOT NULL,
 CONSTRAINT [PK_MateriaProfesor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignaturas]    Script Date: 27/09/2021 12:00:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaturas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Asignaturas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignaturasAlumno]    Script Date: 27/09/2021 12:00:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignaturasAlumno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NOT NULL,
	[IdAsignatura] [int] NOT NULL,
	[AnioLectivo] [smallint] NOT NULL,
	[Calificacion] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_AsignaturasAlumno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 27/09/2021 12:00:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Edad] [smallint] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 

INSERT [dbo].[Alumnos] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (1, N'154545', N'Alberto', N'Palencia', 33, N'Manzana k casa 4', N'3506183409')
INSERT [dbo].[Alumnos] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (8, N'78945611', N'Pepito', N'Perez', 25, N'Calle 123b#14-06', N'145236789')
INSERT [dbo].[Alumnos] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (9, N'741854795', N'Ricardo', N'Cantillo', 45, N'Transv 91 #2-92 Tierra buena', N'3174859645')
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[AsignaturaProfesor] ON 

INSERT [dbo].[AsignaturaProfesor] ([Id], [IdAsignatura], [IdProfesor]) VALUES (1, 1, 1)
INSERT [dbo].[AsignaturaProfesor] ([Id], [IdAsignatura], [IdProfesor]) VALUES (5, 2, 4)
INSERT [dbo].[AsignaturaProfesor] ([Id], [IdAsignatura], [IdProfesor]) VALUES (4, 3, 3)
INSERT [dbo].[AsignaturaProfesor] ([Id], [IdAsignatura], [IdProfesor]) VALUES (6, 4, 5)
SET IDENTITY_INSERT [dbo].[AsignaturaProfesor] OFF
GO
SET IDENTITY_INSERT [dbo].[Asignaturas] ON 

INSERT [dbo].[Asignaturas] ([Id], [Nombre]) VALUES (1, N'Música')
INSERT [dbo].[Asignaturas] ([Id], [Nombre]) VALUES (2, N'Matemáticas')
INSERT [dbo].[Asignaturas] ([Id], [Nombre]) VALUES (3, N'Ciencias')
INSERT [dbo].[Asignaturas] ([Id], [Nombre]) VALUES (4, N'Filosofia')
SET IDENTITY_INSERT [dbo].[Asignaturas] OFF
GO
SET IDENTITY_INSERT [dbo].[AsignaturasAlumno] ON 

INSERT [dbo].[AsignaturasAlumno] ([Id], [IdAlumno], [IdAsignatura], [AnioLectivo], [Calificacion]) VALUES (1, 1, 1, 2020, CAST(3.50 AS Decimal(18, 2)))
INSERT [dbo].[AsignaturasAlumno] ([Id], [IdAlumno], [IdAsignatura], [AnioLectivo], [Calificacion]) VALUES (2, 1, 1, 2021, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[AsignaturasAlumno] ([Id], [IdAlumno], [IdAsignatura], [AnioLectivo], [Calificacion]) VALUES (3, 1, 2, 2022, CAST(2.90 AS Decimal(18, 2)))
INSERT [dbo].[AsignaturasAlumno] ([Id], [IdAlumno], [IdAsignatura], [AnioLectivo], [Calificacion]) VALUES (4, 1, 1, 2022, CAST(3.50 AS Decimal(18, 2)))
INSERT [dbo].[AsignaturasAlumno] ([Id], [IdAlumno], [IdAsignatura], [AnioLectivo], [Calificacion]) VALUES (6, 8, 1, 2019, CAST(3.20 AS Decimal(18, 2)))
INSERT [dbo].[AsignaturasAlumno] ([Id], [IdAlumno], [IdAsignatura], [AnioLectivo], [Calificacion]) VALUES (7, 1, 1, 2024, CAST(3.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[AsignaturasAlumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesores] ON 

INSERT [dbo].[Profesores] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (1, N'787979', N'Loraine', N'Palomino', 29, N'Mz k casa 20 santa marta', N'45656446')
INSERT [dbo].[Profesores] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (2, N'787919', N'Lorenzo', N'Palomino', 30, N'Mz k casa 20 pivijay', N'45656446')
INSERT [dbo].[Profesores] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (3, N'78412012', N'Jose ', N'Palencia Benedetty', 38, N'Barranquilla', N'352145141')
INSERT [dbo].[Profesores] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (4, N'123456789', N'Juan', N'ternera', 44, N'Quillita', N'444444')
INSERT [dbo].[Profesores] ([Id], [Identificacion], [Nombre], [Apellido], [Edad], [Direccion], [Telefono]) VALUES (5, N'852963741', N'Javier', N'Acosta', 44, N'Manzana 5', N'74845412')
SET IDENTITY_INSERT [dbo].[Profesores] OFF
GO
ALTER TABLE [dbo].[AsignaturaProfesor]  WITH CHECK ADD  CONSTRAINT [FK_AsiganturaProfesor_Asignaturas] FOREIGN KEY([IdAsignatura])
REFERENCES [dbo].[Asignaturas] ([Id])
GO
ALTER TABLE [dbo].[AsignaturaProfesor] CHECK CONSTRAINT [FK_AsiganturaProfesor_Asignaturas]
GO
ALTER TABLE [dbo].[AsignaturaProfesor]  WITH CHECK ADD  CONSTRAINT [FK_AsiganturaProfesor_Profesores] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesores] ([Id])
GO
ALTER TABLE [dbo].[AsignaturaProfesor] CHECK CONSTRAINT [FK_AsiganturaProfesor_Profesores]
GO
ALTER TABLE [dbo].[AsignaturasAlumno]  WITH CHECK ADD  CONSTRAINT [FK_AsignaturasAlumno_Alumnos] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumnos] ([Id])
GO
ALTER TABLE [dbo].[AsignaturasAlumno] CHECK CONSTRAINT [FK_AsignaturasAlumno_Alumnos]
GO
ALTER TABLE [dbo].[AsignaturasAlumno]  WITH CHECK ADD  CONSTRAINT [FK_AsignaturasAlumno_Asignaturas] FOREIGN KEY([IdAsignatura])
REFERENCES [dbo].[Asignaturas] ([Id])
GO
ALTER TABLE [dbo].[AsignaturasAlumno] CHECK CONSTRAINT [FK_AsignaturasAlumno_Asignaturas]
GO
/****** Object:  StoredProcedure [dbo].[TotalProductoComprado]    Script Date: 27/09/2021 12:00:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Alberto Palencia Benedetty
-- Create date: 21-09-2021
-- Description:	Devuelve el total comprado por un usuario
-- =============================================
CREATE PROCEDURE [dbo].[TotalProductoComprado]
	 @xml_usuarios XML,
	 @xml_compras XML, 
	 @xml_itemsIva XML 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     DECLARE @docHandleUsuario int,@docHandleCompra int, @docHandleItemsIva int ;

EXEC sp_xml_preparedocument @docHandleUsuario OUTPUT, @xml_usuarios; 
EXEC sp_xml_preparedocument @docHandleCompra OUTPUT, @xml_compras;
EXEC sp_xml_preparedocument @docHandleItemsIva OUTPUT, @xml_itemsIva;


SELECT
Datos.Id,
Datos.Nombre,
Sum(Datos.Valor) AS ValorTotal,
Sum(Datos.Iva) AS Iva
FROM ( 
		SELECT  
			 Usu.Id,
			 Usu.Nombre,
			 ISNULL(Item.Valor,0) AS Valor,
			 ISNULL(Item.Valor,0) * ISNULL(ItemsIva.Porcentaje,0)  AS Iva 
		 FROM OPENXML(@docHandleUsuario, '/Data/Usuario', 2)   
		      WITH (
					Id int,
					Nombre varchar(80)
					) As Usu   LEFT JOIN  (
		 SELECT  
				Item.Valor,
				Item.Usuario,
				Item.Producto
		 FROM OPENXML(@docHandleCompra, '/Data/Item', 2)
				WITH (
						Usuario int,
						Producto int,
						Valor numeric(8,2) 
					  ) AS Item		
										   ) AS Item 
		        ON Usu.Id = Item.Usuario  LEFT  JOIN  (

		 SELECT  
				ItemsIva.IdProducto,
				ItemsIva.Porcentaje
		 FROM OPENXML(@docHandleItemsIva, '/Data/Producto', 2)
				WITH ( 
						IdProducto int,
						Porcentaje numeric(8,2) 
					  ) AS ItemsIva						) AS ItemsIva 

				ON Item.Producto = ItemsIva.IdProducto
	) AS Datos

GROUP BY Datos.Id, Datos.Nombre
ORDER BY Datos.Id
 

EXEC sp_xml_removedocument  @docHandleUsuario;
EXEC sp_xml_removedocument  @docHandleCompra;
EXEC sp_xml_removedocument  @docHandleItemsIva;


END
GO
