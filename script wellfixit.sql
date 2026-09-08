--DROP DATABASE We_ll_Fix_It

SELECT * FROM Usuarios;
SELECT * FROM Tecnicos;
SELECT * FROM Solicitud_Servicios;
SELECT * FROM Pedidos_Agendados;
SELECT * FROM Reseña;
SELECT * FROM Estatus

create database We_ll_Fix_It;
go
use We_ll_Fix_It;
go


create table Usuarios
(
    id_Usuarios   int identity (1,1), 
    nombre        varchar(50),
    apellido      varchar(50),
    correo        varchar(50)UNIQUE,
	telefono      varchar(10),
    calle		  varchar (100),
	nomenclatura  varchar(5),
	colonia	   	  varchar(100),---
	entrecalles   varchar (150),
	codigopostal  varchar (5),
	municipio     varchar(50),
	estado        varchar(50),
    contraseña    varchar(50),
    Hash	      nvarchar(max),   
    Salt          nvarchar(max), 
	foto		  VARBINARY(MAX) 
);
go
                     
create table Tecnicos
(
    id_Tecnicos			int identity (1,1),
    nombre              varchar(50),
	apellidos           varchar (50),
	correo              varchar (50)UNIQUE,
	telefono            varchar(10),
	calle			    varchar(50),
	nomenclatura		varchar(5),
	colonia			    varchar(100),
	entrecalles         varchar (150),
	codigpostal         varchar (5),
    municipio           varchar(50),
	estado              varchar(50),
	especialidad        varchar(50),
	añosdeexperiencia   varchar(50),
    Genero              varchar(30),
	contraseña          varchar(50),
	Hash				nvarchar(max),
	Salt				nvarchar (max),
	foto				VARBINARY(MAX),
	fotopersonal		VARBINARY(MAX)
	);
go

create table Estatus
(
	id_Estatus	     	int identity (1,1),
   	Nombre		     	varchar(100),
);
go

create table Solicitud_Servicios
(
    id_Solicitud_Servicios int identity (1,1), 
	Categoria			   varchar(30),
	descripcionproblema	   varchar(200),
	tipodeservicio		   varchar (50),
    antiguedadequipo	   varchar(20),
	tipopago			   varchar(20),
	fechasolicitud		   date,
    horavisita			   varchar(25),
	marcaequipo			   varchar (25),
	id_Estatus			   int, 
    id_Usuarios			   int, 
    id_Tecnicos			   int,
	motivo_cancelacion     varchar(300)
);
go

create table Pedidos_Agendados
(
    id_Pedidos_Agendados   int identity (1,1),
    costoreparacion        float,
    id_Solicitud_Servicios int unique,
	id_Tecnicos            int,
);
go

create table Reseña
(
    id_Reseña			    int identity (1,1),
    calificacion	        int,
    comentario			    varchar(100),
    fecha				    date,
    emisor				    varchar(max) ,
    id_Pedidos_Agendados	int
);
go
                   ------PRIMARY KEYS------
ALTER TABLE Usuarios
ADD CONSTRAINT PK_Usuarios
PRIMARY KEY(id_Usuarios);
GO
ALTER TABLE Tecnicos
ADD CONSTRAINT PK_Tecnicos
PRIMARY KEY(id_Tecnicos);
GO
ALTER TABLE Solicitud_Servicios
ADD CONSTRAINT PK_Solicitud_Servicios
PRIMARY KEY(id_Solicitud_Servicios);
GO
ALTER TABLE Pedidos_Agendados
ADD CONSTRAINT PK_Pedidos_Agendados
PRIMARY KEY(id_Pedidos_Agendados);
GO
ALTER TABLE Reseña
ADD CONSTRAINT PK_Reseña
PRIMARY KEY(id_Reseña);
GO
ALTER TABLE Estatus
ADD CONSTRAINT PK_Estatus
PRIMARY KEY(id_Estatus);
GO

                                                          ------FOREING KEYS-----
                    -- FKs para Solicitud_Servicios
Alter table Solicitud_Servicios
add constraint FK_Solicitud_Usuarios Foreign key(id_Usuarios)
References Usuarios(id_Usuarios);
go
Alter table Solicitud_Servicios
add constraint FK_Solicitud_Tecnicos Foreign key(id_Tecnicos)
References Tecnicos(id_Tecnicos);
go
Alter table Solicitud_Servicios
add constraint FK_Estatus Foreign key(id_Estatus)
References Estatus(id_Estatus);
go
                  -- FKs para pedidos_agendados
Alter table Pedidos_Agendados
add constraint FK_Pedidos_Agendados_Solicitud Foreign key(id_Solicitud_Servicios)
References Solicitud_Servicios(id_Solicitud_Servicios);
go
Alter table Pedidos_Agendados
add constraint FK_Pedidos_Agendados_Tecnicos Foreign key(id_Tecnicos)
References Tecnicos(id_Tecnicos);
go
                  -- FKs para Reseña
Alter table Reseña
add constraint FK_Reseña_Pedidos_Agendados Foreign key(id_Pedidos_Agendados) 
References Pedidos_Agendados(id_Pedidos_Agendados);
go

--ALTER TABLE Tecnicos ADD UNIQUE (correo)
--ALTER TABLE Usuarios ALTER COLUMN Hash NVARCHAR(MAX);
--ALTER TABLE Usuarios ALTER COLUMN Salt NVARCHAR(MAX);
--DELETE FROM Solicitud_Servicios;
--ALTER TABLE Solicitud_Servicios  ADD motivo_cancelacion VARCHAR(300) NULL;
--ALTER TABLE Reseña  ALTER COLUMN comentario VARCHAR(MAX); 
--ALTER TABLE Tecnicos ADD fotopersonal VARBINARY(MAX) NULL;
--ESTO ES PARA BORRAR UNA LINEA ES BD
--DELETE FROM Usuarios WHERE id_Usuarios =2;  
--DROP TABLE Solicitudes_Finalizadas;
-- ESTO ES PARA CAMBIA UN DATO DE UN USUARIO EN DB
--UPDATE Solicitudes_Finalizadas SET Solicitudes_Servicios = 'Solicitudes_Finalizadas' WHERE id_Reseña = 100;
--para borrar una columna de alguna tabla
--alter table Solicitud_Servicios add categoriaequipo VARCHAR(30), BEFORE descripcionproblema;
--alter table Usuarios  drop column  letra;



/*
select pa.id_Solicitud_Servicios,ss.antiguedadequipo
from Pedidos_Agendados pa
inner join Solicitud_Servicios ss
ON pa.id_Pedidos_Agendados = ss.id_Solicitud_Servicios

select u.nombre,u.apellido,u.correo,u.municipio,ss.id_Estatus,ss.descripcionproblema,ss.fechasolicitud,ss.horavisita
from Usuarios u
left join Solicitud_Servicios ss
on u.apellido = 'HERNANDEZ'
*/

create procedure sp_insert_usuario
	@nombre        varchar(50),
    @apellido      varchar(50),
    @correo        varchar(50),
	@telefono      varchar(10),
    @calle		  varchar (100),
	@nomenclatura  varchar(5),
	@colonia	   	  varchar(100),
	@entrecalles   varchar (150),
	@codigopostal  varchar (5),
	@municipio     varchar(50),
	@estado        varchar(50),
    @contraseña    varchar(50),
    @Hash	      nvarchar(max),   
    @Salt          nvarchar(max), 
	@foto		  VARBINARY(MAX) null
	as
	begin
		begin try
			insert into Usuarios(Nombre, Apellido, Correo, Telefono,Calle,Nomenclatura, Colonia,Entrecalles,Codigopostal,Municipio, Estado, Contraseña,Hash,Salt,Foto)
		 	values(@nombre,@apellido,@correo,@telefono,@calle,@nomenclatura,@colonia,@entrecalles,@codigopostal,@municipio,@estado,@contraseña,@Hash,@Salt,@foto)
	   	    print 'Usuario insertado correctamente';
		end try
		begin catch
			print 'Ocurrió un error al insertar el usuario';
			print ERROR_MESSAGE();
		end catch
	end;

	create procedure sp_insert_tecnicos
	@nombre              varchar(50),
	@apellidos           varchar (50),
	@correo              varchar (50),
	@telefono            varchar(10),
	@calle			     varchar(50),
	@nomenclatura		 varchar(5),
	@colonia			 varchar(100),
	@entrecalles         varchar (150),
	@codigpostal         varchar (5),
    @municipio           varchar(50),
	@estado              varchar(50),
	@especialidad        varchar(50),
	@añosdeexperiencia   varchar(50),
    @genero              varchar(30),
	@contraseña          varchar(50),
	@Hash				nvarchar(max),
	@Salt				nvarchar (max),
	@foto				VARBINARY(MAX),
	@fotopersonal		VARBINARY(MAX) 
	as
	begin
		begin try
			insert into Tecnicos(Nombre, Apellidos, Correo, Telefono,Calle,Nomenclatura, Colonia,Entrecalles,Codigpostal,Municipio, Estado,Especialidad,Añosdeexperiencia,Genero, Contraseña,Hash,Salt,Foto,Fotopersonal)
		 	values(@nombre,@apellidos,@correo,@telefono,@calle,@nomenclatura,@colonia,@entrecalles,@codigpostal,@municipio,@estado,@especialidad,@añosdeexperiencia,@genero,@contraseña,@Hash,@Salt,@foto,@fotopersonal)
	   	    print 'Tecnico insertado correctamente';
		end try
		begin catch
			print 'Ocurrió un error al insertar el usuario';
			print ERROR_MESSAGE();
		end catch
	end;
	




	exec sp_insert_usuario 
    @nombre = 'Prueba',
    @apellido = 'Demo',
    @correo = 'demo@mail.com',
    @telefono = '8123456789',
    @calle = 'Av. Siempre Viva',
    @nomenclatura = '123',
    @colonia = 'Centro',
    @entrecalles = 'Juárez y Hidalgo',
    @codigopostal = '64000',
    @municipio = 'Monterrey',
    @estado = 'Nuevo León',
    @contraseña = '12345',
    @Hash = NULL,
    @Salt = NULL,
    @foto = NULL;


