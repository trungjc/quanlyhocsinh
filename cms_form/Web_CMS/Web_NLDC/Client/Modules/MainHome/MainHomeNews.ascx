<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeNews.ascx.cs"
    Inherits="Web_NLDC.Client.Modules.MainHome.MainHomeNews" %>
<div class="container">
    <div class="row news">
        <asp:Repeater ID="rptNews" runat="server">
            <ItemTemplate>
                <div class="col-md-4 col-sm-4 col-xs-12 news-content">
                    <div class="row news-title">
                        <h3>
                            <a href="<%# ReturnUrl(Eval("CateNewsGroupID").ToString()) %>"><%# Eval("CateNewsGroupName")%></a>
                        </h3>
                    </div>
                    <div class="row news-img">
                        <a href="<%# Page.ResolveUrl("newsg/" + Eval("GroupCate") + "/" + Eval("NewsGroupID") + "/" + GetString(Eval("Title")) +"/default.aspx") %>">
                            <img alt="" src="ImageHandler.aspx?image=Admin/Upload/NewsGroup/NewsGroupThumb/<%# Eval("ImageThumb") %>" width="100%"></a>
                    </div>
                    <div class="row news-description">
                        <%# Eval("Title")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
