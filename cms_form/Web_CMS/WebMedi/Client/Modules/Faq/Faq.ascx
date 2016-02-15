<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Faq.ascx.cs" Inherits="WebMedi.Client.Modules.Faq.Faq" %>
<div class="col-md-9 main-content">
    <div class="row navigater">
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server" Text="<%$ Resources: resource, Faq%>"></asp:Literal></span>
    </div>
    <h4>Danh sách câu hỏi</h4>
    <asp:DataList ID="DataListFaq" runat="server" Width="100%">
        <ItemTemplate>
            <div class="row main-category">
                <div class="col-md-2 main-img">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/cauhoi.png" />
                </div>
                <div class="col-md-7 main-text">
                    <asp:HyperLink ID="HyperLinkQuestion" runat="server" CssClass="text_faq_title_link"
                        Text='<%# Eval("Question") %>' NavigateUrl='<%# "~/faqdetail/" +Eval("FaqID") +"/Default.aspx" %>'></asp:HyperLink>
                </div>
                 <div class="col-md-3" align="right">
                  <asp:HyperLink ID="HyperLink1" runat="server" CssClass="detail_link" Text='Xem trả lời...'
                    NavigateUrl='<%# "~/faqdetail/" +Eval("FaqID") +"/Default.aspx" %>'></asp:HyperLink>
                 </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
     <div class="row" align="center">
     <h4><asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-primary btn-lg" Text='Đặt câu hỏi'
            NavigateUrl="~/questions/Default.aspx"></asp:HyperLink></h4>
     </div>
     <div class="row" style="border-bottom: 2px solid #018a44; margin-top:10px;"></div>
</div>
