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
    public partial class Manual_uso_tecnico_2 : Form
    {
        public Manual_uso_tecnico_2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manual_uso_tecnico_3 manual_uso_tecnico_3 = new Manual_uso_tecnico_3();
            manual_uso_tecnico_3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manual_uso_tecnico manual_uso_tecnico = new Manual_uso_tecnico();
            manual_uso_tecnico.Show();
        }
    }
}
