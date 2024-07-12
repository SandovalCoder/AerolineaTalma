-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2024-06-15 04:50:38.775

-- tables
-- Table: Avion
CREATE TABLE Avion (
    Codigo_Avion int  NOT NULL IDENTITY(1, 1),
    Modelo char(20)  NOT NULL,
    Longitud_Metros char(10)  NOT NULL,
    Ancho_Metros char(10)  NOT NULL,
    Capacidad int  NOT NULL,
    CONSTRAINT Avion_pk PRIMARY KEY  (Codigo_Avion)
);

-- Table: Avion_Equipaje
CREATE TABLE Avion_Equipaje (
    Id int  NOT NULL IDENTITY(1, 1),
    Avion_Codigo int  NOT NULL,
    Equipaje_Codigo_Equipaje int  NOT NULL,
    CONSTRAINT Avion_Equipaje_pk PRIMARY KEY  (Id)
);

-- Table: EmpleadoTalma
CREATE TABLE EmpleadoTalma (
    Codigo_Empleado int  NOT NULL IDENTITY(1, 1),
    Nombre char(100)  NOT NULL,
    DNI int  NOT NULL,
    Usuario char(30)  NOT NULL,
    Contrasena char(30)  NOT NULL,
    Rango char(30)  NOT NULL,
    Rol char(30)  NOT NULL,
    Hora_Inicio_Labores time  NOT NULL,
    Hora_Fin_Labores time  NOT NULL,
    CONSTRAINT EmpleadoTalma_pk PRIMARY KEY  (Codigo_Empleado)
);

-- Table: Equipaje
CREATE TABLE Equipaje (
    Codigo_Equipaje int  NOT NULL IDENTITY(1, 1),
    Nombre_Equipaje char(50)  NOT NULL,
    Bodega_Asignada_en_Aeronave char(100)  NOT NULL,
    Estado_Equipaje char(30)  NOT NULL,
    Peso char(30)  NOT NULL,
    Destino char(30)  NOT NULL,
    Pasajero_Codigo int  NOT NULL,
    CONSTRAINT Equipaje_pk PRIMARY KEY  (Codigo_Equipaje)
);

-- Table: Equipo_ServicioLimpieza
CREATE TABLE Equipo_ServicioLimpieza (
    Codigo_EpLimpienza int  NOT NULL IDENTITY(1, 1),
    EmpleadoTalma_Codigo int  NOT NULL,
    Cantidad_Auxiliares int  NOT NULL,
    Recursos_Empleados char(300)  NOT NULL,
    Tareas_Realizadas char(1000)  NOT NULL,
    Comentarios char(1000)  NOT NULL,
    Hora_Inicio_Servicio_Limpieza time  NOT NULL,
    Hora_Fin_Servicio_Limpieza time  NOT NULL,
    CONSTRAINT Equipo_ServicioLimpieza_pk PRIMARY KEY  (Codigo_EpLimpienza)
);

-- Table: Equipo_ServicioRampa
CREATE TABLE Equipo_ServicioRampa (
    Codigo_EpServicio int  NOT NULL IDENTITY(1, 1),
    EmpleadoTalma_Codigo int  NOT NULL,
    Cantidad_Auxiliares int  NOT NULL,
    Recursos_Empleados char(300)  NOT NULL,
    Hora_Inicio_Servicio_Rampa time  NOT NULL,
    Hora_Fin_Servicio_Rampa time  NOT NULL,
    CONSTRAINT Equipo_ServicioRampa_pk PRIMARY KEY  (Codigo_EpServicio)
);

-- Table: Pasajero
CREATE TABLE Pasajero (
    Codigo_Pasajero int  NOT NULL IDENTITY(1, 1),
    DNI char(8)  NOT NULL,
    Nombre_Completo char(70)  NOT NULL,
    CONSTRAINT Pasajero_pk PRIMARY KEY  (Codigo_Pasajero)
);

-- Table: PuertaEmbarque
CREATE TABLE PuertaEmbarque (
    Codigo_Puerta int  NOT NULL IDENTITY(1, 1),
    Nombre_Puerta char(50)  NOT NULL,
    Ubicacion char(100)  NOT NULL,
    Tipo char(30)  NOT NULL,
    CONSTRAINT PuertaEmbarque_pk PRIMARY KEY  (Codigo_Puerta)
);

-- Table: ServiciosTalma_Vuelo
CREATE TABLE ServiciosTalma_Vuelo (
    Codigo_Servicio int  NOT NULL IDENTITY(1, 1),
    Equipo_ServicioRampa_Codigo int  NOT NULL,
    Equipo_ServicioLimpieza_Codigo int  NOT NULL,
    Vuelo_Codigo_Vuelo int  NOT NULL,
    CONSTRAINT ServiciosTalma_Vuelo_pk PRIMARY KEY  (Codigo_Servicio)
);

-- Table: Vuelo
CREATE TABLE Vuelo (
    Codigo_Vuelo int  NOT NULL IDENTITY(1, 1),
    Identificador_Vuelo char(20)  NOT NULL,
    Avion_Codigo int  NOT NULL,
    Llegada_Vuelo datetime  NOT NULL,
    Salida_Vuelo datetime  NOT NULL,
    Estado char(30)  NOT NULL,
    Origen char(30)  NOT NULL,
    Destino char(30)  NOT NULL,
    Cantidad_de_Equipaje int  NOT NULL,
    CONSTRAINT Vuelo_pk PRIMARY KEY  (Codigo_Vuelo)
);

-- Table: Vuelo_PuertaEmbarque
CREATE TABLE Vuelo_PuertaEmbarque (
    Id int  NOT NULL IDENTITY(1, 1),
    Vuelo_Codigo_Vuelo int  NOT NULL,
    PuertaEmbarque_Codigo int  NOT NULL,
    CONSTRAINT Vuelo_PuertaEmbarque_pk PRIMARY KEY  (Id)
);

-- Table: Vuelos_Pasajeros
CREATE TABLE Vuelos_Pasajeros (
    Id int  NOT NULL IDENTITY(1, 1),
    Vuelo_Codigo_Vuelo int  NOT NULL,
    Pasajero_Codigo_Usuario int  NOT NULL,
    CONSTRAINT Vuelos_Pasajeros_pk PRIMARY KEY  (Id)
);

-- foreign keys
-- Reference: AvionEquipaje_Avion (table: Avion_Equipaje)
ALTER TABLE Avion_Equipaje ADD CONSTRAINT AvionEquipaje_Avion
    FOREIGN KEY (Avion_Codigo)
    REFERENCES Avion (Codigo_Avion);

-- Reference: AvionEquipaje_Equipaje (table: Avion_Equipaje)
ALTER TABLE Avion_Equipaje ADD CONSTRAINT AvionEquipaje_Equipaje
    FOREIGN KEY (Equipaje_Codigo_Equipaje)
    REFERENCES Equipaje (Codigo_Equipaje);

-- Reference: Equipaje_Pasajero (table: Equipaje)
ALTER TABLE Equipaje ADD CONSTRAINT Equipaje_Pasajero
    FOREIGN KEY (Pasajero_Codigo)
    REFERENCES Pasajero (Codigo_Pasajero);

-- Reference: EquipoLimpieza_EmpleadoTalma (table: Equipo_ServicioLimpieza)
ALTER TABLE Equipo_ServicioLimpieza ADD CONSTRAINT EquipoLimpieza_EmpleadoTalma
    FOREIGN KEY (EmpleadoTalma_Codigo)
    REFERENCES EmpleadoTalma (Codigo_Empleado);

-- Reference: ServicioRampa_EmpleadoTalma (table: Equipo_ServicioRampa)
ALTER TABLE Equipo_ServicioRampa ADD CONSTRAINT ServicioRampa_EmpleadoTalma
    FOREIGN KEY (EmpleadoTalma_Codigo)
    REFERENCES EmpleadoTalma (Codigo_Empleado);

-- Reference: ServiciosTalma_Vuelo_Vuelo (table: ServiciosTalma_Vuelo)
ALTER TABLE ServiciosTalma_Vuelo ADD CONSTRAINT ServiciosTalma_Vuelo_Vuelo
    FOREIGN KEY (Vuelo_Codigo_Vuelo)
    REFERENCES Vuelo (Codigo_Vuelo);

-- Reference: Table_24_Equipo_ServicioLimpieza (table: ServiciosTalma_Vuelo)
ALTER TABLE ServiciosTalma_Vuelo ADD CONSTRAINT Table_24_Equipo_ServicioLimpieza
    FOREIGN KEY (Equipo_ServicioLimpieza_Codigo)
    REFERENCES Equipo_ServicioLimpieza (Codigo_EpLimpienza);

-- Reference: Table_24_Equipo_ServicioRampa (table: ServiciosTalma_Vuelo)
ALTER TABLE ServiciosTalma_Vuelo ADD CONSTRAINT Table_24_Equipo_ServicioRampa
    FOREIGN KEY (Equipo_ServicioRampa_Codigo)
    REFERENCES Equipo_ServicioRampa (Codigo_EpServicio);

-- Reference: Tripulacion_Pasajero (table: Vuelos_Pasajeros)
ALTER TABLE Vuelos_Pasajeros ADD CONSTRAINT Tripulacion_Pasajero
    FOREIGN KEY (Pasajero_Codigo_Usuario)
    REFERENCES Pasajero (Codigo_Pasajero);

-- Reference: Tripulacion_Vuelo (table: Vuelos_Pasajeros)
ALTER TABLE Vuelos_Pasajeros ADD CONSTRAINT Tripulacion_Vuelo
    FOREIGN KEY (Vuelo_Codigo_Vuelo)
    REFERENCES Vuelo (Codigo_Vuelo);

-- Reference: Vuelo_AvionContratista (table: Vuelo)
ALTER TABLE Vuelo ADD CONSTRAINT Vuelo_AvionContratista
    FOREIGN KEY (Avion_Codigo)
    REFERENCES Avion (Codigo_Avion);

-- Reference: Vuelo_PuertaEmbarque_PuertaEmbarque (table: Vuelo_PuertaEmbarque)
ALTER TABLE Vuelo_PuertaEmbarque ADD CONSTRAINT Vuelo_PuertaEmbarque_PuertaEmbarque
    FOREIGN KEY (PuertaEmbarque_Codigo)
    REFERENCES PuertaEmbarque (Codigo_Puerta);

-- Reference: Vuelo_PuertaEmbarque_Vuelo (table: Vuelo_PuertaEmbarque)
ALTER TABLE Vuelo_PuertaEmbarque ADD CONSTRAINT Vuelo_PuertaEmbarque_Vuelo
    FOREIGN KEY (Vuelo_Codigo_Vuelo)
    REFERENCES Vuelo (Codigo_Vuelo);

-- End of file.

-- Insert data into Pasajero first to avoid FK constraint issues in Equipaje
INSERT INTO Pasajero (DNI, Nombre_Completo) 
VALUES 
('12345678', 'Juan Perez'),
('87654321', 'Maria Lopez'),
('11223344', 'Carlos Sanchez');

-- Insert data into Equipaje
INSERT INTO Equipaje (Nombre_Equipaje, Bodega_Asignada_en_Aeronave, Estado_Equipaje, Peso, Destino, Pasajero_Codigo) 
VALUES 
('Maleta Roja', 'Bodega 1', 'Proceso de carga', '23kg', 'Lima', 1),
('Mochila Azul', 'Bodega 2', 'Proceso de descargar', '10kg', 'Cusco', 2),
('Bolso Negro', 'Bodega 3', 'Translado al avion', '15kg', 'Arequipa', 3);

-- Insert data into Avion
INSERT INTO Avion (Modelo, Longitud_Metros, Ancho_Metros, Capacidad) 
VALUES 
('Boeing 737', '39.5', '35.8', 160),
('Airbus A320', '37.6', '34.1', 150),
('Embraer E190', '36.2', '28.7', 114);

-- Insert data into EmpleadoTalma
INSERT INTO EmpleadoTalma (Nombre, DNI, Usuario, Contrasena, Rango, Rol, Hora_Inicio_Labores, Hora_Fin_Labores) 
VALUES 
('Vilder Luis', 10293847, 'Admin', 'E1234', 'CCO', 'Administrador', '06:00:00', '20:00:00'),
('Rafael', 56473829, 'Rafa123', '1234', 'Auxiliar de cabina', 'Empleado', '07:00:00', '21:00:00'),
('Roly Mori', 48392018, 'Roly650', '12345', 'Lider de cabina', 'Empleado', '07:00:00', '21:00:00');

-- Insert data into Equipo_ServicioLimpieza
INSERT INTO Equipo_ServicioLimpieza (EmpleadoTalma_Codigo, Cantidad_Auxiliares, Recursos_Empleados, Tareas_Realizadas, Comentarios, Hora_Inicio_Servicio_Limpieza, Hora_Fin_Servicio_Limpieza) 
VALUES 
(2, 3, 'Escobas, Trapeadores, Detergentes', 'Limpieza completa', 'Ninguno', '06:00:00', '08:00:00'),
(2, 2, 'Escobas, Trapeadores', 'Limpieza parcial', 'Falta detergente', '14:00:00', '16:00:00'),
(3, 1, 'Escobas', 'Limpieza superficial', 'Rapido', '22:00:00', '23:00:00');

-- Insert data into Equipo_ServicioRampa
INSERT INTO Equipo_ServicioRampa (EmpleadoTalma_Codigo, Cantidad_Auxiliares, Recursos_Empleados, Hora_Inicio_Servicio_Rampa, Hora_Fin_Servicio_Rampa) 
VALUES 
(2, 4, 'Cargadores, Tractores', '06:00:00', '10:00:00'),
(2, 3, 'Cargadores', '14:00:00', '18:00:00'),
(3, 2, 'Tractores', '22:00:00', '02:00:00');

-- Insert data into PuertaEmbarque
INSERT INTO PuertaEmbarque (Nombre_Puerta, Ubicacion, Tipo) 
VALUES 
('Gate 1', 'Terminal A', 'Nacional'),
('Gate 2', 'Terminal B', 'Internacional'),
('Gate 3', 'Terminal C', 'Nacional');

-- Insert data into Vuelo
INSERT INTO Vuelo (Identificador_Vuelo, Avion_Codigo, Llegada_Vuelo, Salida_Vuelo, Estado, Origen, Destino, Cantidad_de_Equipaje) 
VALUES 
('LA123', 1, '2024-06-15', '2024-06-15', 'Avion aterrizando', 'Lima', 'Cusco', 50),
('IB456', 2, '2024-06-15', '2024-06-15', 'Avion en puesto de embarque', 'Madrid', 'Lima', 100),
('AA789', 3, '2024-06-15', '2024-06-15', 'Avion despegando', 'Miami', 'Lima', 75);

-- Insert data into Avion_Equipaje
INSERT INTO Avion_Equipaje (Avion_Codigo, Equipaje_Codigo_Equipaje) 
VALUES 
(1, 1),
(2, 2),
(3, 3);

-- Insert data into Vuelo_PuertaEmbarque
INSERT INTO Vuelo_PuertaEmbarque (Vuelo_Codigo_Vuelo, PuertaEmbarque_Codigo) 
VALUES 
(1, 1),
(2, 2),
(3, 3);

-- Insert data into Vuelos_Pasajeros
INSERT INTO Vuelos_Pasajeros (Vuelo_Codigo_Vuelo, Pasajero_Codigo_Usuario) 
VALUES 
(1, 1),
(2, 2),
(3, 3);

-- Insert data into ServiciosTalma_Vuelo
INSERT INTO ServiciosTalma_Vuelo (Equipo_ServicioRampa_Codigo, Equipo_ServicioLimpieza_Codigo, Vuelo_Codigo_Vuelo) 
VALUES 
(1, 1, 1),
(2, 2, 2),
(3, 3, 3);