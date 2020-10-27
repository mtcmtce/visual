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
using System.Linq;

public partial class pages_panel_lev2 : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();
    string q1, q2, q3;
    protected void Page_Load(object sender, EventArgs e)
    {
  
        if (Session["ssl"] == null)
        {
            Response.Redirect("login_log.aspx");
        }
        else
        {
            q1 = Session["VALUE"].ToString();
            q2 = Session["VALUEE"].ToString();
            q3 = Session["pay"].ToString();
       
        }
        if (!IsPostBack)
        {
            soune();
        }
    }

   private void soune()
    {
        cmd.CommandText = "select id,code,typ,name,meli,stat,lev,img,nom from lev1 where code='" + q1 + "' and lev=N'"+q3+"'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }
   protected void lnkdeletery_Click(object sender, EventArgs e)
   {
       int id = int.Parse((sender as LinkButton).CommandArgument);
       cmd.CommandText = "delete from lev1 where Id=@Id";
       cmd.Parameters.AddWithValue("@Id", id);
       cmd.Connection = con;
       con.Open();
       cmd.ExecuteNonQuery();
       con.Close();
       Response.Redirect(Request.RawUrl);

   }

   protected void lnkdeletery_Click1(object sender, EventArgs e)
   {
       GridViewRow row = GridView3.SelectedRow;

       int id = int.Parse((sender as LinkButton).CommandArgument);
       TextBox tb = (TextBox)row.FindControl("TextBox2");
       string value = tb.Text;
       cmd.CommandText = "update lev1 set nom = '" + value + "' where Id=@Id";
       cmd.Parameters.AddWithValue("@Id", id);
       cmd.Connection = con;
       con.Open();
       cmd.ExecuteNonQuery();
       con.Close();
       Response.Redirect(Request.RawUrl);

   }


   private DataTable ExecuteQuery(SqlCommand cmd, string action)
   {
       using (SqlConnection con = new SqlConnection(connStr))
       {
           cmd.Connection = con;
           switch (action)
           {
               case "SELECT":
                   using (SqlDataAdapter sda = new SqlDataAdapter())
                   {
                       sda.SelectCommand = cmd;
                       using (DataTable dt = new DataTable())
                       {
                           sda.Fill(dt);
                           return dt;
                       }
                   }
               case "UPDATE":
                   con.Open();
                   cmd.ExecuteNonQuery();
                   con.Close();
                   break;
           }
           return null;
       }
   }
   protected void Button2_Click1(object sender, EventArgs e)
   {
       foreach (GridViewRow row in GridView3.Rows)
       {
           SqlCommand cmd = new SqlCommand("UPDATE lev1 SET nom=@nom WHERE id = @id");
           cmd.Parameters.AddWithValue("@nom", row.Cells[7].Controls.OfType<TextBox>().FirstOrDefault().Text);
           cmd.Parameters.AddWithValue("@id", GridView3.DataKeys[row.RowIndex].Value);
           this.ExecuteQuery(cmd, "SELECT");
       }
   }
}