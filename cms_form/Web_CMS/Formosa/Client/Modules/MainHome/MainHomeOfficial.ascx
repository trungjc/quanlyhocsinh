<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeOfficial.ascx.cs" Inherits="Fomusa.Client.Modules.MainHome.MainHomeOfficial" %>
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
        <asp:HyperLinkField DataNavigateUrlFields="OfficialID" DataNavigateUrlFormatString="~/News/4/{0}/Default.aspx"
            DataTextField="OfficialName" HeaderText="Tên văn bản">
            <HeaderStyle HorizontalAlign="Center" />
            <ControlStyle CssClass="content_text_KQTK" />
        </asp:HyperLinkField>
        <asp:BoundField DataField="DatePublic" HeaderText="Ngày ban hành" DataFormatString="{0:dd/MM/yyyy}"
            HtmlEncode="False">
            <ItemStyle HorizontalAlign="Center" Height="25px" Font-Size="11px" />
            <HeaderStyle HorizontalAlign="Center" Width="100px" />
        </asp:BoundField>
        <asp:HyperLinkField DataNavigateUrlFields="Attached" DataNavigateUrlFormatString="~/Upload/Files/{0}"
            Text="Tải về" HeaderText="Tải về" ItemStyle-HorizontalAlign="Center">
            <HeaderStyle HorizontalAlign="Center" Width="80px" />
            <ControlStyle CssClass="content_text_Download" />
            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
        </asp:HyperLinkField>
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
