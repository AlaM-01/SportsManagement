<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allL.aspx.cs" Inherits="DBM.allL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <asp:Button ID="Button2" runat="server" OnClick="fan" Text="fan" Height="104px" Width="203px" />
        <asp:Button ID="Button3" runat="server" Text="stadium manager" Height="101px" OnClick="sm" />
        <asp:Button ID="Button4" runat="server" Text="sport association manager" OnClick="spm" Height="101px" />
        <asp:Button ID="Button5" runat="server" Text="club representative" Height="95px" OnClick="cr" />
      <asp:Button ID="Button1" runat="server" Text="SYSTEM ADMIN" Height="95px" OnClick="systemadmin" />
    
        </div>

    <div>
        <br />
        <br />

        <br />
        <asp:Button ID="Button6" runat="server" Text="register" Height="164px" OnClick="Button6_Click" Width="307px" />
    </div>
    </form>
</body>
</html>
