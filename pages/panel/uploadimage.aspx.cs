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

public partial class uploadimage : System.Web.UI.Page
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
      //  if (Session["tcuV"] == null)
       // {
           // Response.Redirect("login_admin.aspx");
      //  }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
       // saveInsert();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        // Upload Logo
        try
        {
            int k = 0;
            ImageResizer img = new ImageResizer();

            foreach (HttpPostedFile htfiles in FileUpload3.PostedFiles)
            {
                getFileName = Path.GetFileName(htfiles.FileName);
                getFileName = "";
                k++;
                htfiles.SaveAs(Server.MapPath("~/al/" + k + ".jpg" + getFileName));

                img.Resize(Server.MapPath("~/al/" + k + ".jpg" + getFileName), Server.MapPath("~/logo/" + k + ".jpg" + getFileName));

                File.Delete(Server.MapPath("~/al/" + k + ".jpg" + getFileName));

            }
            WebMessageBox.WebMessageBox.Show(FileUpload3.PostedFiles.Count.ToString() + " - " + "فایل ها ارسال شد");
        }
        catch
        {
            WebMessageBox.WebMessageBox.Show(FileUpload3.PostedFiles.Count.ToString() + "حجم فایل ها زیاد میباشد");
        } 
    }
    protected void Button6_Click(object sender, EventArgs e)
    {   // Upload Image Gallary
        try
        {
            int k = 0;
            ImageResizer img = new ImageResizer();

            foreach (HttpPostedFile htfiles in FileUpload4.PostedFiles)
            {
                getFileName = Path.GetFileName(htfiles.FileName);
                getFileName = "";
                k++;
                htfiles.SaveAs(Server.MapPath("~/al/" + k + ".jpg" + getFileName));

                img.Resize(Server.MapPath("~/al/" + k + ".jpg" + getFileName), Server.MapPath("~/images/" + k + ".jpg" + getFileName));

                File.Delete(Server.MapPath("~/al/" + k + ".jpg" + getFileName));

            }

            WebMessageBox.WebMessageBox.Show(FileUpload4.PostedFiles.Count.ToString() + " - " + "فایل ها ارسال شد");
        }
        catch
        {
            WebMessageBox.WebMessageBox.Show(FileUpload4.PostedFiles.Count.ToString() + "حجم فایل ها زیاد میباشد");
        } 
    }
}