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

public partial class pages_panel_news : System.Web.UI.Page
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
        cmd.CommandText = "select id,onvan,descs,dat from news"; //where meli='" + Label1.Text + "'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }
    protected void lnkdeletet_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "delete from news where Id=@Id";
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
            da.SelectCommand.CommandText = "select id,onvan,descs,dat from news where onvan=N'" + TextBox1.Text + "' or dat=N'" + TextBox1.Text + "'";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        else
        {
            DataSet dt = new DataSet();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = "select id,onvan,descs,dat from news";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
  
             string dada = String.Format("{0}", Request.Form["AnotherDate2"]);
                string StrQury = "Insert Into news (onvan,descs,dat) Values (@onvan,@descs,@dat)";
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = StrQury;
                cmd.Parameters.Add("onvan", SqlDbType.NVarChar, 4000).Value = this.TextBox2.Text;
                cmd.Parameters.Add("descs", SqlDbType.NVarChar, 300).Value = this.TextBox3.Text;
                cmd.Parameters.Add("dat", SqlDbType.NVarChar, 50).Value = dada;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Request.RawUrl);
       }
        catch (Exception f)
        {
            WebMessageBox.WebMessageBox.Show("عکسی برای آزمون انتخاب نشده است");
        }
    }
}