<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUserList.aspx.cs" Inherits="cms_EditUserList" %>

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

        label {
            display: inline-block;
        }
    </style>
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/charisma-app.css" rel="stylesheet" />
    <link href='css/uniform.default.css' rel='stylesheet' />
    <link href='css/uploadify.css' rel='stylesheet' />
    <script type="text/javascript">
        function fnviewimage() {

            window.open(document.getElementById('txtimagepath').value, "view", "scrollbars=no,resizable=yes,width=300,height=200");

            return false;
        }
        function fnviewimage1() {

            window.open(document.getElementById('txtimagepath1').value, "view", "scrollbars=no,resizable=yes,width=300,height=200");

            return false;
        }
        function fnviewimage2() {

            window.open(document.getElementById('txtimagepath2').value, "view", "scrollbars=no,resizable=yes,width=300,height=200");

            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- topbar starts -->
        <ucheader:header ID="header" runat="server" />
        <!-- topbar ends -->
        <div class="container-fluid">
            <div class="row-fluid">
                <!-- left menu starts -->
                <ucleftnav:LeftNav ID="LeftNavigation" runat="server" />
                <!-- left menu ends -->
                <div id="content" class="span10">
                    <div class="row-fluid sortable">
                        <div class="box span12">
                            <div class="box-content">
                                <form class="form-horizontal" id="form2">
                                    <fieldset>
                                        <legend>Edit User Details</legend>
                                        <table>

                                            <tr>
                                                <td>
                                                    <label class="control-label" for="typeahead">
                                                        Name
                                                        <span style="color: red">*</span>
                                                    </label>
                                                </td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                                    <br />
                                                    <asp:Label ID="lblNameErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3"></td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="control-label" for="typeahead">
                                                        Email Id
                                                        <span style="color: red">*</span>
                                                    </label>
                                                </td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                    <br />
                                                    <asp:Label ID="lblEmailErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3"></td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>

                                          
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3"></td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="control-label" for="typeahead">
                                                        User Name  
                                                        <span style="color: red">*</span>
                                                    </label>
                                                </td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>

                                                    <br />
                                                    <asp:Label ID="lblUsername" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                                                <td class="auto-style2"></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td class="auto-style1">&nbsp;</td>
                                                <td class="auto-style3"></td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td>Password</td>
                                                <td class="auto-style1"></td>
                                                <td class="auto-style3">
                                                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                                    <br />
                                                    <asp:Label ID="lblPassword" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>Sections</td>
                                                <td class="auto-style1"></td>
                                                <td class="auto-style3">
                                                    <%--<asp:TextBox ID="txtSections" runat="server"></asp:TextBox>--%>
                                                    <asp:CheckBox ID="chkAll" Text="Select All" runat="server" OnCheckedChanged="Check_UnCheckAll" AutoPostBack="true" TextAlign="Right" />
                                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                                                    <br />
                                                    <asp:Label ID="lblsections" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                                                <td class="auto-style2">&nbsp;</td>
                                            </tr>

                                        </table>
                                        <div class="form-actions">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
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
