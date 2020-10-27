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

public partial class pages_panel_Register : System.Web.UI.Page
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

    protected void Button3_Click(object sender, EventArgs e)
    {
       // try
      //  {
            if (TextBox2.Text != null)
            {
                string dada = String.Format("{0}", Request.Form["AnotherDate2"]);
                string StrQury = "Insert Into consultant (name,meli,com,dat,stat,typ) Values (@name,@meli,@com,@dat,@stat,@typ)";
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = StrQury;
                cmd.Parameters.Add("name", SqlDbType.NVarChar, 4000).Value = this.TextBox2.Text;
                cmd.Parameters.Add("meli", SqlDbType.NVarChar, 300).Value = this.TextBox3.Text;
                cmd.Parameters.Add("com", SqlDbType.NVarChar, 4000).Value = this.TextBox4.Text; //پایه تحصیلی
                cmd.Parameters.Add("dat", SqlDbType.NVarChar, 1500).Value = dada;
                cmd.Parameters.Add("stat", SqlDbType.NVarChar, 4000).Value = "1";
                cmd.Parameters.Add("typ", SqlDbType.NVarChar, 4000).Value = "عدم تایید";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                WebMessageBox.WebMessageBox.Show("لطفا تمامی موارد خواسته شده را پر نمائید");
            }
     //   }
      //  catch (Exception f)
      //  {
       //     WebMessageBox.WebMessageBox.Show("خطا در ثبت اطلاعات");
      //  }

    }
   private void soune()
    {
        cmd.CommandText = "select id,name,meli,com,dat,stat,typ from consultant"; //where meli='" + Label1.Text + "'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "delete from consultant where Id=@Id";
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
            da.SelectCommand.CommandText = "select id,name,meli,com,dat,stat,typ from consultant where namee=N'" + TextBox1.Text + "' or meli=N'" + TextBox1.Text + "'";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        else
        {
            DataSet dt = new DataSet();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = "select id,name,meli,com,dat,stat,typ from consultant";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
    }

    protected void update_un(object sender, EventArgs e)
    {

        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "update consultant set stat = '2',typ=N'تایید شده' where Id=@Id";
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
        cmd.CommandText = "update consultant set stat = '1',typ=N'عدم تایید' where Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }
}
