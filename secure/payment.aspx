<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="secure_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/payment.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- section divider -->
    <div class="section-divider">
        <div class="container">
            <asp:Label ID="lblTitle" runat="server" Text="Payment Screen" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    </div>
    <section class="section">
        <!-- payment box -->
        <div class="payment-box container">
            <div class="container myIcon">
            <i class="fab fa-cc-visa cards"></i><i class="fab fa-cc-amazon-pay cards"></i><i class="fab fa-cc-paypal cards"></i><i class="fab fa-cc-mastercard cards"></i>
            </div>
            <br />
            <asp:Label ID="lblInfo" runat="server" Text="Please Enter your Card Details:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblCardNumber" runat="server" Text="Card Number: "></asp:Label>
            <asp:TextBox ID="txtCardNumber" runat="server" Width="50%" Height="22px" Font-Size="Large"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCardNumber" runat="server" ErrorMessage=" *" ControlToValidate="txtCardNumber" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revCardNumber" runat="server" ControlToValidate="txtCardNumber" ErrorMessage="*Must be 16 digits long." ForeColor="Red" ValidationExpression="^[0-9]{16}$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="lblCodeNumber" runat="server" Text="Security Code: "></asp:Label>
            <asp:TextBox ID="txtCardSecurityNum" runat="server" Width="15%" Height="22px" Font-Size="Large"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSecurityNum" runat="server" ErrorMessage=" *" ControlToValidate="txtCardSecurityNum" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revSecurityNum" runat="server" ErrorMessage="*Must be 3 digits long." ForeColor="Red" ValidationExpression="^[0-9]{3}$" ControlToValidate="txtCardSecurityNum"></asp:RegularExpressionValidator>
            <br />
            <div class="container">
                <asp:Button ID="btnConfirmPayment" CssClass="btn" runat="server" Text="Confirm Payment" OnClick="btnConfirmPayment_Click" />
            </div>
        </div>
    </section>
</asp:Content>

