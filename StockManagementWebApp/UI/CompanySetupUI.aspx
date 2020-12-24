<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagementWebApp.UI.CompanySetupUI" %>

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
            <legend>Company Setup</legend>
        <table>
        <br />
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="companyNameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
            </td>
        </tr>
        </table>
            <asp:Label ID="outputLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="AllCompanyGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="SL No ">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Name ">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Name")%>'>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    

                </Columns>

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </fieldset>
    </div>
    </form>
</body>
</html>
