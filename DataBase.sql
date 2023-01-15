Server=localhost\SQLEXPRESS;Database=TEST;Trusted_Connection=True;

CREATE DATABASE TEST
GO

USE TEST
GO


IF OBJECT_ID('COLEGIO ','U') IS NULL
BEGIN
	CREATE TABLE COLEGIO (
	Id int identity(1,1) PRIMARY KEY,
	Nombre varchar(256) unique,
	TipoColegio varchar(64)
	)
END
	
GO

IF OBJECT_ID('MATERIA ','U') IS NULL
BEGIN
	CREATE TABLE MATERIA (
	Id int identity(1,1) PRIMARY KEY,
	IdColegio int,
	Nombre varchar(256) unique,
	Area varchar(128),
	NumeroEstudiantes int,
	DocenteAsignado varchar(512),
	Curso varchar(64),
	Paralelo varchar(16),
	CONSTRAINT fk_Colegio FOREIGN KEY (IdColegio) REFERENCES COLEGIO (Id),
	)
END

GO

IF OBJECT_ID('USUARIO ','U') IS NULL
BEGIN
	CREATE TABLE USUARIO (
	Id int identity(1,1) PRIMARY KEY,
	NombreCompleto varchar(256) ,
	Username varchar(128) unique,
	Password varchar(128) ,
	CorreoElectronico varchar(256) ,
	Rol varchar(32)
	)
END
	
GO

IF OBJECT_ID('CALIFICACIONES ','U') IS NULL
BEGIN
	CREATE TABLE CALIFICACIONES (
	Id int identity(1,1) PRIMARY KEY,
	IdColegio int,
	IdMateria int,
	IdUsuario int,
	Calificacion numeric(18,2),	
	CONSTRAINT fk_ColegioCal FOREIGN KEY (IdColegio) REFERENCES COLEGIO (Id),
	CONSTRAINT fk_Materia FOREIGN KEY (IdMateria) REFERENCES COLEGIO (Id),
	CONSTRAINT fk_Usuario FOREIGN KEY (IdUsuario) REFERENCES USUARIO (Id),
	)
END

GO


INSERT INTO USUARIO (NombreCompleto ,Username,Password ,CorreoElectronico ,	Rol)VALUES('USUARIO', 'user','password','correo@correo.com','Admin')
 