using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Well_Fix_It_Forms
{
    public partial class Reseña : Form
    {

        private int idPedidoAgendado;
        private string tipoUsuario;

        public Reseña(int idPedido, string emisor)
        {
            InitializeComponent();
            this.idPedidoAgendado = idPedido;
            this.tipoUsuario = emisor;

        }

        private async void button1_Click(object sender, EventArgs e)
        {          
            if (textBox1.Text.Length < 5)
            {
                MessageBox.Show("Por favor, escribe un comentario breve sobre el servicio.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una calificación.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            int calif = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            string comentario = textBox1.Text;

            // Estos datos los recibimos cuando abrimos la ventana (ID Pedido
            int idPed = this.idPedidoAgendado;
            string emisor = this.tipoUsuario;

            // 3. LLAMAMOS AL MOTOR (El que ya pusiste en Conexion.cs)
            Conexion coon = new Conexion();
            if (coon.GuardarReseña(calif, comentario, idPed, emisor))
            {
                progressBar1.Visible = true;
                label14.Visible = true;
                progressBar1.Value = 0;
                button1.Enabled = false;
                for (int i = 0; i <= 100; i += 10)
                {
                    progressBar1.Value = i;
                    label14.Text = $"Guardando Registro... {i}%";
                    // Simulamos una demora de red o procesamiento
                    await Task.Delay(200);
                }
                label14.Text = "Registro Guardado con Éxito!";
                progressBar1.Value = 100;

                await Task.Delay(2000); // Pequeña pausa para mostrar el mensaje de éxito
                progressBar1.Visible = false;
                label14.Visible = false;
                button1.Enabled = true;

                MessageBox.Show("¡Gracias por Por tu comentario te lo agradecemos!", "", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close(); // Cerramos la ventanita
            }
        }
    }
}
