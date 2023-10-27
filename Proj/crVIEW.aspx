<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crVIEW.aspx.cs" Inherits="DBM.crVIEW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button3" runat="server" Text="all upcoming matches" OnClick="aumc"/>
            <asp:Button ID="Button4" runat="server" Text="availabe stadium" OnClick="avs" /> 
            <asp:TextBox ID="dateforav"  runat="server"> </asp:TextBox>
            <asp:Label ID="ldateforav" runat="server"  Text="insert date"></asp:Label> 
            <br />
         <br />
         <br />
         <br />
            </div>
               <div>
                   <asp:Button ID="Button1" runat="server" Text="send request" OnClick="Button1_Click" />
                   <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
                   </asp:DropDownList>
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBMConnectionString %>" SelectCommand="viewAvailableStadiumsOnfun" SelectCommandType="StoredProcedure">
                       <SelectParameters>
                           <asp:SessionParameter Name="date" SessionField="crviewdatestad" Type="DateTime" />
                       </SelectParameters>
                   </asp:SqlDataSource>
                   <asp:Label ID="Label1" runat="server" Text="chose stadium you are sending the request for"></asp:Label>
          </div> 
        <br />
        chose match id you are sending the request for after seeing matches&#39;s IDs in all upcoming matches<br />

                <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource2" DataTextField="matchID" DataValueField="startTime">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBMConnectionString %>" SelectCommand="upcomingMatchesOfClubreq" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="clubname" SessionField="clubname" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

                <br /><br /><br /><br />
        <asp:Button ID="Button6" runat="server" Text="logout" OnClick="Button6_Click" />
    </form>
</body>
</html>
