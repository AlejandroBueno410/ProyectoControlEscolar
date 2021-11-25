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
using System.IO;

namespace ControlEscolar
{
    public partial class frmMaestros : Form
    {
        public frmMaestros()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-EA6J31N;DATABASE=ControlEscolar;Integrated security=true");

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            DialogResult rs = fo.ShowDialog();
            if (rs == DialogResult.OK)
            {
                imgAlumno.Image = Image.FromFile(fo.FileName);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();


                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Imagenes VALUES (@image)";

                // Creando los parámetros necesarios
                cmd.Parameters.Add("@image", System.Data.SqlDbType.Image);

                // Asignando el valor de la imagen

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                imgAlumno.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@image"].Value = ms.GetBuffer();

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string strSql = "Select * from Imagenes where Id=1000";
            SqlCommand comando = new SqlCommand(strSql, cn);
            SqlDataAdapter dp = new SqlDataAdapter(comando);
            DataSet ds = new DataSet("Imagenes");

            byte[] MisDatos = new byte[0];

            dp.Fill(ds, "Imagenes");

            DataRow myRow = ds.Tables["Imagenes"].Rows[0];
            MisDatos = (byte[])myRow["Imagen"];
            MemoryStream ms = new MemoryStream(MisDatos);
            pbImagen.Image = Image.FromStream(ms);

            cn.Close();
        }
    }
    
}
