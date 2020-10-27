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

public partial class student_regaz2s : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();
    string m5;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sec"] == null)
        {
            Response.Redirect("login_student.aspx");
        }
        else if (Session["VALUE"] == null)
        {
            Response.Redirect("onlineaz.aspx");
        }
        else
        {
            Label2.Text = Session["sec"].ToString();
            m5 = Session["VALUE"].ToString();
            list();
            soune1();
       }
        
    }
    private void soune1()
    {

        con.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter("Select id,img from regaz2 where code =N'"+m5+"' Order by Id Desc", con);
        adapt.Fill(dt);
        con.Close();
        PagedDataSource pds = new PagedDataSource();
        DataView dv = new DataView(dt);
        pds.DataSource = dv;
        pds.AllowPaging = true;
        pds.PageSize = 20;
        pds.CurrentPageIndex = PageNumber;
        if (pds.PageCount > 1)
        {
            rptPaging.Visible = true;
            ArrayList arraylist = new ArrayList();
            for (int i = 0; i < pds.PageCount; i++)
                arraylist.Add((i + 1).ToString());
            rptPaging.DataSource = arraylist;
            rptPaging.DataBind();
        }
        else
        {
            rptPaging.Visible = false;
        }
        Repeater2.DataSource = pds;
        Repeater2.DataBind();
    }

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }
    protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;

    }

    protected void rptPaging_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        // soune();
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
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~\\jav\\" + filename.Trim()));
            string path = "~\\jav\\" + filename.Trim();
            string StrQury = "Insert Into lev1 (name,meli,lev,img,stat,code) Values (@name,@meli,@lev,@img,@stat,@code)";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = StrQury;
            cmd.Parameters.Add("name", SqlDbType.NVarChar, 50).Value = this.Label1.Text;
            cmd.Parameters.Add("meli", SqlDbType.NVarChar, 4000).Value = this.Label2.Text;
            cmd.Parameters.Add("lev", SqlDbType.NVarChar, 50).Value = this.lbl.Text;
            cmd.Parameters.Add("img", SqlDbType.NVarChar, 3000).Value = path;
            cmd.Parameters.Add("stat", SqlDbType.NVarChar, 3000).Value = "خاتمه یافته";
            cmd.Parameters.Add("code", SqlDbType.NVarChar, 3000).Value = m5;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Session.Remove("VALUE");
            Response.Redirect("onlineaz.aspx");
        }
        catch (Exception)
        {
            WebMessageBox.WebMessageBox.Show("جواب سوالات را بارگذاری کنید");
        }
    }

   /* public void updateonline()
    {
         con.Open();
           SqlCommand cmd = new SqlCommand("update lev1 set tvp=N'خاتمه یافته'  where meli='" + Label2.Text + "'", con);
           cmd.ExecuteNonQuery();
           con.Close(); 
    } */
}