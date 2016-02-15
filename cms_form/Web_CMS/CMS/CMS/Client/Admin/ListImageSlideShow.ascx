<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListImageSlideShow.ascx.cs" Inherits="CMS.Client.Admin.ListImageSlideShow" %>
<div class="headerText">
	<asp:Image ID="imgIcon" runat="server" CssClass="icon_image"/>
    <span class="subNavLink"><asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        
         <td align="right" width="200">
            <div class="toolbar" id="toolbar">
                    <table class="toolbar"><tbody><tr>
                        <td  id="toolbar-unarchive">
                            <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx" CssClass="toolbar">
                                <span class="icon-32-home" title="Trở về trang chủ">
                                </span>
                                Trang chủ
                            </asp:HyperLink>
                        </td>
                        
                       
                        
                         <td  id="Td2" style="text-align:center">
                          <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/EditImageSlideShow/Default.aspx">
                                <span class="icon-32-publish" title="Đăng tin mới">
                                </span>
                                Tạo mới
                            </asp:HyperLink>
    			            
                        </td>
		                
		            
                        
                        <td  id="Td6">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/home/Default.aspx" CssClass="toolbar">
                                <span class="icon-32-help" title="Trợ giúp">
                                </span>
                                Trợ giúp
                            </asp:HyperLink>
                        </td>
                        
                    
                      </tr>
                  </tbody>
            </table>
        </div>

        </td>
      </tr>
    </table>


    <table width="100%" border="0" cellspacing="0" cellpadding="5">
      <tr>
        <td>
    
            <asp:GridView ID="grvLink" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grvLink_RowCommand" OnRowDataBound="grvLink_RowDataBound" CssClass="gridviewBorder">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="LinkID" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight" HeaderStyle-Width="31" HeaderStyle-Height="22" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="LinkImage" DataImageUrlFormatString="~/Upload/Link/{0}" HeaderText="Ảnh logo" DataAlternateTextField="LinkUrl" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"  HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                    </asp:ImageField>
                    <asp:BoundField HeaderText="Chiều rộng" DataField="LinkWidth" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight" HeaderStyle-Width="80" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight"/>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Chiều cao" DataField="LinkHeight" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight" HeaderStyle-Width="80" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="X&#243;a" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight" HeaderStyle-Width="60" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("LinkID") %>' ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />
                            &nbsp;<asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("LinkID") %>' ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="xóa ???" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    
	    </td>
      </tr>
    </table>
</div>