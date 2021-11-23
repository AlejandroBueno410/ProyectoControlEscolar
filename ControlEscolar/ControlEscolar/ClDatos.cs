using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ControlEscolar
{
    public class ClDatos
    {
        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-EA6J31N;DATABASE=ControlEscolar;Integrated security=true");

        public void AgregarAlumno(ClAgregarAlumno alumno)
        {
            string strSql = "Sp_InsertarAlumnos";
            SqlCommand comando = new SqlCommand(strSql, cn);
            cn.Open();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", alumno.Usuario);
            comando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
            comando.Parameters.AddWithValue("@Grupo", alumno.Grupo);
            comando.Parameters.AddWithValue("@CorreoElectronico", alumno.Correo);
            comando.Parameters.AddWithValue("@Fecha", alumno.Fecha);
            comando.Parameters.AddWithValue("@Ciudad", alumno.Ciudad);
            comando.Parameters.AddWithValue("@Pais", alumno.Pais);
            comando.Parameters.AddWithValue("@Edad", alumno.Edad);


            comando.ExecuteNonQuery();
            cn.Close();

        }

        public void ModificarAlumno(ClAgregarAlumno alumno)
        {
            ActualizarDatosAlumno formulario = new ActualizarDatosAlumno();
            int Id = int.Parse(formulario.txtId.Text);

            string strSql = "sp_ModificarDatos";
            SqlCommand comando = new SqlCommand(strSql, cn);
            cn.Open();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id",Id);
            comando.Parameters.AddWithValue("@Usuario", alumno.Usuario);
            comando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
            comando.Parameters.AddWithValue("@Grupo", alumno.Grupo);
            comando.Parameters.AddWithValue("@CorreoElectronico", alumno.Correo);
            comando.Parameters.AddWithValue("@Fecha", alumno.Fecha);
            comando.Parameters.AddWithValue("@Ciudad", alumno.Ciudad);
            comando.Parameters.AddWithValue("@Pais", alumno.Pais);
            comando.Parameters.AddWithValue("@Edad", alumno.Edad);


            comando.ExecuteNonQuery();
            cn.Close();

        }


    }

  

}


