CREATE DATABASE OBRA_SOCIAL;
GO
USE OBRA_SOCIAL;
GO
CREATE TABLE CLIENTES(
nombre VARCHAR(40), 
apellido VARCHAR(40),
dni INT PRIMARY KEY,
_plan VARCHAR(40), 
cantidadGrupoFamiliar int,
localidad VARCHAR(30)
);
GO

INSERT INTO CLIENTES(nombre, apellido, dni, _plan, cantidadGrupoFamiliar, localidad)
VALUES('LIONEL', 'MESSI', 250,'Basico', 3, 'Lanus'),
('RODRIGO', 'DE PAUL', 562,'Alto', 1, 'Avellaneda'),
('GIOVANI', 'LO CELSO', 210,'Medio', 4, 'Bandield'),
('EMILIANO', 'MARTINEZ', 963,'Basico', 2, 'Temperley'),
('LIONEL', 'SCALONI', 321,'Alto', 1, 'Lanus');

