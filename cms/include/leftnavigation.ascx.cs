﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class include_LeftNavigation : System.Web.UI.UserControl
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;


    DataTable dTable, dTableSeCtions;
    string strQuery = "";

    protected void Page_Init(object sender, EventArgs e)
    {
        //First, check for the existence of the Anti-XSS cookie
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;

        //If the CSRF cookie is found, parse the token from the cookie.
        //Then, set the global page variable and view state user
        //key. The global variable will be used to validate that it matches 
        //in the view state form field in the Page.PreLoad method.
        if (requestCookie != null
            && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            //Set the global token variable so the cookie value can be
            //validated against the value in the view state form field in
            //the Page.PreLoad method.
            _antiXsrfTokenValue = requestCookie.Value;

            //Set the view state user key, which will be validated by the
            //framework during each request
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        //If the CSRF cookie is not found, then this is a new session.
        else
        {
            //Generate a new Anti-XSRF token
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");

            //Set the view state user key, which will be validated by the
            //framework during each request
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            //Create the non-persistent CSRF cookie
            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                //Set the HttpOnly property to prevent the cookie from
                //being accessed by client side script
                HttpOnly = true,

                //Add the Anti-XSRF token to the cookie value
                Value = _antiXsrfTokenValue
            };

            //If we are using SSL, the cookie should be set to secure to
            //prevent it from being sent over HTTP connections
            if (FormsAuthentication.RequireSSL &&
                Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }

            //Add the CSRF cookie to the response
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += Page_PreLoad;
    }

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        //During the initial page load, add the Anti-XSRF token and user
        //name to the ViewState
        if (!IsPostBack)
        {
            //Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

            //If a user name is assigned, set the user name
            ViewState[AntiXsrfUserNameKey] =
                   Context.User.Identity.Name ?? String.Empty;
        }
        //During all subsequent post backs to the page, the token value from
        //the cookie should be validated against the token in the view state
        //form field. Additionally user name should be compared to the
        //authenticated users name
        else
        {
            //Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] !=
                     (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of " +
                                    "Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (BasicFunction.getExternalIp() != "141.113.3.14" || BasicFunction.getExternalIp() != "141.113.3.15" || BasicFunction.getExternalIp() != "141.113.3.16" || BasicFunction.getExternalIp() != "141.113.3.17" || BasicFunction.getExternalIp() != "202.54.40.233")
        //{
        //    Response.Redirect("https://53.196.44.44/bbfwebsite/index.aspx");
        //}

        if (string.IsNullOrEmpty(Response.Cookies["AuthToken"].ToString()))
        {
            Response.Redirect("Login.aspx");
        }

        strQuery = @"SELECT AdminType FROM tbl_AdminLoginDetails where username='" + Session["username1"].ToString() + "'";

        dTable = new DataTable();
        dTable = BasicFunction.GetDetailsByDatatable(strQuery);

        if (dTable.Rows.Count > 0)
        {
            if (dTable.Rows[0]["AdminType"].ToString() == "Superadmin")
            {
                hrefSuperAdmin.Visible = true;
            }
            else
            {
                hrefSuperAdmin.Visible = false;
            }
        }
        else
        {
            hrefSuperAdmin.Visible = false;
        }

        if (!Page.IsPostBack)
        {
            FillSectionDetails();
        }
    }

    private void FillSectionDetails()
    {
        try
        {
            if (!string.IsNullOrEmpty(Session["admin"] as string))
            {

                strQuery = @"SELECT * FROM tbl_AdminLoginDetails where username='" + Session["username1"].ToString() + "'";

                dTable = new DataTable();
                dTable = BasicFunction.GetDetailsByDatatable(strQuery);

                if (dTable.Rows.Count > 0)
                {
                    //strQuery = @"SELECT * from tbl_CMS_Sections where id in (" + dTable.Rows[0]["Section"].ToString() + ")";
					
					strQuery = @"SELECT * from tbl_CMS_Sections";

                    dTableSeCtions = new DataTable();
                    dTableSeCtions = BasicFunction.GetDetailsByDatatable(strQuery);

                    rptrSections.DataSource = dTableSeCtions;
                    rptrSections.DataBind();
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.StackTrace);
        }

    }
}