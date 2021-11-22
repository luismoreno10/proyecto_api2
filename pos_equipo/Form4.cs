using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pos_equipo
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            panel2.Visible = false;
        }
        private String server = "127.0.0.1";
        private String user = "root";
        private String database = "punto_de_venta";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_error.Visible = false;
            panel2.Visible = false;
            tabla_reportes.DataSource = null;
            if (comboBox1.SelectedIndex.ToString() == "0") //Producto + vendido
            {
                productoMasVendido();
            } else if (comboBox1.SelectedIndex.ToString() == "1") //Producto - vendido
            {
                productoMenosVendido();
            } else if (comboBox1.SelectedIndex.ToString() == "2") // Vendedor con mas ventas
            {
                VendedorConMasVentas();
            } else if (comboBox1.SelectedIndex.ToString() == "3") // Vendedor con menos ventas
            {
                VendedorConMenosVentas();
            } else if (comboBox1.SelectedIndex.ToString() == "4") // Ventas por dia
            {
                panel2.Visible = true; //checar metodo dateTimePicker1_ValueChanged
            }

        }

        public void productoMasVendido()
        {
            try
            {
                //label_error.Visible = false;
                DataTable dt = new DataTable();
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT nombre_producto AS Producto, COUNT(ventas_detalle.id_producto) AS Cantidad FROM productos INNER JOIN ventas_detalle USING (id_producto) GROUP BY ventas_detalle.id_producto HAVING cantidad = ( SELECT COUNT(ventas_detalle.id_producto) FROM ventas_detalle INNER JOIN productos USING (id_producto) GROUP BY ventas_detalle.id_producto ORDER BY COUNT(ventas_detalle.id_producto) DESC LIMIT 1) ORDER BY cantidad;"; 
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
                    label_error.Visible = true;
                    label_error.Text ="Data not found";
                }

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                    label_error.Visible = true;
                MessageBox.Show(err.ToString());
            }

        }

        public void productoMenosVendido()
        {
            try
            {
                //label_error.Visible = false;
                DataTable dt = new DataTable();
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT nombre_producto, COUNT(ventas_detalle.id_producto) as cantidad FROM productos INNER JOIN ventas_detalle USING (id_producto) GROUP BY ventas_detalle.id_producto HAVING cantidad = ( SELECT COUNT(ventas_detalle.id_producto) FROM ventas_detalle INNER JOIN productos USING (id_producto) GROUP BY ventas_detalle.id_producto ORDER BY COUNT(ventas_detalle.id_producto) LIMIT 1) ORDER BY cantidad;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
                    label_error.Visible = true;
                    label_error.Text = "Data not found";
                }

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }  //OK

        public void VendedorConMasVentas()
        {
            try
            {
                //label_error.Visible = false;
                DataTable dt = new DataTable();
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT CONCAT(nombre_usuario, ' ', apellido_usuario) as nombre, COUNT(id_usuario) AS ventas_realizadas FROM `usuarios` INNER JOIN ventas ON id_usuario = operadorVenta GROUP BY id_usuario HAVING ventas_realizadas = ( SELECT COUNT(ventas.operadorVenta) FROM ventas INNER JOIN usuarios ON id_usuario = operadorVenta GROUP BY ventas.operadorVenta ORDER BY COUNT(ventas.operadorVenta) DESC LIMIT 1) ORDER BY ventas_realizadas;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
                    label_error.Visible = true;
                    label_error.Text = "Data not found";
                }

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        } //OK

        public void VendedorConMenosVentas()
        {
            try
            {
                //label_error.Visible = false;
                DataTable dt = new DataTable();
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT CONCAT(nombre_usuario, ' ', apellido_usuario) as nombre, COUNT(id_usuario) AS ventas_realizadas FROM `usuarios` INNER JOIN ventas ON id_usuario = operadorVenta GROUP BY id_usuario HAVING ventas_realizadas = ( SELECT COUNT(ventas.operadorVenta) FROM ventas INNER JOIN usuarios ON id_usuario = operadorVenta GROUP BY ventas.operadorVenta ORDER BY COUNT(ventas.operadorVenta) ASC LIMIT 1) ORDER BY ventas_realizadas";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
                    label_error.Visible = true;
                    label_error.Text = "Data not found";

                }

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        } //OK 

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label_error.Visible = false;
            String date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            try
            {
                DataTable dt = new DataTable();
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT fechaventa AS fecha, horaventa AS hora, CONCAT(nombre_usuario,' ',apellido_usuario) AS nombre, nombre_producto AS producto, cantidad, precio_producto AS precio, (cantidad*precio_producto) AS total FROM ((ventas INNER JOIN ventas_detalle ON ventas.idventa=ventas_detalle.id_venta) INNER JOIN usuarios on operadorVenta=id_usuario) INNER JOIN productos ON ventas_detalle.id_producto=productos.id_producto WHERE fechaventa='"+date+"' ORDER BY idventa";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
                    label_error.Visible = true;
                    label_error.Text = "Data not found";
                    tabla_reportes.DataSource = null;
                }

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Form1 ventana_inicio = new Form1();
                ventana_inicio.Show();
                this.Hide();
            } 
            else if(e.KeyCode== Keys.F7)
            {
                Form2 ventana_pos = new Form2();
                this.Hide();
                ventana_pos.Show();
            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 ventana_inicio = new Form1();
            ventana_inicio.Show();
            this.Hide();
        }
    }
}
