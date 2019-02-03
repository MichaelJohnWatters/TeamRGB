<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/manager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="section">
        <div class="container" style="color:white">
            <!--Error message prompted to the user-->
            <asp:Label ID="lblOops" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Oops something went wrong..."></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblHappened" runat="server" Font-Size="X-Large" Text="Heres what happened..."></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
        <!--return the index page -->
        <div class="container">
            <asp:Button ID="btnIndezx" CssClass="btn" runat="server" Text="Return to home page..." OnClick="btnIndezx_Click" />
        </div>
    </section>
</asp:Content>

