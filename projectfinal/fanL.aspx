<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fanL.aspx.cs" Inherits="DBM.fanL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label2" runat="server" Text="username"></asp:Label>
        <asp:TextBox ID="userf" runat="server"></asp:TextBox>
        &nbsp
        <div>
            <asp:Label ID="Label1" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="passf" runat="server"></asp:TextBox>
            <br>
            <div>
                <asp:Button ID="Button1" runat="server" Text="LOGIN" OnClick="Button1_Click" />
        </div>
            </div>
            </div>
    </form>
</body>
</html>
