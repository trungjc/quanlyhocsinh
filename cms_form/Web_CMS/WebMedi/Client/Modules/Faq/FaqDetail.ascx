<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FaqDetail.ascx.cs" Inherits="WebMedi.Client.Modules.Faq.FaqDetail" %>
<div class="col-md-9 main-content">
    <div class="row navigater">
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="row">
        <h4>
            Nội dung câu hỏi: <asp:Literal ID="LiteralQuestion" runat="server"></asp:Literal></h4>
    </div>
    <div class="row">
        <h5>
            Phần trả lời: <asp:Literal ID="Literal1" runat="server"></asp:Literal></h5>
    </div>
    <div class="row main-category text-body">
        <asp:Literal ID="LiteralAnswer" runat="server"></asp:Literal>
    </div>
    <div class="row">
        <h4>
            Câu hỏi khác</h4>
    </div>
    <div class="row">
        <asp:Repeater ID="DataListOtherFaq" runat="server">
            <ItemTemplate>
                <div class="col-md-2 main-img">
                     <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/cauhoi.png" />
                </div>
                <div class="col-md-10">
                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Question") %>' NavigateUrl='<%# "~/FaqDetail/" +Eval("FaqID") +"/Default.aspx" %>'></asp:HyperLink></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="row" align="center">
     <h4><asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-primary btn-lg" Text='Đặt câu hỏi'
            NavigateUrl="~/questions/Default.aspx"></asp:HyperLink></h4>
     </div>
    <div class="row" style="border-bottom: 2px solid #018a44; margin-top:10px;"></div>
</div>
