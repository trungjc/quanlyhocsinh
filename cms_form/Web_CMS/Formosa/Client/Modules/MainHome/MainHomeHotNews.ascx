<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeHotNews.ascx.cs" Inherits="Fomusa.MainHomeHotNews" %>
<link href="<%=ResolveUrl("~/")%>css/slide.css" rel="stylesheet" type="text/css"
    media="screen" />
<script type="text/javascript" src="<%=ResolveUrl("~/")%>scripts/slider1/jquery.js"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/")%>scripts/slider1/s3Slider.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#slider').s3Slider({
            timeOut: 8000
        });
    });
</script>
<style type="text/css">
    .style1
    {        
        float: left;
    }
    .style2
    {
        padding-bottom: 0px;
    }
    .style3
    {
        width: 246px;
        padding-bottom: 10px;
        height: auto;
    }
</style>
<div class="main_hotnews">
    <div class="main_hotnews_title">
        <img src="<%= ResolveUrl("~/") %>images/hotnews.png" class="main_hotnews_icon" 
            style="width: 24px" />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/FullNews/1/"+GetString("Tin tức nổi bật")+"/default.aspx" %>' Text="<%$ Resources: resource, BreakingNews%>"></asp:HyperLink>
    </div>
    <div class="main_hotnews_body">
        <table align="left">
            <tr>
                <td class="style1">
                    <div id="slider">
                        <div id="sliderContent">
                            <asp:DataList ID="DataListCateNews" runat="server" OnItemDataBound="DataListCateNews_ItemDataBound">
                                <ItemTemplate>
                                    <div class="sliderImage">
                                        <asp:Literal ID="ltlImageThumb" runat="server"></asp:Literal>
                                        <asp:Literal ID="ltlText" runat="server"></asp:Literal>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            <div class="clear sliderImage">
                            </div>
                        </div>
                    </div>
                </td>
                <td class="style2" valign="top">
                    <div class="main_hotnews_link">
                        <ul>
                            <asp:DataList ID="DataListNewsHot" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <img alt="" src="<%# ResolveUrl("~/") %>admin/Upload/NewsGroup/NewsGroupThumb/<%# Eval("ImageThumb") %>" width="50px"
                                            height="50px" style="float: left; margin-right: 5px;" />
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/News/" +Eval("GroupCate") + "/" +Eval("NewsGroupID")+ "/" + GetString(Eval("Title")) + "/default.aspx" %>'
                                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:DataList>
                        </ul>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>