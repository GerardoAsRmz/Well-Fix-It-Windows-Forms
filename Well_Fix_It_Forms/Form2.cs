using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Well_Fix_It_Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = UsuarioSesion.NombreUsuario + " " + UsuarioSesion.ApellidoUsuario;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refrigeradores formRefrigeradores = new Refrigeradores();
            formRefrigeradores.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {

           //Televisores formTelevisores = new Televisores();
            //formTelevisores.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Minisplits minisplits = new Minisplits();
            minisplits.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Ventiladores ventiladores = new Ventiladores();
            ventiladores.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Lavadoras lavadoras = new Lavadoras();
            lavadoras.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Microondas microondas = new Microondas();
            microondas.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Secadoras secadoras = new Secadoras();
            secadoras.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Licuadoras licuadoras = new Licuadoras();
            licuadoras.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Aspiradoras aspiradoras = new Aspiradoras();    
            aspiradoras.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Tostadores tostadores = new Tostadores();
            tostadores.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Microondas microondas = new Microondas();
            microondas.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Secadoras secadoras = new Secadoras();
            secadoras.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Refrigeradores Refrigeradores = new Refrigeradores();
            Refrigeradores.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Minisplits minisplits = new Minisplits();
            minisplits.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
           Ventiladores ventiladores = new Ventiladores();
            ventiladores.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Lavadoras lavadoras = new Lavadoras();
            lavadoras.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Licuadoras licuadoras = new Licuadoras();
            licuadoras.Show();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Aspiradoras aspiradoras = new Aspiradoras();
            aspiradoras.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Tostadores tostadores = new Tostadores();
            tostadores.Show();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {


        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            Televisiones televisiones = new Televisiones();
            televisiones.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Televisores televisores3 = new Televisores();
            televisores3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 1. Usamos el ID de tu clase estática
            int idActual = UsuarioSesion.IdUsuario;

            // 2. Llamamos al método que creamos en tu clase de conexión
            Conexion objCon = new Conexion();
            Image fotoGuardada = objCon.ObtenerFotoPerfilUsuario(idActual);

            // 3. Si encontramos una foto en la BD, la mostramos
            if (fotoGuardada != null)
            {
                pictureBox13.Image = fotoGuardada;
                pictureBox13.SizeMode = PictureBoxSizeMode.Zoom; // Para que se vea bien
            }
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            Refrigeradores refrigeradores = new Refrigeradores();
            refrigeradores.Show();
        }

        private void button5_Click_4(object sender, EventArgs e)
        {
            Televisiones televisiones = new Televisiones();
            televisiones.Show();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            Minisplits minisplits = new Minisplits();
            minisplits.Show();
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            Ventiladores ventiladores = new Ventiladores();
            ventiladores.Show();
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            Lavadoras lavadoras = new Lavadoras();
            lavadoras.Show();
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            Microondas microondas = new Microondas();
            microondas.Show();
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            Secadoras secadoras = new Secadoras();
            secadoras.Show();
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            Licuadoras licuadoras = new Licuadoras();
            licuadoras.Show();
        }

        private void button12_Click_2(object sender, EventArgs e)
        {
            Aspiradoras aspiradoras = new Aspiradoras();
            aspiradoras.Show();
        }

        private void button13_Click_2(object sender, EventArgs e)
        {
            Tostadores tostadores = new Tostadores();
            tostadores.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Text = "Salir";
            DialogResult result = MessageBox.Show("¿Quieres finalizar tu sesion?", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Refrigeradores refrigeradores = new Refrigeradores();
            refrigeradores.Show();
        }

        private void button5_Click_5(object sender, EventArgs e)
        {
            this.Hide();
            Televisiones televisiones = new Televisiones(); 
            televisiones.Show();
        }

        private void button6_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Minisplits  minisplits = new Minisplits();
            minisplits.Show();
        }

        private void button7_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Ventiladores ventiladores = new Ventiladores();
            ventiladores.Show();
        }

        private void button8_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Lavadoras lavadoras = new Lavadoras();
            lavadoras.Show();
        }

        private void button9_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Microondas microondas = new Microondas();
            microondas.Show();
        }

        private void button10_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Secadoras secadoras = new Secadoras();
            secadoras.Show();
        }

        private void button11_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Licuadoras licuadoras = new Licuadoras();
            licuadoras.Show();
        }

        private void button12_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Aspiradoras aspiradoras = new Aspiradoras();
            aspiradoras.Show();
        }

        private void button13_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            Tostadores  tostadores = new Tostadores();
            tostadores.Show();
        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.instagram.com/well.fix.it1?igsh=eHd3dzNxd29ydWpn&utm_source=qr");
        }

        private void linkLabel2_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.facebook.com/share/1SXGWn8EBA/");
        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button3_Click_3(object sender, EventArgs e)
        {

            button3.Text = "Salir";
            DialogResult result = MessageBox.Show("¿Quieres finalizar tu sesion?   " + UsuarioSesion.NombreUsuario, "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }

        }

        private void lbl2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_2(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Televisores televisores = new Televisores();
            televisores.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            Historial_Usuario historial_Usuario = new Historial_Usuario();
            historial_Usuario.Show();
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
                    int idUsuarioActual =UsuarioSesion.IdUsuario;

                    // Suponiendo que tu clase de conexión se llama "Conexion"
                    Conexion objetoCon = new Conexion();
                    objetoCon.ActualizarFotoPerfilUsuario(idUsuarioActual, pictureBox13.Image);

                    MessageBox.Show("¡Foto Actualizada con exito!");
                }
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
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

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Manual_uso_usuario manual_Uso_Usuario = new Manual_uso_usuario();
            manual_Uso_Usuario.Show();
        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Manual_uso_tecnico manual_Uso_Tecnico = new Manual_uso_tecnico();
            manual_Uso_Tecnico.Show();
        }
    }
}
