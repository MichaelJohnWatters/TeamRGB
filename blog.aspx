<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="blog.aspx.cs" Inherits="blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/blog.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="section">
        <!-- section divider-->
        <div class="section-divider">
            <div class="container">
                <asp:Label ID="lblBlogTitle" Font-Bold="true" runat="server" Font-Size="XX-Large" Text="Blog"></asp:Label>
            </div>
        </div>
        <!-- blog Display -->
        <div class="blog-box container">
            <asp:Label ID="lblStatusBlog" runat="server"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtBlog" Font-Size="x-Large" runat="server" Height="242px" TextMode="MultiLine" Width="95%" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <!-- Below Controls allow the user to enter there message and add to the blog. -->
            <asp:TextBox ID="txtEntry" runat="server" Font-Size="Large" Width="95%"></asp:TextBox>
            <br />
            <asp:RegularExpressionValidator ID="revtxtEntry" runat="server" ErrorMessage="invalid characters" ControlToValidate="txtEntry" ValidationExpression="[0-9A-Za-z\s]{1,100}"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="rfvtxtEnter" runat="server" ErrorMessage="comment required" ControlToValidate="txtEntry"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnSubmit" CssClass="btn" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </div>
    </section>
</asp:Content>

