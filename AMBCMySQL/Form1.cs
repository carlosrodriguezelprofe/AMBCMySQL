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
    public partial class Form1 : Form
    {

        MySQL conector = new MySQL();

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string[] mensaje = new string[2];

            mensaje = conector.buscaRegistro(Convert.ToInt32(txtDNIB.Text));

            txtAPEB.Text = mensaje[0];

            txtNOMB.Text = mensaje[1];

            if((mensaje[0]!= "no se encontró el DNI buscado") && (mensaje[0] != "error al buscar los datos"))
            {

                DialogResult opcion;

                opcion = MessageBox.Show("borrar registro seleccionado?","Ventana",MessageBoxButtons.YesNo);

                if(opcion==DialogResult.Yes)
                {

                    mensaje[0] = conector.bajaRegistro(Convert.ToInt32(txtDNIB.Text));

                    MessageBox.Show(mensaje[0]);

                }
    
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string mensaje = "";
            
            mensaje = conector.altaRegistro(Convert.ToInt32(txtDNIA.Text),txtAPEA.Text,txtNOMA.Text);

            MessageBox.Show(mensaje);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string mensaje = "";

            mensaje = conector.modificarRegistro(Convert.ToInt32(txtDNIM.Text), txtAPEM.Text, txtNOMM.Text);

            MessageBox.Show(mensaje);

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            Grilla grilla = new Grilla();

            grilla.Show();


        }
    }
}
