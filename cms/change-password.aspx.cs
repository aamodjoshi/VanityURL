using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_change_password : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(BasicFunction.GetConnectionstring());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["admin"] as string))
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (isValidate())
        {
            con.Open();
            SqlCommand cmd_Update = new SqlCommand("sp_CMS_Password_Update", con);
            cmd_Update.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd_Update.Parameters.AddWithValue("@UserName", Session["username1"].ToString());
                cmd_Update.Parameters.AddWithValue("@Password", BasicFunction.Encrypt(txtNewPsw.Text.Trim()));

                cmd_Update.ExecuteNonQuery();

                //Response.Redirect("viewinvestor.aspx");

                BasicFunction.Show1("Password changed successfully");

                txtConfirmPsw.Text = "";
                txtNewPsw.Text = "";
                txtOldPsw.Text = "";
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

    private bool isValidate()
    {
        if (string.IsNullOrEmpty(txtOldPsw.Text.Trim()))
        {
            BasicFunction.Show1("Please enter old password");
            txtOldPsw.Focus();
            return false;
        }
        if (BasicFunction.IsSQLCharPresent(txtOldPsw.Text.Trim()))
        {
            BasicFunction.Show1("Please enter valid old password");
            txtOldPsw.Focus();
            return false;
        }

        if (!string.IsNullOrEmpty(Session["username1"].ToString()))
        {

            //Response.Write("select * from tbl_AdminLoginDetails where UserName='" + Session["username1"].ToString() + "' and Password='" + txtOldPsw.Text.Trim() + "'");

            DataTable dt = BasicFunction.GetDetailsByDatatable("select * from tbl_AdminLoginDetails where UserName='" + Session["username1"].ToString() + "' and Password='" + BasicFunction.Encrypt(txtOldPsw.Text.Trim()) + "'");

            //Response.Write("select * from tbl_AdminLoginDetails where UserName='" + Session["username1"].ToString() + "' and Password='" + BasicFunction.Encrypt(txtOldPsw.Text.Trim()) + "'");

            if (dt.Rows.Count < 1)
            {
                BasicFunction.Show1("Incorrect old password");
                txtOldPsw.Focus();
                return false;
            }
        }
        if (string.IsNullOrEmpty(txtNewPsw.Text.Trim()))
        {
            BasicFunction.Show1("Please enter new password");
            txtNewPsw.Focus();
            return false;
        }
        if (BasicFunction.IsSQLCharPresent(txtNewPsw.Text.Trim()))
        {
            BasicFunction.Show1("Please enter valid new password");
            txtNewPsw.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtConfirmPsw.Text.Trim()))
        {
            BasicFunction.Show1("Please enter confirm password");
            txtConfirmPsw.Focus();
            return false;
        }
        if (BasicFunction.IsSQLCharPresent(txtConfirmPsw.Text.Trim()))
        {
            BasicFunction.Show1("Please enter valid confirm password");
            txtConfirmPsw.Focus();
            return false;
        }
        if (txtNewPsw.Text.Trim() != txtConfirmPsw.Text.Trim())
        {
            BasicFunction.Show1("Confirm password does not match with new password");
            txtConfirmPsw.Focus();
            return false;
        }

        return true;
    }
}