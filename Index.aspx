<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/index.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--Showcase-->
    <div class="showcase">
    </div>
    <!--Categorys Title-->
    <section class="section-divider">
        <div class="container">
            <asp:Label ID="lblCategorys" runat="server" Text="Categories" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </div>
    </section>
    <!-- Categorys -->
    <section class="section-index">
        <div class="container">
            <a href="shop.aspx?search=PC">
                <div id="offer1" class="offers">
                    <h3>PC</h3>
                </div>
            </a>
            <a href="shop.aspx?search=PS">
                <div id="offer2" class="offers">
                    <h3>PlayStation</h3>
                </div>
            </a>
            <a href="shop.aspx?search=XBOX">
                <div id="offer3" class="offers">
                    <h3>XBOX</h3>
                </div>
            </a>
            <a href="shop.aspx?search=GAMES">
                <div id="offer4" class="offers">
                    <h3>Games</h3>
                </div>
            </a>
        </div>
    </section>

    <!-- products header -->
    <section class="section-divider">
        <div class="container">
            <asp:Label ID="Label1" runat="server" Text="Featured Products" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </div>
    </section>
    <!-- products section-->
        <section class="section-index">
        <div class="container">
            <asp:AdRotator ID="AdRotator1" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad1.xml" />
            <asp:AdRotator ID="AdRotator2" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad2.xml" />
            <asp:AdRotator ID="AdRotator3" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad3.xml" />
            <asp:AdRotator ID="AdRotator4" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad4.xml" />
            <asp:AdRotator ID="AdRotator5" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad5.xml" />
            <asp:AdRotator ID="AdRotator6" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad6.xml" />
            <asp:AdRotator ID="AdRotator7" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad7.xml" />
            <asp:AdRotator ID="AdRotator8" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad8.xml" />
            <asp:AdRotator ID="AdRotator9" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad9.xml" />
            <asp:AdRotator ID="AdRotator10" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad10.xml" />
            <asp:AdRotator ID="AdRotator11" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad11.xml" />
            <asp:AdRotator ID="AdRotator12" CssClass="offers" runat="server" AdvertisementFile="~/Files/Ad12.xml" />
        </div>
    </section>
    <!--last viewed products Title -->
    <section class="section-divider">
        <div class="container">
            <asp:Label ID="lblProductsTitle" runat="server" Text="Last Viewed Product" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </div>
    </section>
    <!--Last viewed products-->
    <section class="section-index">
        <div class="container">
            <asp:ImageButton CssClass="offers" ID="imgBtnlastViewedProductImage" runat="server" DescriptionUrl="Your Last Viewed Product" AlternateText="Last viewed product" OnClick="imgBtnlastViewedProductImage_Click" />
            <br />
            <asp:Label ID="lblIDOfLastViewed" runat="server" Text="1"></asp:Label>
        </div>
    </section>
</asp:Content>

