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

public partial class pages_panel_list_list : System.Web.UI.Page
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
        cmd.CommandText = "select id,name,meli,tel,stu,pay from reg"; //where meli='" + Label1.Text + "'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }

    protected void lnkdelete_Click6(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "delete from reg where Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }

    protected void update_un(object sender, EventArgs e)
    {

        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "update reg set stat = '2',stu=N'تایید شده' where Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);

    }
    protected void updateun_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "update reg set stat = '1',stu=N'عدم تایید' where Id=@Id";
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
            da.SelectCommand.CommandText = "select id,name,meli,tel,stu,pay from reg where meli=N'" + TextBox1.Text + "' or pay=N'" + TextBox1.Text + "'";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        else
        {
            DataSet dt = new DataSet();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = "select id,name,meli,tel,stu,pay from reg";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        WebMessageBox.WebMessageBox.Show("در حال بررسی");
    }
}