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
public partial class _Default : System.Web.UI.Page
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
        soune1();
    }

    private void soune1()  // khabar
    {

        con.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter adapt = new SqlDataAdapter("Select id,onvan,dat from news",con); // where sta = '2' Order by Id Desc", con);
        adapt.Fill(dt);
        con.Close();
        PagedDataSource pds = new PagedDataSource();
        DataView dv = new DataView(dt);
        pds.DataSource = dv;
        pds.AllowPaging = true;
        pds.PageSize = 8;
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
        Repeater4.DataSource = pds;
        Repeater4.DataBind();
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
    protected void Label1_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        Session.Add("news", id);
        Response.Redirect("newe.aspx");
    }
}