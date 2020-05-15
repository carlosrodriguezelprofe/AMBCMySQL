using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMBCMySQL
{
    class MySQL
    {

        public string altaRegistro(int dni, string apellido, string nombre)
        {

            string retorno = "";

            try
            {

                string MyConnection2 = "datasource=localhost;database=abm;port=3307;username=root;password=usbw";

                string Query = "INSERT INTO registros(dni, apellido, nombre) VALUES(" + dni + ",'" + apellido + "','" + nombre + "')";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MyConn2.Open();

                MyCommand2.ExecuteNonQuery();

                retorno = "Registros agregados";

                MyConn2.Close();

            }
            catch (Exception ex)
            {

                retorno = "error del cargar datos";

            }

            return retorno;


        }

        public string modificarRegistro(int dni, string apellido, string nombre)
        {

            string retorno = "";

            try
            {

                int cantidad = 0;

                string MyConnection2 = "datasource=localhost;database=abm;port=3307;username=root;password=usbw";

                string Query = "UPDATE registros SET apellido='" + apellido + "', nombre='" + nombre + "' WHERE dni=" + dni + ";";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MyConn2.Open();

                cantidad = MyCommand2.ExecuteNonQuery();

                if (cantidad > 0)
                {

                    retorno = "Registro actualizado";

                }
                else
                {

                    retorno = "No se encontró el DNI";

                }


                MyConn2.Close();

            }
            catch (Exception ex)
            {

                retorno = "error al modificar datos";

            }

            return retorno;

        }



        public string[] buscaRegistro(int dni)
        {

            string[] retorno = new string[2];

            try
            {

                string MyConnection2 = "datasource=localhost;database=abm;port=3307;username=root;password=usbw";

                string Query = "SELECT apellido, nombre FROM registros WHERE dni=" + dni + ";";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MyConn2.Open();

                MySqlDataReader registro = MyCommand2.ExecuteReader();

                if (registro.Read())
                {

                    retorno[0] = registro["apellido"].ToString();
                    retorno[1] = registro["nombre"].ToString();


                }
                else
                {

                    retorno[0] = "no se encontró el DNI buscado";

                }


                MyConn2.Close();

            }
            catch (Exception ex)
            {

                retorno[0] = "error al buscar los datos";

            }

            return retorno;

        }




        public string bajaRegistro(int dni)
        {

            int cantidad = 0;

            string retorno = "";

            try
            {

                string MyConnection2 = "datasource=localhost;database=abm;port=3307;username=root;password=usbw";

                string Query = "DELETE FROM registros WHERE dni=" + dni + ";";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MyConn2.Open();

                cantidad = MyCommand2.ExecuteNonQuery();

                if (cantidad > 0)
                {

                    retorno = "Registro borrado";

                }
                else
                {

                    retorno = "No se encontró el DNI";

                }


                MyConn2.Close();

            }
            catch (Exception ex)
            {

                retorno = "error al borrar los datos";

            }

            return retorno;

        }


        public void consultarTabla(DataGridView dgv, int opcion)
        {

            string MyConnectionDG = "datasource=localhost;database=abm;port=3307;username=root;password=usbw";

            string Query = "SELECT * FROM registros;";

            MySqlConnection MyConnDG = new MySqlConnection(MyConnectionDG);

            MyConnDG.Open();

            MySqlCommand MyCommandDG = new MySqlCommand(Query, MyConnDG);

            MySqlDataAdapter da = new MySqlDataAdapter(MyCommandDG);


            if (opcion == 1)
            {
                //Opcion1:
                //Aqui estamos mostrando los datos mediante un DataTable

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgv.DataSource = dt;


            }

            if (opcion == 2)
            {
                //Opcion 2:
                //Aqui mediante un DataSet  

                DataSet ds = new DataSet();

                da.Fill(ds);

                dgv.DataSource = ds.Tables[0];


            }

            MyConnDG.Close();

        }



        public string actualizarTabla(int dni, string apellido, string nombre)
        {

            int cantidad = 0;
            string retorno;

            try
            {
                string MyConnection3 = "datasource=localhost;database=abm;port=3307;username=root;password=usbw";

                string Query = "UPDATE registros SET apellido='" + apellido + "', nombre='" + nombre + "' WHERE dni=" + dni + ";";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection3);

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

                MyConn2.Open();

                cantidad = MyCommand2.ExecuteNonQuery();

                if (cantidad > 0)
                {

                    retorno = "Registro actualizado";

                }
                else
                {

                    retorno = "No se encontró el DNI";

                }

                MyConn2.Close();

            }
            catch
            {

                retorno = "Error al modificar los datos";

                

            }

            return retorno;



        }

    }

}
