using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pos_equipo
{
    public partial class Form3 : Form
    {
        bool pagocompleto = false;
        public Form3()
        {
            InitializeComponent();
            textBox2.Focus();
            textBox1.Text = venta.total.ToString();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                double Total = Double.Parse(textBox1.Text);
                double pagado = Double.Parse(textBox2.Text);
                if (pagado == Total) 
                {
                    pagocompleto = true;
                    textBox3.Text = "0.00";
                }
                else
                if (pagado > Total)
                {
                    double cambio = pagado - Total;
                    textBox3.Text = cambio.ToString();
                    pagocompleto = true;
                } 
                else
                {
                    MessageBox.Show("Pago incompleto.");
                    pagocompleto = false;
                }

            } else 
            
            if (e.KeyCode == Keys.F2)
            {
                this.Hide();
            } else 
            
            if (e.KeyCode == Keys.F5)
            {
                if (pagocompleto == true)
                {
                    venta.venta_realizada = true;
                    MessageBox.Show("Gracias por su compra!.");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Pago incompleto.");
                }
            }
        }
    }
}
