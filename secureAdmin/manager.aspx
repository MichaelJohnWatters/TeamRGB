<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="secureAdmin_manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-divider">
        <div class="container">
            <asp:Label ID="lblTitle" runat="server" Text="Manager Screen" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    </div>
    <section class="section">
        <div class="manager-box container">

            <!--Add Stock-->
            <asp:Label ID="lblAddStock" runat="server" Font-Bold="true" Text="Add/remove Stock"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblSelectProductLabel" runat="server" Text="Select Product: "></asp:Label>
            <asp:DropDownList ID="ddlProductID" runat="server" ValidationGroup="UpdateStock" OnSelectedIndexChanged="ddlProductID_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblAddStockLabel" runat="server" Text="Add Stock: "></asp:Label>
            <asp:TextBox ID="txtAddStockValue" runat="server" ValidationGroup="UpdateStock"></asp:TextBox>
            <asp:Button ID="btnAddStock" runat="server" Text="Update Stock" CssClass="btn" OnClick="btnAddStock_Click" ValidationGroup="UpdateStock" />
            <br />
            <asp:Label ID="lblStockMessage" runat="server" Visible="false" Text=""></asp:Label>
            <asp:RegularExpressionValidator ID="revAddStock" CssClass="red-text" runat="server" ErrorMessage="*invalid input" ValidationGroup="UpdateStock" ControlToValidate="txtAddStockValue" ValidationExpression="[0-9]{1,10}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvAddStock" CssClass="red-text" runat="server" ErrorMessage="*required" ValidationGroup="UpdateStock" ControlToValidate="txtAddStockValue"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnRefreshProdudctsDDL" runat="server" CssClass="btn" Text="Refresh" OnClick="btnRefreshProdudctsDDL_Click" />
            <hr />
            <br />
            <!-- all products -->
            <asp:Label ID="lblAllProductsTitle" Font-Bold="true" runat="server" Text="All Product"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="grvAllProduct" runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="grvAllProduct_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name">
                        <ControlStyle BackColor="White" />
                        <FooterStyle BackColor="White" ForeColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price $" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock Level">
                        <FooterStyle BackColor="White" ForeColor="Black" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ImageLocation" HeaderText="Image Info" />
                    <asp:BoundField DataField="TypeName" HeaderText="Type" />
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
            <br />
            <asp:Button ID="btnRefreshProducts" CssClass="btn" runat="server" OnClick="btnRefreshProducts_Click" Text="Refresh" />

            <br />
            <hr />
            <!-- alter product info -->
            <br />
            <asp:Label ID="lblUpdateTitle" runat="server" Font-Bold="true" Text="Update Product Information"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblUpdateProduct" runat="server" Text="Select Product: "></asp:Label>
            <asp:DropDownList ID="ddlUpdateProduct" runat="server" ValidationGroup="UpdateStock" OnSelectedIndexChanged="ddlUpdateProduct_SelectedIndexChanged"></asp:DropDownList>
            <asp:Button ID="btnRefreshUpdate" runat="server" Text="Refresh" OnClick="btnRefreshUpdate_Click" />
            <asp:Label ID="lblUpdateProductName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblUpdateName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtUpdateName" runat="server" ValidationGroup="updateName"></asp:TextBox>
            <asp:Button ID="btnUpdateName" runat="server" Text="Update Name" ValidationGroup="updateName" OnClick="btnUpdateName_Click" />
            <asp:RequiredFieldValidator ID="rfvUpdateName" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="updateName" ControlToValidate="txtUpdateName" ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revUpdateName" CssClass="red-text" runat="server" ErrorMessage="*Invalid input" ValidationGroup="updateName" ValidationExpression="[0-9A-Za-z\s]{2,30}" ControlToValidate="txtUpdateName"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblUpdateDesc" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="txtUpdateDesc" runat="server" ValidationGroup="updateDesc"></asp:TextBox>
            <asp:Button ID="btnUpdateDesc" runat="server" Text="Update Description" ValidationGroup="updateDesc" OnClick="btnUpdateDesc_Click" />
            <asp:RequiredFieldValidator ID="rfvUpdateDesc" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="updateDesc" ControlToValidate="txtUpdateDesc"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revUpdateDesc" CssClass="red-text" runat="server" ErrorMessage="*Invalid input" ValidationGroup="updateDesc" ValidationExpression="[0-9A-Za-z\s]{1,200}" ControlToValidate="txtUpdateDesc"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblUpdatePrice" runat="server" Text="Price: £  "></asp:Label>
            <asp:TextBox ID="txtUpdatePrice" runat="server" ValidationGroup="updatePrice"></asp:TextBox>
            <asp:Button ID="btnUpdatePrice" runat="server" ValidationGroup="updatePrice" Text="Update Price" OnClick="btnUpdatePrice_Click" />
            <asp:RequiredFieldValidator ID="rfvUpdatePrice" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="updatePrice" ControlToValidate="txtUpdatePrice" ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revUpdatePrice" CssClass="red-text" runat="server" ErrorMessage="*Invalid input" ValidationGroup="updatePrice" ValidationExpression="^\d+(\.\d\d)?$" ControlToValidate="txtUpdatePrice"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblUpdateType" runat="server" Text="Type: "></asp:Label>
            <asp:DropDownList ID="ddlUpdateType" runat="server" ValidationGroup="NewProduct">
                <asp:ListItem>PC</asp:ListItem>
                <asp:ListItem>PS</asp:ListItem>
                <asp:ListItem>XBOX</asp:ListItem>
                <asp:ListItem>GAMES</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnUpdateType" runat="server" Text="Update Type" OnClick="btnUpdateType_Click" />
            <br />
            <asp:Label ID="lblUpdateImage" runat="server" Text="Image: "></asp:Label>
            <asp:FileUpload ID="fulUpdateImage" runat="server"/>
            <asp:Button ID="btnUpdateImage" runat="server" Text="UpdateImage" ValidationGroup="updateImage" OnClick="btnUpdateImage_Click" style="height: 26px" />
            <asp:RequiredFieldValidator ID="rfvUpdateFul" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="updateImage" ControlToValidate="fulUpdateImage"></asp:RequiredFieldValidator>
            <asp:Label ID="lblUpdateFul" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblUpdateWarning" runat="server" Text="" Visible="false"></asp:Label>
            <hr />
            <!-- add new Product -->
            <br />
            <asp:Label ID="lblCreateNewProduct" Font-Bold="true" runat="server" Text="Create New Product"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblNewProductNameLabel" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="txtNewProductName" runat="server" ValidationGroup="NewProduct"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="NewProduct" ControlToValidate="txtNewProductName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revName" CssClass="red-text" runat="server" ErrorMessage="*Invalid input" ValidationGroup="NewProduct" ControlToValidate="txtNewProductName" ValidationExpression="[0-9A-Za-z\s]{2,30}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblNewProductDesc" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="txtNewProductDesc" runat="server" ValidationGroup="NewProduct"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDesc" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="NewProduct" ControlToValidate="txtNewProductDesc"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDesc" CssClass="red-text" runat="server" ErrorMessage="*Invalid input" ValidationGroup="NewProduct" ControlToValidate="txtNewProductDesc" ValidationExpression="[0-9A-Za-z\s]{1,200}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblNewProductPrice" runat="server" Text="Price: £ "></asp:Label>
            <asp:TextBox ID="txtNewProductPrice" runat="server" ValidationGroup="NewProduct"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrice" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="NewProduct" ControlToValidate="txtNewProductPrice"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPrice" CssClass="red-text" runat="server" ErrorMessage="*Invalid input" ValidationGroup="NewProduct" ControlToValidate="txtNewProductPrice" ValidationExpression="^\d+(\.\d\d)?$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblNewProductStock" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="txtNewProductStockLevel" runat="server" ValidationGroup="NewProduct"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvStock" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="NewProduct" ControlToValidate="txtNewProductStockLevel"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revStock" CssClass="red-text" runat="server" ErrorMessage="*Invalid input" ValidationGroup="NewProduct" ControlToValidate="txtNewProductStockLevel" ValidationExpression="[0-9]{1,10}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblNewProductType" runat="server" Text="Type: "></asp:Label>
            <asp:DropDownList ID="ddlType" runat="server" ValidationGroup="NewProduct">
                <asp:ListItem>PC</asp:ListItem>
                <asp:ListItem>PS</asp:ListItem>
                <asp:ListItem>XBOX</asp:ListItem>
                <asp:ListItem>GAMES</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblNewProductImage" runat="server" Text="Image: "></asp:Label>
            <asp:FileUpload ID="fulNewProductImage" runat="server" />
            <asp:RequiredFieldValidator ID="rfvImage" CssClass="red-text" runat="server" ErrorMessage="*" ValidationGroup="NewProduct" ControlToValidate="fulNewProductImage"></asp:RequiredFieldValidator>
            <asp:Label ID="lblImageFileName" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnCreateNewProduct" runat="server" Text="Add New Product" CssClass="btnlonger" OnClick="btnCreateNewProduct_Click" ValidationGroup="NewProduct" />
            <asp:Label ID="lblWarning" runat="server" Text="" Visible="false"></asp:Label>
            <br />
            <br />
            <hr />
            <!-- all orders -->
            <br />
            <asp:Label ID="lblAllOrdersTitle" Font-Bold="true" runat="server" Text="All Orders"></asp:Label>
            <br />
            <br />
            <div class="container">
            <asp:GridView ID="grvAllOrdersValue" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CustomerID" HeaderText="Customer ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="datePlaced" HeaderText="Date">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="TotalPrice" HeaderText="Price $" DataFormatString="{0:c}">
                        <HeaderStyle HorizontalAlign="Center"/>
                        <ItemStyle HorizontalAlign="Center"/>
                    </asp:BoundField>
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
                </div>
            <br />
            <br />
            <hr />
            <!-- throw exception handler -->
            <asp:Label ID="lblException" runat="server" Text="For demo purposes:"></asp:Label>
            <br />
            <asp:Button ID="btnCauseException" CssClass="btnlonger" runat="server" Text="Cause an Exception" OnClick="btnCauseException_Click" />
            <br />
            <hr />
        </div>
        <asp:HiddenField ID="hiddenAddStock" runat="server" />
        <asp:HiddenField ID="hiddenUpdateProduct" runat="server" />
        <asp:HiddenField ID="hidden" runat="server" />
    </section>
</asp:Content>

