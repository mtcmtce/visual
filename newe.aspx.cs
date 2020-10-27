using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
public partial class newe : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand com = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["news"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Label1.Text = Session["news"].ToString();
            list();
        }
    }

    private void list()
    {
        try
        {
            com.Connection = con;

            com.CommandText = "select * from news  where id = '" + Label1.Text + "'";

            SqlDataReader dr;
            con.Open();
            dr = com.ExecuteReader();

            //  Label1.Visible = false;

            for (int j = 0; dr.Read(); j++)
            {
                Label4.Text = dr["onvan"].ToString();
                Label3.Text =  dr["dat"].ToString();
                Label2.Text = dr["descs"].ToString();
            }
        }
        catch (Exception e)
        {

        } 
    }
}