<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reporte.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>WS Consulta Datacrédito</h1>
            <asp:Label ID="IdPersonaLbl" Text="ID a consultar: " runat="server"></asp:Label>
            <asp:TextBox ID="IDPersonaText" runat="server"></asp:TextBox>
            <hr />
            <asp:Button ID="Submit" Text="Consultar score" runat="server" OnClick="Submit_Click" />
            <hr />
            <asp:Label ID="Score" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
