using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class cms_ViewSchedule : System.Web.UI.Page
{
    string strQuery = "";
    DataTable dTable;
    SqlConnection con = new SqlConnection(BasicFunction.GetConnectionstring());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty(Session["admin"] as string))
            {
                Response.Redirect("Login.aspx");
            }
            ShowSchedule();
        }
    }

    private void ShowSchedule()
    {
        strQuery = @"select * from tblSchedule order by id desc";

        dTable = new DataTable();
        dTable = BasicFunction.GetDetailsByDatatable(strQuery);

        GridView1.DataSource = dTable;
        GridView1.DataBind();
    }

    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtnActivate;
        lnkbtnActivate = (sender) as LinkButton;
        GridViewRow row = lnkbtnActivate.NamingContainer as GridViewRow;

        string id = GridView1.DataKeys[row.RowIndex].Value.ToString();

        if (id != "")
        {
            Response.Redirect("editSchedule.aspx?id=" + BasicFunction.Encrypt(id));
        }
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        try
        {
            int chkcount = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lblid = (Label)GridView1.Rows[i].FindControl("lblId");
                CheckBox CheckBox1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

                if (CheckBox1.Checked)
                {
                    chkcount += 1;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update tblSchedule set flag='T' where id='" + lblid.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
            }
            if (chkcount == 0)
            {
                ClientScript.RegisterStartupScript(typeof(string), "trkey", "alert('Select atleast one record for approving');", true);
            }
            ShowSchedule();
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
        finally
        {
            //ebal = null;
            con.Close();
        }
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {
            int chkcount = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lblid = (Label)GridView1.Rows[i].FindControl("lblId");
                CheckBox CheckBox1 = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

                if (CheckBox1.Checked)
                {
                    chkcount += 1;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update tblSchedule set flag='F' where id='" + lblid.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
            }
            if (chkcount == 0)
            {
                ClientScript.RegisterStartupScript(typeof(string), "trkey", "alert('Select atleast one record For rejecting.');", true);
            }
            ShowSchedule();
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
        finally
        {
            //ebal = null;
            con.Close();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[10].Text == "F")
            {
                e.Row.Cells[10].Text = "Inactive";
                e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                e.Row.Cells[10].Text = "Active";
                e.Row.Cells[10].ForeColor = System.Drawing.Color.Green;
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ShowSchedule();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("addSchedule.aspx");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}