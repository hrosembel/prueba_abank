--Crear tabla de usuarios
CREATE TABLE usuarios (
    id SERIAL PRIMARY KEY,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    fechanacimiento DATE NOT NULL,
    direccion VARCHAR(255) NOT NULL,
    password VARCHAR(120) NOT NULL,
    telefono VARCHAR(8) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    fechacreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    fechamodificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP 
);

--Usuario administrador
INSERT INTO usuarios (nombres, apellidos, fechanacimiento, direccion, password, telefono, email)
VALUES ('admin', 'admin', '1985-09-23', 'Calle Falsa 123', 'password123', '555-1234', 'admin@example.com');


select * from usuarios