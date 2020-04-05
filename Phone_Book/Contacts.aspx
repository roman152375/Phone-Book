<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="Phone_Book.Contacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 113px;
            width: 92px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
            <asp:Label ID="Label1" runat="server" Text="Phone Book" Font-Bold="True" Font-Size="XX-Large" ForeColor="Green"></asp:Label>
                     </td>
                </tr>

            <tr>
                <td>

        <p id="lblname">
            Name<asp:TextBox ID="txtName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                </td>
            </tr>

                <tr>
                    <td>
        <p id="lblContact">
            Contact No.<asp:TextBox ID="txtContact" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                    </td>
                </tr>
                 <tr>
                    <td>
        <p id="lblEmail">
            Email<asp:TextBox ID="txtEmail" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                 </td>
                    </tr>
                 <tr>
                    <td>

        <p id="lblAddress">
            Address<asp:TextBox ID="txtAddress" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            </p>
                     </td>
                  </tr>
                <tr>
                   
            <p>
                 <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                </td>

                <td>
                <asp:Button ID="btnEdit" runat="server" Enabled="false" OnClick="btnEdid_Click" Text="Edit" />
                </td>
            </p>  
                  </tr>
          </table>
   </div>     
    </form>
</body>
</html>
