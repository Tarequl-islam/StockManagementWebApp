<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesUi.aspx.cs" Inherits="StockManagementWebApp.UI.ViewSalesUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<title>STOCK MANAGEMENT SYSTEM</title>
	<link rel="stylesheet" type="text/css" href="../style.css" media="all" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#fromDateTextbox").datepicker();
          $("#toDateTextbox").datepicker();
      });
  </script>
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
            <legend>View Sates Between Two Dates</legend>
        <table>
        <br />
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                
                <asp:TextBox ID="fromDateTextbox" runat="server">DatePicker</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="To Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="toDateTextbox" runat="server">DatePicker</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                
            </td>
            <td>
                <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="saveButton_Click" />
            </td>
        </tr>
        </table>
            <asp:Label ID="outputLabel" runat="server" ForeColor="#009933"></asp:Label>
            <br />
            <asp:GridView ID="viewSalesListGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="363px">
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
                     <asp:TemplateField HeaderText="Sale Quantity ">
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

        </fieldset>
    </div>
    </form>
</body>
</html>
