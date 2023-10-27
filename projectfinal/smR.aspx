<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="smR.aspx.cs" Inherits="DBM.smR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                            <asp:Label ID="Label1" runat="server" Text="name"></asp:Label>
            <asp:TextBox ID="smrname" runat="server"></asp:TextBox>
             <div>
            <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="smrpass" runat="server"></asp:TextBox>
                  <div>
            <asp:Label ID="Label3" runat="server" Text="username"></asp:Label>
            <asp:TextBox ID="smruser" runat="server"></asp:TextBox>
                      <div>
                            <asp:Label ID="Label4" runat="server" Text="stadium"></asp:Label>
            <asp:TextBox ID="stadiumn" runat="server"></asp:TextBox>
                       <div>
                           <asp:Button ID="Button1" runat="server" Text="register" OnClick="reg" />
        </div></div>
    </form>
</body>
</html>
