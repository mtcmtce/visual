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

public partial class pages_panel_regaz2 : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();
    string m5;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ssl"] == null)
        {
            Response.Redirect("login_log.aspx");
        }
        else
        {
            TextBox2.Text = Session["VALUE"].ToString();
            m5 = Session["VALUEE"].ToString();
            list();
            soune();
        }
    }

    private void soune()
    {
        cmd.CommandText = "select id,code,descs,lev from regaz2  where code='" + TextBox2.Text + "'";// and lev=N'" + m5 + "'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }

    private void list()
    {
        try
        {
            cmd.Connection = con;

            cmd.CommandText = "select * from online  where code = '" + TextBox2.Text + "'";

            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            for (int j = 0; dr.Read(); j++)
            {
                TextBox3.Text = dr["name_az"].ToString();
                TextBox4.Text = dr["pay_az"].ToString();
                TextBox5.Text = dr["typ_az"].ToString();
            }
            con.Close();
        }
        catch (Exception e)
        {

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string filename = FileUpload1.FileName;
        FileUpload1.PostedFile.SaveAs(Server.MapPath("~\\regaz2\\" + filename.Trim()));
        string path = "~\\regaz2\\" + filename.Trim();
        string StrQury = "Insert Into regaz2 (code,descs,lev,img) Values (@code,@descs,@lev,@img)";
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = StrQury;
        cmd.Parameters.Add("code", SqlDbType.NVarChar, 50).Value = this.TextBox2.Text;
        cmd.Parameters.Add("descs", SqlDbType.NVarChar, 4000).Value = this.TextBox6.Text;
        cmd.Parameters.Add("lev", SqlDbType.NVarChar, 50).Value = this.DropDownList1.Text;
        cmd.Parameters.Add("img", SqlDbType.NVarChar, 3000).Value = path;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "delete from regaz2 where Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }
}