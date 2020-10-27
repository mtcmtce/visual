using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

public partial class student_onlineaz : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand cmd = new SqlCommand();
    string mu, mtc,mmc = "";
    int s1 = 0;
    string scrapid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sec"] == null)
        {
            Response.Redirect("login_student.aspx");
        }
        else
        {
            Label2.Text = Session["sec"].ToString();
            list();
            soune();
        }
    }
    //this.myGridview.Columns[0].Visible = false;
    private void soune()
    {
        cmd.CommandText = "select id,code,name_az,tad,pay_az,typ_az,comment_az,tim_az from online where pay_az=N'" + lbl.Text + "' and stat='2'";
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


    private void listV()
    {
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from lev1  where  meli = '" + Label2.Text + "' and lev =N'"+lbl.Text+"' and stat=N'خاتمه یافته' and code='"+scrapid+"'";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            for (int j = 0; dr.Read(); j++)
            {
                mtc = dr["stat"].ToString();
            }
            con.Close();
        }
        catch (Exception e)
        {

        }
    }

    private void listV2()
    {
        try
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from lev1  where meli = '" + Label2.Text + "' and lev =N'" + lbl.Text + "' and code='"+scrapid+"'";
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();

            for (int j = 0; dr.Read(); j++)
            {
                mmc = dr["nom"].ToString();
            }
            con.Close();
        }
        catch (Exception e)
        {

        }
    }
    protected void lnkdeletery_Click(object sender, EventArgs e)
    {
            string[] commandArgs = (sender as LinkButton).CommandArgument.ToString().Split(new char[] { ',' });
            scrapid = commandArgs[0];
            string uid = commandArgs[1];

            Session.Add("VALUE", scrapid);
            Session.Add("VALUEE", uid);

            if (uid == "چهارگزینه" || uid == "هوش")
            {
                Response.Redirect("regazs.aspx");
            }
            else
            {
                listV();
                if (mtc == "خاتمه یافته")
                {
                    Session.Remove("VALUE");
                    WebMessageBox.WebMessageBox.Show("آزمون شما پایان یافته است");
                }
                else
                {
                    Response.Redirect("regaz2s.aspx");
                }
            }
      
     }
    protected void viewkar_Click(object sender, EventArgs e)
    {
             string[] commandArgs = (sender as LinkButton).CommandArgument.ToString().Split(new char[] { ',' });
             string code = commandArgs[0];
             Session.Add("code", code);
             Response.Redirect("nom.aspx");
    }
}