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
public partial class student_edit_reg : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand com = new SqlCommand();

    string getFileName;
    string getfil;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void finde(object sender, EventArgs e)
    {
        try
        {

            com.Connection = con;

            com.CommandText = "SELECT * FROM reg WHERE meli='" + TextBox1.Text + "' AND code='" + TextBox9.Text + "' ";


            SqlDataReader dr;
            con.Open();
            dr = com.ExecuteReader();

            //  Label1.Visible = false;

            for (int j = 0; dr.Read(); j++)
            {
                TextBox4.Text = dr["name"].ToString();
                TextBox8.Text = dr["father"].ToString();
                TextBox3.Text = dr["meli"].ToString();
                TextBox7.Text = dr["location"].ToString();
                TextBox2.Text = dr["datev"].ToString();
                TextBox6.Text = dr["tel"].ToString();
                DropDownList2.Text = dr["pay"].ToString();
            }
            con.Close();

        }
        catch
        {

        }
    }
    protected void upd(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update reg set name=@name,father=@father,meli=@meli,location=@location, datev=@datev, tel=@tel,pay=@pay,serv=@serv  where code='" + TextBox9.Text + "'", con);
            //update reg set name='" + TextBox4.Text + "',father='" + TextBox8.Text + "',meli='" + TextBox3.Text + "',location='" + TextBox7.Text + "', datev='" + TextBox2.Text + "', tel='" + TextBox6.Text + "',pay='" + DropDownList2.Text + "',serv='" + DropDownList1.Text + "'  where meli='" + TextBox1.Text + "'", con);
            cmd.Parameters.AddWithValue("@Name", TextBox4.Text);
            cmd.Parameters.AddWithValue("@father", TextBox8.Text);
            cmd.Parameters.AddWithValue("@meli", TextBox3.Text);
            cmd.Parameters.AddWithValue("@location", TextBox7.Text);
            cmd.Parameters.AddWithValue("@datev", TextBox2.Text);
            cmd.Parameters.AddWithValue("@tel", TextBox6.Text);
            cmd.Parameters.AddWithValue("@pay", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@serv", "0");
            cmd.ExecuteNonQuery();
            con.Close();
            WebMessageBox.WebMessageBox.Show("ویرایش با موفقیت انجام شد");
        }
        catch
        {
            /* MySqlCommand cmd = new MySqlCommand("update student Set  
            Name=@Name,Address=@Address,Mobile=@Mobile,Email=@Email where SID=@SID", conn);  
                cmd.Parameters.AddWithValue("@Name", txtName.Text);  
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);  
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);  
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);  
                cmd.Parameters.AddWithValue("SID",SID);  
                cmd.ExecuteNonQuery();  
                cmd.Dispose();  */
        }
    }

}