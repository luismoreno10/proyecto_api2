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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                DataTable dt = new DataTable();
                String server = "127.0.0.1";
                String user = "root";
                String database = "punto_de_venta";
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT ventas_detalle.id_producto, nombre_producto, COUNT(ventas_detalle.id_producto) as cantidad FROM productos INNER JOIN ventas_detalle USING (id_producto) GROUP BY ventas_detalle.id_producto HAVING cantidad = ( SELECT COUNT(ventas_detalle.id_producto) FROM ventas_detalle INNER JOIN productos USING (id_producto) GROUP BY ventas_detalle.id_producto ORDER BY COUNT(ventas_detalle.id_producto) DESC LIMIT 1) ORDER BY cantidad;"; 
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
                    label_error.Text ="Data not found";
                }

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        public void productoMenosVendido()
        {
            try
            {
                DataTable dt = new DataTable();
                String server = "127.0.0.1";
                String user = "root";
                String database = "punto_de_venta";
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT ventas_detalle.id_producto, nombre_producto, COUNT(ventas_detalle.id_producto) as cantidad FROM productos INNER JOIN ventas_detalle USING (id_producto) GROUP BY ventas_detalle.id_producto HAVING cantidad = ( SELECT COUNT(ventas_detalle.id_producto) FROM ventas_detalle INNER JOIN productos USING (id_producto) GROUP BY ventas_detalle.id_producto ORDER BY COUNT(ventas_detalle.id_producto) LIMIT 1) ORDER BY cantidad;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
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
                DataTable dt = new DataTable();
                String server = "127.0.0.1";
                String user = "root";
                String database = "punto_de_venta";
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT nombre_usuario, apellido_usuario , COUNT(id_usuario) AS numero_ventas FROM `usuarios` INNER JOIN ventas ON id_usuario = operadorVenta WHERE permisosUsuario = 1 GROUP BY id_usuario HAVING numero_ventas = ( SELECT COUNT(ventas.operadorVenta) FROM ventas INNER JOIN usuarios ON id_usuario = operadorVenta GROUP BY ventas.operadorVenta ORDER BY COUNT(ventas.operadorVenta) DESC LIMIT 1) ORDER BY numero_ventas;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
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
                DataTable dt = new DataTable();
                String server = "127.0.0.1";
                String user = "root";
                String database = "punto_de_venta";
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "SELECT nombre_usuario, apellido_usuario , COUNT(id_usuario) AS numero_ventas FROM `usuarios` INNER JOIN ventas ON id_usuario = operadorVenta WHERE permisosUsuario = 1 GROUP BY id_usuario HAVING numero_ventas = ( SELECT COUNT(ventas.operadorVenta) FROM ventas INNER JOIN usuarios ON id_usuario = operadorVenta GROUP BY ventas.operadorVenta ORDER BY COUNT(ventas.operadorVenta) ASC LIMIT 1) ORDER BY numero_ventas;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
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
            String date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            try
            {
                DataTable dt = new DataTable();
                String server = "127.0.0.1";
                String user = "root";
                String database = "punto_de_venta";
                MySqlConnection mySqlConnection =
                    new MySqlConnection("server=" + server + "; user=" + user + "; database=" + database + "; SSL mode=none");
                mySqlConnection.Open();
                String query = "select * from ventas";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                dt.Load(mySqlDataReader);
                if (dt.Rows.Count > 0)
                {
                    tabla_reportes.DataSource = dt;
                }
                else
                {
                    label_error.Text = "Data not found";
                }

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
