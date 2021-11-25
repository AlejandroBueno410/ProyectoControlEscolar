using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace ControlEscolar
{
    public partial class ActualizarDatosAlumno : Form
    {
        public ActualizarDatosAlumno()
        {
            InitializeComponent();
           
        }
        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-EA6J31N;DATABASE=ControlEscolar;Integrated security=true");

        private void ActualizarDatosAlumno_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtNombre.Text == "" || cbGrupo.Text == "" || txtCorreo.Text == "" || dtFecha.Text == "" || txtCiudad.Text == "" || txtPais.Text == "" || txtEdad.Text == "" || imgAlumno.Image==null) 
            {
                MessageBox.Show("faltan datos por llenar");
            }
            else if (email_bien_escrito(txtCorreo.Text) == false)
            {
                errorEmail.SetError(txtCorreo, "Ingrese un email valido");
                return;

            }
            else
            {
                ClAgregarAlumno alumno = new ClAgregarAlumno();
                alumno.Usuario = txtUsuario.Text;
                alumno.Nombre = txtNombre.Text;
                alumno.Grupo = cbGrupo.Text;
                alumno.Correo = txtCorreo.Text;
                alumno.Fecha = DateTime.Parse(dtFecha.Text);
                alumno.Ciudad = txtCiudad.Text;
                alumno.Pais = txtPais.Text;
                alumno.Edad = int.Parse(txtEdad.Text);



                int Id = int.Parse(txtId.Text);
                string strSql = "sp_ModificarDatos";
                SqlCommand comando = new SqlCommand(strSql, cn);
                cn.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id", Id);
                comando.Parameters.AddWithValue("@Usuario", alumno.Usuario);
                comando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                comando.Parameters.AddWithValue("@Grupo", alumno.Grupo);
                comando.Parameters.AddWithValue("@CorreoElectronico", alumno.Correo);
                comando.Parameters.AddWithValue("@Fecha", alumno.Fecha);
                comando.Parameters.AddWithValue("@Ciudad", alumno.Ciudad);
                comando.Parameters.AddWithValue("@Pais", alumno.Pais);
                comando.Parameters.AddWithValue("@Edad", alumno.Edad);
                // Creando los parámetros necesarios
                comando.Parameters.Add("@Imagen", System.Data.SqlDbType.Image);

                // Asignando el valor de la imagen

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                imgAlumno.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                comando.Parameters["@Imagen"].Value = ms.GetBuffer();



                comando.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Actualizado");



                Form formulario = new frmAlumnos();
                formulario.Show();
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form formulario = new frmAlumnos();
            formulario.Show();
            this.Close();
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo se aceptan numeros");
                e.Handled = true;
                return;
            }
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cn.Open();
            int Id = int.Parse(txtId.Text);
            SqlCommand Comando = new SqlCommand("Select * from Alumnos where Id=@Id", cn);
            Comando.Parameters.AddWithValue("@Id", Id);


            SqlDataReader lector = Comando.ExecuteReader();

            if (lector.Read())
            {

                txtUsuario.Text = lector["Usuario"].ToString();
                txtNombre.Text = lector["Nombre"].ToString();
                cbGrupo.Text = lector["Grupo"].ToString();
                txtCorreo.Text = lector["CorreoElectronico"].ToString();
                dtFecha.Text= lector["FechaNacimiento"].ToString();
                txtCiudad.Text = lector["Ciudad"].ToString();
                txtPais.Text = lector["Pais"].ToString();
                txtEdad.Text = lector["Edad"].ToString();

                cn.Close();

            }
            else
            {
                MessageBox.Show("Este alumno no existe");
            }
            SqlCommand comando2 = new SqlCommand("Select * from Alumnos where Id=@Id", cn);
            comando2.Parameters.AddWithValue("@Id", Id);

            SqlDataAdapter dp = new SqlDataAdapter(comando2);
            DataSet ds = new DataSet("Alumnos");

            byte[] MisDatos = new byte[0];

            dp.Fill(ds, "Alumnos");

            DataRow myRow = ds.Tables["Alumnos"].Rows[0];
            MisDatos = (byte[])myRow["Imagen"];
            MemoryStream ms = new MemoryStream(MisDatos);
            imgAlumno.Image = Image.FromStream(ms);

            cn.Close();

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if (rs == DialogResult.OK)
            {
                imgAlumno.Image = Image.FromFile(fo.FileName);
            }
        }

        private void imgAlumno_Click(object sender, EventArgs e)
        {

        }
    }
}
