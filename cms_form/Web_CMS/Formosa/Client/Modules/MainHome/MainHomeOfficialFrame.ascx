<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeOfficialFrame.ascx.cs" Inherits="Fomusa.Client.Modules.MainHome.MainHomeOfficialFrame" %>
<div class="main_homepage">
    <div class="cattitle">
        <div class="cattitle1">
            <div class="cattitle2">
                <div class="cattitlebg">
                    <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <div class="cattitle_sub">
            <asp:Repeater ID="rptCateNews" runat="server">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%# "~/Category/"+ Eval("GroupCate") +"/"+ Eval("CateNewsID") + "/" + GetString(Eval("CateNewsName")) + "/default.aspx" %>'
                        Text='<%# Eval("CateNewsName") %>' CssClass="sub_link"></asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear">
            </div>
        </div>
    </div>
    <%-- Main --%>
    <div class="cat_main_bg">
        <div style="padding: 5px;">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="gridviewBorder_doc" CellPadding="4" ForeColor="#333333" GridLines="None"
                Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20"
                ShowHeader="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/bullet3.gif" />
                        </ItemTemplate>
                        <HeaderStyle Width="15px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên văn bản">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/News/4/"+Eval("OfficialID")+"/"+GetString(Eval("OfficialName"))+"/default.aspx"  %>'
                                CssClass="content_text_KQTK"><%# Eval("OfficialName")%></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle CssClass="content_text_KQTK" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="DatePublic" HeaderText="Ngày ban hành" DataFormatString="{0:dd/MM/yyyy}"
                        HtmlEncode="False">
                        <ItemStyle HorizontalAlign="Center" Height="25px" Font-Size="11px" />
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Chi tiết">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl='<%#"~/News/4/"+Eval("OfficialID")+"/"+GetString(Eval("OfficialName"))+"/default.aspx"  %>'
                                CssClass="content_text_KQTK">Chi tiết...</asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle CssClass="content_text_Download" Width="60" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="gridviewTitleBg_doc" BackColor="#d6e2f0" Font-Bold="True"
                    ForeColor="#003273" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <PagerStyle Font-Names="Tahoma" Font-Size="11px" HorizontalAlign="Right" BackColor="#E0E0E0"
                    ForeColor="MidnightBlue" />
                <FooterStyle BackColor="#FCFCFC" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
    </div>
    <div class="cat_main_bottom">
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<asp:HiddenField ID="hddTitle" runat="server" />