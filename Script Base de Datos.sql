USE [master]
GO

CREATE DATABASE [PracticaS12]
GO

USE [PracticaS12]
GO

CREATE TABLE [dbo].[Abonos](
  [Id_Compra] [bigint] NOT NULL,
  [Id_Abono] [bigint] IDENTITY(1,1) NOT NULL,
  [Monto] [decimal](18, 2) NOT NULL,
  [Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Abonos] PRIMARY KEY CLUSTERED 
(
  [Id_Abono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Principal](
  [Id_Compra] [bigint] IDENTITY(1,1) NOT NULL,
  [Precio] [decimal](18, 5) NOT NULL,
  [Saldo] [decimal](18, 5) NOT NULL,
  [Descripcion] [varchar](500) NOT NULL,
  [Estado] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Principal] PRIMARY KEY CLUSTERED 
(
  [Id_Compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Principal] ON 
GO
INSERT [dbo].[Principal] ([Id_Compra], [Precio], [Saldo], [Descripcion], [Estado]) VALUES (1, CAST(50000.00000 AS Decimal(18, 5)), CAST(50000.00000 AS Decimal(18, 5)), N'Producto 1', N'Pendiente')
GO
INSERT [dbo].[Principal] ([Id_Compra], [Precio], [Saldo], [Descripcion], [Estado]) VALUES (2, CAST(13500.00000 AS Decimal(18, 5)), CAST(13500.00000 AS Decimal(18, 5)), N'Producto 2', N'Pendiente')
GO
INSERT [dbo].[Principal] ([Id_Compra], [Precio], [Saldo], [Descripcion], [Estado]) VALUES (3, CAST(83600.00000 AS Decimal(18, 5)), CAST(83600.00000 AS Decimal(18, 5)), N'Producto 3', N'Pendiente')
GO
INSERT [dbo].[Principal] ([Id_Compra], [Precio], [Saldo], [Descripcion], [Estado]) VALUES (4, CAST(1220.00000 AS Decimal(18, 5)), CAST(1220.00000 AS Decimal(18, 5)), N'Producto 4', N'Pendiente')
GO
INSERT [dbo].[Principal] ([Id_Compra], [Precio], [Saldo], [Descripcion], [Estado]) VALUES (5, CAST(480.00000 AS Decimal(18, 5)), CAST(480.00000 AS Decimal(18, 5)), N'Producto 5', N'Pendiente')
GO
SET IDENTITY_INSERT [dbo].[Principal] OFF
GO

ALTER TABLE [dbo].[Abonos]  WITH CHECK ADD  CONSTRAINT [FK_Abonos_Principal] FOREIGN KEY([Id_Compra])
REFERENCES [dbo].[Principal] ([Id_Compra])
GO
ALTER TABLE [dbo].[Abonos] CHECK CONSTRAINT [FK_Abonos_Principal]
GO

USE [master]
GO
ALTER DATABASE [PracticaS12] SET  READ_WRITE 
GO


/*otro SP*/

CREATE PROCEDURE SP_ProductosPendientes
AS
BEGIN
    SELECT [Id_Compra]
          ,[Precio]
          ,[Saldo]
          ,[Descripcion]
          ,[Estado]
    FROM [dbo].[Principal]
    WHERE [Estado] = 'pendiente'
    ORDER BY [Id_Compra];
END
GO
EXEC SP_ProductosPendientes;
GO

--
CREATE PROCEDURE RegistrarAbonoSP
    @IdCompra bigint,
    @Monto decimal(18, 2)
AS
BEGIN
    -- Verificar si el monto del abono es menor o igual al saldo
    IF @Monto <= (SELECT Saldo FROM Principal WHERE Id_Compra = @IdCompra)
    BEGIN
        -- Insertar el abono en la tabla Abonos
        INSERT INTO Abonos (Id_Compra, Monto, Fecha)
        VALUES (@IdCompra, @Monto, GETDATE())

        -- Actualizar el saldo en la tabla Principal restando el monto del abono
        UPDATE Principal
        SET Saldo = Saldo - @Monto
        WHERE Id_Compra = @IdCompra

        PRINT 'Abono registrado exitosamente.'
    END
    ELSE
    BEGIN
        PRINT 'Error: El monto del abono es mayor al saldo de la compra.'
    END
END
EXEC RegistrarAbonoSP @IdCompra = 1, @Monto = 1;
GO
--
CREATE PROCEDURE SP_ORDENADO
AS
BEGIN
    SELECT [Id_Compra]
          ,[Precio]
          ,[Saldo]
          ,[Descripcion]
          ,[Estado]
    FROM [dbo].[Principal]
    ORDER BY
        CASE WHEN [Estado] = 'pendiente' THEN 0 ELSE 1 END,  --Primero ordena por estado
        [Estado],
        [Id_Compra]; -- Luego ordena por Id
END
GO
EXEC SP_ORDENADO;
GO
--
--
CREATE PROCEDURE SP_ConsultarProducto
    @Id_Compra INT
AS
BEGIN
    SELECT [Id_Compra]
          ,[Precio]
          ,[Saldo]
          ,[Descripcion]
          ,[Estado]
    FROM [dbo].[Principal]
    WHERE [Estado] = 'pendiente'
      AND [Id_Compra] = @Id_Compra
    ORDER BY [Id_Compra];
END
GO
EXEC SP_ConsultarProducto @Id_Compra = 1;
USE PracticaS12;
--
SELECT * FROM Principal;
SELECT * FROM ABONOS;