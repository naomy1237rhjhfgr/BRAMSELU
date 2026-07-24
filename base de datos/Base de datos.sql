CREATE DATABASE BRAMSELU;
GO

USE BRAMSELU;
GO

CREATE TABLE dbo.Clientes (
    IdCliente varchar(20) PRIMARY KEY,
    Nombre varchar(100) NOT NULL,
    Telefono varchar(20) NOT NULL,
    Correo varchar(100) NOT NULL,
    Direccion varchar(200) NOT NULL,
    TipoPiel varchar(50) NOT NULL
);

CREATE TABLE dbo.Empleados (
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
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    Estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE dbo.Productos (
    IdProducto int IDENTITY(1,1) PRIMARY KEY,
    NombreProducto varchar(100) NOT NULL,
    Marca varchar(50) NOT NULL,
    Categoria varchar(50) NOT NULL,
    Precio decimal(10,2) NOT NULL,
    Stock int NOT NULL,
    FechaRegistro datetime DEFAULT GETDATE(),
    Imagen varbinary(MAX) NULL
);
GO