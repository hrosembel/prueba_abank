-- Crear la base de datos abank
CREATE DATABASE IF NOT EXISTS abankdb;

-- Usar la base de datos abank
USE abankdb;

-- Crear la tabla usuarios dentro de la base de datos abank
CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombres VARCHAR(50) NOT NULL,
    apellidos VARCHAR(50) NOT NULL,
    fechanacimiento DATE NOT NULL,
    direccion VARCHAR(100),
    password VARCHAR(120) NOT NULL,
    telefono VARCHAR(8) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    fechacreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    fechamodificacion TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

--Usuario administrador
INSERT INTO usuarios (nombres, apellidos, fechanacimiento, direccion, password, telefono, email)
VALUES ('admin', 'admin', '1985-09-23', 'Calle Falsa 123', 'password123', '555-1234', 'admin@example.com');


select * from usuarios
