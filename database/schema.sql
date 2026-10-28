-- ==============================================================================
-- SISTEMA DE GESTIÓN INTEGRAL PARA CLUB DEPORTIVO
-- Script de Base de Datos Relacional: MySQL 8.0+
-- Autora: Sabrina Belén Mamaniz
-- Rol: Analista Funcional / Modelado de Software
-- Descripción: Estructura de tablas normalizadas, restricciones de integridad,
--              claves foráneas y datos de prueba para validación de reglas de negocio.
-- ==============================================================================

CREATE DATABASE IF NOT EXISTS club_deportivo_db
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE club_deportivo_db;

-- ------------------------------------------------------------------------------
-- 1. TABLA: usuarios (Autenticación y Seguridad)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    contrasenia VARCHAR(255) NOT NULL,
    rol VARCHAR(30) NOT NULL DEFAULT 'Administrativo',
    activo BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 2. TABLA: clientes (Superclase para Socios y No Socios)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    dni VARCHAR(15) NOT NULL UNIQUE,
    nombre VARCHAR(60) NOT NULL,
    apellido VARCHAR(60) NOT NULL,
    telefono VARCHAR(25),
    direccion VARCHAR(120),
    apto_fisico BOOLEAN NOT NULL DEFAULT FALSE,
    tipo_cliente ENUM('Socio', 'NoSocio') NOT NULL,
    fecha_inscripcion DATE NOT NULL,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_dni (dni)
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 3. TABLA: socios (Subclase de Cliente - Membresía recurrente)
-- Regla de Negocio: Vence cada 30 días acumulativos desde vencimiento previo.
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS socios (
    id_socio INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL UNIQUE,
    vigente BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_vencimiento DATE NOT NULL,
    carnet_emitido BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT fk_socio_cliente FOREIGN KEY (id_cliente)
        REFERENCES clientes(id_cliente)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    INDEX idx_socio_vencimiento (fecha_vencimiento, vigente)
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 4. TABLA: no_socios (Subclase de Cliente - Pases eventuales por actividad)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS no_socios (
    id_no_socio INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL UNIQUE,
    vigente BOOLEAN NOT NULL DEFAULT TRUE,
    CONSTRAINT fk_nosocio_cliente FOREIGN KEY (id_cliente)
        REFERENCES clientes(id_cliente)
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 5. TABLA: carnets (Credencial exclusiva para Socios con cuota al día)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS carnets (
    id_carnet INT AUTO_INCREMENT PRIMARY KEY,
    id_socio INT NOT NULL,
    numero_carnet VARCHAR(30) NOT NULL UNIQUE,
    fecha_emision DATE NOT NULL,
    estado_carnet ENUM('Activo', 'Inhabilitado', 'Extraviado') NOT NULL DEFAULT 'Activo',
    CONSTRAINT fk_carnet_socio FOREIGN KEY (id_socio)
        REFERENCES socios(id_socio)
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 6. TABLA: profesores (Personal docente del club)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS profesores (
    id_profesor INT AUTO_INCREMENT PRIMARY KEY,
    dni VARCHAR(15) NOT NULL UNIQUE,
    nombre VARCHAR(60) NOT NULL,
    apellido VARCHAR(60) NOT NULL,
    telefono VARCHAR(25),
    direccion VARCHAR(120),
    especialidad VARCHAR(60),
    sueldo DECIMAL(12,2) NOT NULL DEFAULT 0.00,
    activo BOOLEAN NOT NULL DEFAULT TRUE
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 7. TABLA: asistencias_profesores (Control diario de jornada laboral)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS asistencias_profesores (
    id_asistencia INT AUTO_INCREMENT PRIMARY KEY,
    id_profesor INT NOT NULL,
    fecha DATE NOT NULL,
    hora_ingreso TIME NOT NULL,
    hora_egreso TIME NULL,
    CONSTRAINT fk_asistencia_profesor FOREIGN KEY (id_profesor)
        REFERENCES profesores(id_profesor)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    INDEX idx_asistencia_fecha (fecha)
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 8. TABLA: actividades (Disciplinas deportivas y cupos)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS actividades (
    id_actividad INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(60) NOT NULL,
    horario VARCHAR(60) NOT NULL,
    cupo_maximo INT NOT NULL DEFAULT 20,
    precio DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    activo BOOLEAN NOT NULL DEFAULT TRUE
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 9. TABLA: pagos (Superclase para transacciones de cobro)
-- Subtipos: CuotaMensual (Socios) y PagoActividad (No Socios)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS pagos (
    id_pago INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    fecha_pago DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    medio_de_pago ENUM('Efectivo', 'TarjetaCredito', 'TarjetaDebito', 'Transferencia') NOT NULL,
    tipo_pago ENUM('Mensual', 'Actividad') NOT NULL,
    cuotas INT NOT NULL DEFAULT 1,
    id_actividad INT NULL,
    comprobante_numero VARCHAR(40) NOT NULL UNIQUE,
    CONSTRAINT fk_pago_cliente FOREIGN KEY (id_cliente)
        REFERENCES clientes(id_cliente)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_pago_actividad FOREIGN KEY (id_actividad)
        REFERENCES actividades(id_actividad)
        ON DELETE SET NULL ON UPDATE CASCADE,
    INDEX idx_pago_fecha (fecha_pago)
) ENGINE=InnoDB;

-- ------------------------------------------------------------------------------
-- 10. TABLA: fichas_medicas (Servicio de Nutrición y Apto Físico)
-- Regla de Negocio: Carga física permitida escala 1 a 5 (Validada por check)
-- ------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS fichas_medicas (
    id_ficha INT AUTO_INCREMENT PRIMARY KEY,
    id_socio INT NOT NULL UNIQUE,
    tratamiento_nutricional TEXT,
    carga_fisica_permitida TINYINT NOT NULL CHECK (carga_fisica_permitida BETWEEN 1 AND 5),
    observaciones TEXT,
    fecha_ultima_consulta DATE NOT NULL,
    CONSTRAINT fk_ficha_socio FOREIGN KEY (id_socio)
        REFERENCES socios(id_socio)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;


-- ==============================================================================
-- DATOS DE PRUEBA (SEED DATA PARA TEST DE REQUISITOS Y REGLAS DE NEGOCIO)
-- ==============================================================================

-- 1. Usuario Administrativo por defecto
INSERT INTO usuarios (usuario, contrasenia, rol) VALUES
('admin', '$2a$12$e8Yh7t4qPq3N0vQZ9X9Z1uF4mFhG6A9P6Q8j7h4qPq3N0vQZ9X9Z1u', 'Administrador');

-- 2. Actividades del Club
INSERT INTO actividades (nombre, horario, cupo_maximo, precio) VALUES
('Musculación', 'Lunes a Viernes 07:00 a 22:00', 50, 4500.00),
('Crossfit', 'Lunes, Miércoles y Viernes 19:00', 20, 6000.00),
('Natación Libre', 'Martes y Jueves 18:00 a 20:00', 15, 7500.00),
('Spinning', 'Martes y Jueves 09:00', 25, 5000.00);

-- 3. Profesores
INSERT INTO profesores (dni, nombre, apellido, telefono, direccion, especialidad, sueldo) VALUES
('32111222', 'Esteban', 'Pérez', '11-4433-2211', 'Av. Rivadavia 8500, CABA', 'Preparación Física & Crossfit', 650000.00),
('34555666', 'Valeria', 'Gómez', '11-5566-7788', 'Yerbal 4200, CABA', 'Spinning & Entrenamiento Funcional', 580000.00);

-- 4. Clientes: 1 Socio con cuota al día, 1 Socio con cuota vencida, 1 No Socio
INSERT INTO clientes (dni, nombre, apellido, telefono, direccion, apto_fisico, tipo_cliente, fecha_inscripcion) VALUES
('40123456', 'Martín', 'Rossi', '11-9876-5432', 'Ramón Falcón 5100, CABA', TRUE, 'Socio', '2026-01-10'),
('38999888', 'Camila', 'Fernández', '11-2345-6789', 'Bacacay 3100, CABA', TRUE, 'Socio', '2025-11-05'),
('42333444', 'Lucas', 'Benítez', '11-3456-7890', 'Av. Juan B. Justo 7200, CABA', TRUE, 'NoSocio', '2026-03-01');

-- 5. Socios
-- Martín Rossi: Cuota al día (vence en 20 días)
INSERT INTO socios (id_cliente, vigente, fecha_vencimiento, carnet_emitido) VALUES
(1, TRUE, DATE_ADD(CURRENT_DATE, INTERVAL 20 DAY), TRUE);

-- Camila Fernández: Cuota vencida (venció hace 5 días) -> Inhabilitada
INSERT INTO socios (id_cliente, vigente, fecha_vencimiento, carnet_emitido) VALUES
(2, FALSE, DATE_SUB(CURRENT_DATE, INTERVAL 5 DAY), TRUE);

-- 6. No Socios
INSERT INTO no_socios (id_cliente, vigente) VALUES
(3, TRUE);

-- 7. Carnets
INSERT INTO carnets (id_socio, numero_carnet, fecha_emision, estado_carnet) VALUES
(1, 'CRN-2026-0001', '2026-01-10', 'Activo'),
(2, 'CRN-2025-0045', '2025-11-05', 'Inhabilitado');

-- 8. Ficha Médica (Martín Rossi)
INSERT INTO fichas_medicas (id_socio, tratamiento_nutricional, carga_fisica_permitida, observaciones, fecha_ultima_consulta) VALUES
(1, 'Dieta hiperproteica con déficit calórico controlado para aumento de masa magra.', 4, 'Apto para trabajos de alta intensidad aeróbica y fuerza progresiva.', '2026-02-15');

-- 9. Historial de Pagos
INSERT INTO pagos (id_cliente, monto, fecha_pago, medio_de_pago, tipo_pago, cuotas, id_actividad, comprobante_numero) VALUES
(1, 15000.00, '2026-02-10 10:15:00', 'TarjetaDebito', 'Mensual', 1, NULL, 'FAC-B-0001-00003421'),
(3, 4500.00, CURRENT_TIMESTAMP, 'Efectivo', 'Actividad', 1, 1, 'TIK-B-0001-00009102');
