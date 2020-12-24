<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemsSetupUI.aspx.cs" Inherits="StockManagementWebApp.UI.ItemsSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<title>STOCK MANAGEMENT SYSTEM</title>
	<link rel="stylesheet" type="text/css" href="../style.css" media="all" />
    <style type="text/css">
        .auto-style4 {
            width: 156px;
        }
        .auto-style5 {width: 130px;
        }
    </style>
</head>
<body>
<header> 
	<div class="container">
		<div class="logo">
		<a href="#"><img src="img/2.jpg" alt="" /></a>
		</div>
		<div class="menu"> 
			<nav> 
			<ul>
				<li><a href="CompanySetupUI.aspx">Company Setup</a></li>
				<li><a href="CategorySetupUI.aspx">Category Setup</a></li>
				<li><a href="ItemsSetupUI.aspx">Item Setup</a></li>
				<li><a href="StockInUI.aspx">Stock In</a></li>
				<li><a href="StockOutUI.aspx">Stock Out</a></li>
				<li><a href="SearchViewItemsUI.aspx">Search & View</a></li>
				<li><a href="ViewSalesUi.aspx">View Sales</a></li>
				
			</ul>
		</nav>
		</div>
	</div>
	</header>
    <form id="form1" runat="server">
        <br/>
    <div align="center">
        <fieldset style="width: 40%" >
            <legend>Items Setup</legend>
        <table>
        <br />
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="categoryDropDownList" runat="server" AppendDataBoundItems="True"
                    Width="167px" Height="16px"></asp:DropDownList>
            </td>
        </tr>
            <tr>
            <td class="auto-style5">
                <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="companyDropDownList" runat="server" AppendDataBoundItems="True" Width="166px"></asp:DropDownList>
            </td>
        </tr>
            <tr>
            <td class="auto-style5">
                <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="nameTextBox" runat="server" Width="161px"></asp:TextBox>
            </td>
        </tr>
            <tr>
            <td class="auto-style5">
                <asp:Label ID="Label4" runat="server" Text="Reorder Level"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="reorderTextBox" runat="server" Width="161px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                
            </td>
            <td class="auto-style4">
                
            </td>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
            </td>
        </tr>
        </table>
            <asp:Label ID="outputLabel" runat="server"></asp:Label>
            <br />
            <br />
        </fieldset>
    </div>
    </form>
</body>
</html>
