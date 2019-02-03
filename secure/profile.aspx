<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="secure_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/profile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="section">
        <!-- section Divider -->
        <div class="section-divider">
            <div class=" container">
                <asp:Label ID="lblTitle" runat="server" Text="Your Profile" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            </div>
        </div>
        <!-- profile box-->
        <div class="profile-box container">
            <asp:Label ID="lblCustomerID" runat="server" Text="Customer ID: "></asp:Label>
            <asp:Label ID="lblCustomerIDValue" CssClass="read-only" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:Label ID="lblEmailValue" runat="server" CssClass="read-only" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
            <asp:TextBox ID="txtFirstName" CssClass="profile-text-box" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revFirstName" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtFirstName" ValidationExpression="[A-Za-z]{2,20}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblSecondName" runat="server" Text="Second Name: "></asp:Label>
            <asp:TextBox ID="txtSecondName" CssClass="profile-text-box" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSecondName" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtSecondName"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revSecondName" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtSecondName" ValidationExpression="[A-Za-z]{2,20}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="txtAddress" CssClass="profile-text-box" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revAddress" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtAddress" ValidationExpression="[0-9A-Za-z\s]{2,40}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblPostCode" runat="server" Text="PostCode: "></asp:Label>
            <asp:TextBox ID="txtPostCode" CssClass="profile-text-box" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtPostCode"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPostCode" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtPostCode" ValidationExpression="[0-9A-Za-z\s]{2,30}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblCountry" runat="server" Text="Country: "></asp:Label>
            <asp:TextBox ID="txtCountry" CssClass="profile-text-box" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtCountry"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCountry" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtCountry" ValidationExpression="[A-Za-z\s]{2,30}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblPwd" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPwd" CssClass="profile-text-box" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtPwd"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPassword" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtPwd" ValidationExpression="[A-Za-z]{8,20}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security Question: "></asp:Label>
            <asp:TextBox ID="txtSecurityQuestion" CssClass="profile-text-box" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtSecurityQuestion"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revQuestion" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtSecurityQuestion" ValidationExpression="[A-Za-z\s]{2,40}"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblSecurityAnswer" runat="server" Text="Security Answer: "></asp:Label>
            <asp:TextBox ID="txtSecurityAnswer" CssClass="profile-text-box" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" CssClass="red-text" ErrorMessage="*" ControlToValidate="txtSecurityAnswer"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revAnswer" runat="server" CssClass="red-text" ErrorMessage="*invalid" ControlToValidate="txtSecurityAnswer" ValidationExpression="[A-Za-z\s]{2,40}"></asp:RegularExpressionValidator>
            <br />
            <br />
            <!-- buttons -->
            <div class="container">
                <asp:Label ID="lblLogoutWarning" Font-Size="Medium" runat="server" Text="You will be logged out if your save changes."></asp:Label>
            </div>
            <div class="container">
                <asp:Button ID="btnSaveChanges" CssClass="btn" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" />
            </div>
            <!-- Admin nav button -->
            <div class="container">
                <asp:Button ID="btnGoToAdmin" Visible="false" CssClass="btn" runat="server" Text="Admin Page" OnClick="btnGoToAdmin_Click" />
            </div>
        </div>
    </section>
</asp:Content>

