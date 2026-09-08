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
    public partial class Manual_uso_usuario : Form
    {
        public Manual_uso_usuario()
        {
            InitializeComponent();
        }

        private void Manual_uso_usuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manual_uso_usuario_2 manual_uso_usuario_2 = new Manual_uso_usuario_2();
            manual_uso_usuario_2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Solo ocultamos si hay una sesión válida a donde volver
            if (TecnicoSesion.IdTecnico != 0)
            {
                this.Hide();
                Form7 f7 = new Form7();
                f7.Show();
            }
            else if (UsuarioSesion.IdUsuario != 0)
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("No hay sesión activa para regresar.");
            }
        }
    }
}
