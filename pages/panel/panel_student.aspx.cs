using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using ExcelPlugInShell;
using System.Configuration;

public partial class student_panel_student : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();

    string getFileName;
    string getfil;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sec"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
           Label1.Text = Session["sec"].ToString();
           list();
        }
    }

    private void list()
    {
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from reg  where meli = '" + Label1.Text + "'";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            for (int j = 0; dr.Read(); j++)
            {
                Label2.Text = dr["pay"].ToString();
                Label3.Text = dr["name"].ToString();
                
            }
            con.Close();
        }
        catch (Exception e)
        {

        }
    }
}