using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_Final
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=farmacias;Data Source=localhost;User Id=root;Password=''");

            string query;
            MySqlCommand SqlCommand;
            MySqlDataReader reader;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Open the connection to db
            conn.Open();

            //Generating the query to fetch the contact details
            query = "SELECT * FROM clientes";

            SqlCommand = new MySqlCommand(query, conn);
            adapter.SelectCommand = new MySqlCommand(query, conn);
            //execute the query
            reader = SqlCommand.ExecuteReader();
            //Assign the results 

            GridView1.DataSource = reader;

            //Bind the data
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Volver", "volver();", true);
        }
    }
}