<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change-password.aspx.cs" Inherits="cms_change_password" %>


<%@ Register TagName="header" Src="include/header.ascx" TagPrefix="ucheader" %>
<%@ Register TagName="footer" Src="include/footer.ascx" TagPrefix="ucfooter" %>
<%@ Register TagName="LeftNav" Src="include/LeftNavigation.ascx" TagPrefix="ucleftnav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Vanity URL CMS</title>
    <link href="css/bootstrap-cerulean.css" rel="stylesheet" />
    <style type="text/css">
        body {
            padding-bottom: 40px;
        }

        .sidebar-nav {
            padding: 9px 0;
        }

        .auto-style1 {
            width: 36px;
        }

        .auto-style2 {
            width: 130px;
        }

        .auto-style3 {
            width: 369px;
        }
    </style>
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/charisma-app.css" rel="stylesheet" />
    <link href='css/uniform.default.css' rel='stylesheet' />
    <link href='css/uploadify.css' rel='stylesheet' />

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- topbar starts -->
        <ucheader:header ID="header" runat="server" />
        <!-- topbar ends -->
        <div class="container-fluid">
            <div class="row-fluid">
                <!-- left menu starts -->
               <ucleftnav:LeftNav ID="LeftNavigation" runat="server" />
                <!-- left menu ends -->
                <div id="content" class="span9">
                    <div class="row-fluid sortable">
                        <div class="box span12">
                            <div class="box-content">
                                <form class="form-horizontal" id="form2">
                                    <fieldset>
                                        <legend>Forgot Password</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="control-label" for="typeahead">
                                                       Old Password
                                                        <span style="color: red">*</span>
                                                    </label>
                                                </td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtOldPsw" runat="server" Width="500"></asp:TextBox>
                                                    <br />
                                                    <asp:Label ID="lblUserName" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <div>
                                                    </div>
                                                    <div>
                                                    </div>
                                                    <div>
                                                    </div>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <label class="control-label" for="typeahead">
                                                       New Password
                                                        <span style="color: red">*</span>
                                                    </label>
                                                </td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtNewPsw" runat="server" Width="500"></asp:TextBox>
                                                    <br />
                                                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <div>
                                                    </div>
                                                    <div>
                                                    </div>
                                                    <div>
                                                    </div>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <label class="control-label" for="typeahead">
                                                      Confirm Password
                                                        <span style="color: red">*</span>
                                                    </label>
                                                </td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtConfirmPsw" runat="server" Width="500"></asp:TextBox>
                                                    <br />
                                                    <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    <div>
                                                    </div>
                                                    <div>
                                                    </div>
                                                    <div>
                                                    </div>
                                                </td>
                                            </tr>


                                        </table>
                                        <div class="form-actions">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                            
                                        </div>
                                    </fieldset>
                                </form>

                            </div>
                        </div>
                        <!--/span-->
                    </div>
                    <!--/row-->
                    <!-- content ends -->
                </div>
                <!--/#content.span10-->
            </div>
            <!--/fluid-row-->
            <hr />
            <div class="modal hide fade" id="myModal">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h3>Settings</h3>
                </div>
                <div class="modal-body">
                    <p>Here settings can be configured...</p>
                </div>
                <div class="modal-footer">
                    <a href="#" class="btn" data-dismiss="modal">Close</a>
                    <a href="#" class="btn btn-primary">Save changes</a>
                </div>
            </div>
            <ucfooter:footer ID="footer" runat="server" />
        </div>
    </form>
</body>
</html>
