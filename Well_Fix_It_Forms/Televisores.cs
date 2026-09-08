using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Well_Fix_It_Forms
{
    public partial class Televisores : Form
    {
        public Televisores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1. Obtenemos el estatus y el ID de la fila seleccionada
                int estatus = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_Estatus"].Value);
                int idSol = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                pictureBox1.Image = null;
                // Mostramos el ID en tu caja de texto
                textBox1.Text = idSol.ToString();

                // 2. Configuramos el botón de cancelar (Lo que ya tenías)
                btnCancelar.Enabled = true;
                btnCancelar.Text = "Cancelar Solicitud";

                // 3. Lógica para mostrar los datos del técnico (SOLO SI EL ESTATUS ES 2)
                if (estatus == 2)
                {
                    Conexion obj = new Conexion();
                    System.Data.DataTable dt = obj.ObtenerPerfilTecnicoAsignado(idSol);
                    
                    if (dt.Rows.Count > 0)
                    {
                        System.Data.DataRow fila = dt.Rows[0];

                        // LLENAMOS LOS DATOS (Asegúrate de que estos nombres existan en tu diseño)
                        textBox2.Text = fila["nombre"].ToString() + " " + fila["apellidos"].ToString();
                        textBox3.Text = "Correo: " + fila["correo"].ToString();
                        textBox4.Text = "Tel: " + fila["telefono"].ToString();
                        textBox5.Text = "Experiencia: " + fila["añosdeexperiencia"].ToString() + " años";
                        textBox6.Text = "Género: " + fila["Genero"].ToString();

                        // MOSTRAMOS LA FOTO PERSONAL
                        if (fila["fotopersonal"] != DBNull.Value)
                        {
                            byte[] img = (byte[])fila["fotopersonal"];
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(img))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
                else
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    pictureBox1.Image = null;
                }
            }
        }
        private void LimpiarLosCuadros(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                // Usamos el nombre completo para evitar el error de "referencia ambigua"
                if (c is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)c).Clear();
                }

                // Si tiene paneles o groupbox, buscamos adentro también
                if (c.HasChildren)
                {
                    LimpiarLosCuadros(c.Controls);
                }
            }
        }
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, selecciona un pedido de la tabla para poder cancelarlo.","Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int estatus = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_Estatus"].Value);
            DateTime fechaServicio = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha"].Value);
            DateTime hoy = DateTime.Now;

            if (estatus == 2) 
            {
                TimeSpan diferencia = fechaServicio - hoy;
                if (diferencia.TotalDays < 2)
                {
                    MessageBox.Show("Aviso de Cancelación:\n\n" +
                                    "Para servicios agendados, las políticas del negocio requieren un mínimo de " +
                                    "2 días de anticipación.\n\n", 
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; 
                }
            }
            DialogResult pregunta = MessageBox.Show("¿Estás seguro de que deseas CANCELAR tu solicitud?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                // 5. Pedir el motivo
                string motivo = Microsoft.VisualBasic.Interaction.InputBox("Por favor, dinos el motivo de la cancelación:", "Motivo", "Ya no lo necesito");

                if (!string.IsNullOrEmpty(motivo))
                {
                    int id = Convert.ToInt32(textBox1.Text);
                    Conexion coon = new Conexion();

                    if (coon.CancelarSolicitudPorCliente(id, motivo))
                    {
                        // Inicia animación de la barra de progreso
                        progressBar1.Visible = true;
                        label14.Visible = true;
                        button1.Enabled = false;

                        for (int i = 0; i <= 100; i += 10)
                        {
                            progressBar1.Value = i;
                            label14.Text = $"Cancelando Solicitud... {i}%";
                            await Task.Delay(100); // Pequeña pausa para que se vea la barra
                        }

                        label14.Text = "Solicitud Cancelada con Éxito";

                        // 7. REFRESCAR LA TABLA (Usa el nombre correcto de tu clase de sesión)
                        dataGridView1.DataSource = coon.MostrarSolicitudesPropias(UsuarioSesion.IdUsuario);
                        textBox1.Clear();
                        await Task.Delay(1000); // Pausa final

                        // Limpieza de controles
                        progressBar1.Visible = false;
                        label14.Visible = false;
                        button1.Enabled = true;

                        MessageBox.Show("Pedido cancelado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debes ingresar un motivo para cancelar.");
                }
            }
        }

        private void Televisores_Load(object sender, EventArgs e)
        {
            Conexion coon = new Conexion();

            // 1. LLENAMOS LA TABLA usando tu variable estática de sesión
            // Esto hace que el usuario vea sus pedidos en cuanto se abre la ventana
            dataGridView1.DataSource = coon.MostrarSolicitudesPropias(UsuarioSesion.IdUsuario);

            // 2. OCULTAMOS EL ID DEL ESTATUS
            // Lo necesitamos para que el botón de cancelar funcione, pero el usuario no debe verlo
            if (dataGridView1.Columns.Contains("ID"))
                dataGridView1.Columns["ID"].Visible = false;

            if (dataGridView1.Columns.Contains("id_Estatus"))
                dataGridView1.Columns["id_Estatus"].Visible = false;

            // 3. OPCIONAL: Ajustar el ancho de las columnas para que se vea bien
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Reseña fr = new Reseña(Convert.ToInt32(textBox1.Text), "Usuario");
            fr.ShowDialog();
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
