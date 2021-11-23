
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_ModificarDatos
	@Id int, @Usuario varchar(30), @Nombre varchar(40), @Grupo varchar(15), @CorreoElectronico varchar(50), @Fecha date,
		@Ciudad varchar(30), @Pais varchar(30),@Edad int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		update Alumnos set Usuario=@Usuario, Nombre=@Nombre, Grupo=@Grupo, CorreoElectronico=@CorreoElectronico, FechaNacimiento=@Fecha, Ciudad=@Ciudad, Pais=@Pais, Edad=@Edad where Id=@Id
	END
GO
