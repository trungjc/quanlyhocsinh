<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebMedi.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row main">        
            <asp:PlaceHolder ID="phLeft" runat="server"></asp:PlaceHolder>            
            <asp:PlaceHolder ID="phRight" runat="server"></asp:PlaceHolder>        
    </div>
    <div style="margin-bottom:10px;"></div>
</asp:Content>
