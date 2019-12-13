using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Final
{
    public class BdComun
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public void ObtenerConexion()
        {
            string connectionString;

            server = "localhost";
            database = "farmacias";
            uid = "root";
            password = "";

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public bool AbrirConexion()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexion Exitosa");
                return true;
            }

            catch (MySqlException ex) { Console.WriteLine("Error al abrir conexion [" + ex.Number + "]:" + ex.Message); return false; }
        }

        public bool CerraConexion()
        {
            try { connection.Close(); Console.WriteLine("Desconexion Exitosa"); return true; }
            catch (MySqlException ex) { Console.WriteLine("Error al cerrar conexion [" + ex.Number + "]:" + ex.Message); return false; }
        }

        public List<string> Consulta(int rut)
        {
            List<string> datos = null;

            {
                string query = "SELECT * FROM clientes where rut=@rut";
                //   MessageBox.Show("Valor del Rut:" + rut.ToString());
                MySqlCommand mycmd = new MySqlCommand(query, connection);
                mycmd.Parameters.AddWithValue("@rut", rut);
                MySqlDataReader myreader = mycmd.ExecuteReader();
                //  myreader.Read();
                if (myreader.Read())
                {
                    datos = new List<string>();
                    datos.Add(myreader["nombre"].ToString());
                    datos.Add(myreader["apellido"].ToString());
                    datos.Add(myreader["direccion"].ToString());
                    return datos;
                }
            }
            return datos;

        }


        public void Agregar(int rut, List<string> datosdos)
        {
            List<string> datos = datosdos;
            this.CerraConexion();
            string query = "SELECT * FROM clientes where rut=@rut";
            if (this.AbrirConexion() == true)
            {
                {

                    MySqlCommand mycmd = new MySqlCommand(query, connection);
                    mycmd.Parameters.AddWithValue("@rut", rut);
                    MySqlDataReader myreader = mycmd.ExecuteReader();
                    if (myreader.Read())
                    {

                        this.CerraConexion();
                    }
                    else
                    {
                        this.CerraConexion();
                        query = "INSERT INTO clientes(rut,nombre,apellido,direccion) VALUES (@rut,@nombre,@apellido,@direccion)";
                        MySqlCommand mycmdi = new MySqlCommand(query, connection);
                        mycmdi.Parameters.AddWithValue("@rut", rut);
                        mycmdi.Parameters.AddWithValue("@nombre", datos[0]);
                        mycmdi.Parameters.AddWithValue("@apellido", datos[1]);
                        mycmdi.Parameters.AddWithValue("@direccion", datos[2]);
                        this.AbrirConexion();
                        mycmdi.ExecuteNonQuery();

                    }
                }
            }

        }


        public void Actualizar(int rut, List<string> datosdos)
        {
            List<string> datos = datosdos;
            this.CerraConexion();
            string query = "SELECT * FROM clientes WHERE rut=@rut";
            if (this.AbrirConexion() == true)
            {
                MySqlCommand mycmd = new MySqlCommand(query, connection);
                mycmd.Parameters.AddWithValue("@rut", rut);
                MySqlDataReader myreader = mycmd.ExecuteReader();
                if (!myreader.Read())
                {

                    this.CerraConexion();
                }
                else
                {
                    this.CerraConexion();
                    query = "UPDATE clientes SET  nombre = @nombre,apellido=@apellido,direccion=@direccion " +
                        "WHERE rut = @rut";
                    MySqlCommand mycmdi = new MySqlCommand(query, connection);
                    mycmdi.Parameters.AddWithValue("@rut", rut);
                    mycmdi.Parameters.AddWithValue("@nombre", datos[0]);
                    mycmdi.Parameters.AddWithValue("@apellido", datos[1]);
                    mycmdi.Parameters.AddWithValue("@direccion", datos[2]);
                    this.AbrirConexion();
                    mycmdi.ExecuteNonQuery();

                }
            }

        }


        public void Borrar(int rut)
        {
            this.CerraConexion();
            string query = "SELECT * FROM clientes WHERE rut=@rut";
            if (this.AbrirConexion() == true)
            {
                MySqlCommand mycmd = new MySqlCommand(query, connection);
                mycmd.Parameters.AddWithValue("@rut", rut);
                MySqlDataReader myreader = mycmd.ExecuteReader();
                if (!myreader.Read())
                {
                    this.CerraConexion();
                }
                else
                {
                    this.CerraConexion();
                    query = "DELETE FROM clientes WHERE rut=@rut";
                    MySqlCommand mycmdi = new MySqlCommand(query, connection);
                    this.AbrirConexion();
                    mycmdi.Parameters.AddWithValue("@rut", rut);
                    mycmdi.ExecuteNonQuery();
                }
            }
        }
    }
}