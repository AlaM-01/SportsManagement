<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crR.aspx.cs" Inherits="DBM.crR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:Label ID="Label1" runat="server" Text="name"></asp:Label>
            <asp:TextBox ID="crrname" runat="server"></asp:TextBox>
             <div>
            <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="crrpass" runat="server"></asp:TextBox>
                  <div>
            <asp:Label ID="Label3" runat="server" Text="username"></asp:Label>
            <asp:TextBox ID="crruser" runat="server"></asp:TextBox>
                      <div>
                            <asp:Label ID="Label4" runat="server" Text="club"></asp:Label>
            <asp:TextBox ID="clubn" runat="server"></asp:TextBox>
                       <div>
                           <asp:Button ID="Button1" runat="server" Text="register" OnClick="reg" />
        </div></div>
    </form>
</body>
</html>
