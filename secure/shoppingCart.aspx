<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shoppingCart.aspx.cs" Inherits="shoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/shoppingCart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- section divider -->
    <div class="section-divider">
        <div class="container">
            <asp:Label ID="lblTitle" runat="server"  Text="Shopping Cart" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    </div>
    <section class="section">
        <!-- Cart  box -->
        <div class="cart-box container">
            <asp:Label ID="lblYourShoppingCart" Text="Your Items" Font-Size="x-large" runat="server"></asp:Label>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
            <asp:Label ID="lblOrderSummary" runat="server"></asp:Label>
            <br />
            <!-- Panel used to append cart items -->
            <asp:Panel ID="pnlOrders" runat="server">
            </asp:Panel>
            <br />
            <asp:Label ID="lblTotalCost" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnClear" CssClass="btn" runat="server" Text="Empty Basket" OnClick="btnClear_Click" />
            <asp:Button ID="btnPurchase" CssClass="btn" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
            <br />
        </div>
    </section>
</asp:Content>

