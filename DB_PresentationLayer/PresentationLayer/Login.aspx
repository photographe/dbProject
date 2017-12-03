<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DB_PresentationLayer.PresentationLayer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 625px; font-size: x-large; background-image: url('../Images/Untitled-1.jpg'); width: 1304px; margin-left: 2px; background-attachment: scroll; background: url('../Images/Untitled-1.jpg') center; margin-top: 0px">
        <asp:Menu ID="Menu1" runat="server" BackColor="#003300" BorderColor="#333300" BorderWidth="1px" Font-Size="X-Large" ForeColor="White" Orientation="Horizontal" Width="1300px" Font-Names="Calibri">
                <DynamicMenuItemStyle BorderColor="Yellow" />
                <Items>
                    <asp:MenuItem Text="TAXI" Value="TAXI COMPARISON"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Login.aspx" Text="Login" Value="Login"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="registration.aspx" Text="Register Profile" Value="Login"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Contact.aspx" Text="Contact" Value="Logoff"></asp:MenuItem>
                </Items>
            </asp:Menu>
        <p style="margin-left: 200px">
            <asp:Label ID="Label1" runat="server" Text="User Name" Font-Names="Calibri"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </p>
        <div style="margin-left: 200px">
            <asp:Label ID="Label2" runat="server" Text="Password" Font-Names="Calibri"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <p style="margin-left: 280px">
            <asp:Button ID="cmdLogin" runat="server" OnClick="Button1_Click" Text="Log In" />
        </p>
        </div>
    </form>
</body>
</html>
