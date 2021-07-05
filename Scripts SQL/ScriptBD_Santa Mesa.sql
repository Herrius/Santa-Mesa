CREATE DATABASE BD_SantaMesa
GO
USE BD_SantaMesa
GO

CREATE TABLE Administrador(
id_Administrador int IDENTITY PRIMARY KEY, 
nombres CHAR(30),
tenefono CHAR(11),
email CHAR(30),
direccion CHAR(50),
dni CHAR(8),
estado bit)

GO

CREATE TABLE Clientes(
id_Cliente int IDENTITY PRIMARY KEY,
nombres VARCHAR(30),
telefono CHAR(11),
email VARCHAR(40) UNIQUE,
direccion VARCHAR(50),
dni CHAR(8),
ciudad VARCHAR(25),
estado bit,
clave VARCHAR(16))

GO

CREATE TABLE Productos(
id_Producto int IDENTITY PRIMARY KEY,
nombre_producto CHAR(30),
idioma CHAR(10),
edad_player int,
descripcion text,
imagen CHAR(500),
estado bit)

GO

CREATE TABLE Pedidos(
id_Pedido int IDENTITY PRIMARY KEY,
id_Cliente int FOREIGN KEY REFERENCES Clientes(id_Cliente),
fecha DATE,
montoTotal float,
estado bit)

GO	

CREATE TABLE DetallePedidos(
id_detalle int IDENTITY PRIMARY KEY,
id_pedido int FOREIGN KEY REFERENCES Pedidos(id_Pedido),
id_producto int FOREIGN KEY REFERENCES Productos,
precio_unidad float,
cantidad int)



