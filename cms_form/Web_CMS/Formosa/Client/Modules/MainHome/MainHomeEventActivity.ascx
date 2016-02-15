<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeEventActivity.ascx.cs" Inherits="Fomusa.Client.Modules.MainHome.MainHomeEventActivity" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    Width="100%" CssClass="gridviewBorder_doc"  CellPadding="4" ForeColor="#333333" 
    GridLines="None" Font-Size="11px" 
    OnPageIndexChanging="GridView1_PageIndexChanging" ShowHeader="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/bullet3.gif" />
                </ItemTemplate>
                <HeaderStyle Width="15px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

          
            <asp:TemplateField HeaderText="Tiêu đề">
				<ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/News/"+ DataBinder.Eval(Container.DataItem,"GroupCate") +"/" + DataBinder.Eval(Container.DataItem,"NewsGroupID") + "/Default.aspx" %>'> <%# DataBinder.Eval(Container.DataItem, "Title")%> </asp:HyperLink>
				</ItemTemplate>
				<HeaderStyle HorizontalAlign="Center"   />
                <ControlStyle CssClass="content_text_KQTK" />
			</asp:TemplateField>
			
			
            <asp:BoundField DataField="PostDate" HeaderText="Ngày đăng" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" >
                <ItemStyle HorizontalAlign="Center"  Height="25px" Font-Size="11px"/>
                <HeaderStyle HorizontalAlign="Center" Width="100px"/>
            </asp:BoundField>

             
             <asp:TemplateField HeaderText="Chi tiết">
				<ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/News/"+ DataBinder.Eval(Container.DataItem,"GroupCate") +"/" + DataBinder.Eval(Container.DataItem,"NewsGroupID") + "/Default.aspx" %>'> Chi tiết </asp:HyperLink>
				</ItemTemplate>
				<HeaderStyle HorizontalAlign="Center"   />
                <ControlStyle CssClass="content_text_KQTK" />
			</asp:TemplateField>                                 
            
        </Columns>
        <HeaderStyle CssClass="gridviewTitleBg_doc" BackColor="#d6e2f0" Font-Bold="True" ForeColor="#003273" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <PagerStyle Font-Names="Tahoma" Font-Size="11px" HorizontalAlign="Right" BackColor="#E0E0E0" ForeColor="MidnightBlue" />
    <FooterStyle BackColor="#FCFCFC" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <EditRowStyle BackColor="#999999" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>