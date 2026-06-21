CREATE DATABASE BRAMSELU1;
GO

USE BRAMSELU1;
GO

CREATE TABLE Roles (
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol VARCHAR(30) NOT NULL
);
GO

INSERT INTO Roles (NombreRol)
VALUES
('Administrador'),
('Empleado');
GO

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(100) NOT NULL,
    IdRol INT NOT NULL,
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);
GO

INSERT INTO Usuarios
(NombreCompleto, Usuario, Contrasena, IdRol)
VALUES
('Administrador General', 'admin', '12345', 1),
('Empleado Principal', 'empleado', '12345', 2);
GO

SELECT
    U.IdUsuario,
    U.NombreCompleto,
    U.Usuario,
    R.NombreRol
FROM Usuarios U
INNER JOIN Roles R
ON U.IdRol = R.IdRol;
GO