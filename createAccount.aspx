<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createAccount.aspx.cs" Inherits="createAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="section">
        <!-- grey box-->
        <div class="grey-box">
            <div class="login-box">
                <h1>Create Account</h1>
                <div class="textbox">
                    <i class="fa fa-user" aria-hidden="true"></i>
                    <asp:TextBox ID="txtFirstName" CssClass="textbox-txt" placeholder="first name" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fa fa-user" aria-hidden="true"></i>
                    <asp:TextBox ID="txtSecondName" CssClass="textbox-txt" placeholder="second name" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fas fa-map-marker-alt" aria-hidden="true"></i>
                    <asp:TextBox ID="txtAddress" CssClass="textbox-txt" placeholder="address" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fas fa-mail-bulk" aria-hidden="true"></i>
                    <asp:TextBox ID="txtPostCode" CssClass="textbox-txt" placeholder="post code" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fas fa-globe-americas" aria-hidden="true"></i>
                    <asp:TextBox ID="txtCountry" CssClass="textbox-txt" placeholder="country" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fas fa-envelope" aria-hidden="true"></i>
                    <asp:TextBox ID="txtEmail" CssClass="textbox-txt" placeholder="email" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fa fa-lock" aria-hidden="true"></i>
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="textbox-txt" placeholder="password" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fa fa-lock" aria-hidden="true"></i>
                    <asp:TextBox ID="txtPasswordCheck" TextMode="Password" CssClass="textbox-txt" placeholder="repeat password" runat="server"></asp:TextBox>
                </div>
                <asp:HyperLink ID="hylCreateAccount" CssClass="hyl-need-account" NavigateUrl="~/login.aspx" runat="server">Already have an Account?</asp:HyperLink>
                <asp:Button ID="btn" CssClass="btn" runat="server" Text="Create Account" OnClick="btn_Click" />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br />

            </div>

        </div>
        <!-- validators -->
        <div class="container red-text">
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="*first name required" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="*First Name Invalid" ControlToValidate="txtFirstName" ValidationExpression="[A-Za-z]{2,20}"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvSecondName" runat="server" ErrorMessage="*second name required" ControlToValidate="txtSecondName"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revSecondName" runat="server" ErrorMessage="*Second Name Invalid" ControlToValidate="txtSecondName" ValidationExpression="[A-Za-z]{2,20}"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*address required" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revAddress" runat="server" ErrorMessage="*Address Invalid" ControlToValidate="txtAddress" ValidationExpression="[0-9A-Za-z\s]{2,40}"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ErrorMessage="*post code required" ControlToValidate="txtPostCode"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revPostCode" runat="server" ErrorMessage="*PostCode Invalid" ControlToValidate="txtPostCode" ValidationExpression="[0-9A-Za-z\s]{2,30}"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="*country required" ControlToValidate="txtCountry"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revCountry" runat="server" ErrorMessage="*Country Invalid" ControlToValidate="txtCountry" ValidationExpression="[A-Za-z\s]{2,30}"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*email required" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="*Email Invalid" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*password required" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="*password invalid" ControlToValidate="txtPassword" ValidationExpression="[A-Za-z]{8,20}"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvPasswordCheck" runat="server" ErrorMessage="*repeat password required" ControlToValidate="txtPasswordCheck"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="revPasswordCheck" runat="server" ErrorMessage="*repeat password invalid" ControlToValidate="txtPasswordCheck" ValidationExpression="[A-Za-z]{8,20}"></asp:RegularExpressionValidator>
        </div>
    </section>
</asp:Content>

