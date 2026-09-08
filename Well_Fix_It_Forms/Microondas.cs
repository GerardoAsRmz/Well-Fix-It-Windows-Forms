using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well_Fix_It_Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Well_Fix_It_Forms
{
    public partial class Microondas : Form
    {
        public Microondas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            DateTime hora = dTP2.Value;
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox4.Text == "" || comboBox6.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (fechaSeleccionada.Date < DateTime.Now.AddDays(2))
            {
                MessageBox.Show("Debe agendar con al menos 2 días de anticipación. Seleccione una fecha válida.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox1.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("La descripcion del problema solo debe contener letras.", "Descripcion del Problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox2.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("Servicio solicitado solo debe contener letras.", "Que Servicio Necesita tu Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox4.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("La antiguedad del equipo solo debe contener letras.", "Antiguedad del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox6.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("La marca del equipo solo debe contener letras.", "Selecciona Marca del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Desea confirmar y agendar su solicitud de servicio?", "Confirmar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Si todo pasa, continuar con el registro
                string categoria = "Microondas";
                string descripcionproblema = comboBox1.Text;
                string tipodeservicio = comboBox2.Text;
                string antiguedadequipo = comboBox4.Text;
                string tipopago = textBox4.Text;
                DateTime fechasolicitud = fechaSeleccionada;
                string horasivita = hora.ToString("HH:mm");
                string marcaequipo = comboBox6.Text;

                Conexion conn = new Conexion();

                if (conn.Solicitud_Servicios(categoria, descripcionproblema, tipodeservicio, antiguedadequipo, tipopago, fechasolicitud, horasivita, marcaequipo))
                {
                    MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ExitoSolicitud enviarSolicitud = new ExitoSolicitud();
                    enviarSolicitud.Show();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Microondas_Load(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;

        }
    }
}




