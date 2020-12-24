<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockManagementWebApp.UI.StockInUI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<title>STOCK MANAGEMENT SYSTEM</title>
	<link rel="stylesheet" type="text/css" href="../style.css" media="all" />
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
            <legend>Stock In</legend>
        <table>
        <br />
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True"
                    Width="128px" Height="16px" AppendDataBoundItems="True"
                    OnSelectedIndexChanged="companyDropDownList_OnSelectedIndexChanged">
                    
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Item"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="itemDropDownList" runat="server" Width="128px" Height="16px" 
                    AutoPostBack="True" AppendDataBoundItems="True"
                    OnSelectedIndexChanged="itemDropDownList_OnSelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Reorder Level"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="reorderLevelTextBox" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Available Quantity"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="availableQuantityTextBox" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Stock In Quantity"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="stockoutQuantityTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                <asp:Button ID="addButton" runat="server" Text="Save" OnClick="saveButton_Click" />
            </td>
        </tr>
        </table>
            <asp:Label ID="outputLabel" runat="server" ForeColor="#009933"></asp:Label>

        </fieldset>
    </div>
    </form>
</body>
</html>