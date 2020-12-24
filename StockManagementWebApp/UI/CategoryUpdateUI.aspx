<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryUpdateUI.aspx.cs" Inherits="StockManagementWebApp.UI.CategoryUpdateUI" %>

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
            <legend>Category Update</legend>
        <table>
        <br />
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                <asp:HiddenField runat="server" ID="idHiddenField"/>
            </td>
            <td>
                <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click"/>
            </td>
        </tr>
        </table>
            <br />
            <br />
            
        </fieldset>
    </div>
    </form>
</body>
</html>
