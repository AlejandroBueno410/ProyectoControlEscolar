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

namespace ControlEscolar
{
    public partial class frmAlumnos : Form
    {
        public frmAlumnos()
        {
            InitializeComponent();
            cn.Open();

            SqlCommand comando = new SqlCommand("Select * from Alumnos",cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgAlumnos.DataSource = tabla;

               
            cn.Close();
        }

        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-EA6J31N;DATABASE=ControlEscolar;Integrated security=true");

        private void frmAlumnos_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form formulario = new frmAgregarAlumno();
            formulario.Show();
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form formulario = new FrmPrincipal();
            formulario.Show();
            this.Close();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            if (txtModificar.Text=="")
            {
                MessageBox.Show("ingrese el id del alumno a modificar");
                txtModificar.Focus();
            }

            else{
                int Id = int.Parse(txtModificar.Text);
                cn.Open();
                SqlCommand comando3 = new SqlCommand("Select * from Alumnos where Id =@Id", cn);
                comando3.Parameters.AddWithValue("@Id", Id);    
                SqlDataReader lector = comando3.ExecuteReader();

                if (lector.Read())
                {
                    cn.Close();
                    ActualizarDatosAlumno formulario = new ActualizarDatosAlumno();

                    formulario.txtId.Text = txtModificar.Text;
                    formulario.Show();
                    this.Hide();

                }
                else
                {
                    cn.Close();

                    MessageBox.Show("Error al encontrar al usuario");
                    
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtEliminar.Text == "")
            {
                MessageBox.Show("ingrese el id del alumno a eliminar");
                txtEliminar.Focus();
            }
            else
            {
                

                int  Id = int.Parse(txtEliminar.Text);
                string strSql = "sp_EliminarAlumno";
                SqlCommand comando = new SqlCommand(strSql, cn);
                cn.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ID",Id);
                comando.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Usuario Eliminado");

                cn.Open();

                SqlCommand comando2 = new SqlCommand("Select * from Alumnos", cn);
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando2;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgAlumnos.DataSource = tabla;


                cn.Close();

            }

        }

        private void dgAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtModificar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo se aceptan numeros");
                e.Handled = true;
                return;
            }
        }

        private void txtEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("solo se aceptan numeros");
                e.Handled = true;
                return;
            }
        }
    }
}
