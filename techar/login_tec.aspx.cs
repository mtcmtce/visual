using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class techar_login_tec : System.Web.UI.Page
{
    // public SqlConnection con = new SqlConnection ("Data Source=.\\MSSQLSERVER2014;Database=sst;Integrated Security=False;User ID=sst;Password=siVh50_4;MultipleActiveResultSets=True;Connect Timeout=15;Encrypt=False;Packet Size=4096;");
    public SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=azmoon; Integrated security=true;");
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand com = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Click(object sender, System.EventArgs e)
    {
        da.SelectCommand = new SqlCommand();
        da.SelectCommand.Connection = con;
        da.SelectCommand.CommandText = "SELECT * FROM tech WHERE meli='" + TextBox1.Text + "' AND pass='" + TextBox2.Text + "' AND val='2'";

        if (da.Fill(ds) == 1)
        {
            da.Fill(ds);

            if (TextBox1.Text == "admin")
            {
                Response.Redirect("../../Default.aspx");
            }
            Session.Add("sec", TextBox1.Text);
            Response.Redirect("../pages/panel/panel_techar.aspx");

        }
        else
        {
            WebMessageBox.WebMessageBox.Show("حساب کاربری شما توسط مدیر هنوز تایید نشده است");
        }
    }

}