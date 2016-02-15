<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeChildNews.ascx.cs"
    Inherits="Web_NLDC.Client.Modules.MainHome.MainHomeChildNews" %>
<div class="col-md-6 categories-item">
    <div class="row categories-title">
        <h4>
            <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
        </h4>
    </div>
    <asp:Repeater ID="rptNews" runat="server">
        <ItemTemplate>
            <div class="row categories-content">
                <a href="<%# Page.ResolveUrl("newsg/" + Eval("GroupCate") + "/" + Eval("NewsGroupID") + "/" + GetString(Eval("Title")) + "/default.aspx") %>">
                    <div class="col-md-3 col-sm-3 col-xs-3 categories-img">
                        <img alt="không ảnh" src="ImageHandler.aspx?image=Admin/Upload/NewsGroup/NewsGroupThumb/<%# Eval("ImageThumb") %>"
                            width="100%" />
                    </div>
                    <div class="col-md-9 col-sm-9 col-xs-9 categories-text">
                        <%# Eval("Title")%><br />
                        <span style="color: #cfcfcf">
                            <%# String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Eval("PostDate")))%></span>
                    </div>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<asp:HiddenField ID="hddTitle" runat="server" />
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
