<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fanR.aspx.cs" Inherits="DBM.fanr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label11" runat="server" Text="name"></asp:Label>
            <asp:TextBox ID="fname" runat="server"></asp:TextBox>
            &nbsp

        </div>
        <asp:Label ID="Label2" runat="server" Text="username"></asp:Label>
        <asp:TextBox ID="fusername" runat="server"></asp:TextBox>
        &nbsp
        <div>
            <asp:Label ID="Label1" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="fpass" runat="server"></asp:TextBox>
            &nbsp
            <div>
            <asp:Label ID="Label3" runat="server" Text="national id"></asp:Label>
            <asp:TextBox ID="nidd" runat="server"></asp:TextBox>
            &nbsp
                <div>
            <asp:Label ID="Label4" runat="server" Text="phone number"></asp:Label>
            <asp:TextBox ID="phnn" runat="server"></asp:TextBox>
            &nbsp
            <div>
            <asp:Label ID="Label5" runat="server" Text="birth date"></asp:Label>
            <asp:TextBox ID="birthdatee" runat="server"></asp:TextBox>
            &nbsp
                <div>
            <asp:Label ID="Label6" runat="server" Text="address"></asp:Label>
            <asp:TextBox ID="addresss" runat="server"></asp:TextBox>
            &nbsp
                     <div>
                          <div>
                              <asp:Button ID="Button1" runat="server" Text="register" OnClick="register" />

    </form>
</body>
</html>
