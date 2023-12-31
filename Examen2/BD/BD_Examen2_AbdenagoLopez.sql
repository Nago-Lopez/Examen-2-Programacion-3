

Create database Examen2

Go 

Use Examen2

Go 

Create Table Usuarios 
(

ID int identity,
Nombre varchar(50) NOT NULL,
CorreoElectronico varchar (50), 
Telefono varchar (15) UNIQUE,
CONSTRAINT pk_IDusuarios PRIMARY KEY(ID)


)

Go 


Create Table Equipos 
(

EquipoID int identity,
TipoEquipo varchar(50) NOT NULL,
Modelo varchar(50),
IDusuarios int,
CONSTRAINT fk_IDusuarios FOREIGN KEY(IDusuarios) REFERENCES Usuarios(ID),
CONSTRAINT pk_IDequipos PRIMARY KEY(EquipoID)


)

Go 




Create Table Tecnicos 
(

TecnicoID int identity,
Nombre varchar(50) NOT NULL,
CONSTRAINT pk_IDtecnicos PRIMARY KEY(TecnicoID)


)

Go 

Create Table Reparaciones 
(

ReparacionID int identity,
EquipoID int,
FechaSolicitud date DEFAULT GETDATE(),
Estado char (1),
CONSTRAINT fk_IDequipos FOREIGN KEY(EquipoID) REFERENCES Equipos(EquipoID),
CONSTRAINT pk_IDreparaciones PRIMARY KEY(ReparacionID)


)

Go 

Create Table Asignaciones 
(

AsginacionID int identity,
ReparacionID int,
TecnicoID int,
FechaAsignacion date DEFAULT GETDATE(),
CONSTRAINT fk_IDreparaciones FOREIGN KEY(ReparacionID) REFERENCES Reparaciones(ReparacionID),
CONSTRAINT fk_IDtecnicos FOREIGN KEY(TecnicoID) REFERENCES Tecnicos(TecnicoID),
CONSTRAINT pk_IDasignaciones PRIMARY KEY(AsginacionID)


)

Go 

Create Table DetallesReparacion 
(

DetalleID int identity,
ReparacionID int,
Descripcion varchar(50) NOT NULL,
FechaInicio date DEFAULT GETDATE(),
FechaFin date DEFAULT GETDATE(),
CONSTRAINT fk_IDasignaciones FOREIGN KEY(ReparacionID) REFERENCES Reparaciones(ReparacionID),
CONSTRAINT pk_IDdetallesreparacion PRIMARY KEY(DetalleID)

)
Go 

--- STORE PROCEDURES ---- USUARIOS

CREATE PROCEDURE CONSULTARUSUARIOS 
AS
BEGIN
SELECT * FROM Usuarios

END 

CREATE PROCEDURE BORRARUSUARIOS  
@CODIGO INT
AS
BEGIN
DELETE Usuarios WHERE ID = @CODIGO

END 

CREATE PROCEDURE CONSULTAR_FILTROUSUARIOS 
@CODIGO INT
AS
BEGIN
SELECT * FROM Usuarios WHERE ID = @CODIGO

END 

CREATE PROCEDURE ACTUALIZARUSUARIOS 
@ID INT,
@NOMBRE VARCHAR (50),
@CORREO VARCHAR (50),
@TELEFONO VARCHAR (15)

AS
BEGIN
UPDATE Usuarios SET Nombre = @NOMBRE, CorreoElectronico = @CORREO, Telefono= @TELEFONO WHERE ID = @ID 

END 


CREATE PROCEDURE AGREGARUSUARIOS 
@NOMBRE VARCHAR (50),
@CORREO VARCHAR (50),
@TELEFONO VARCHAR (15)

AS
BEGIN

INSERT INTO Usuarios (Nombre,CorreoElectronico,Telefono) VALUES (@NOMBRE,@CORREO, @TELEFONO)

END




INSERT INTO Usuarios (Nombre,CorreoElectronico,Telefono) VALUES ('PEDRO MASIS', 'MASIS.PEDRO@GMAIL.COM', '26398562')

EXECUTE AGREGARUSUARIOS 'MARCO MARIN', 'MARCO.TANIA@GMAIL.COM', '23658954'
EXECUTE ACTUALIZARUSUARIOS 1005,'MATIAS LOPEZ', 'MATIAS.LOPEZ@GMAIL.COM', '85621456'
EXECUTE CONSULTARUSUARIOS
EXECUTE CONSULTAR_FILTROUSUARIOS  4
EXECUTE BORRARUSUARIOS 5



------------------------------------- EQUIPOS

CREATE PROCEDURE CONSULTAREQUIPOS
AS
BEGIN
SELECT * FROM Equipos

END 

CREATE PROCEDURE BORRAREQUIPO
@CODIGO INT
AS
BEGIN
DELETE Equipos WHERE EquipoID = @CODIGO

END 

CREATE PROCEDURE CONSULTAR_FILTROEQUIPO
@CODIGO INT
AS
BEGIN
SELECT * FROM Equipos WHERE EquipoID = @CODIGO

END 

CREATE PROCEDURE ACTUALIZAREQUIPO
@ID INT,
@TIPOEQUIPO VARCHAR (50),
@MODELO VARCHAR (50)

AS
BEGIN
UPDATE Equipos SET TipoEquipo = @TIPOEQUIPO, Modelo=@MODELO WHERE EquipoID = @ID 

END 

CREATE PROCEDURE AGREGAREQUIPO
@TIPOEQUIPO VARCHAR (50),
@MODELO VARCHAR (50)

AS
BEGIN

INSERT INTO Equipos (TipoEquipo,Modelo) VALUES (@TIPOEQUIPO,@MODELO)

END


INSERT INTO Equipos (TipoEquipo,Modelo) VALUES ('LAPTOP PRO', 'DELL' )

EXECUTE AGREGAREQUIPO 'COMPUTADORA DE ESCRITORIO 25 GB', 'HP'
EXECUTE ACTUALIZAREQUIPO 7,'FAX','EPSON'
EXECUTE CONSULTAREQUIPOS
EXECUTE CONSULTAR_FILTROEQUIPO  2
EXECUTE BORRAREQUIPO 4

-------TECNICOS

CREATE PROCEDURE CONSULTARTECNICOS
AS
BEGIN
SELECT * FROM Tecnicos

END 

CREATE PROCEDURE BORRARTECNICOS
@CODIGO INT
AS
BEGIN
DELETE Tecnicos WHERE TecnicoID = @CODIGO

END 

CREATE PROCEDURE CONSULTAR_FILTROTECNICOS
@CODIGO INT
AS
BEGIN
SELECT * FROM Tecnicos WHERE TecnicoID = @CODIGO

END 

CREATE PROCEDURE ACTUALIZARTECNICOS
@ID INT,
@NOMBRE VARCHAR (50)

AS
BEGIN
UPDATE Tecnicos SET Nombre = @NOMBRE WHERE TecnicoID = @ID 

END 


CREATE PROCEDURE AGREGARTECNICOS
@NOMBRE VARCHAR (50)

AS
BEGIN

INSERT INTO Tecnicos(Nombre) VALUES (@NOMBRE)

END

INSERT INTO Tecnicos(Nombre) VALUES ('JUAN LOPEZ')


EXECUTE AGREGARTECNICOS 'MARISOL SALSEDA'
EXECUTE ACTUALIZARTECNICOS 1,'JUANA LOPEZ'
EXECUTE CONSULTARTECNICOS
EXECUTE CONSULTAR_FILTROTECNICOS  4
EXECUTE BORRARTECNICOS 2
------

