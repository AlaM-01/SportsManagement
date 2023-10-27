<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="all.aspx.cs" Inherits="DBM.all" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button2" runat="server" OnClick="fan" Text="fan" Height="104px" Width="203px" />
        <asp:Button ID="Button3" runat="server" Text="stadium manager" Height="101px" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="sport association manager" OnClick="spm" Height="101px" />
        <asp:Button ID="Button5" runat="server" Text="club representative" Height="95px" OnClick="Button5_Click" />
    </form>
</body>
</html>
