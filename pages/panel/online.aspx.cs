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

public partial class pages_panel_online : System.Web.UI.Page
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
        cmd.CommandText = "select id,code,name_az,tad,dat,pay_az,typ_az,tim_az,typ from online"; //where meli='" + Label1.Text + "'";
        cmd.Connection = con;
        con.Open();
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con.Close();
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        cmd.CommandText = "delete from online where Id=@Id";
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
        cmd.CommandText = "update online set stat = '2',typ=N'تایید شده' where Id=@Id";
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
        cmd.CommandText = "update online set stat = '1',typ=N'عدم تایید' where Id=@Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect(Request.RawUrl);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

            string dada = String.Format("{0}", Request.Form["AnotherDate2"]);
            string StrQury = "Insert Into online (code,name_az,tad,dat,pay_az,typ_az,tim_az,comment_az,stat,typ) Values (@code,@name_az,@tad,@dat,@pay_az,@typ_az,@tim_az,@comment_az,@stat,@typ)";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = StrQury;
            cmd.Parameters.Add("code", SqlDbType.NVarChar, 50).Value = this.TextBox2.Text;
            cmd.Parameters.Add("name_az", SqlDbType.NVarChar, 50).Value = this.TextBox3.Text;
            cmd.Parameters.Add("tad", SqlDbType.NVarChar, 50).Value = this.TextBox4.Text;
            cmd.Parameters.Add("dat", SqlDbType.NVarChar, 50).Value = dada;
            cmd.Parameters.Add("pay_az", SqlDbType.NVarChar, 50).Value = this.DropDownList3.Text;
            cmd.Parameters.Add("typ_az", SqlDbType.NVarChar, 50).Value = this.DropDownList1.Text;
            cmd.Parameters.Add("tim_az", SqlDbType.NVarChar, 50).Value = this.TextBox7.Text;
            cmd.Parameters.Add("comment_az", SqlDbType.NVarChar, 2500).Value = this.TextBox5.Text;
            cmd.Parameters.Add("stat", SqlDbType.NVarChar, 50).Value = "1";
            cmd.Parameters.Add("typ", SqlDbType.NVarChar, 50).Value = "عدم تایید";
            //cmd.Parameters.Add("tvp", SqlDbType.NVarChar, 50).Value = "در جریان";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        
    }
    protected void lnkdeletery_Click(object sender, EventArgs e)
    {
        //int id = int.Parse((sender as LinkButton).CommandArgument);
        string[] commandArgs = (sender as LinkButton).CommandArgument.ToString().Split(new char[] { ',' });
        string scrapid = commandArgs[0];
        string uid = commandArgs[1];
        Session.Add("VALUE", scrapid);
        Session.Add("VALUEE", uid);
        if (uid == "چهارگزینه" || uid == "هوش")
        {
            Response.Redirect("regaz.aspx");
        }
        else if (uid == "تشریحی")
        {
            Response.Redirect("regaz2.aspx");
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            DataSet dt = new DataSet();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = "select id,code,name_az,tad,dat,pay_az,typ_az,tim_az,typ from online where name_az=N'" + TextBox1.Text + "' or code=N'" + TextBox1.Text + "'";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
        else
        {
            DataSet dt = new DataSet();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = "select id,code,name_az,tad,dat,pay_az,typ_az,tim_az,typ from online";
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
    }
    protected void lnkdeleteryT_Click(object sender, EventArgs e)
    {
        //code") + "," + Eval("typ_az") + "," + Eval("pay_az")+ "," + Eval("name_az
        string[] commandArgs = (sender as LinkButton).CommandArgument.ToString().Split(new char[] { ',' });
        string scrapid = commandArgs[0];
        string uid = commandArgs[1];
        string pay = commandArgs[2];
        string name = commandArgs[3];

            Session.Add("VALUE", scrapid);
            Session.Add("VALUEE", uid);
            Session.Add("pay", pay);
            Session.Add("name", name);

            if (uid == "چهارگزینه" || uid == "هوش")
            {
                Response.Redirect("regazs.aspx");
            }
            else if (uid == "تشریحی")
            {
                Response.Redirect("lev1.aspx");
            }
        }
}