<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="trackOrders.aspx.cs" Inherits="secure_trackOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/trackOrders.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- section divider-->
    <div class="section-divider">
        <div class="container">
            <asp:Label ID="lblTitle" runat="server" Text="View Order History" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    </div>
    <section class="section">
        <div class="container">
            <!-- All users orders Grid view-->
            <div class="track-orders-box">
                <asp:Label ID="lblTitleGreyBox" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Please Select an Order you would like to view..."></asp:Label>
                 <br />
                <br />
                <asp:GridView ID="dvgOrders" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="80px" HorizontalAlign="Center" OnPageIndexChanging="dvgOrders_PageIndexChanging" OnSelectedIndexChanged="dvgOrders_SelectedIndexChanged" Width="100%">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                        <asp:BoundField DataField="datePlaced" HeaderText="Date" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Price $" DataFormatString="{0:c}" />
                        <asp:CommandField SelectText="View Details" ShowSelectButton="True" ButtonType="Button" >
                        <ControlStyle Font-Size="Large" />
                        </asp:CommandField>
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
            </div>
        </div>
    </section>
</asp:Content>

