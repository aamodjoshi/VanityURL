<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="cms_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vanity URL CMS</title>
    <link id="bscss" href="css/bootstrap-cerulean.css" rel="stylesheet" />
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
    <link href="css/jquery-ui-1.8.21.custom.css" rel="stylesheet" />
</head>
<body>
    <script language="javascript" type="text/javascript">
        function regcaptchaclear() {
            if (document.getElementById('<%=txtImg.ClientID%>').value == "Enter the captcha code") {
                document.getElementById('<%=txtImg.ClientID%>').value = "";
                return true;
            }
        }
        function regcaptchadefault() {
            if (document.getElementById('<%=txtImg.ClientID%>').value == "") {
                document.getElementById('<%=txtImg.ClientID %>').value = "Enter the captcha code";
                return true;
            }
        }

    </script>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="row-fluid">
                    <div class="span12 center login-header">
                        <h2>ADMIN PANEL</h2>
                    </div>
                    <!--/span-->
                </div>
                <!--/row-->
                <div class="row-fluid">
                    <div class="well span5 center login-box">
                        <div class="alert alert-info">
                            Please login with your Username and Password.
                        </div>
                        <form class="form-horizontal" action="index.html" method="post">
                            <fieldset>
                                <div class="input-prepend" title="Username" data-rel="tooltip">
                                    <span class="add-on"><i class="icon-user"></i></span>
                                    <input autofocus class="input-large span10" name="username" id="txtusername" type="text" placeholder="Username" runat="server" autocomplete="off" />
                                    <asp:RequiredFieldValidator ID="RV1" runat="server" ControlToValidate="txtusername"
                                        ErrorMessage="Please Enter User Name" SetFocusOnError="True" ForeColor="Yellow">*
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="clearfix"></div>
                                <div class="input-prepend" title="Password" data-rel="tooltip">
                                    <span class="add-on"><i class="icon-lock"></i></span>
                                    <input class="input-large span10" name="password" id="txtpassword" type="password" placeholder="Password" runat="server" autocomplete="off" />
                                    <asp:RequiredFieldValidator ID="RV2" runat="server" ControlToValidate="txtpassword"
                                        ErrorMessage="Please Enter Your Password" SetFocusOnError="True" ForeColor="Yellow">*
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txtImg" MaxLength="6" CssClass="newUserForm" Text="Enter the captcha code" onclick="return regcaptchaclear();" onblur="return regcaptchadefault();" />
                                    <asp:Image ID="imgCaptcha" runat="server" Style="vertical-align: bottom;" />
                                </div>
                                <div class="clearfix"></div>
                                <div class="input-prepend">
                                    <label class="remember" for="remember">
                                        <p><a href="forgot-password.aspx">Forgot your Password?</a></p>
                                </div>
                                <div class="clearfix"></div>
                                <p class="center span5">
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                </p>
                                <p class="center span5">
                                    <asp:Button ID="submit" runat="server" Text="Login" OnClick="submit_Click" />
                                </p>
                            </fieldset>
                        </form>
                    </div>
                    <!--/span-->
                </div>
                <!--/row-->
            </div>
            <!--/fluid-row-->
        </div>
    </form>
</body>
</html>
