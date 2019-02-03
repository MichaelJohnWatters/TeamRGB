<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/login.css" rel="stylesheet" />
</asp:Content>      
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="section">
        <!-- grey box -->
        <div class="grey-box">
            <div class="login-box">
                <h1>Login</h1>
                <!-- user inputs -->
                <div class="textbox">
                    <i class="fas fa-envelope" aria-hidden="true"></i>
                    <asp:TextBox ID="txtEmail" CssClass="textbox-txt" placeholder="email" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <i class="fa fa-lock" aria-hidden="true"></i>
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="textbox-txt" placeholder="password" runat="server"></asp:TextBox>
                </div>
                <div class="textbox">
                    <%--<i class="fa fa-save" aria-hidden="true"></i>--%>
                    <asp:CheckBox ID="chkPersist" Text="remeber me?" CssClass="textbox-txt checked" runat="server" TextAlign="Right" AutoPostBack="True" OnCheckedChanged="chkPersist_CheckedChanged" />
                </div>
                <asp:HyperLink ID="hylLogin" CssClass="hyl-need-account" NavigateUrl="~/createAccount.aspx" runat="server">Need an Account?</asp:HyperLink>
                <asp:Button ID="btn" CssClass="btn" runat="server" Text="Sign In" OnClick="btn_Click" />
                <p>
                    <asp:RequiredFieldValidator ID="rfvEmail" CssClass="red-text" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email: Cannot be empty." runat="server"/>
                    <br />
                    <asp:RegularExpressionValidator ID="revEmail" CssClass="red-text" runat="server" ErrorMessage="*Email Invalid Chars" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvPassword" CssClass="red-text" ControlToValidate="txtPassword" ErrorMessage="Password: Cannot be empty." runat="server"/>
                    <br />
                    <asp:RegularExpressionValidator ID="revPassword" CssClass="red-text" runat="server" ErrorMessage="*Password Invalid Chars" ControlToValidate="txtPassword" ValidationExpression="[0-9A-Za-z]{5,20}"></asp:RegularExpressionValidator>
                    <br />
                    <asp:Label ID="lblMsg" ForeColor="Red" runat="server" />
                </p>
            </div>
        </div>
    </section>
</asp:Content>

