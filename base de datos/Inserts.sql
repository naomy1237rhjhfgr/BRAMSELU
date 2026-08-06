USE BRAMSELU
GO

INSERT INTO Categorias (NombreCategoria, Descripcion)
VALUES
('Cuidado Facial','Productos para limpieza e hidratación facial'),
('Maquillaje','Productos de maquillaje profesional'),
('Cuidado Capilar','Productos para el cuidado del cabello'),
('Protección Solar','Protectores solares para todo tipo de piel'),
('Tratamientos','Productos especializados para el cuidado de la piel'),
('Accesorios','Brochas, esponjas y accesorios'),
('Perfumería','Perfumes y fragancias'),
('Cuidado Corporal','Productos para el cuerpo');
GO

INSERT INTO Clientes
(IdCliente,Nombre,Telefono,Correo,Direccion,TipoPiel)
VALUES
('0801199912345','María López','99887766','maria@gmail.com','Tegucigalpa','Mixta'),
('0801200054321','Carlos Gómez','88776655','carlos@gmail.com','San Pedro Sula','Grasa'),
('0801199811111','Ana Hernández','96554411','ana@gmail.com','Comayagua','Seca'),
('0801199722222','José Martínez','97778811','jose@gmail.com','La Ceiba','Normal'),
('0801199633333','Sofía Rivera','99334455','sofia@gmail.com','Choluteca','Mixta'),
('0801199544444','Luis Flores','94443322','luis@gmail.com','Danlí','Grasa'),
('0801199455555','Andrea Castro','95556677','andrea@gmail.com','Santa Rosa','Seca'),
('0801199366666','Miguel Reyes','96667788','miguel@gmail.com','El Progreso','Normal'),
('0801199277777','Paola Sánchez','98885544','paola@gmail.com','Tela','Mixta'),
('0801199188888','Kevin Torres','99994411','kevin@gmail.com','Juticalpa','Grasa'),
('0801199099999','Fernanda Díaz','94442211','fernanda@gmail.com','Gracias','Seca'),
('0801199010101','Daniel Mejía','93334444','daniel@gmail.com','Tocoa','Normal'),
('0801199020202','Valeria Cruz','92225555','valeria@gmail.com','Yoro','Mixta'),
('0801199030303','Gabriela Ortiz','91116666','gabriela@gmail.com','Puerto Cortés','Grasa'),
('0801199040404','Ricardo Molina','90007777','ricardo@gmail.com','Copán','Normal');
GO

INSERT INTO Proveedores
(NombreEmpresa,Contacto,Telefono)
VALUES
('Cosméticos S.A.','Lucía Fernández','22334455'),
('Distribuidora Belleza HN','Jorge Martínez','25447788'),
('Dermocosméticos Honduras','Karla Mejía','22119988'),
('Beauty Import','Luis Torres','22887766'),
('L''Oréal Distribución','Paola Rivera','22446688'),
('Nivea Honduras','Sandra López','22557799'),
('Maybelline HN','Carlos Pineda','22335577'),
('Belleza Total','María Flores','22998811');
GO

INSERT INTO Empleados
(Nombre,Apellido,Identidad,Telefono,Direccion,Correo,Usuario,Contrasena,TipoUsuario,Estado)
VALUES
('Ana','Martínez','0801199500123','33445566','Tegucigalpa','ana@bramselu.com','amartinez','1234','Administrador',1),
('Laura','Pérez','0801199700456','33556677','Tegucigalpa','laura@bramselu.com','lperez','1234','Empleado',1),
('Nahomy','Rivera','0801199800567','94445566','Tegucigalpa','nahomy@bramselu.com','nao','1234','Administrador',1),
('Sofía','Gómez','0801199600789','95554433','San Pedro Sula','sofia@bramselu.com','sofia','1234','Empleado',1),
('Miguel','Cruz','0801199300234','97774455','Comayagua','miguel@bramselu.com','mcruz','1234','Empleado',1),
('Kevin','Flores','0801199400999','98882211','La Ceiba','kevin@bramselu.com','kflores','1234','Empleado',1);
GO

INSERT INTO Productos
(NombreProducto,Marca,Precio,Stock,IdCategoria,Categoria)
VALUES
('Crema Hidratante Facial','Nivea',250,50,1,'Cuidado Facial'),
('Gel Limpiador','Cetaphil',380,30,1,'Cuidado Facial'),
('Protector Solar SPF50','La Roche Posay',550,25,4,'Protección Solar'),
('Agua Micelar','Garnier',220,45,1,'Cuidado Facial'),
('Sérum Vitamina C','Garnier',470,20,5,'Tratamientos'),
('Contorno de Ojos','L''Oréal',420,18,5,'Tratamientos'),
('Base Fit Me','Maybelline',340,40,2,'Maquillaje'),
('Corrector Instant Age','Maybelline',260,35,2,'Maquillaje'),
('Polvo Compacto','L''Oréal',310,30,2,'Maquillaje'),
('Rubor Líquido','Sheglam',280,28,2,'Maquillaje'),
('Labial Mate','Maybelline',210,50,2,'Maquillaje'),
('Máscara de Pestañas','Maybelline',295,38,2,'Maquillaje'),
('Shampoo Reparador','Pantene',180,60,3,'Cuidado Capilar'),
('Acondicionador','Pantene',185,55,3,'Cuidado Capilar'),
('Mascarilla Capilar','Garnier',350,20,3,'Cuidado Capilar'),
('Crema Corporal','Nivea',190,40,8,'Cuidado Corporal'),
('Exfoliante Corporal','Dove',260,18,8,'Cuidado Corporal'),
('Perfume Floral','Ésika',790,15,7,'Perfumería'),
('Brocha para Base','Real Techniques',320,25,6,'Accesorios'),
('Esponja de Maquillaje','Beauty Blender',180,35,6,'Accesorios');
GO

INSERT INTO Cajas
(MontoInicial, TotalVentasEfectivo, MontoFinal, Estado, UsuarioApertura, TotalCompras)
VALUES
(1000,2500,2300,'Cerrada','nao',1200),
(800,1700,1900,'Cerrada','amartinez',600),
(1000,0,NULL,'Abierta','sofia',0);
GO

INSERT INTO Compras
(Total,IdProveedor,NombreEmpleado)
VALUES
(1850,1,'Nahomy Rivera'),
(2450,2,'Nahomy Rivera'),
(980,3,'Ana Martínez'),
(1450,4,'Laura Pérez'),
(2100,5,'Miguel Cruz');
GO

INSERT INTO DetalleCompra
(IdCompra,IdProducto,Cantidad,PrecioUnitario,Subtotal)
VALUES
(1,1,5,200,1000),
(1,2,3,283.33,850),
(2,7,5,300,1500),
(2,8,5,190,950),
(3,13,5,180,900),
(4,16,5,190,950),
(4,17,2,250,500),
(5,18,2,700,1400),
(5,19,2,350,700);
GO

INSERT INTO Ventas
(Total,EfectivoRecibido,Cambio,IdCaja)
VALUES
(590,600,10,1),
(840,1000,160,1),
(470,500,30,2),
(980,1000,20,2),
(1350,1500,150,3);
GO

INSERT INTO DetalleVenta
(IdVenta,IdProducto,Cantidad,PrecioUnitario,Subtotal)
VALUES
(1,1,1,250,250),
(1,11,1,210,210),
(1,20,1,130,130),

(2,7,1,340,340),
(2,12,1,295,295),
(2,19,1,205,205),

(3,5,1,470,470),

(4,18,1,790,790),
(4,20,1,190,190),

(5,2,1,380,380),
(5,3,1,550,550),
(5,6,1,420,420);
GO

INSERT INTO Servicios
(NombreServicio,Descripcion,Precio,Duracion,Estado)
VALUES
('Limpieza Facial','Limpieza profunda con extracción',500,45,1),
('Tratamiento Antiacné','Tratamiento especializado para piel grasa',750,60,1),
('Hidratación Facial','Aplicación de mascarillas hidratantes',600,50,1),
('Peeling Facial','Exfoliación profesional',850,60,1),
('Dermaplaning','Eliminación de células muertas',950,60,1),
('Microneedling','Estimulación de colágeno',1500,90,1),
('Diseño de Cejas','Perfilado profesional',250,25,1),
('Laminado de Cejas','Tratamiento estético',650,45,1),
('Lifting de Pestañas','Realce natural de pestañas',800,60,1),
('Masaje Facial','Relajación y estimulación facial',450,40,1);
GO