<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="checkOut.aspx.cs" Inherits="secure_checkOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/checkOut.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="section">
        <!-- section divider -->
        <div class="section-divider">
            <div class="container">
                <asp:Label ID="lblPageTitle" runat="server" Text="Checkout" Font-Size="XX-Large" Font-Bold="true"></asp:Label>
            </div>
        </div>
        <!-- check out -->
        <div class="checkout-box container">
            <div class="section-divider">
                <asp:Label ID="lblPersonal" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Personal Details"></asp:Label>
            </div>
            <br />
            <asp:Label ID="lblDetails" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblDelivery" runat="server" Text="Delivery options:"> 
            </asp:Label>

            <asp:DropDownList ID="ddlDelivery" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="ddlDelivery_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblDelCostPrefix" runat="server" Text="Delivery Cost: $"></asp:Label>
            <asp:Label ID="lblDelCost" Text="0" runat="server"></asp:Label>
            <br />
            <br />
            <div class="section-divider">
                <asp:Label ID="lblBasket" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Basket Contents"></asp:Label>
            </div>
            <br />
            <asp:Label ID="lblItems" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblBasketCostPrefix" runat="server" Text="Basket Cost: $"></asp:Label>
            <asp:Label ID="lblBasketCost" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblHiddenCost" Visible="false" runat="server"></asp:Label>

<%--            <div class="container">
                <div class="twoColumnbox">
                    <div class="twoColumninnerbox">
                    </div>
                </div>
                <div class="twoColumnbox">
                    <div class="twoColumninnerbox">
                    </div>
                </div>
            </div>--%>
            <div class="clearfloat">
                <hr />
                <asp:Label ID="lblDeliveryCost" runat="server"></asp:Label>
                <asp:Label ID="lblTotalCostLabel" runat="server" Text="Final Price: $"></asp:Label>
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                <hr />
                <br />
                <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel Purchase" OnClick="btnCancel_Click" />
                <asp:Button ID="btnInvoice" CssClass="btn" runat="server" Text="Complete Transaction" OnClick="btnInvoice_Click" />
            </div>
        </div>
    </section>
</asp:Content>

