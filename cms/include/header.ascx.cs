using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class include_header : System.Web.UI.UserControl
{
    SqlConnection con = new SqlConnection(BasicFunction.GetConnectionstring());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Session.RemoveAll();
        //Response.Redirect("Login.aspx");


        //if (!string.IsNullOrEmpty(Response.Cookies["AuthToken"].Value))
        //{
        //    SqlCommand cmd_insert = new SqlCommand("update tbl_CMS_Login_Session set SessionId='', LoginTime=null where UserName='" + Response.Cookies["AuthToken"].Value + "'", con);
        //    con.Open();
        //    cmd_insert.ExecuteNonQuery();
        //    con.Close();


        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("update tbl_AdminLoginDetails set Flag='T',UnsuccessLoginAttempt=0 where UserName='" + Response.Cookies["AuthToken"].Value + "'", con);
        //    cmd.ExecuteNonQuery();
        //    cmd.Dispose();
        //    con.Close();
        //}



        SqlCommand cmd_insert = new SqlCommand("DELETE FROM tbl_CMS_Login_Session", con);
        con.Open();
        cmd_insert.ExecuteNonQuery();
        con.Close();

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

        Response.Redirect("login.aspx");
    }
}