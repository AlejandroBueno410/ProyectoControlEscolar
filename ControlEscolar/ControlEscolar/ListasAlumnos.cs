using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlEscolar
{
    public partial class ListasAlumnos : Form
    {
        public ListasAlumnos()
        {
            InitializeComponent();
            cn.Open();

            SqlCommand comando = new SqlCommand("Select Id,Nombre,Usuario,CorreoElectronico from Alumnos", cn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgAlumnos.DataSource = tabla;


            cn.Close();
        }
        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-EA6J31N;DATABASE=ControlEscolar;Integrated security=true");


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();

            SqlCommand comando = new SqlCommand("Select Id,Nombre,Usuario,CorreoElectronico from Alumnos where Grupo=@Grupo", cn);
            comando.Parameters.AddWithValue("@Grupo",cbGrupo.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgAlumnos.DataSource = tabla;


            cn.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form formulario = new FrmPrincipal();
            formulario.Show();
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = true;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;


            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                const int DGV_ALTO = 35;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;
                if(cbGrupo.Text=="")
                {
                    ep.Graphics.DrawString("Lista de todos los Alumnos Inscritos", new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Red, left, Left);
                }
                else
                {
                    ep.Graphics.DrawString("Lista de Alumnos del " + cbGrupo.Text, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Red, left, Left);
                }


                foreach (DataGridViewColumn col in dgAlumnos.Columns)
                {
                    ep.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, left, top);
                    left += col.Width;

                    if (col.Index < dgAlumnos.ColumnCount - 1)
                        ep.Graphics.DrawLine(Pens.Gray, left - 5, top, left - 5, top + 43 + (dgAlumnos.RowCount - 1) * DGV_ALTO);
                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dgAlumnos.Rows)
                {
                    if (row.Index == dgAlumnos.RowCount - 1) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Segoe UI", 13), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DGV_ALTO;
                    ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                }
            };
            ppd.ShowDialog();

        }
    }
}
