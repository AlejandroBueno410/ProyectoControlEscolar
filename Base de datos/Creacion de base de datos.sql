Create database ControlEscolar

Use ControlEscolar


CREATE TABLE Usuarios 
   (Id int identity(1,1) PRIMARY KEY NOT NULL,  
   Usuario varchar(30) NOT NULL,
   Nombre varchar(40) NOT NULL,
   Contrasena varchar(40) NOT NULL,  
   )  
GO  


insert into Usuarios values('Alejandro1','Alejandro','123');



CREATE TABLE Alumnos 
   (Id int identity(1000,1) PRIMARY KEY NOT NULL,  
   Usuario varchar(30) NOT NULL,
   Nombre varchar(40) NOT NULL,
   Grupo varchar(15) NOT NULL,
   CorreoElectronico varchar(50) NOT NULL,
   FechaNacimiento date NOT NULL,
   Ciudad varchar(30) NOT NULL,
   Pais varchar(30) NOT NULL,
   Edad int
   )  
GO  

	

insert into Alumnos values('Eduardo123','Eduardo Lopez','G1','alejandro@hotmail.com','1999-03-20','Culiacán','México',21);



