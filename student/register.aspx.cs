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
public partial class student_register : System.Web.UI.Page
{
    private static String connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    private SqlConnection con = new SqlConnection(connStr);
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();
    public SqlCommand com = new SqlCommand();
    string getFileName;
    string getfil;
    private int res;
    private String mel;
    private String m1;

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    private void meli()
    {
        try
        {

            if (TextBox3.Text == "0000000000" || TextBox3.Text == "1111111111" || TextBox3.Text == "2222222222" || TextBox3.Text == "3333333333" || TextBox3.Text == "4444444444" || TextBox3.Text == "5555555555" || TextBox3.Text == "6666666666" || TextBox3.Text == "7777777777" || TextBox3.Text == "8888888888" || TextBox3.Text == "9999999999")
            {

                // WebMessageBox.WebMessageBox.Show("کد ملی صحیح می باشد");
                res = 1;
            }
            else
            {

                char[] chArray = this.TextBox3.Text.ToCharArray();
                int[] numArray = new int[chArray.Length];
                for (int i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                int num2 = numArray[9];
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    //MessageBox.Show("کد ملی صحیح می باشد");
                    // label8.Text = "$a$";
                }
                else
                {
                    res = 2;
                    WebMessageBox.WebMessageBox.Show("کد ملی نامعتبر است");
                }
            }
        }
        catch (Exception)
        {
            res = 2;
            WebMessageBox.WebMessageBox.Show("کد ملی وارد نمائید");
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Response.Redirect("sys_pn.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //  try
        //   {
        searche();

        if (TextBox3.Text == mel)
        {
            WebMessageBox.WebMessageBox.Show(" ثبت نام انجام نشد دانش آموزی با چنین مشخصاتی در سیستم وجود دارد");
        }
        else
        {
            meli();
            if (res == 2)
            {
                WebMessageBox.WebMessageBox.Show("کد ملی نامعتبر است");
            }
            else
            {
                if (TextBox8.Text == "" || TextBox7.Text == "" || TextBox6.Text == "" || TextBox4.Text == "" || TextBox3.Text == "")// || TextBox2.Text == "")
                {
                    WebMessageBox.WebMessageBox.Show("لطفا تمامی فیلدها را پر نمائید");
                }
                else
                {
                    Random rand = new Random();
                    int num = 53782;
                    String s1 = rand.Next(num).ToString();
                    string StrQury = "Insert Into reg (name,father,meli,location,datev,tel,code,pay,pass,school,serv,stu,stat)Values (@name,@father,@meli,@location,@datev,@tel,@code,@pay,@pass,@school,@serv,@stu,@stat)";
                    string dada = String.Format("{0}", Request.Form["AnotherDate2"]);
                    con = new SqlConnection(connStr);
                    com = new SqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = StrQury;
                    com.Parameters.Add("name", SqlDbType.NVarChar, 300).Value = this.TextBox4.Text;
                    com.Parameters.Add("father", SqlDbType.NVarChar, 50).Value = this.TextBox8.Text;
                    com.Parameters.Add("meli", SqlDbType.NVarChar, 50).Value = this.TextBox3.Text;
                    com.Parameters.Add("location", SqlDbType.NVarChar, 50).Value = this.TextBox7.Text;
                    com.Parameters.Add("datev", SqlDbType.NVarChar, 50).Value = dada;// this.TextBox2.Text;
                    com.Parameters.Add("tel", SqlDbType.NVarChar, 50).Value = this.TextBox6.Text;
                    com.Parameters.Add("code", SqlDbType.NVarChar, 50).Value = s1.ToString();
                    com.Parameters.Add("pay", SqlDbType.NVarChar, 50).Value = this.DropDownList2.Text;
                    com.Parameters.Add("pass", SqlDbType.NVarChar, 50).Value = this.TextBox3.Text;
                    com.Parameters.Add("school", SqlDbType.NVarChar, 50).Value = "0";
                    com.Parameters.Add("serv", SqlDbType.NVarChar, 50).Value = "0";
                    com.Parameters.Add("stu", SqlDbType.NVarChar, 50).Value = "عدم ثبت نام";
                    com.Parameters.Add("stat", SqlDbType.NVarChar, 50).Value = "1"; 
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    // TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    TextBox5.Text = "";
                    WebMessageBox.WebMessageBox.Show("ثبت نام با موفقیت انجام شد" + "---" + "کد رهگیری شما:" + s1 );
                }
            }
        }

        //    }  //edn try

        //  catch
        //   {

        //  } 
    }
    protected void reg(object sender, EventArgs e)
    {
        Response.Redirect("edit_reg.aspx");
    }
    private void searche()
    {
        try
        {

            com.Connection = con;

            com.CommandText = "select * from reg where meli = '" + TextBox3.Text + "'";

            SqlDataReader dr;
            con.Open();
            dr = com.ExecuteReader();

            //  Label1.Visible = false;

            for (int j = 0; dr.Read(); j++)
            {
                mel = dr["meli"].ToString();

            }
        }
        catch
        {

        }
    }
}