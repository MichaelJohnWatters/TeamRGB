<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="invoice.aspx.cs" Inherits="secure_invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/invoice.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- section divider -->
    <div class="section-divider">
        <div class="container">
            <asp:Label ID="lblInvoiceTitle" runat="server" Text="Invoice Screen" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    </div>
    <section class="section">
        <!-- display invoice -->
        <div class="invoice-box container">
            <asp:Label ID="lblCongratz" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Thank you for purchasing!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblInvoice" runat="server" Text="Your Invoice"></asp:Label>
            <br />
            <asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblCardDetails" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblItems" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblDel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnCompleted" runat="server" Text="Completed" CssClass="btn" OnClick="btnCompleted_Click" />
        </div>
    </section>
</asp:Content>

