<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spmR.aspx.cs" Inherits="DBM.spmr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="name"></asp:Label>
            <asp:TextBox ID="spmrname" runat="server"></asp:TextBox>
             <div>
            <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="spmrpass" runat="server"></asp:TextBox>
                  <div>
            <asp:Label ID="Label3" runat="server" Text="username"></asp:Label>
            <asp:TextBox ID="spmruser" runat="server"></asp:TextBox>

                       <div>
                           <asp:Button ID="Button1" runat="server" Text="register" OnClick="reg" />
        </div>
    </form>
</body>
</html>
