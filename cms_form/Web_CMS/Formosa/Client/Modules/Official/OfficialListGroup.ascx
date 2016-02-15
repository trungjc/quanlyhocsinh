<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OfficialListGroup.ascx.cs"
    Inherits="Fomusa.Client.Modules.Official.OfficialListGroup" %>
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
        <div style="padding: 0 10px; vertical-align: top">
            <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                <ItemTemplate>
                    <div class="main_title_catenews">
                        <asp:HyperLink ID="hyperLink1" runat="server" NavigateUrl='<%#"~/Category/"+Eval("GroupCate")+"/"+Eval("CateNewsID") +"/"+ GetString(Eval("CateNewsName").ToString()) +"/Default.aspx" %>'><%#Eval("CateNewsName")%></asp:HyperLink></div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        CssClass="gridviewBorder_doc" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Font-Size="11px" 
                        onpageindexchanging="GridView1_PageIndexChanging">
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
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/News/4/"+Eval("OfficialID")+"/"+GetString(Eval("OfficialName"))+"/default.aspx"  %>'
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
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>    
</div>
<asp:HiddenField ID="hddGroupCate" runat="server" />
