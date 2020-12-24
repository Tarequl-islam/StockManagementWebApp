<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchViewItemsUI.aspx.cs" Inherits="StockManagementWebApp.UI.SearchViewItemsUI" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>STOCK MANAGEMENT SYSTEM</title>
	<link rel="stylesheet" type="text/css" href="../style.css" media="all" />
    <style type="text/css">
        .auto-style1 {
            width: 132px;
        }
        .auto-style2 {
            width: 129px;
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
            <legend> Search And View Items</legend>
        <table>
        <br />
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True"
                    Width="128px" Height="16px" AppendDataBoundItems="True">
                    
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="categoryDropDownList" runat="server" Width="128px" Height="16px" 
                    AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
            </td>
        </tr>
        </table>
            <asp:Label ID="outputLabel" runat="server" ForeColor="#009933"></asp:Label>
            <br />
            <asp:GridView ID="viewItemListGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <center>
                                        <%#Container.DataItemIndex + 1 %>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Available Quantity">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label runat="server" Text='<%#Eval("AvailableQuantity") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reorder Level">
                                <ItemTemplate>
                                    <center>
                                        <asp:Label runat="server" Text='<%#Eval("ReorderLevel") %>'></asp:Label>
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
            <br/>
        </fieldset>
    </div>
    </form>
</body>