<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DB_PresentationLayer.PresentationLayer.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 711px">
    <form id="form1" runat="server">
        <div style="background-repeat: no-repeat; background-image: url('../Images/Untitled-1.jpg'); background: #FFFFFF url('../Images/Untitled-1.jpg') center; margin-left: 0px; height: 623px; margin-top: 0px; width: 1305px; border-bottom-color: #000000; font-size: x-large;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Menu ID="Menu1" runat="server" BackColor="#003300" BorderColor="#333300" BorderWidth="1px" Font-Size="X-Large" ForeColor="White" Orientation="Horizontal" Width="1300px" Font-Names="Calibri">
                <Items>
                    <asp:MenuItem Text="TAXI" Value="TAXI COMPARISON"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Login.aspx" Text="Login" Value="Login"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Profile.aspx" Text="Update Profile" Value="Login"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="bookingpage.aspx" Text="Book" Value="New Item"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="bookingpage.aspx" Text="Compare" Value="Compare"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Contact.aspx" Text="Contact" Value="Logoff"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Thankyou.aspx" Text="Logoff" Value="Logoff"></asp:MenuItem>
                </Items>
            </asp:Menu>
&nbsp;&nbsp;<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <div style="border: #FFFFFF; height: 353px; background: #FFFFFF center; width: 1304px;">
            <strong>&nbsp; <span class="auto-style1">Name</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1">Address</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" height="25px" width="168px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;</strong><br />
            <br />
            <strong>&nbsp; <span class="auto-style1">Email</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CausesValidation="True" height="25px" width="168px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <span class="auto-style1">Contribute</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtContribute" runat="server" height="25px" width="168px"></asp:TextBox>
            <br />
            </strong>
            <br />
            <strong>&nbsp;<span class="auto-style1">Username</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserName" runat="server" height="25px" width="168px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style1">Add Review</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtReview" runat="server" Height="25px" width="168px"></asp:TextBox>
            </strong>
            <br />
            <br />
            <strong>&nbsp;&nbsp;<span class="auto-style1">Password</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" height="25px" width="168px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chkMakeDefault" runat="server"/>
            </strong>&nbsp;<strong><asp:Label ID="lblMakeDefault" runat="server" Text="Make default " Font-Bold="False" Font-Names="Calibri"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </strong>
            <br />
            <br />
            &nbsp;&nbsp;<strong><span class="auto-style1">Phone</span></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" CausesValidation="True" height="25px" width="168px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="cmdSave" runat="server" Text="Save" font-size=20px OnClick="cmdSave_Click" Height="39px" Width="151px" />
            &nbsp;
            <br />
        </div>
            <br />
            &nbsp;&nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;<br />
            </strong>
            <br />
            <br />
            &nbsp;&nbsp;<br />
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
    </form>
</body>
</html>
