<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsgDetail.ascx.cs"
    Inherits="WebMedi.Client.Modules.News.NewsgDetail" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<div class="col-md-9" style="padding-right: 40px;">
    <div class="row navigater">
        <span>
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="row main_title_news_bold">
        <h4>
            <asp:Label ID="ltlTitle" runat="server"></asp:Label></h4>
        <span class="date">(
            <asp:Label ID="LabelDate" runat="server" CssClass="date"></asp:Label>
            )</span>
    </div>
    <div class="row text-body">
        <strong>
            <asp:Literal ID="ltlDescribe" runat="server"></asp:Literal></strong>
        <h4>
        </h4>
    </div>
    <div class="row text_attach">
        <asp:Literal ID="ltlFile" runat="server"></asp:Literal>
    </div>
    <div class="row text-body">
        <asp:Label ID="FullDescirbe" runat="server"></asp:Label></div>
    <div class="row main_content_author">
        <asp:Label ID="LabelAuthor" runat="server" /></div>
    <div class="row">
        <h5>
            <asp:Label ID="lblComment" runat="server" Text=""></asp:Label></h5>
    </div>
    <div id="CommentPanel" runat="server" class="row">
        <asp:DataList ID="DataListProductComment" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
            CellPadding="4" ForeColor="#333333" BorderColor="#FFE0C0" BorderStyle="Solid"
            BorderWidth="1px">
            <ItemTemplate>
                <span style="font-family: Tahoma; font-size: 11px; font-weight: bold; color: #9a1706">
                    <asp:Label ID="label1" Text='<%# Eval("Title") %>' runat="server"></asp:Label>
                </span>&nbsp;<span style="font-family: Tahoma; font-size: 11px; font-style: italic;
                    color: Gray"><asp:Label ID="label2" Text='<%# Eval("DateCreated") %>' runat="server"></asp:Label></span><br />
                <span style="font-family: Tahoma; font-size: 11px; color: Black">
                    <asp:Label ID="label3" Text='<%# Eval("Content") %>' runat="server"></asp:Label></span>
                <br />
                <div align="right">
                    <span style="font-family: Tahoma; font-size: 11px; font-weight: bold; color: Black;
                        text-align: right">
                        <asp:Label ID="label4" Text='<%# Eval("Email") %>' runat="server"></asp:Label></span></div>
            </ItemTemplate>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <AlternatingItemStyle ForeColor="#284775" BackColor="Transparent" />
            <ItemStyle BackColor="#FCF7F4" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        <div style="border-bottom: 2px solid #018a44; margin-top: 10px;">
        </div>
        <div align="center" class='row title_article_top_comment' style="font-weight: bold;">
            <h4>
                Gửi ý kiến nhận xét</h4>
        </div>
        <div class="row" style="color: #e51d18; text-align: center">
            <asp:Literal ID="error" runat="server"></asp:Literal>
        </div>
        <div class="row" style="margin-top: 5px;">
            <div class="col-md-3">
                Tên của bạn
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="margin-top: 5px;">
            <div class="col-md-3">
                Địa chỉ Email
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    class="register_text_error1">Email không đúng</asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row" style="margin-top: 5px;">
            <div class="col-md-3">
                Tiêu đề
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row" style="margin-top: 5px;">
            <div class="col-md-3">
                Nội dung
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" Height="100px"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <%--xử lý captchar--%>
        <div class="row" style="margin-top: 5px;">
            <div class="col-sm-3">
                Nhập mã captcha</div>
            <div class="col-sm-3">
                <asp:TextBox ID="txtCapcha" Visible="true" placeholder="Mã bảo mật" class="form-control"
                    runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaWidth="130" 
                    CaptchaHeight="34" LineColor="DarkGreen" NoiseColor="Green" />
            </div>
            <div class="col-sm-3">
                <asp:LinkButton ID="LinkButton1" runat="server" Visible="true" OnClick="LinkButton1_Click">Chọn mã khác</asp:LinkButton></div>
        </div>
        <div id="ErrorMess" runat="server" class="row nNote nFailure" align="center" style="margin-top: 5px;">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <%------------------%>
        <div class="row" style="margin-top: 5px;">
            <div class="row" align="center">
                <asp:Button ID="ImageButton1" runat="server" Text="<%$ Resources:Resource, Send%>"
                    OnClick="Send_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
    <!--Tin tuc khác -->
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <div class="row">
        <ul>
            <asp:Repeater ID="DataListNews" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID") +"/"+GetString(Eval("Title")) +"/default.aspx"%>'
                            Text='<%# Eval("Title") %>'></asp:HyperLink>
                        <asp:Label ID="LabelDate" runat="server" Text='<%#" ("+ Convert.ToString(Eval("PostDate")).Substring(0,10)+")" %>'
                            CssClass="date"></asp:Label>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!--End Tin tức khác-->
    <div class="row" style="border-bottom: 2px solid #018a44; margin-top:10px;"></div>
</div>
<asp:HiddenField ID="txtNewsGroupID" runat="server" />
<asp:HiddenField ID="hddGroupCate" runat="server" />
