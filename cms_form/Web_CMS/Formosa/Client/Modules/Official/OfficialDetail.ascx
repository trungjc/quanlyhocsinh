<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OfficialDetail.ascx.cs" Inherits="Fomusa.Client.Modules.Official.OfficialDetail" %>
<div class="mainContent_panel2">
    <div class="mainContent_mainTitle">
        <asp:Image ID="Image1" ImageUrl="~/images/icon_official.png" runat="server" CssClass="icon"
            Width="32px" />
        <span class="content_Text_Cat">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
        </span><span class="content_Text">
            <asp:Literal ID="title_name" runat="server"></asp:Literal></span>
    </div>
    <div class="main_home">
        <div style="margin: 0 10px; vertical-align: top">
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="gridviewBorder_doc">
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Số/ ký hiệu </span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litNoCode" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Tên văn bản </span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litOfficialName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Ngày ban hành</span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litDatePublic" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Đơn vị ban hành</span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litCompany" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Loại văn bản</span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litClassify" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Người ký </span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litWriter" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc"
                        valign="top">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Trích yếu</span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litQuote" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">Từ khóa </span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc content_table_CTVB">
                        <asp:Literal ID="litKeyShort" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="156" align="left" class="gridviewCellBottom_doc gridviewCellRight_doc gridviewTitle_doc">
                        <img src="<%=Page.ResolveUrl("~/")%>images/bullet3.gif" class="icon" />&nbsp;<span
                            class="title_table_KQTK">File văn bản (Download) </span>
                    </td>
                    <td align="left" class="gridviewCellBottom_doc gridviewCellRight_doc text_underline">
                        <asp:Literal ID="litAttached" runat="server"></asp:Literal>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="text_attach">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Upload/Official/Files/"+Eval("FileName") %>'
                                        Text='<%# Eval("Title") %>'></asp:HyperLink>
                                </div>
        </ItemTemplate> </asp:Repeater> </td> </tr> </table>
    </div>
    <!--Tin tuc khác -->
    <div style="padding: 0 10px; vertical-align: top">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <div class="main_content_panel_group">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="gridviewBorder_doc" CellPadding="4" ForeColor="#333333" GridLines="None"
                Font-Size="11px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                PageSize="30">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/bullet3.gif" />
                        </ItemTemplate>
                        <HeaderStyle Width="15px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="NoCode" HeaderText="Số văn bản">
                        <ItemStyle HorizontalAlign="Center" Height="35px" Font-Size="11px" />
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tên văn bản">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/News/4/"+Eval("OfficialID")+"/"+GetString(Eval("OfficialName"))+".aspx"  %>'
                                CssClass="content_text_KQTK"><%# Eval("OfficialName")%></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle CssClass="content_text_KQTK" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="DatePublic" HeaderText="Ng&#224;y ban h&#224;nh" DataFormatString="{0:dd/MM/yyyy}"
                        HtmlEncode="False">
                        <ItemStyle HorizontalAlign="Center" Height="35px" Font-Size="11px" />
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Classify" HeaderText="Loại văn bản">
                        <ItemStyle HorizontalAlign="Center" Font-Size="11px" />
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle CssClass="gridviewTitleBg_doc" BackColor="#D7E0E4" Font-Bold="True"
                    ForeColor="#003273" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <PagerStyle Font-Names="Arial" Font-Size="Small" HorizontalAlign="Center" BackColor="#D7E0E4"
                    ForeColor="003273" />
                <FooterStyle BackColor="#FCFCFC" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
    </div>
    <!--End Tin tức khác-->
</div>
</div>
<asp:HiddenField ID="hddID" runat="server" />
<asp:HiddenField ID="hddGroupCate" runat="server" />
<asp:HiddenField ID="txtNewsGroupID" runat="server" />