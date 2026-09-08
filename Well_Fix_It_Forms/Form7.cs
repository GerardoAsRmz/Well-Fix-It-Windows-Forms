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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            textBox1.Text = TecnicoSesion.NombreTecnico+" "+TecnicoSesion.ApellidoTecnico;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Salir";
            DialogResult result = MessageBox.Show("¿Quieres finalizar tu sesion?", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();  
                form1.Show();
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 =new _10();
            _10.Show();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.Hide();
            _10 _10 = new _10();
            _10.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas agregar una foto a tu perfil?", "Cambiar foto de perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                OpenFileDialog buscarimagen = new OpenFileDialog();
                buscarimagen.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (buscarimagen.ShowDialog() == DialogResult.OK)
                {
                    pictureBox13.Image = Image.FromFile(buscarimagen.FileName);
                    int idUsuarioActual = UsuarioSesion.IdUsuario;

                    // Suponiendo que tu clase de conexión se llama "Conexion"
                    Conexion objetoCon = new Conexion();
                    objetoCon.ActualizarFotoPerfilTecnico(idUsuarioActual, pictureBox13.Image);

                    MessageBox.Show("¡Foto Actualizada con exito!");
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            int idActual = TecnicoSesion.IdTecnico;

            // 2. Llamamos al método que creamos en tu clase de conexión
            Conexion objCon = new Conexion();
            Image fotoGuardada = objCon.ObtenerFotoPerfilTecnico(idActual);

            // 3. Si encontramos una foto en la BD, la mostramos
            if (fotoGuardada != null)
            {
                pictureBox13.Image = fotoGuardada;
                pictureBox13.SizeMode = PictureBoxSizeMode.Zoom; // Para que se vea bien
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Preguntas_Frecuentes preguntasFrecuentes = new Preguntas_Frecuentes();
            preguntasFrecuentes.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            USUARIOS usuarios = new USUARIOS();
            usuarios.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.instagram.com/well.fix.it1?igsh=eHd3dzNxd29ydWpn&utm_source=qr");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.facebook.com/share/1SXGWn8EBA/");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Manual_uso_usuario manual_Uso_Usuario = new Manual_uso_usuario();
            manual_Uso_Usuario.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Manual_uso_tecnico manual_Uso_Tecnico = new Manual_uso_tecnico();
            manual_Uso_Tecnico.Show();
        }
    }
}
