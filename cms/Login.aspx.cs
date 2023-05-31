using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_Login : System.Web.UI.Page
{
    string strQuery = "";
    DataTable dTable, dTableSeCtions;
    SqlConnection con = new SqlConnection(BasicFunction.GetConnectionstring());
    static string RandomImgText = "";

    string key = "MAKV2SPBNI99212";
    string sIpaddress = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["admin"] = "admin";
        Session["username1"] = "admin";

        if (!Page.IsPostBack)
        {
            CreateRandomString(6);
            CheckLoginTime();
            //Session.Abandon();
            //Session.Clear();
            //Session.RemoveAll();

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }

        }

    }



    private bool isValidateRegistration()
    {
        bool status = ValidateForm();
        if (status == false)
        {
            // Response.Write("123" + status);
            Show1("Entered Captcha Text is incorrect.");

            return false;
        }

        return true;
    }

    public static void Show1(string message)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\\'");
        string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
        // string script = "<script type=\"text/javascript\">" + cleanMessage + "</script>";
        Page page = (Page)HttpContext.Current.CurrentHandler;
        string keyy = "key1";
        if (!page.IsStartupScriptRegistered(keyy))
        {

            page.RegisterStartupScript(keyy, script);
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (isValidateRegistration() == true)
            {
                CheckConcurrentLogin(txtusername.Value.Trim());
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.StackTrace);
        }



    }

    public void CheckConcurrentLogin(string username)
    {
        strQuery = @"SELECT * FROM tbl_CMS_Login_Session where UserName='" + BasicFunction.Encrypt(username) + "'";
        dTable = new DataTable();
        dTable = BasicFunction.GetDetailsByDatatable(strQuery);
        if (dTable.Rows.Count > 0)
        {
            //if (string.IsNullOrEmpty(dTable.Rows[0]["SessionId"].ToString()) || string.IsNullOrEmpty(dTable.Rows[0]["LoginTime"].ToString()))
            if (string.IsNullOrEmpty(dTable.Rows[0]["SessionId"].ToString()))
            {
                CheckLogin();
            }
            else
            {
                //lblMsg.Text = "User is  already logged in another browser/tab.";
                CheckLogin();
            }
        }
        else
        {
            SqlCommand cmd_insert = new SqlCommand("insert into tbl_CMS_Login_Session (UserName,SessionId,LoginTime,Status) VALUES('" + BasicFunction.Encrypt(username) + "','" + HttpContext.Current.Session.SessionID.ToString() + "','" + DateTime.Now + "','T')", con);
            con.Open();
            cmd_insert.ExecuteNonQuery();
            con.Close();
            CheckLogin();
        }
    }

    public void CheckLogin()
    {

        //CheckConcurrentLogin(txtusername.Value.Trim());

        strQuery = @"SELECT * FROM tbl_AdminLoginDetails where UserName='" + BasicFunction.Encrypt(txtusername.Value) + "' and Password='" + BasicFunction.Encrypt(txtpassword.Value) + "' and flag='T'";


        //Response.Write(strQuery);

        dTable = new DataTable();
        dTable = BasicFunction.GetDetailsByDatatable(strQuery);
        if (dTable.Rows.Count > 0)
        {
            Session["admin"] = "admin";
            Session["username1"] = dTable.Rows[0]["UserName"].ToString();



            con.Open();
            SqlCommand cmd = new SqlCommand("update tbl_AdminLoginDetails set Flag='T',UnsuccessLoginAttempt=0 where UserName='" + BasicFunction.Encrypt(txtusername.Value) + "'", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

            SqlCommand cmd_insert = new SqlCommand("update tbl_CMS_Login_Session set SessionId='" + HttpContext.Current.Session.SessionID.ToString() + "', LoginTime='" + DateTime.Now + "' where UserName='" + BasicFunction.Encrypt(txtusername.Value) + "'", con);
            con.Open();
            cmd_insert.ExecuteNonQuery();
            con.Close();

            string guid = Guid.NewGuid().ToString();
            guid = guid + Guid.NewGuid().ToString();
            guid = guid + Guid.NewGuid().ToString();
            Session["AuthToken"] = guid;
            // now create a new cookie with this guid value  
            Response.Cookies.Add(new HttpCookie("AuthToken", guid));

            Response.Redirect("default.aspx");
        }
        else
        {
            lblMsg.Text = "Invalid Login Credentials.";

            SqlCommand cmd_insert1 = new SqlCommand("update tbl_CMS_Login_Session set SessionId='', LoginTime=null where UserName='" + BasicFunction.Encrypt(txtusername.Value) + "'", con);
            con.Open();
            cmd_insert1.ExecuteNonQuery();
            con.Close();


            strQuery = @"SELECT UnsuccessLoginAttempt + 1 as UnsuccessLoginAttempt FROM tbl_AdminLoginDetails where UserName='" + BasicFunction.Encrypt(txtusername.Value) + "'";
            dTable = new DataTable();
            dTable = BasicFunction.GetDetailsByDatatable(strQuery);
            if (dTable.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dTable.Rows[0]["UnsuccessLoginAttempt"].ToString()))
                {
                    dTable.Rows[0]["UnsuccessLoginAttempt"] = "0";
                }

                if (Convert.ToInt32(dTable.Rows[0]["UnsuccessLoginAttempt"]) >= 3)
                {
                    SqlCommand cmd_insert = new SqlCommand("update tbl_AdminLoginDetails set UnsuccessLoginAttempt=3,Flag='F'where UserName='" + BasicFunction.Encrypt(txtusername.Value) + "'", con);
                    con.Open();
                    cmd_insert.ExecuteNonQuery();
                    con.Close();

                    lblMsg.Text = "Your account is blocked. please contact administrator.";
                }
                else
                {
                    SqlCommand cmd_insert = new SqlCommand("update tbl_AdminLoginDetails set UnsuccessLoginAttempt='" + dTable.Rows[0]["UnsuccessLoginAttempt"].ToString() + "' where UserName='" + BasicFunction.Encrypt(txtusername.Value) + "'", con);
                    con.Open();
                    cmd_insert.ExecuteNonQuery();
                    con.Close();
                }
            }

        }
    }

    public void CheckLoginTime()
    {
        strQuery = "select * from tbl_CMS_Login_Session where SessionId !=''";
        dTable = new DataTable();
        dTable = BasicFunction.GetDetailsByDatatable(strQuery);
        if (dTable.Rows.Count > 0)
        {
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                DateTime LoginTIme = Convert.ToDateTime(dTable.Rows[i]["LoginTime"].ToString());
                int result = DateTime.Compare(LoginTIme.AddMinutes(15), DateTime.Now);
                if (result < 0)
                {
                    SqlCommand cmd_insert = new SqlCommand("update tbl_CMS_Login_Session set SessionId='', LoginTime=null where Id=" + dTable.Rows[i]["Id"].ToString(), con);
                    con.Open();
                    cmd_insert.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }

    //---- Method to create random string to be used as captcha.
    public void CreateRandomString(int length)
    {

        string guidResult = System.Guid.NewGuid().ToString();
        guidResult = guidResult.Replace("-", string.Empty);
        guidResult = guidResult.Substring(0, length);

        imgCaptcha.ImageUrl = "CaptchaHandler.ashx?txt=" + guidResult;
        //Session["RandomImgText"] = guidResult;
        RandomImgText = guidResult;
    }

    //--- Method to check whether entered captcha is correct or not.
    protected bool ValidateForm()
    {
        bool IsValid = true;
        if (txtImg.Text != RandomImgText)
        {
            IsValid = false;
        }
        return IsValid;
    }

    private string GetIpValue()
    {
        return HttpContext.Current.Request.UserHostAddress; ;
    }
}