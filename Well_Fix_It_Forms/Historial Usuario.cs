using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Well_Fix_It_Forms
{
    public partial class Historial_Usuario : Form
    {
        public Historial_Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow == null) return;

            // 1. Obtenemos el ID del pedido terminado
            int idPed = Convert.ToInt32(dGV1.CurrentRow.Cells["ID"].Value);

            // 2. ABRIMOS TU VENTANA DE RESEÑA
            // Pero ahora le pasamos "Usuario" como emisor
            Reseña ventana = new Reseña(idPed, "Usuario");
            ventana.ShowDialog();

            MessageBox.Show("¡Gracias por calificar al técnico! Tu opinión ayuda a la comunidad.");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();    
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Historial_Usuario_Load(object sender, EventArgs e)
        {
            Conexion coon = new Conexion();
            dGV1.DataSource = coon.MostrarHistorialFinalizado(UsuarioSesion.IdUsuario);
            dGV1.Columns["id_Estatus"].Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Reseña fr = new Reseña(Convert.ToInt32(textBox1.Text), "Usuario");
            fr.ShowDialog();
            Conexion coon = new Conexion();
            dGV1.DataSource = coon.MostrarHistorialFinalizado(UsuarioSesion.IdUsuario);
            dGV1.Columns["id_Estatus"].Visible = false;
        }

        private void dGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex >= 0)
                {
                    // 1. Obtener el estatus de la fila
                    int estatus = Convert.ToInt32(dGV1.Rows[e.RowIndex].Cells["id_Estatus"].Value);
                    textBox1.Text = dGV1.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                    if (estatus == 3)
                    {
                        button1.Enabled = true;
                        button1.Text = "Calificar Servicio";
                    }
                    else if (estatus == 5)
                    {
                        button1.Enabled = false;
                        button1.Text = "Ya Calificado";
                    }
                    else if (estatus == 4)
                    {
                        button1.Enabled = false;
                        button1.Text = "Cancelado";
                    }


                }
            }
        }
    }
}
