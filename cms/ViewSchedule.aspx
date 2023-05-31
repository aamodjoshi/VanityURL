<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSchedule.aspx.cs" Inherits="cms_ViewSchedule" %>

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
                <div id="content" class="span9">
                    <div class="row-fluid sortable">
                        <div class="box span12">
                            <div class="box-content">
                                <fieldset>
                                    <legend>VIEW SCHEDULE</legend>
                                    <div>
                                        <asp:Button ID="btnAccept" runat="server" Text="Enable" Width="100px" OnClick="btnAccept_Click" />
                                        <asp:Button ID="btnReject" runat="server" Text="Disable" Width="100px" OnClick="btnReject_Click" />
                                        <asp:Button ID="btnAdd" runat="server" Text="Add Schedule" Width="120px" OnClick="btnAdd_Click" />
                                    </div>
                                    <br />
                                    <div class="EU_TableScroll" id="showData" style="display: block">
                                        <asp:GridView ID="GridView1" runat="server" Width="100%" EnableModelValidation="True" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" PageSize="30" EmptyDataText="No records Found" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EventName" HeaderText="Event Name" />
                                                <asp:BoundField DataField="Date" HeaderText="Event Date" DataFormatString="{0:yyyy-MM-dd}" />
                                                <asp:BoundField DataField="StartTime" HeaderText="Start Time" />
                                                <asp:BoundField DataField="EndTime" HeaderText="End Time" />
                                                <asp:BoundField DataField="Location" HeaderText="Location" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                                <asp:BoundField DataField="UrlLink" HeaderText="Url Link" />
                                                <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:yyyy-MM-dd hh:mm}" />
                                                <asp:BoundField DataField="UpdatedAt" HeaderText="Updated At" DataFormatString="{0:yyyy-MM-dd hh:mm}" />
                                                <asp:BoundField DataField="flag" HeaderText="Status" />
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
                            </div>
                        </div>
                    </div>
                    <!--/row-->
                    <!-- content ends -->
                </div>
                <!--/#content.span10-->
            </div>
            <!--/fluid-row-->
            <hr />
            <!-- footer starts -->
            <!-- footer ends -->
        </div>
    </form>
</body>
</html>
