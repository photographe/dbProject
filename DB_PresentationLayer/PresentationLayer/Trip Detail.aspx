<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trip Detail.aspx.cs" Inherits="DB_PresentationLayer.PresentationLayer.Trip_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 625px; font-size: x-large; background-image: url('../Images/Untitled-1.jpg'); width: 1304px; margin-left: 2px; background-attachment: scroll; background: url('../Images/Untitled-1.jpg') center; margin-top: 0px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
            <br />
            <asp:Menu ID="Menu1" runat="server" BackColor="#003300" BorderColor="#333300" BorderWidth="1px" Font-Size="X-Large" ForeColor="White" Orientation="Horizontal" Width="1300px" Font-Names="Calibri">
                <Items>
                    <asp:MenuItem Text="Trip Detail Page" Value="Trip Detail Page"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Profile.aspx" Text="MY PROFILE" Value="Profile"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="bookingpage.aspx" Text="BOOK" Value="booking"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="bookingpage.aspx" Text="COMPARE" Value="booking"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Contact.aspx" Text="CONTACT" Value="Logoff"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Thankyou.aspx" Text="LOG OFF" Value="Logoff"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <p>

                <asp:DataList ID="dlstTripDetail" runat="server" CellPadding="4" ForeColor="#333333">
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TripTable]"></asp:SqlDataSource>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Button" />

            </p>
        </div>
    </form>
</body>
</html>
