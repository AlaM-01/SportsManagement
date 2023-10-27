<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fanVIEW.aspx.cs" Inherits="DBM.fanview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="insert date to get available matches"></asp:Label>
        &nbsp;&nbsp; (clicking on &quot;get matches&quot; button without inserting a date will resultin a system crash)&nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
        <asp:TextBox ID="getmatch" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Get matches" OnClick="Getmatch" style="height: 29px" />
      
        <div>
            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp; insert match id to purchase the ticket<br />
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="purchase ticket" />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="matchID" DataValueField="matchID" style="margin-left: 26px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBMConnectionString %>" SelectCommand="availableMatchesToAttendfun" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="date" SessionField="datefan" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>
       <div> 
                   <br /><br /><br /><br />
        <asp:Button ID="Button6" runat="server" Text="logout" OnClick="Button6_Click" />
       </div>
    </form>
</body>
</html>
