using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Well_Fix_It_Forms.Conexion;

namespace Well_Fix_It_Forms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private void btn1_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtBox6.UseSystemPasswordChar = true;
            txtBoxConfirmarContraseña.UseSystemPasswordChar = true;
            radioButton1.Checked = true;
            textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
       

        private async void btn1_Click_1(object sender, EventArgs e)
        {
            string correoo = txtBox4.Text.Trim().ToLower();

            if (txtBox1.Text == ""|| txtBox2.Text == ""|| txtBox4.Text == ""|| txtBox5.Text == ""|| txtBox7.Text=="" || textBox1.Text == "" || textBox2.Text==""|| txtBox8.Text == "" || txtBox9.Text==""|| comboBox1.Text==""|| textBox3.Text==""|| txtBox6.Text == "" || txtBoxConfirmarContraseña.Text=="")
            {
                MessageBox.Show("Debes llenar todos los caampos para poder registrarte", "Datos incompletos ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox1.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo debe contener letras", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox2.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El apellido solo debe contener letras", "Apellido inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox1.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre del municipio solo debe contener letras", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!correoo.Contains("@"))
            {
                MessageBox.Show("El correo debe contener el símbolo @.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(correoo.Contains("@gmail") || correoo.Contains("@hotmail")))
            {
                MessageBox.Show("El correo debe ser de Gmail o Hotmail.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(correoo.EndsWith(".com", StringComparison.OrdinalIgnoreCase)||correoo.EndsWith(".org", StringComparison.OrdinalIgnoreCase)||correoo.EndsWith(".mx", StringComparison.OrdinalIgnoreCase)||correoo.EndsWith(".edu", StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("El correo debe terminar en .com, .org, .mx o .edu.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox5.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Los numeros telefónicos en MEXICO deben contener solo 10 dígitos", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox7.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre de la calle solo debe contener letras", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^\d{1,4}$"))
            {
                MessageBox.Show("Solo  permite un maximo de 4 números", "Número de Exterior", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre de la colonia solo debe contener letras", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox9.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("Entrecalles solo debe contener letras", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox8.Text, @"^\d{5}$"))
            {
                MessageBox.Show("El codigo postal en MEXICO deben contener solo 5 dígitos", "Codigo postal inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox1.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El municipio solo debe contener letras", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox6.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$"))
            {
                MessageBox.Show("Seguridad insuficiente:\n\n• Entre 8 y 20 caracteres.\n• Al menos una mayúscula y una minúscula.\n• Al menos un número y un símbolo.",
                                "Validación de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtBox6.Text != txtBoxConfirmarContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            


            string nombre, apellido, correo, telefono,calle,nomenclatura,colonia, entrecalles, codigopostal, municipio, estado, contraseña,confirmarcontraseña ;
                nombre = txtBox1.Text;
                apellido = txtBox2.Text;
                correo = txtBox4.Text;
                telefono = txtBox5.Text;
                calle = txtBox7.Text;
                nomenclatura = textBox1.Text;
                colonia = textBox2.Text;
                entrecalles = txtBox8.Text;
                codigopostal = txtBox9.Text;
                municipio = comboBox1.Text;
                estado = textBox3.Text;
                contraseña = txtBox6.Text;
                confirmarcontraseña = txtBoxConfirmarContraseña.Text;
           
                if (contraseña != confirmarcontraseña)
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                    return;
                }           
                 var (hash, salt) = PasswordHelper.HashPassword(contraseña);

            DialogResult resultado = MessageBox.Show("¿Deseas registrarte con esta información?", "Confirmar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    Conexion conn = new Conexion();
                    if (conn.RegistroUsuario(nombre, apellido, correo, telefono, calle, nomenclatura, colonia, codigopostal, entrecalles, municipio, estado, contraseña, hash, salt))
                    {
                        // 1. Mostrar y resetear la barra
                        progressBar1.Visible = true;
                        label12.Visible = true;
                        progressBar1.Value = 0;
                        btn1.Enabled = false; // Desactivar botón para evitar clics dobles

                        // 2. Simular el proceso de guardado (o llamar a tu base de datos)
                        for (int i = 0; i <= 100; i += 10)
                        {
                            progressBar1.Value = i;
                            label12.Text = $"Guardando Registro... {i}%";
                            // Simulamos una demora de red o procesamiento
                            await Task.Delay(200);
                        }                     
                        label12.Text = "Registro Guardado con Éxito!";
                        progressBar1.Value= 100;
                        

                        await Task.Delay(2000); // Pequeña pausa para mostrar el mensaje de éxito
                        progressBar1.Visible = false;
                        label12.Visible = false;
                        btn1.Enabled = true;

                        MessageBox.Show("Usuario registrado con exito", "Registro Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form6 form6 = new Form6();
                        form6.Show();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Código de error para violación de clave única
                    {
                        MessageBox.Show("El correo ya está registrado. Por favor, utiliza otro correo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al registrarte. Por favor, intenta nuevamente.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }



        }
        private void txtBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxConfirmarContraseña_TextChanged_1(object sender, EventArgs e)
        {

        }
        private int CalcularFuerza(string password)
        {
            int puntuacion = 0;
            if (string.IsNullOrEmpty(password)) return 0;

            // 1. Longitud (Damos puntos más rápido)
            if (password.Length >= 8) puntuacion++;
            if (password.Length >= 12) puntuacion++; // Con 12 ya tiene el máximo de puntos por largo

            // 2. Complejidad (1 punto por cada uno)
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-z]") &&
                System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]")) puntuacion++; // Mayúsculas y minúsculas

            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"\d")) puntuacion++; // Números

            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[^a-zA-Z0-9]")) puntuacion++; // Símbolos

            return puntuacion;
        }

        private void txtBox6_TextChanged(object sender, EventArgs e)
        {
            int fuerza = CalcularFuerza(txtBox6.Text); // Usando la función anterior (0 a 5)

            // 1. Ajustar el ancho del panel (suponiendo que el ancho máximo deseado es 200)
            // El ancho será: (fuerza actual / fuerza máxima) * ancho máximo
            panel2.Width = (fuerza * 40);

            // 2. Cambiar el color según la fuerza
            if (fuerza <= 2)
            {
                panel2.BackColor = Color.Red;
                label9.Text = "Contraseña Débil";
            }
            else if (fuerza <= 4)
            {
                panel2.BackColor = Color.Yellow; // El amarillo a veces no se lee bien
                label9.Text = "Contraseña Media";
            }
            else
            {
                panel2.BackColor = Color.LimeGreen;
                label9.Text = "Contraseña Fuerte";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtBox6.UseSystemPasswordChar = true; // oculta la contraseña
                txtBoxConfirmarContraseña.UseSystemPasswordChar = true; // Oculta la contraseña
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txtBox6.UseSystemPasswordChar = false; // oculta la contraseña
                txtBoxConfirmarContraseña.UseSystemPasswordChar = false; // Oculta la contraseña
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
