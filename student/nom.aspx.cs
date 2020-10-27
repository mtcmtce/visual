using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

public partial class student_nom : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();
    string q1, q2, q3;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sec"] == null)
        {
            Response.Redirect("login_student.aspx");
        }
        else
        {
            q1 = Session["code"].ToString();
            Label2.Text = Session["sec"].ToString();  // meli  //lbl pay
            list();
            soune();
        }
    }

    private void list()
    {
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from reg  where meli = '" + Label2.Text + "'";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            for (int j = 0; dr.Read(); j++)
            {
                lbl.Text = dr["pay"].ToString();
                Label1.Text = dr["name"].ToString();
            }
            con.Close();
        }
        catch (Exception e)
        {

        }
    }

    private void soune()
    {
        cmd.CommandText = "select id,code,lev,name,meli,nom from lev1 where code='" + q1 + "' and meli = '"+Label2.Text+"' and name =N'"+Label1.Text+"'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }
}