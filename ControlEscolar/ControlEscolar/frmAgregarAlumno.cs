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

namespace ControlEscolar
{
    public partial class frmAgregarAlumno : Form
    {
        public frmAgregarAlumno()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-EA6J31N;DATABASE=ControlEscolar;Integrated security=true");

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

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar<=47)|| (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo se aceptan numeros");
                e.Handled = true;
                return;
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregarAlumno_Load(object sender, EventArgs e)
        {

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

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if(rs == DialogResult.OK)
            {
                imgAlumno.Image = Image.FromFile(fo.FileName);
            }
        }

        private void imgAlumno_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}
