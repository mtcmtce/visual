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
using System.Collections;
public partial class pages_panel_consultant : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ssl"] == null)
        {
            Response.Redirect("login_log.aspx");
        }
        else
        {
            soune();
        }
    }

    private void soune()
    {
        cmd.CommandText = "select id,onvan,descs,dat from cons";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "delete from cons where Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            DataSet dt = new DataSet();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = "select id,onvan,descs,dat from cons where onvan=N'" + TextBox1.Text + "' or dat=N'" + TextBox1.Text + "'";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        else
        {
            DataSet dt = new DataSet();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = "select id,onvan,descs,dat from cons";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
            string dada = String.Format("{0}", Request.Form["AnotherDate2"]);
            string StrQury = "Insert Into cons (onvan,descs,dat,typ) Values (@onvan,@descs,@dat,@typ)";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = StrQury;
            cmd.Parameters.Add("onvan", SqlDbType.NVarChar, 50).Value = this.TextBox2.Text;
            cmd.Parameters.Add("descs", SqlDbType.NVarChar, 50).Value = this.TextBox3.Text;
            cmd.Parameters.Add("dat", SqlDbType.NVarChar, 50).Value = dada;
            cmd.Parameters.Add("typ", SqlDbType.NVarChar, 50).Value = this.TextBox4.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
    }
}