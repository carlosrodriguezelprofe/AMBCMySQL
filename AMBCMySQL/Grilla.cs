using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMBCMySQL
{
    public partial class Grilla : Form
    {

        MySQL conectorDG = new MySQL();

        public Grilla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            conectorDG.consultarTabla(this.dgRegistros,1);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            mensaje = conectorDG.actualizarTabla(Convert.ToInt32(txtDNI.Text), txtAPE.Text, txtNOM.Text);

            MessageBox.Show(mensaje);

        }

        private void dgRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int seleccionado = dgRegistros.CurrentRow.Index;

            txtDNI.Text = dgRegistros.Rows[seleccionado].Cells[0].Value.ToString();

            txtAPE.Text = dgRegistros.Rows[seleccionado].Cells[1].Value.ToString();

            txtNOM.Text = dgRegistros.Rows[seleccionado].Cells[2].Value.ToString();

        }

        private void dgRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
