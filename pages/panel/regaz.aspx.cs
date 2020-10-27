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

public partial class pages_panel_regaz : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();
    string cal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ssl"] == null)
        {
            Response.Redirect("login_log.aspx");
        }
        else
        {
            TextBox2.Text = Session["VALUE"].ToString();
          //  string m5 = Session["VALUEE"].ToString();
            list();
            soune();
        }
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
        FileUpload1.PostedFile.SaveAs(Server.MapPath("~\\regaz\\" + filename.Trim()));
        string path = "~\\regaz\\" + filename.Trim();
        string StrQury = "Insert Into regaz (code,descs,a1,a2,a3,a4,nem,lev,img) Values (@code,@descs,@a1,@a2,@a3,@a4,@nem,@lev,@img)";
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = StrQury;
        cmd.Parameters.Add("code", SqlDbType.NVarChar, 50).Value = this.TextBox2.Text;
        cmd.Parameters.Add("descs", SqlDbType.NVarChar, 4000).Value = this.TextBox6.Text;
        cmd.Parameters.Add("a1", SqlDbType.NVarChar, 50).Value = this.TextBox7.Text;
        cmd.Parameters.Add("a2", SqlDbType.NVarChar, 50).Value = this.TextBox8.Text;
        cmd.Parameters.Add("a3", SqlDbType.NVarChar, 50).Value = this.TextBox9.Text;
        cmd.Parameters.Add("a4", SqlDbType.NVarChar, 50).Value = this.TextBox10.Text;
      //  cmd.Parameters.Add("dat", SqlDbType.NVarChar, 50).Value = dada;
        cmd.Parameters.Add("nem", SqlDbType.NVarChar, 50).Value = this.DropDownList1.Text;
        cmd.Parameters.Add("lev", SqlDbType.NVarChar, 50).Value = this.DropDownList2.Text;
        cmd.Parameters.Add("img", SqlDbType.NVarChar, 3000).Value = path;
        //cmd.Parameters.Add("tim_az", SqlDbType.NVarChar, 50).Value = this.TextBox7.Text;
       // cmd.Parameters.Add("comment_az", SqlDbType.NVarChar, 2500).Value = this.TextBox5.Text;
       // cmd.Parameters.Add("stat", SqlDbType.NVarChar, 50).Value = "1";
       // cmd.Parameters.Add("typ", SqlDbType.NVarChar, 50).Value = "عدم تایید";
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }

    private void soune()
    {
        cmd.CommandText = "select id,code,descs,a1,a2,a3,a4,nem,lev from regaz  where code='" + TextBox2.Text + "'";// and lev=N'" + m5 + "'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "delete from regaz where Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }
}