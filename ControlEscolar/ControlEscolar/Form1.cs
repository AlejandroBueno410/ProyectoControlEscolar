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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-EA6J31N;DATABASE=ControlEscolar;Integrated security=true");

        private void btnIngresar_Click(object sender, EventArgs e)
        {


            //Form formulario = new FrmPrincipal();
            //formulario.Show();
            cn.Open();
            SqlCommand Comando = new SqlCommand("Select Usuario, Contrasena from Usuarios where Usuario=@vUsuario AND Contrasena=@vContrasena",cn);
            Comando.Parameters.AddWithValue("@vUsuario",txtUsuario.Text);
            Comando.Parameters.AddWithValue("@vContrasena", txtContrasena.Text);

            SqlDataReader lector = Comando.ExecuteReader();

            if (lector.Read())
            {
                cn.Close();
                Form formulario = new FrmPrincipal();
                formulario.Show();
                this.Hide();

            }
            else
            {
                cn.Close();

                MessageBox.Show("Error al entrar");
                txtContrasena.Clear();
                txtUsuario.Clear();
            }
        }
    }
}
