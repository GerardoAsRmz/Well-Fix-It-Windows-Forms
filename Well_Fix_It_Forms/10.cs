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
    public partial class _10 : Form
    {
        public _10()
        {
            InitializeComponent();
        }

        private void _10_Load(object sender, EventArgs e)
        {
            dtp1.Enabled = false;
            dateTimePicker1.Enabled = false;
            
            cargarData();
            cargarHistorial();
        }

        private void cargarData()
        {
            Conexion conn = new Conexion();
            DataTable dtMostrarSolicitudServicios = new DataTable();
            dtMostrarSolicitudServicios = conn.MostrarSolicitudServicios();
            dGV1.DataSource = dtMostrarSolicitudServicios;
           
            DataTable dtMostrarSolicitudServiciosPorTecnico = new DataTable();
            dtMostrarSolicitudServiciosPorTecnico = conn.MostrarSolicitudServiciosPorTecnico(TecnicoSesion.IdTecnico);
            dGV2.DataSource = dtMostrarSolicitudServiciosPorTecnico;
        }

        private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dGV1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 2. Obtenemos el valor de la celda del ID de la fila seleccionada
                // Cambia "id_Solicitud_Servicios" por el nombre exacto de tu columna si es distinto
                var idSeleccionado = dGV1.Rows[e.RowIndex].Cells["id_Solicitud_Servicios"].Value;

                if (idSeleccionado != null)
                {
                    // 3. Lo ponemos en el textBox1 para que el técnico sepa qué va a agendar
                    textBox1.Text = idSeleccionado.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validamos que el cuadro de texto no esté vacío para que no truene el programa
            if (string.IsNullOrWhiteSpace(textBox34.Text))
            {
                MessageBox.Show("Por favor, selecciona un pedido de la lista de agendados primero.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            // Supongamos que tienes la fecha del servicio en el DataGridView
            DateTime fechaServicio = dateTimePicker1.Value;
            DateTime hoy = DateTime.Now;

            // Calculamos la diferencia
            TimeSpan diferencia = fechaServicio - hoy;

            if (diferencia.TotalDays < 2)
            {
                MessageBox.Show("Aviso de Cancelación:\n\n" +
                                "Las políticas del negocio indican que la cancelación debe hacerse " +
                                "con al menos 2 días de anticipación.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            DialogResult result = MessageBox.Show("¿Quieres cancelar esta solicitud de servicio?   ", "Cancelar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(textBox34.Text);
                Conexion coon = new Conexion();
                coon.CancelarPedido(id);
                cargarData();
                textBox34.Clear();
                LimpiarLosCuadros(this.Controls); 
                MessageBox.Show("Solicitud cancelada con exito", "Solicitud Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        // Este método va afuera de los botones, pero dentro de la clase del Formulario
        private void LimpiarLosCuadros(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                // Si el control es un cuadro de texto, lo vaciamos
                if (c is System.Windows.Forms.TextBox)
                {
                    c.Text = "";
                }

                // Si el control tiene "hijos" (como un Panel o GroupBox), buscamos adentro
                if (c.HasChildren)
                {
                    LimpiarLosCuadros(c.Controls);
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { 
            if(textBox1.Text =="")
            {
                MessageBox.Show("Selecciona un pedido en la pantalla ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
         
            int id = Convert.ToInt32(textBox1.Text);
         

            DialogResult result = MessageBox.Show("¿Quieres agendar esta solicitud de servicio? " , "Agendar servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Conexion coon = new Conexion();
                coon.AgendarServicio(id, TecnicoSesion.IdTecnico, 200.00);
                cargarData();
                textBox1 .Clear();
                MessageBox.Show("Solicitud agendado con exito", "Solicitud Agendada",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void dGV1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dGV1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
            if(textBox1.Text=="")
            {
              MessageBox.Show("No hay solicitudes por el momento","Solicitudes vacias ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;   
            }          
                int id;
                id = Convert.ToInt32(textBox1.Text);

                Conexion coon = new Conexion();
                DataTable dt = new DataTable();
                dt = coon.BuscarPorId(id);
                dGV1.DataSource = dt;
                return;      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void dGV2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 2. Obtenemos el valor de la celda del ID de la fila seleccionada
                // Cambia "id_Solicitud_Servicios" por el nombre exacto de tu columna si es distinto
                var idSeleccionado = dGV2.Rows[e.RowIndex].Cells["id_Solicitud_Servicios"].Value;

                if (idSeleccionado != null)
                {
                    // 3. Lo ponemos en el textBox1 para que el técnico sepa qué va a agendar
                    textBox34.Text = idSeleccionado.ToString();
                }
            }
        }
        public void cargarHistorial()
        {
            // 1. Instanciamos tu clase de conexión
            Conexion coon = new Conexion();

            // 2. Llamamos al método que arreglamos (HistorialFinalizadoTecnico)
            // Le pasamos el ID del técnico que inició sesión
            DataTable datosHistorial = coon.HistorialFinalizadoTecnico(TecnicoSesion.IdTecnico);

            // 3. Conectamos los datos con el nuevo DataGridView
            dGV3.DataSource = datosHistorial;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            DateTime hoy = DateTime.Now.Date;

            
            if (textBox34.Text == "")
            {
                MessageBox.Show("Selecciona un pedido en la pantalla ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(fechaSeleccionada != hoy)
            {
                MessageBox.Show("Los pedidos agendados solo se pueden finalizar despues de la revicion ó reparacion ","Finalizar solo el dia agendado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            int id = Convert.ToInt32(textBox34.Text);                  
            DialogResult result = MessageBox.Show("¿Quieres Finalizar esta solicitud de servicio?   ", "Finalizar Servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Conexion coon = new Conexion();
                coon.FinalizarServicio(id);
                this.Hide();
                Reseña ventana = new Reseña(id, "Tecnico");
                ventana.ShowDialog(); // Esto obliga a calificar antes de seguir
               
                _10 _10 = new _10();                    
                _10.Show();

                cargarData();
                cargarHistorial();
                LimpiarLosCuadros(this.Controls);

                MessageBox.Show("Solicitud Finalizada con exito", "Servicio Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dGV1.Rows[e.RowIndex];

                // 2. Llenar el ID para que el botón de agendar sepa cuál es
                textBox1.Text = fila.Cells["id_Solicitud_Servicios"].Value.ToString();

                // 3. LLENADO AUTOMÁTICO DE DATOS DEL CLIENTE (Lado derecho de tu diseño)
                txtBox5.Text = fila.Cells["Cliente"].Value.ToString();
                textBox23.Text = fila.Cells["Calle"].Value.ToString();
                textBox22.Text = fila.Cells["Num Ext"].Value.ToString();
                textBox21.Text = fila.Cells["Colonia"].Value.ToString();

                textBox20.Text = fila.Cells["Entre Calles"].Value.ToString();
                textBox26.Text = fila.Cells["CP"].Value.ToString();

                textBox7.Text = fila.Cells["Municipio"].Value.ToString();
                textBox25.Text = fila.Cells["Teléfono"].Value.ToString();
                textBox24.Text = fila.Cells["Correo"].Value.ToString();

                // 4. LLENADO AUTOMÁTICO DE DATOS TÉCNICOS (Lado izquierdo de tu diseño)
                textBox2.Text = fila.Cells["Equipo"].Value.ToString();
                textBox4.Text = fila.Cells["Servicio"].Value.ToString();
                textBox3.Text = fila.Cells["Falla"].Value.ToString();
                textBox5.Text = fila.Cells["Antigüedad"].Value.ToString();
                textBox6.Text = fila.Cells["Pago"].Value.ToString();
                dtp1.Text = fila.Cells["Fecha Visita"].Value.ToString();
                textBox8.Text = fila.Cells["Hora Visita"].Value.ToString();
                textBox9.Text = fila.Cells["Marca"].Value.ToString();
            }
        }

        private void dGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dGV2.Rows[e.RowIndex];
                if (fila.Cells["id_Solicitud_Servicios"].Value != null && fila.Cells["id_Solicitud_Servicios"].Value != DBNull.Value)
                {
                    int id = Convert.ToInt32(fila.Cells["id_Solicitud_Servicios"].Value);
                    textBox34.Text = id.ToString();

                    // 2. Buscamos los detalles (Esto ya trae los datos de Usuarios y Solicitud juntos)
                    Conexion coon = new Conexion();
                    DataTable dt = coon.BuscarDetallesCompletos(id);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow datos = dt.Rows[0];

                        // 3. LLENADO AUTOMÁTICO DE DATOS DEL CLIENTE (Lado derecho de tu diseño)
                        textBox18.Text = datos["nombre"].ToString() + " " + datos["apellido"].ToString();
                        textBox17.Text = datos["calle"].ToString();
                        textBox16.Text = datos["nomenclatura"].ToString();
                        textBox15.Text = datos["entrecalles"].ToString();
                        textBox14.Text = datos["colonia"].ToString();

                        textBox13.Text = datos["municipio"].ToString();
                        textBox12.Text = datos["codigopostal"].ToString();
                        textBox11.Text = datos["telefono"].ToString();
                        textBox10.Text = datos["correo"].ToString();

                        // 4. LLENADO DE DATOS TÉCNICOS
                        textBox33.Text = datos["Categoria"].ToString();
                        textBox32.Text = datos["descripcionproblema"].ToString();
                        textBox31.Text = datos["tipodeservicio"].ToString();
                        textBox30.Text = datos["antiguedadequipo"].ToString();
                        textBox29.Text = datos["tipopago"].ToString();
                        dateTimePicker1.Text = datos["fechasolicitud"].ToString();
                        textBox28.Text = datos["horavisita"].ToString();
                        textBox27.Text = datos["marcaequipo"].ToString();         
                    }
                    else
                    {
                        MessageBox.Show("el programa detecto que la fila esta vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimpiarLosCuadros(this.Controls);
                    }
                }  
            }
        }
        private void dGV2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dGV1_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }
        private void dGV3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dGV3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
