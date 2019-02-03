<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shop.aspx.cs" Inherits="shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/shop.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="section">
        <div class="container">
            <!--shop box -->
            <div class="shop-box">
                <div class="section-divider">
                    <asp:Label ID="lblTitle" runat="server" Font-Size="XX-Large" Text="Products"></asp:Label>
                </div>
                <div class="container">
                    <!-- Search Bar -->
                    <div class="search-bar">
                        <br />
                        <a class="lblSearchBar"><i class="fa fa-search"></i> Search</a>
                        <asp:TextBox ID="txtSearchBar" CssClass="txtSearchBar" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSearchButton" CssClass="btnSearchButton" runat="server" Text="Search" OnClick="btnSearchButton_Click" />
                        <asp:RegularExpressionValidator ID="revSearchBar" runat="server" ErrorMessage="*Invalid Characters" ValidationExpression="[0-9A-Za-z\s]{0,40}" ControlToValidate="txtSearchBar"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div>
                    <!-- shop grid view -->
                    <asp:GridView ID="dgvProducts2" runat="server" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="dgvProducts2_PageIndexChanging" OnSelectedIndexChanged="dgvProducts2_SelectedIndexChanged" BorderStyle="None" Height="80px" HorizontalAlign="Center">
                        <AlternatingRowStyle BorderStyle="None" BackColor="#666666" />
                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="ID" >
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:ImageField DataImageUrlField="imageLocation" NullDisplayText="No Image Found" Visible="true">
                                <ControlStyle Height="200px" Width="200px" BorderStyle="None" />
                                <FooterStyle BorderStyle="None" />
                                <HeaderStyle BorderStyle="None" />
                                <ItemStyle BorderStyle="None" />
                            </asp:ImageField>
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" >
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Description" >
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TypeName" HeaderText="Type" >
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="Price $" DataFormatString="{0:c}" >
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Stock" HeaderText="Stock" >
                            <ControlStyle BorderStyle="None" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:BoundField>
                            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="View" >
                            <ControlStyle BorderColor="Black" BorderStyle="None" BorderWidth="1px" CssClass="btnSearchButton" Font-Size="Large" Height="40px" Width="80px" />
                            <FooterStyle BorderStyle="None" />
                            <HeaderStyle BorderStyle="None" />
                            <ItemStyle BorderStyle="None" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle BorderStyle="None" />
                        <EmptyDataRowStyle BorderStyle="None" />
                        <HeaderStyle BackColor="DodgerBlue" Font-Size="x-large" Wrap="False" BorderStyle="None" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

