using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_panel_panel_consultant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mot"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
            String m1 = Session["mot"].ToString();
        }
    }
}