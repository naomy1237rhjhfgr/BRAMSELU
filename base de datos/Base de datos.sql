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
    IdEmpleado int IDENTITY(1,1) PRIMARY KEY,
    Nombre varchar(100) NOT NULL,
    Apellido varchar(100) NOT NULL,
    Identidad varchar(20) NOT NULL,
    Telefono varchar(20) NULL,
    Direccion varchar(200) NULL,
    Correo varchar(100) NULL,
    Usuario varchar(50) NOT NULL,
    Contrasena varchar(100) NOT NULL,
    TipoUsuario varchar(20) NOT NULL,
    FechaRegistro datetime DEFAULT GETDATE()
);

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