<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Webshop.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong><span class="auto-style1">Catalog</span><br class="auto-style1" />
            </strong>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="894px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Product ID" />
                    <asp:BoundField DataField="Categoryid" HeaderText="Category" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:ImageField DataImageUrlField="Picture" DataImageUrlFormatString="~/Images/{0}" HeaderText="Picture">
                        <ControlStyle Height="30px" Width="50px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                    <asp:CommandField SelectText="Add to basket..." ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
