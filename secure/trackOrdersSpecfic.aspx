<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="trackOrdersSpecfic.aspx.cs" Inherits="secure_trackOrdersSpecfic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/trackOrders.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- section divider -->
    <div class="section-divider">
        <div class="container">
            <asp:Label ID="lblTitle" runat="server" Text="View Specfic Order History" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    </div>
    <section class="section">
        <div class="container">
            <!-- Specfic users order Grid view-->
            <div class="track-orders-box ">
                Order ID:
                <asp:Label ID="lblOrderID" runat="server"></asp:Label>
                <br />
                <br />
                Date Ordered:
                <asp:Label ID="lblDate" runat="server"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="dgvOrderlines" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" Width="90%">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product name" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Price" HeaderText="Price $" DataFormatString="{0:c}" />
                        <asp:BoundField DataField="TypeName" HeaderText="Product type" />
                        <asp:BoundField DataField="LineTotal" HeaderText="Line Total $" DataFormatString="{0:c}" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <br />
                                Delivery Cost: $
                <asp:Label ID="lblDel" runat="server"></asp:Label>
                <br />
                <br />
                Total Price(delivery included): 
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnGoBack" CssClass="btn" runat="server" Text="Return to Orders" OnClick="btnGoBack_Click" />

            </div>
        </div>
    </section>
</asp:Content>

