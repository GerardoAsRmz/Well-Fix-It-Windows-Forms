using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Well_Fix_It_Forms
{
    public partial class Form4 : Form
    {
        private int intentos = 0;
        System.Windows.Forms.Timer timerBloqueo = new System.Windows.Forms.Timer();

        int segundosRestantes = 30;
        System.Windows.Forms.Timer timerVisual = new System.Windows.Forms.Timer();
        public Form4()
        {
            InitializeComponent();
            timerBloqueo.Interval = 60000; // 30 segundos
            timerBloqueo.Tick += TimerBloqueo_Tick; // Asignamos la función de desbloqueo

            timerVisual.Interval = 1000; // 1000ms = 1 segundo
            timerVisual.Tick += TimerVisual_Tick;
        }

        private void textGuardarPassword_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textConfirmarPassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void txtBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void TimerBloqueo_Tick(object sender, EventArgs e)
        {
            timerBloqueo.Stop(); // Detiene el reloj
            btn1.Enabled = true; // Vuelve a habilitar el botón
            MessageBox.Show("El boton esta disponible de nuevo puedes volver a intentarlo.","",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void TimerVisual_Tick(object sender, EventArgs e)
        {
            segundosRestantes--; // Resta 1 al tiempo
            label1.Text = "Puedes volver a intentarlo en: " + segundosRestantes + "s";

            if (segundosRestantes <= 0)
            {
                timerVisual.Stop(); // Se detiene cuando llega a cero
                label1.Visible = false;
            }
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            if (intentos >= 3)
            {
                MessageBox.Show("Acceso bloqueado por seguridad. Demasiados intentos.");
                btn1.Enabled = false; // Opcional: apaga el botón
                return;
            }

            if (textBox1.Text == "" || txtGuardarPassword.Text == "" )
            {
                MessageBox.Show("Porfabor llena los campos para poder iniciar sesion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
                string correo,contraseña;
               
                correo = textBox1.Text;
                contraseña = txtGuardarPassword.Text;
             
                Conexion conn = new Conexion();
                DataTable dt = new DataTable();
                dt = conn.InicioSesionUsuario( correo,  contraseña);
                if (dt.Rows.Count > 0)
                {                               
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();               
                }

                else
                {
                    dt = conn.InicioSesionTecnico(correo, contraseña);                  
                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        Form7 form7 = new Form7();
                        form7.Show();
   
                    }                   
                    else
                    {
                         intentos++;      
                         int restantes = 3 - intentos;
                        if (intentos == 1)
                        {
                            MessageBox.Show($"Datos incorrectos. Te quedan {restantes} intentos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                        }

                        if (intentos == 2) // AQUÍ LA LÓGICA ESPECIAL
                        {
                           DialogResult result = MessageBox.Show("Datos incorrectos. Parece que tienes problemas para entrar. ¿Deseas restablecer tu contraseña?","¿OLVIDASTE TU CONTRASEÑA?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                              MessageBox.Show("Para poder cambiar tu contraseña deberas ingresar los sguientes datos: Nombre/s , Apellidos/s y correo Electronico con el que te registraste para comprobar que eres tu realmente","Cambiar Contraseña",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            
                              RecuperarContraseña recuperarContraseña = new RecuperarContraseña();
                              recuperarContraseña.ShowDialog();
                              return; // Salimos para que el usuario no siga intentando aquí
                            }
                        }
                        if (restantes > 0)
                        {
                           MessageBox.Show($"Datos incorrectos. Te quedan {restantes} intentos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                          MessageBox.Show("Has agotado tus intentos. El botón se bloqueará por 60 segundos.", "BLOQUEO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                          textBox1.Clear();           // Limpia el usuario/correo
                          txtGuardarPassword.Clear();                         
                          btn1.Enabled = false;
                          intentos = 0;           // Reiniciamos el contador para la próxima vez
                          timerBloqueo.Start();   // Iniciamos la cuenta regresiva de 30s
                          segundosRestantes = 60; // Reiniciamos el número a 30                     
                          label1.Visible = true;
                          timerVisual.Start(); // Iniciamos el reloj que resta de 1 en 1
                        }
                    }
                }
                
        }
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void txtBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtConfirmarPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGuardarPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtGuardarPassword.UseSystemPasswordChar = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txtGuardarPassword.UseSystemPasswordChar = false;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // 4. Cargamos los textos que tradujiste en el paso anterior
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(this.GetType());

            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name);

                // Si tienes cosas dentro de un GroupBox o Panel
                if (c is GroupBox || c is Panel)
                {
                    foreach (Control hijo in c.Controls)
                    {
                        resources.ApplyResources(hijo, hijo.Name);
                    }
                }
            }
            txtGuardarPassword.UseSystemPasswordChar = true;

            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Para cambiar tu contraseña, se pedira que llenes unos datos personales, sigue las instrucciones para verificar tu identidad y actualizar tu contraseña."
                ,"Actualizar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RecuperarContraseña recuperarContraseña = new RecuperarContraseña();
            recuperarContraseña.ShowDialog() ;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
