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
public partial class pages_panel_login_cons : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Click(object sender, System.EventArgs e)
    {
        da.SelectCommand = new SqlCommand();
        da.SelectCommand.Connection = con;
        da.SelectCommand.CommandText = "SELECT * FROM consultant WHERE meli='" + TextBox1.Text + "' AND pass='" + TextBox2.Text + "' and stat ='" + '2' + "' ";

        if (da.Fill(ds) == 1)
        {
            da.Fill(ds);
            Session.Add("mot", TextBox1.Text);
            Response.Redirect("../../pages/panel/panel_consultant.aspx");
        }
        else
        {
            WebMessageBox.WebMessageBox.Show("مجوز ورود به سیستم برای شما توسط مدیر سیستم صادر نشده است");
        }
    }
}