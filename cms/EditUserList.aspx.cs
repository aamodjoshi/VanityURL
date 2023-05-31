using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class cms_EditUserList : System.Web.UI.Page
{
    static int id;
    string strQuery = "";
    DataTable dTable;
    SqlConnection con = new SqlConnection(BasicFunction.GetConnectionstring());

 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            id = Convert.ToInt32(BasicFunction.Decrypt(Request.QueryString["id"].ToString()));
        }
        if (!Page.IsPostBack)
        {
            GetSection();
            if (string.IsNullOrEmpty(Session["admin"] as string))
            {
                Response.Redirect("Login.aspx");
            }
            ShowAdminDetails();
        }
    }

    private void ShowAdminDetails()
    {

        strQuery = @"SELECT * FROM tbl_AdminLoginDetails where Id=" + id;
        dTable = new DataTable();
        dTable = BasicFunction.GetDetailsByDatatable(strQuery);

        if (dTable.Rows.Count > 0)
        {
            txtName.Text = dTable.Rows[0]["Name"].ToString();
            txtEmail.Text = dTable.Rows[0]["EmailId"].ToString();
            //drplistAdminType.SelectedValue = dTable.Rows[0]["AdminType"].ToString();
            txtUserName.Text = BasicFunction.Decrypt(dTable.Rows[0]["UserName"].ToString());
            txtPassword.Text = BasicFunction.Decrypt(dTable.Rows[0]["Password"].ToString());
            //txtSections.Text = dTable.Rows[0]["Section"].ToString();
            string[] section = dTable.Rows[0]["Section"].ToString().Split(',');
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                for (int j = 0; j < section.Length; j++)
                {
                    if (section[j] == CheckBoxList1.Items[i].Value)
                    {
                        CheckBoxList1.Items[i].Selected = true;
                    }
                }

            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (isValidate())
        {
            con.Open();
            SqlCommand cmd_Update = new SqlCommand("tbl_AdminLoginDetails_Update", con);
            cmd_Update.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd_Update.Parameters.AddWithValue("@Id", id);
                cmd_Update.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd_Update.Parameters.AddWithValue("@EmailId", txtEmail.Text.Trim());
                //cmd_Update.Parameters.AddWithValue("@AdminType", drplistAdminType.SelectedValue);
                cmd_Update.Parameters.AddWithValue("@UserName", BasicFunction.Encrypt(txtUserName.Text));
                cmd_Update.Parameters.AddWithValue("@Password", BasicFunction.Encrypt(txtPassword.Text));

                string selected_section = "";
                foreach (ListItem lst in CheckBoxList1.Items)
                {
                    if (lst.Selected == true)
                    {
                        if (selected_section == "")
                        {
                            selected_section = lst.Value;
                        }
                        else
                        {
                            selected_section += "," + lst.Value;
                        }

                    }
                }

                cmd_Update.Parameters.AddWithValue("@Section", selected_section.Trim());

                cmd_Update.ExecuteNonQuery();
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
            Response.Redirect("ViewUserList.aspx");
        }
    }

    public bool isValidate()
    {
        resetErrorMessage();
        if (txtName.Text.Trim() == "")
        {
            lblNameErrorMessage.Text = "Please enter name.";
            txtName.Focus();
            return false;
        }

        if (!BasicFunction.ValidateName(txtName.Text.Trim()))
        {
            lblNameErrorMessage.Text = "Please enter valid name.";
            return false;
        }

        if (txtEmail.Text.Trim() == "")
        {
            lblEmailErrorMessage.Text = "Please enter email id.";
            txtEmail.Focus();
            return false;
        }

        if (!BasicFunction.ValidateEmail(txtEmail.Text.Trim()))
        {
            lblEmailErrorMessage.Text = "Please enter valid email id.";
            return false;
        }
        //if (drplistAdminType.SelectedItem.Value == "Select Admin")
        //{
        //    lblAdminErrorMessage.Text = "Please select Admin type";
        //    return false;
        //}

        if (txtUserName.Text.Trim() == "")
        {
            lblUsername.Text = "Please enter User Name";
            return false;
        }

        SqlDataAdapter adpt_Username = new SqlDataAdapter("select * from tbl_AdminLoginDetails where Id!=" + id + " and UserName='" + BasicFunction.Encrypt(txtUserName.Text.Trim()) + "'", con);
        DataTable dt_Username = new DataTable();
        adpt_Username.Fill(dt_Username);
        if (dt_Username.Rows.Count > 0)
        {
            lblUsername.Text = "Username already exists.";
            return false;
        }

        if (txtPassword.Text.Trim() == "")
        {
            lblPassword.Text = "Please enter Password";
            return false;
        }

        if (txtPassword.Text.Trim().Length < 8)
        {
            lblPassword.Text = "Password is too short!";
            return false;
        }
        if (!Regex.IsMatch(txtPassword.Text.Trim(), @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,10}"))
        {
            lblPassword.Text = "Entered password must contain 1 upper character,1 lower character,1 special character and 1 number.";
            return false;
        }

        int atLeast = 1;
        int count = 0;
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.SelectedIndex == i)
            {
                count++;
            }
        }
        if (atLeast > count)
        {
            lblsections.Text = "Please select at least " + atLeast + "section(s).";
            return false;
        }
        //if (txtSections.Text.Trim() == "")
        //{
        //    lblsections.Text = "Please enter Section";
        //}

        return true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewuserlist.aspx");
    }

    public void resetErrorMessage()
    {
        lblNameErrorMessage.Text = "";
        lblEmailErrorMessage.Text = "";
        //lblAdminErrorMessage.Text = "";
        lblUsername.Text = "";
        lblPassword.Text = "";
        lblsections.Text = "";
    }

    public void GetSection()
    {
        SqlDataAdapter adpt_section = new SqlDataAdapter("select * from tbl_CMS_Sections where Flag='T' order by SectionName", con);
        DataTable dt_section = new DataTable();
        adpt_section.Fill(dt_section);
        if (dt_section.Rows.Count > 0)
        {
            CheckBoxList1.DataSource = dt_section;
            CheckBoxList1.DataTextField = "SectionName";
            CheckBoxList1.DataValueField = "Id";
            CheckBoxList1.DataBind();
        }
    }

    protected void Check_UnCheckAll(object sender, EventArgs e)
    {
        foreach (ListItem item in CheckBoxList1.Items)
        {
            item.Selected = chkAll.Checked;
        }
    }
}