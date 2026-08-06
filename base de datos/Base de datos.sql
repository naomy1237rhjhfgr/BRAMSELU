USE [master];
GO

IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'BRAMSELU')
BEGIN
    ALTER DATABASE [BRAMSELU] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [BRAMSELU];
END
GO

CREATE DATABASE [BRAMSELU];
GO

USE [BRAMSELU];
GO


CREATE TABLE Cajas (
    IdCaja INT IDENTITY(1,1) PRIMARY KEY,
    FechaApertura DATETIME NULL DEFAULT GETDATE(),
    FechaCierre DATETIME NULL,
    MontoInicial DECIMAL(18,2) NOT NULL,
    TotalVentasEfectivo DECIMAL(18,2) NULL DEFAULT 0,
    MontoFinal DECIMAL(18,2) NULL,
    Estado VARCHAR(20) NULL DEFAULT 'Abierta',
    UsuarioApertura VARCHAR(100) NULL,
    TotalCompras DECIMAL(18,2) NULL DEFAULT 0
);
GO

CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Clientes (
    IdCliente VARCHAR(20) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200) NOT NULL,
    TipoPiel VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Proveedores (
    IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
    NombreEmpresa VARCHAR(100) NOT NULL,
    Contacto VARCHAR(100) NULL,
    Telefono VARCHAR(20) NULL
);
GO

CREATE TABLE Empleados (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Identidad VARCHAR(20) NOT NULL,
    Telefono VARCHAR(20) NULL,
    Direccion VARCHAR(200) NULL,
    Correo VARCHAR(100) NULL,
    Usuario VARCHAR(50) NOT NULL,
    Contrasena VARCHAR(100) NOT NULL,
    TipoUsuario VARCHAR(20) NOT NULL,
    FechaRegistro DATETIME NULL DEFAULT GETDATE(),
    Estado BIT NULL DEFAULT 1
);
GO

CREATE TABLE Servicios (
    IdServicio INT IDENTITY(1,1) PRIMARY KEY,
    NombreServicio VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Duracion INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);
GO


CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    NombreProducto VARCHAR(100) NOT NULL,
    Marca VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    FechaRegistro DATETIME NULL DEFAULT GETDATE(),
    Imagen VARBINARY(MAX) NULL,
    IdCategoria INT NULL REFERENCES Categorias(IdCategoria),
    Categoria VARCHAR(50) NULL
);
GO

CREATE TABLE Compras (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NULL DEFAULT GETDATE(),
    Total DECIMAL(18,2) NULL,
    IdProveedor INT NULL REFERENCES Proveedores(IdProveedor),
    NombreEmpleado VARCHAR(100) NULL
);
GO

CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    FechaVenta DATETIME NULL DEFAULT GETDATE(),
    Total DECIMAL(18,2) NOT NULL,
    EfectivoRecibido DECIMAL(18,2) NOT NULL,
    Cambio DECIMAL(18,2) NOT NULL,
    IdCaja INT NULL REFERENCES Cajas(IdCaja)
);
GO

CREATE TABLE DetalleCompra (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT NULL REFERENCES Compras(IdCompra),
    IdProducto INT NULL REFERENCES Productos(IdProducto),
    Cantidad INT NULL,
    PrecioUnitario DECIMAL(18,2) NULL,
    Subtotal DECIMAL(18,2) NULL
);
GO

CREATE TABLE DetalleVenta (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NULL REFERENCES Ventas(IdVenta),
    IdProducto INT NULL REFERENCES Productos(IdProducto),
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE Citas (
    IdCita INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente VARCHAR(20) NOT NULL,
    IdServicio INT NOT NULL,
    IdEmpleado INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Estado VARCHAR(30) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_Citas_Clientes 
        FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),

    CONSTRAINT FK_Citas_Servicios 
        FOREIGN KEY (IdServicio) REFERENCES Servicios(IdServicio),

    CONSTRAINT FK_Citas_Empleados 
        FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);
GO

USE BRAMSELU;
GO
ALTER TABLE Ventas 
ADD IdCliente VARCHAR(20) NULL;
GO

ALTER TABLE Ventas 
ADD CONSTRAINT FK_Ventas_Clientes 
FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente);
GO