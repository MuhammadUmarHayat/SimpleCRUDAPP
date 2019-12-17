using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace CRUD_App
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        string constring = @"mystring";
        protected void Button1_Click(object sender, EventArgs e)
        {
            //save data
            string name = TextBox1.Text;
            string fname = TextBox2.Text;
            string address = TextBox3.Text;
            SqlConnection conn = new SqlConnection(constring);

            string query = "INSERT INTO RegistrationTable (id,name,fname,Address)values('" +name  + "','" +fname + "','" + address+ "')";

            SqlCommand sqlCmd = new SqlCommand(query, conn);
            conn.Open();
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("Data is saved");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //update data
            string id = TextBox4.Text;
            string name = TextBox1.Text;
            string fname = TextBox2.Text;
            string address = TextBox3.Text;
            SqlConnection conn = new SqlConnection(constring);

            string query = "update RegistrationTable set name='" + name + "',fname='" + fname + "',address='" + address + "' where id='" + id + "'";

            SqlCommand sqlCmd = new SqlCommand(query, conn);
            conn.Open();
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("Data is updated");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(constring);
            //Open database connection to connect to SQL Server
            con.Open();
            //Data table is used to bind the resultant data
            DataTable dtusers = new DataTable();
            // Create a new data adapter based on the specified query.
            SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM RegistrationTable  ", con);
            //SQl command builder is used to get data from database based on query
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            //Fill data table
            da.Fill(dtusers);
            //assigning data table to Datagridview
            GridView1.DataSource = dtusers;
            GridView1.DataBind();
            
            con.Close();





        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constring);

            string query = "Delete  from RegistrationTable  where where id='" + id + "'";


            SqlCommand sqlCmd = new SqlCommand(query, conn);
            conn.Open();
            sqlCmd.ExecuteNonQuery();// insertion into db
            conn.Close();
        }
    }
}
