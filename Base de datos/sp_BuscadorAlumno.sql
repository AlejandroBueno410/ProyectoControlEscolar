
Create PROCEDURE Sp_BuscadorAlumno
		@Buscar varchar(50)

AS
BEGIN
	
	SELECT * from Alumnos where Nombre like @Buscar + '%' or Usuario like @Buscar +'%'
END
