

CREATE PROCEDURE Sp_InsertarAlumnos
		@Usuario varchar(30), @Nombre varchar(40), @Grupo varchar(15), @CorreoElectronico varchar(50), @Fecha date,
		@Ciudad varchar(30), @Pais varchar(30)
AS
BEGIN

	INSERT INTO Alumnos(Usuario,Nombre,Grupo,CorreoElectronico,FechaNacimiento,Ciudad,Pais) values (@Usuario, @Nombre, @Grupo, @CorreoElectronico, @Fecha, @Ciudad, @Pais)

END
GO
