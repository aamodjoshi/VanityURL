<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="cms_Default" %>

<%@ Register TagName="header" Src="include/header.ascx" TagPrefix="ucheader" %>
<%@ Register TagName="footer" Src="include/footer.ascx" TagPrefix="ucfooter" %>
<%@ Register TagName="LeftNav" Src="include/LeftNavigation.ascx" TagPrefix="ucleftnav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <ucheader:header id="header" runat="server" />
        <div class="container-fluid">
            <div class="row-fluid">

                <!-- left menu starts -->

                <ucleftnav:LeftNav ID="LeftNavigation" runat="server" />
            </div>
        </div>
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
    </form>
</body>
</html>
