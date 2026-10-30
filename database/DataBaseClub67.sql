DROP DATABASE club_67;
CREATE DATABASE IF NOT EXISTS club_67;
USE club_67;

-- TABLA DE USUARIOS
CREATE TABLE IF NOT EXISTS usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    contrasenia VARCHAR(50) NOT NULL
);

INSERT INTO usuarios (usuario, contrasenia) VALUES ('admin', '1234');


-- TABLA BASE: Cliente
CREATE TABLE IF NOT EXISTS Clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    dni VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    tipo_cliente VARCHAR(20) NOT NULL,
    telefono VARCHAR(50),
    direccion VARCHAR(100),
    apto_fisico BOOLEAN DEFAULT FALSE, 
    vigente BOOLEAN DEFAULT TRUE,
    fecha_inscripcion DATETIME NULL,   
    fecha_vencimiento DATETIME NULL    
);


-- TABLA: PAGOS 
CREATE TABLE IF NOT EXISTS pagos (
    id_pago VARCHAR(30) PRIMARY KEY,
    monto DECIMAL(10,2) NOT NULL,
    fecha_pago DATETIME NOT NULL,
    medio_pago VARCHAR(30) NOT NULL,
    tipo_pago VARCHAR(20) NOT NULL, 
    dni_cliente VARCHAR(20) NOT NULL
);


-- TABLA: PROFESORES 
CREATE TABLE IF NOT EXISTS profesores (
    id_profesor INT AUTO_INCREMENT PRIMARY KEY,
    dni VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL
);


-- TABLA: FICHAS MEDICAS
CREATE TABLE IF NOT EXISTS fichas_medicas (
    id_ficha INT AUTO_INCREMENT PRIMARY KEY,
    dni_cliente VARCHAR(20) NOT NULL,
    tratamiento_nutricional VARCHAR(100),
    carga_fisica_permitida VARCHAR(100),
    fecha_ultima_consulta DATETIME,
    observaciones VARCHAR(255)
);


-- 🚀 INSERT CORREGIDO CON LOS 10 VALORES PARA EL TESTING
INSERT INTO Clientes (dni, nombre, apellido, tipo_cliente, vigente, fecha_inscripcion, fecha_vencimiento, telefono, direccion, apto_fisico) 
VALUES ('99999999', 'Socio de', 'Prueba Vencido', 'Socio', 1, DATE_SUB(CURDATE(), INTERVAL 1 MONTH), CURDATE(), '11-2222-3333', 'Av. Siempre Viva 742', 1);