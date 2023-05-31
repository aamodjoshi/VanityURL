<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewUserList.aspx.cs" Inherits="cms_ViewUserList" %>

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
    </style>
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/charisma-app.css" rel="stylesheet" />
    <link href='css/uniform.default.css' rel='stylesheet' />
    <link href='css/uploadify.css' rel='stylesheet' />
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
                                        <legend>View Login Details</legend>
                                        <div>
                                            <asp:Button ID="btnAccept" runat="server" Text="Accept" Width="100px" OnClick="btnAccept_Click" />
                                            <asp:Button ID="btnReject" runat="server" Text="Reject" Width="100px" OnClick="btnReject_Click" />
                                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                                        </div>
                                        <div class="EU_TableScroll" id="showData" style="display: block">
                                            <asp:GridView ID="GridView1" runat="server" Width="100%" EnableModelValidation="True" AutoGenerateColumns="False" DataKeyNames="Id" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">

                                                <EmptyDataTemplate>
                                                    <div style="color: red; text-align: center;">
                                                        No Data Available

                                                    </div>

                                                </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <%--<asp:BoundField DataField="EmailId" HeaderText="Email Id" />--%>

                                                    <%--<asp:BoundField DataField="UserName" HeaderText="User Name" />--%>

                                                   <%-- <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Section") %>'></asp:HiddenField>
                                                            <asp:Label ID="lblSection" runat="server" Text='<%#Eval("Section") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>


                                                    <asp:BoundField DataField="Flag" HeaderText="Flag" />
                                                    <asp:TemplateField HeaderText="Accept/Reject">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="5%" BackColor="#FFFFFF" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnEdit" runat="server" OnClick="lnkbtnEdit_Click">Edit</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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

