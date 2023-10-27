<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="smVIEW.aspx.cs" Inherits="DBM.smVIEW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button1" runat="server" Text="all requests" Height="91px" OnClick="allreq" Width="230px" />

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBMConnectionString %>" SelectCommand="allPendingRequestsfun" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="stadiumManagerUsername" SessionField="smuser" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:Button ID="acce" runat="server" Text="accepts" Enabled="false" OnClick="acce_Click" />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="matchID" DataValueField="matchID">
            </asp:DropDownList>

        </div>
                <br />

            <asp:Button ID="rejeq" runat="server" Text="rejects" Enabled="false" OnClick="rejeq_Click"/>
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="matchID" DataValueField="matchID">
        </asp:DropDownList>
        <br /><br /><br />
        <asp:Button ID="Button6" runat="server" Text="logout" OnClick="Button6_Click" />
    </form>
</body>
</html>
