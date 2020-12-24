<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementWebApp.UI.StockOutUI" %>

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
            <legend>Stock Out</legend>
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
                <asp:Label ID="Label6" runat="server" Text="Stock Out Quantity"></asp:Label>
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
                <asp:Button ID="addButton" runat="server" Text="Add" OnClick="saveButton_Click" />
            </td>
        </tr>
        </table>
            <asp:Label ID="outputLabel" runat="server" ForeColor="#009933"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="List of Stock  Out Items" BorderColor="#999966" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Font-Size="X-Large" ForeColor="#3366CC"></asp:Label>
            <br />
            <asp:GridView ID="stockOutListGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="363px">
                <Columns>
                    <asp:TemplateField HeaderText="SL ">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item ">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("ItemName")%>'>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Company ">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("CompanyName")%>'>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Quantity ">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("StockOutQuantity")%>'>'></asp:Label>
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
            <br/>
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="sellButton" runat="server" Text="Sell" style="margin-left: 0px" Width="81px" OnClick="sellButton_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="damageButton" runat="server" Text="Damage" Width="81px" OnClick="damageButton_Click" />
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="lostButton" runat="server" Text="Lost" style="margin-left: 20px" Width="78px" OnClick="lostButton_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
