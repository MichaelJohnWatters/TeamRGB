<%@ Page Title="" Trace="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="productDetails.aspx.cs" Inherits="productDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/product.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="section">
        <!-- title bar -->
        <div class="section-divider">
            <div class="container">
                <asp:Label ID="lblTitle" runat="server" CssClass="title" Text="Product Details"></asp:Label>
            </div>
        </div>
        <div class="container">
            <!-- white box -->
            <div class="small-box">
                <div class="container">
                    <br />
                    <asp:Label ID="lblProductName" Font-Bold="true" Font-Size="XX-Large" CssClass="product-details" runat="server"></asp:Label>
                    <br />
                </div>
                <!-- image-->
                <div class="container">
                    <asp:Image ID="imgProduct" Width="95%" BorderStyle="Solid" BorderWidth="2px" runat="server" />
                </div>
                <br />
                <hr />
                <div class="container">
                    <asp:Label ID="lblProductInfo" Font-Bold="true" Font-Size="X-Large" runat="server" Text="Product Information"></asp:Label>
                    <br />
                    <br />
                </div>
                <!-- text about product -->
                <div class="foat-left">
                    <asp:Label ID="lblProductIDTitle" CssClass="product-details" runat="server" Text="Product ID: "></asp:Label>

                    <asp:Label ID="lblProductID" CssClass="product-details" Text="" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTypeName" CssClass="product-details" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblDescription" CssClass="product-details" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblPrice" CssClass="product-details" runat="server"></asp:Label>
                    <br />
                </div>
                <hr />
                <!-- title bar -->
                <div class="container">
                    <br />
                    <asp:Label ID="lblQuantity" CssClass="product-details" runat="server" Text="Quantity: "></asp:Label>
                    <asp:DropDownList ID="ddlStock" CssClass="product-details" runat="server"></asp:DropDownList>
                </div>
                <br />
                <!-- title bar -->
                <div class="container">
                    <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" CssClass="btn" OnClick="btnAdd_Click" />
                </div>
            </div>
            <!-- Reviews -->
            <div class="small-box">
                <h3>Reviews</h3>
                <asp:Panel ID="pnlReviews" runat="server">
                    <asp:Panel ID="pnlComments" runat="server"></asp:Panel>
                </asp:Panel>
            </div>
            <!-- Write Review -->
            <div class="small-box">
                <h3>Write a Review!!</h3>
                <hr />
                <!-- stars -->
                <asp:Label runat="server" Text="Stars"></asp:Label>
                <asp:RadioButton ID="star0" Text="0" runat="server" GroupName="stars" Checked="True"></asp:RadioButton>
                <asp:RadioButton ID="star1" Text="1" runat="server" GroupName="stars"></asp:RadioButton>
                <i class="far fa-star"></i>
                <asp:RadioButton ID="star2" Text="2" runat="server" GroupName="stars"></asp:RadioButton>
                <i class="far fa-star"></i><i class="far fa-star"></i>
                <asp:RadioButton ID="star3" Text="3" runat="server" GroupName="stars"></asp:RadioButton>
                <i class="far fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i>
                <asp:RadioButton ID="star4" Text="4" runat="server" GroupName="stars"></asp:RadioButton>
                <i class="far fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i>
                <asp:RadioButton ID="star5" Text="5" runat="server" GroupName="stars"></asp:RadioButton>
                <i class="far fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i>
                <br />
                <br />
                <!-- User input -->
                <asp:Label runat="server" Font-Bold="true" Font-Size="X-Large" Text="Title:"></asp:Label>
                <asp:TextBox ID="txtWriteCommentTitle" runat="server" Width="50%" BorderColor="DodgerBlue" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ToolTip="Title"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="requires Title" ControlToValidate="txtWriteCommentTitle" ValidationGroup="1"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="revTitle" runat="server" ErrorMessage="Invalid Title" ControlToValidate="txtWriteCommentTitle" ValidationExpression="[0-9A-Za-z\s]{1,20}" ValidationGroup="1"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Label runat="server" Font-Bold="true" Font-Size="X-Large" Text="Message:"></asp:Label>
                <br />
                <asp:TextBox ID="txtWriteCommentText" runat="server" Height="70px" Width="80%" BorderColor="DodgerBlue" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" MaxLength="250" ToolTip="Write your message"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfvCommentText" runat="server" ErrorMessage="requires Message" ControlToValidate="txtWriteCommentText" ValidationGroup="1"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="revCommentText" runat="server" ErrorMessage="Invalid Message" ControlToValidate="txtWriteCommentText" ValidationExpression="[0-9A-Za-z\s]{1,200}" ValidationGroup="1"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Button ID="btnSubmitComment" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmitComment_Click" ValidationGroup="1" />
                <br />
            </div>
        </div>
    </section>
</asp:Content>

