USE [master]
GO
/****** Object:  Database [PeluditosDB]    Script Date: 21/08/2023 18:22:47 ******/
CREATE DATABASE [PeluditosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PeluditosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PeluditosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PeluditosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PeluditosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PeluditosDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PeluditosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PeluditosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PeluditosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PeluditosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PeluditosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PeluditosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PeluditosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PeluditosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PeluditosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PeluditosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PeluditosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PeluditosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PeluditosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PeluditosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PeluditosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PeluditosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PeluditosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PeluditosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PeluditosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PeluditosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PeluditosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PeluditosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PeluditosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PeluditosDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PeluditosDB] SET  MULTI_USER 
GO
ALTER DATABASE [PeluditosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PeluditosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PeluditosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PeluditosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PeluditosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PeluditosDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PeluditosDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [PeluditosDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PeluditosDB]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[IdCarrito] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[DiasCaducidad] [int] NOT NULL,
	[Subtotal] [decimal](8, 2) NOT NULL,
	[Descuento] [decimal](8, 2) NOT NULL,
	[Iva] [decimal](8, 2) NOT NULL,
	[Total] [decimal](8, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[IdCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarritoDt]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarritoDt](
	[IdCarritoDt] [int] IDENTITY(1,1) NOT NULL,
	[IdCarrito] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioU] [decimal](8, 2) NOT NULL,
	[Subtotal] [decimal](8, 2) NOT NULL,
	[Descuento] [decimal](8, 2) NOT NULL,
	[Iva] [decimal](8, 2) NOT NULL,
	[Total] [decimal](8, 2) NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CarritoDt] PRIMARY KEY CLUSTERED 
(
	[IdCarritoDt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](35) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](75) NOT NULL,
	[Identificacion] [varchar](15) NOT NULL,
	[Genero] [char](1) NOT NULL,
	[IdEstadoCivil] [int] NOT NULL,
	[Email] [varchar](70) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCivil]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCivil](
	[IdEstadoCivil] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_EstadoCivil] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCivil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascota]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascota](
	[IdMascota] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Mascota] PRIMARY KEY CLUSTERED 
(
	[IdMascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[PrecioCosto] [decimal](8, 2) NOT NULL,
	[PrecioVenta] [decimal](8, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoMascota]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoMascota](
	[IdProductoMascota] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdMascota] [int] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductoMascota] PRIMARY KEY CLUSTERED 
(
	[IdProductoMascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Rol_1] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPago]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPago](
	[IdTipoPago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[IdTipoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](75) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Clave] [varchar](50) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTipoPago] [int] NOT NULL,
	[Subtotal] [decimal](8, 2) NOT NULL,
	[Descuento] [decimal](8, 2) NOT NULL,
	[Iva] [decimal](8, 2) NOT NULL,
	[Total] [decimal](8, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaDt]    Script Date: 21/08/2023 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDt](
	[IdVentaDt] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioU] [decimal](8, 2) NOT NULL,
	[Subtotal] [decimal](8, 2) NOT NULL,
	[Descuento] [decimal](8, 2) NOT NULL,
	[Iva] [decimal](8, 2) NOT NULL,
	[Total] [decimal](8, 2) NOT NULL,
	[CreadoDate] [datetime] NOT NULL,
 CONSTRAINT [PK_VentaDt] PRIMARY KEY CLUSTERED 
(
	[IdVentaDt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrito] ADD  CONSTRAINT [DF_Carrito_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Carrito] ADD  CONSTRAINT [DF_Carrito_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[CarritoDt] ADD  CONSTRAINT [DF_CarritoDt_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [DF_Categoria_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [DF_Categoria_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[EstadoCivil] ADD  CONSTRAINT [DF_EstadoCivil_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[EstadoCivil] ADD  CONSTRAINT [DF_EstadoCivil_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Mascota] ADD  CONSTRAINT [DF_Mascota_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Mascota] ADD  CONSTRAINT [DF_Mascota_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[ProductoMascota] ADD  CONSTRAINT [DF_ProductoMascota_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Rol] ADD  CONSTRAINT [DF_Rol_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Rol] ADD  CONSTRAINT [DF_Rol_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[TipoPago] ADD  CONSTRAINT [DF_TipoPago_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[TipoPago] ADD  CONSTRAINT [DF_TipoPago_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_User_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_User_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Venta] ADD  CONSTRAINT [DF_Venta_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Venta] ADD  CONSTRAINT [DF_Venta_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[VentaDt] ADD  CONSTRAINT [DF_VentaDt_CreadoDate]  DEFAULT (getdate()) FOR [CreadoDate]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Cliente]
GO
ALTER TABLE [dbo].[CarritoDt]  WITH CHECK ADD  CONSTRAINT [FK_CarritoDt_Carrito] FOREIGN KEY([IdCarrito])
REFERENCES [dbo].[Carrito] ([IdCarrito])
GO
ALTER TABLE [dbo].[CarritoDt] CHECK CONSTRAINT [FK_CarritoDt_Carrito]
GO
ALTER TABLE [dbo].[CarritoDt]  WITH CHECK ADD  CONSTRAINT [FK_CarritoDt_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[CarritoDt] CHECK CONSTRAINT [FK_CarritoDt_Producto]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_EstadoCivil] FOREIGN KEY([IdEstadoCivil])
REFERENCES [dbo].[EstadoCivil] ([IdEstadoCivil])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_EstadoCivil]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[ProductoMascota]  WITH CHECK ADD  CONSTRAINT [FK_ProductoMascota_Mascota] FOREIGN KEY([IdMascota])
REFERENCES [dbo].[Mascota] ([IdMascota])
GO
ALTER TABLE [dbo].[ProductoMascota] CHECK CONSTRAINT [FK_ProductoMascota_Mascota]
GO
ALTER TABLE [dbo].[ProductoMascota]  WITH CHECK ADD  CONSTRAINT [FK_ProductoMascota_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[ProductoMascota] CHECK CONSTRAINT [FK_ProductoMascota_Producto]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_TipoPago] FOREIGN KEY([IdTipoPago])
REFERENCES [dbo].[TipoPago] ([IdTipoPago])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_TipoPago]
GO
ALTER TABLE [dbo].[VentaDt]  WITH CHECK ADD  CONSTRAINT [FK_VentaDt_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[VentaDt] CHECK CONSTRAINT [FK_VentaDt_Producto]
GO
ALTER TABLE [dbo].[VentaDt]  WITH CHECK ADD  CONSTRAINT [FK_VentaDt_Venta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[VentaDt] CHECK CONSTRAINT [FK_VentaDt_Venta]
GO
USE [master]
GO
ALTER DATABASE [PeluditosDB] SET  READ_WRITE 
GO
