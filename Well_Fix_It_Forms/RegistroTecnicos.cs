using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Well_Fix_It_Forms.Conexion;

namespace Well_Fix_It_Forms
{
    public partial class RegistroTecnicos : Form
    {

        public RegistroTecnicos()
        {
            InitializeComponent();
           
        }
        
        private async void btn1_Click(object sender, EventArgs e)
        {
            string correoo = txtBox4.Text.Trim().ToLower();
            byte[] fotopersonal = null;

            if (txtBox1.Text=="" || txtBox2.Text==""||txtBox4.Text==""|| txtBox5.Text==""|| txtBox8.Text==""||textBox4.Text==""||textBox5.Text == ""||
                txtBox10.Text == "" ||txtBox9.Text==""|| comboBox1.Text == "" || comboBox3.Text == ""|| comboBox2.Text == ""||txtBox6.Text==""  ||txtBoxConfirmarContraseña.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos son obligatorios.","Campos Vacíos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox1.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo debe contener letras.", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox2.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El apellido solo debe contener letras.", "Apellido inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!(correoo.EndsWith(".com", StringComparison.OrdinalIgnoreCase) ||
                  correoo.EndsWith(".org", StringComparison.OrdinalIgnoreCase) ||
                  correoo.EndsWith(".mx", StringComparison.OrdinalIgnoreCase) ||
                  correoo.EndsWith(".edu", StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("El correo debe terminar en .com, .org, .mx o .edu.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox5.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Los numeros telefónicos en MEXICO deben contener solo 10 dígitos", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox8.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre de la calle solo debe contener letras ", "Nombre Invalido ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, @"^\d{1,4}$"))
            {
                MessageBox.Show("Solo  permite un maximo de 4 números", "Número de Exterior", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre de la colonia solo debe contener letras", "Nombre Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox10.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("Entrecalles solo debe contener letras ", "Nombre Invalido ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox9.Text, @"^\d{5}$"))
            {
                MessageBox.Show("El codigo postal en MEXICO deben contener solo 5 dígitos", "Codigo postal inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox1.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El municipio solo debe contener letras", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(comboBox4.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("Especialidad solo debe contener letras", "Nombre Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
            if (txtBox6.Text != txtBoxConfirmarContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBox6.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$"))
            {
                MessageBox.Show("Seguridad insuficiente:\n\n• Entre 8 y 20 caracteres.\n• Al menos una mayúscula y una minúscula.\n• Al menos un número y un símbolo.",
                                "Validación de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (fotoSeleccionada == false)
            {
                MessageBox.Show("¡Es obligatorio subir una foto!","Campo Obligatorio",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            using (MemoryStream ms = new MemoryStream())
            {
                  if (pictureBox1.Image != null)
                  {
                    pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fotopersonal = ms.ToArray();
                  }
            }
           
            string nombre, apellidos, correo, telefono, calle,nomenclatura, codigpostal,colonia, entrecalles, municipio, estado, especialidad, añosdeexperiencia, contraseña, genero;

                nombre = txtBox1.Text;
                apellidos = txtBox2.Text;
                correo = txtBox4.Text;
                telefono = txtBox5.Text;
                calle = txtBox8.Text;
                nomenclatura = textBox4.Text;
                colonia = textBox5.Text;
                entrecalles = txtBox10.Text;
                codigpostal = txtBox9.Text;
                municipio = comboBox1.Text;
                estado = textBox3.Text;
                especialidad = comboBox4.Text;           
                añosdeexperiencia = comboBox3.Text;
                genero = comboBox2.Text;
                contraseña = txtBox6.Text;
     
            var (hash, salt) = PasswordHelper.HashPassword(contraseña);

            DialogResult resultado = MessageBox.Show("¿Deseas registrarte con esta información?", "Confirmar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    Conexion conn = new Conexion();
                    if (conn.RegistroTecnico(nombre, apellidos, correo, telefono, calle, nomenclatura, colonia, entrecalles, codigpostal, municipio, estado, especialidad, añosdeexperiencia, genero, contraseña, hash, salt,fotopersonal))
                    {
                        // 1. Mostrar y resetear la barra
                        progressBar1.Visible = true;
                        label14.Visible = true;
                        progressBar1.Value = 0;
                        btn1.Enabled = false; // Desactivar botón para evitar clics dobles

                        // 2. Simular el proceso de guardado (o llamar a tu base de datos)
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
                        btn1.Enabled = true;

                        MessageBox.Show("Registro exitoso", "Registro Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBox1.Focus();
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
                        MessageBox.Show("Ocurrió un error al registrar el técnico. Por favor, intenta nuevamente.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    
                    }
                }
            }            
        }

        private void RegistroTecnicos_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
            txtBox6.UseSystemPasswordChar = true; // oculta la contraseña
            txtBoxConfirmarContraseña.UseSystemPasswordChar = true;
            // Siempre inicia oculto


            // RadioButton "Ocultar" marcado por defecto
            radioButton1.Checked = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void lbel4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }
        bool fotoSeleccionada = false;
        private void button3_Click_1(object sender, EventArgs e)
        {
           
            // 1. Abrimos el cuadro de diálogo de Windows
            OpenFileDialog buscarimagen = new OpenFileDialog();

            // 2. Filtramos para que solo acepte fotos reales
            buscarimagen.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (buscarimagen.ShowDialog() == DialogResult.OK)
            {
                // Obtener la extensión del archivo seleccionado
                string extension = System.IO.Path.GetExtension(buscarimagen.FileName).ToLower();

                // Validar si es una extensión permitida
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    pictureBox1.Image = Image.FromFile(buscarimagen.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    // Esta es la variable que mencionamos antes para el botón de Registrar
                    fotoSeleccionada = true;
                }
                else
                {
                    MessageBox.Show("El archivo seleccionado no es una imagen válida. Solo se permiten JPG y PNG.", "Error de formato");
                    fotoSeleccionada = false;
                }
            }
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
                label17.Text = "Contraseña Débil";
            }
            else if (fuerza <= 4)
            {
                panel2.BackColor = Color.Yellow; // El amarillo a veces no se lee bien
                label17.Text = "Contraseña Media";
            }
            else
            {
                panel2.BackColor = Color.LimeGreen;
                label17.Text = "Contraseña Fuerte";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}





