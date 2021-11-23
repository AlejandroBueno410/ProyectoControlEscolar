=========================================
-- Author:		Alejandro Bueno Mendoza	
-- Create date: 23/11/2021
-- Description:	Eliminar alumno
-- =============================================
CREATE PROCEDURE sp_EliminarAlumno
	@ID int
AS
BEGIN
    DELETE FROM Alumnos WHERE Id = @ID
END
GO
