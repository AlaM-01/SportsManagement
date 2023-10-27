<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spmVIEW.aspx.cs" Inherits="DBM.spmVIEW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button1" runat="server" Text="add match" OnClick="addmatch" />

            <asp:TextBox ID="hnamespm" runat="server"></asp:TextBox>
           <asp:Label ID="Label4" runat="server" Text="host club name"></asp:Label>
            
            
            <asp:TextBox ID="gnamespm" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="guest club name"></asp:Label>
            
            <asp:TextBox ID="stimespm" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="start time"></asp:Label>
       
             <asp:TextBox ID="etimespm" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="end time"></asp:Label>
            
        </div>
        <br /> <br /> <br />
        <div>
             <asp:Button ID="Button2" runat="server" Text="delete match" OnClick="deletematch" />

            <asp:TextBox ID="hnamed" runat="server"></asp:TextBox>
           <asp:Label ID="Label5" runat="server" Text="host club name"></asp:Label>
            
            
            <asp:TextBox ID="gnamed" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="guest club name"></asp:Label>
            
            <asp:TextBox ID="stimed" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="start time"></asp:Label>
       
             <asp:TextBox ID="etimed" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="end time"></asp:Label>
            <br /> <br /> <br /><br /> <br /> <br />

            <asp:Button ID="Button3" runat="server" Text="all upcoming matches" OnClick="aum"/>
            <asp:Button ID="Button4" runat="server" Text="already played matches" OnClick="apm" />
            <asp:Button ID="Button5" runat="server" Text="clubs never played" OnClick="cnp" />
        </div>

                <br /><br /><br /><br />
        <asp:Button ID="Button6" runat="server" Text="logout" OnClick="Button6_Click" />
    </form>
</body>
</html>
