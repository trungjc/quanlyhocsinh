<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListChartRound.ascx.cs" Inherits="CMS.Client.Admin.ListChartRound" %>
<div class="headerText">
	<asp:Image ID="imgIcon" runat="server" CssClass="icon_image"/>
    <span class="subNavLink"><asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        
         <td align="right" >
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
                          <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editchartround/Default.aspx">
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
    
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" Width="100%" CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ChartRoundID" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight"/>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                Width="20px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="ChartRoundParentID" HeaderText="Cấp độ">
                            <ItemStyle HorizontalAlign="Center" Width="20px" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="gridviewCellBottom gridviewCellRight" />
                        </asp:BoundField>
                        
                      
                        
                        <asp:BoundField DataField="ChartName" HeaderText="T&#234;n Biểu đồ" >
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight"/>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Value" HeaderText="Giá trị" >
                            <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight"/>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="100px" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="ChartPostDate" HeaderText="Ngày đăng">
                            <ItemStyle HorizontalAlign="center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="200px" />
                        </asp:BoundField>
                    
                    
                    <asp:CheckBoxField DataField="ChartStatus" HeaderText="Trạng th&#225;i" >
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                            Width="60px" />
                    </asp:CheckBoxField>
                    
                        <asp:TemplateField HeaderText="Chức năng" >
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight"/>
                            <ItemTemplate>
                                <asp:ImageButton ID="btn_edit" runat="server" CommandName="edit" CommandArgument='<%# Eval("ChartRoundID") %>' ImageUrl="~/images/Admin_Theme/images/btn_edit.png"  ToolTip="Sửa" />&nbsp;
                                <asp:ImageButton ID="btn_delete" runat="server" CommandName="delete" CommandArgument='<%# Eval("ChartRoundID") %>' ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                                Width="50px" />
                        </asp:TemplateField>
                    </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" HorizontalAlign="Center" CssClass="pagination-ys" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
    
            </td>
          </tr>
        </table>
</div>
