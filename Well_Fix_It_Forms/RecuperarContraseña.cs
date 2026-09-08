using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Well_Fix_It_Forms
{
    public partial class RecuperarContraseña : Form
    {
        public RecuperarContraseña()
        {
            InitializeComponent();
            this.ControlBox = true;   
            this.MinimizeBox = false; 
            this.MaximizeBox = false;
            this.ShowIcon = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text)|| string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos para validar tu identidad.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$"))
            {
                MessageBox.Show("Seguridad insuficiente:\n\n• Entre 8 y 20 caracteres.\n• Al menos una mayúscula y una minúscula.\n• Al menos 2 número y 2 símbolos.",
                                "Validación de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Capturar los datos
            string nombre = textBox1.Text.Trim();
            string apellidos = textBox2.Text.Trim();
            string correo = textBox3.Text.Trim();
            string telefono = textBox5.Text.Trim();
            string nuevaPass = textBox4.Text; // La contraseña nueva

            // 3. Llamar al método de la clase Conexión
            Conexion conn = new Conexion();

            // Usamos el método que creamos anteriormente
            bool exito = conn.RestablecerPasswordTecnico(nombre, apellidos,telefono, correo, nuevaPass);
            if (!exito)
            {
                exito = conn.RestablecerPasswordUsuario(nombre, apellidos,telefono, correo, nuevaPass);
            }

            // 4. Mostrar resultado
            if (exito)
            {
                MessageBox.Show("¡Contraseña actualizada con éxito!",
                                "Contraseña Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerramos la ventanita de recuperación
            }
            else
            {              
                MessageBox.Show("Los datos ingresados (Nombre,Apellidos,telefono,Correo) no coinciden con nuestros registros. Inténtalo de nuevo.", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void RecuperarContraseña_Load(object sender, EventArgs e)
        {
          
        }
    }
}
