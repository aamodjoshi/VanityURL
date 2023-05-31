<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftNavigation.ascx.cs" Inherits="include_LeftNavigation" %>
<div class="span2 main-menu-span">
    <div class="well nav-collapse sidebar-nav">
        <%-- <% if (BasicFunction.Encrypt(Session["username1"].ToString()) == BasicFunction.Encrypt("zhDpDTQQRrOXAJFyB/AGbQ==").ToString())
           { %>--%>

        <ul class="nav nav-tabs nav-stacked main-menu">
            <li class="nav-header hidden-tablet">Menu</li>

            <li runat="server" id="hrefSuperAdmin"><a class="ajax-link" href="ViewUserList.aspx"><i></i><span class="hidden-tablet">View UserList</span></a></li>
            <li ><a class="ajax-link" href="change-password.aspx"><i></i><span class="hidden-tablet">Change Password</span></a></li>
            <asp:Repeater ID="rptrSections" runat="server">
                <ItemTemplate>
                   <li><a class="ajax-link" href='<%#Eval("PageName") %>'><i></i><span class="hidden-tablet"><%#Eval("SectionName") %></span></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <%-- <% } %>--%>
    </div>
    <!--/.well -->
</div>
