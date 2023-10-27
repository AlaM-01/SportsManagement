<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saVIEW.aspx.cs" Inherits="DBM.saVIEW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button1" runat="server" Text="add club" OnClick="addclub" />

            <asp:Label ID="Label1" runat="server" Text="name"></asp:Label>
            <asp:TextBox ID="sacname" runat="server"></asp:TextBox>

              <asp:Label ID="Label2" runat="server" Text="location"></asp:Label>
            <asp:TextBox ID="sacloc" runat="server"></asp:TextBox>

            <br /><br /><br /><br />
        </div>

           <div>
            <asp:Button ID="Button2" runat="server" Text="delete club" OnClick="delclub" />

            <asp:Label ID="Label3" runat="server" Text="name"></asp:Label>
               <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name">
               </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBMConnectionString %>" SelectCommand="SELECT [name] FROM [allCLubs]"></asp:SqlDataSource>

            <br /><br /><br /><br />
        </div>
          <div>

       <asp:Button ID="Button3" runat="server" Text="add stadium"  OnClick="addstadium"/>

            <asp:Label ID="Label5" runat="server" Text="name"></asp:Label>
            <asp:TextBox ID="sasname" runat="server"></asp:TextBox>

              <asp:Label ID="Label6" runat="server" Text="location"></asp:Label>
            <asp:TextBox ID="sasloc" runat="server"></asp:TextBox>

          <asp:Label ID="Label7" runat="server" Text="capacity"></asp:Label>
            <asp:TextBox ID="sacap" runat="server"></asp:TextBox>
            <br /><br /><br /><br />
        </div>
            <div>

       <asp:Button ID="Button4" runat="server" Text="delete stadium" OnClick="delstadd" />

            <asp:Label ID="Label8" runat="server" Text="name"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBMConnectionString %>" SelectCommand="SELECT [name] FROM [allStadiums]"></asp:SqlDataSource>


            <br /><br /><br /><br />
        </div>
            <div>

            <asp:Button ID="Button5" runat="server" Text="block fan" OnClick="blockf"/>

         <asp:Label ID="Label9" runat="server" Text="national id"></asp:Label>
            <asp:TextBox ID="nidbf" runat="server"></asp:TextBox>
            <br /><br /><br /><br />
        </div>
        <br /><br /><br /><br />
        <asp:Button ID="Button6" runat="server" Text="logout" OnClick="Button6_Click" />
    </form>
</body>
</html>
