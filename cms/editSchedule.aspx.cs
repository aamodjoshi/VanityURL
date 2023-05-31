using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_editSchedule : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(BasicFunction.GetConnectionstring());

    string str = string.Empty;
    static string sThumbImage = "";
    int Id;
    string strQuery = "";
    DataTable dTable;
    static string sImage = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["admin"] as string))
        {
            Response.Redirect("Login.aspx");
        }

        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            Id = Convert.ToInt32(BasicFunction.Decrypt(Request.QueryString["id"].ToString()));
        }

        if (!Page.IsPostBack)
        {
            ShowSchedule();
        }
    }

    private void ShowSchedule()
    {
        strQuery = @"select * from tblSchedule where id='" + Id + "'";

        dTable = new DataTable();
        dTable = BasicFunction.GetDetailsByDatatable(strQuery);

        if (dTable.Rows.Count > 0)
        {
            txtEventName.Text = dTable.Rows[0]["EventName"].ToString();
            txtEventDate.Text = Convert.ToDateTime(dTable.Rows[0]["Date"].ToString()).ToString("yyyy-MM-dd"); ;
            txtEventStartTime.Text = dTable.Rows[0]["StartTime"].ToString();
            txtEventEndTime.Text = dTable.Rows[0]["EndTime"].ToString();
            txtEventLocation.Text = dTable.Rows[0]["Location"].ToString();
            txtEventDescription.Text = dTable.Rows[0]["Description"].ToString();
            txtEventUrlLink.Text = dTable.Rows[0]["UrlLink"].ToString();
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewSchedule.aspx");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isValidate())
        {
            con.Open();
            SqlCommand cmd_Update = new SqlCommand("sp_CMS_Schedule_Update", con);
            cmd_Update.CommandType = CommandType.StoredProcedure;
            try
            {

                cmd_Update.Parameters.AddWithValue("@EventName", txtEventName.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@Date", txtEventDate.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@StartTime", txtEventStartTime.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@EndTime", txtEventEndTime.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@Location", txtEventLocation.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@Description", txtEventDescription.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@UrlLink", txtEventUrlLink.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@Id", Id);

                cmd_Update.ExecuteNonQuery();

                Response.Redirect("ViewSchedule.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                cmd_Update.Dispose();
                con.Close();
                con.Dispose();
            }
        }
    }

    public bool isValidate()
    {
        lblEventName.Text = "";

        if (string.IsNullOrEmpty(txtEventName.Text.Trim()))
        {
            lblEventName.Text = "Please enter Event Name.";
            return false;
        }



        return true;
    }
}