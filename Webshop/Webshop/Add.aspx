<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Webshop.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 622px;
        }
        .auto-style3 {
            width: 108px;
        }
        .auto-style4 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong><span class="auto-style4">Add an item to basket</span></strong><br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="picture" runat="server" Height="300px" Width="500px" />
                    </td>
                    <td class="auto-style3">Product ID:<br />
                        <br />
                        Name:<br />
                        <br />
                        Description:<br />
                        <br />
                        Price:<br />
                        <br />
                        Stock:</td>
                    <td>
                        <br />
                        <asp:Label ID="lblid" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblname" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lbldescription" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblprice" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblstock" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <p>
            &nbsp;</p>
        <p>
            Copies of ordered examples of this product:&nbsp;
            <asp:TextBox ID="txtamount" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" Text="Add to basket..." />
        </p>
    </form>
</body>
</html>
