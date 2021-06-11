CREATE DATABASE BD_SantaMesa
GO
USE BD_SantaMesa
GO


CREATE TABLE tblAdministrador(
id_Administrador CHAR(10) PRIMARY KEY,
nombres CHAR(30),
tenefono CHAR(11),
email CHAR(30),
direccion CHAR(50),
dni CHAR(8),
estado bit)

GO

CREATE TABLE tblClientes(
id_Cliente CHAR(10) PRIMARY KEY,
nombres CHAR(30),
telefono CHAR(11),
email CHAR(30),
direccion CHAR(50),
dni CHAR(8),
ciudad CHAR(25),
estado bit)

GO

CREATE TABLE tblProductos(
id_Producto CHAR(15) PRIMARY KEY,
nombre_producto CHAR(30),
idioma CHAR(10),
edad_player int,
descripcion CHAR(50),
imagen CHAR(200),
estado bit)

GO

CREATE TABLE tblPedidos(
id_Pedido CHAR(10) PRIMARY KEY,
id_Cliente CHAR(10) FOREIGN KEY REFERENCES tblClientes(id_Cliente),
fecha DATE,
montoTotal float,
estado bit)

GO	

CREATE TABLE tblDetallePedidos(
id_pedido CHAR(10) FOREIGN KEY REFERENCES tblPedidos(id_Pedido),
id_producto CHAR(15) FOREIGN KEY REFERENCES tblProductos,
precio_unidad float,
cantidad int)



