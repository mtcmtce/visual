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

public partial class pages_panel_login_log : System.Web.UI.Page
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

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        da.SelectCommand = new SqlCommand();
        da.SelectCommand.Connection = con;
        da.SelectCommand.CommandText = "SELECT * FROM ctrl WHERE meli='" + TextBox1.Text + "' AND pass='" + TextBox2.Text + "'"; ;

        if (da.Fill(ds) == 1)
        {
            da.Fill(ds);

            if (TextBox1.Text == "admin")
            {
                // Response.Redirect("sys_info.aspx");
            }
            Session.Add("ssl", TextBox1.Text);
            Response.Redirect("paneladmin.aspx");

        } 

    }
}