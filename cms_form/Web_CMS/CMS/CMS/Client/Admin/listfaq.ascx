<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="listfaq.ascx.cs" Inherits="CMS.Client.Admin.listfaq" %>
<div class="headerText">
	<asp:Image ID="imgIcon" runat="server" CssClass="icon_image"/>
    <span class="subNavLink"><asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        
         <td align="right">
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
                                  <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editfaq/Default.aspx">
                                        <span class="icon-32-publish" title="Đăng tin mới">
                                        </span>
                                        Tạo mới
                                    </asp:HyperLink>
            			            
                                </td>
        		                
        		               <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="btn_Order" runat="server" CssClass="toolbar">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"  
                                            OnClick="btn_Order_Click" />
                                        <br />
                                        Cập nhật
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
    <td align="center">
    
        <asp:GridView ID="grvFaq" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grvFaq_RowCommand" OnRowDataBound="grvFaq_RowDataBound" CssClass="gridviewBorder" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="FaqID" HeaderText="ID">
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                            Width="31px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="Sắp xếp">
                        <ItemStyle HorizontalAlign="Center" Width="70px" CssClass="gridviewCellBottom gridviewCellRight" />
                        <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="gridviewCellBottom gridviewCellRight" />
                        <ItemTemplate>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFaqOrder"
                                Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                            <asp:TextBox ID="txtFaqOrder" runat="server" Width="20px" Text='<%# Eval("FaqOrder")%>'
                                MaxLength="2"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFaqOrder"
                                MaximumValue="1000" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="Question" HeaderText="C&#226;u hỏi" >
                        <ItemStyle HorizontalAlign="Left" CssClass="gridviewCellBottom gridviewCellRight" />
                        <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="Status" HeaderText="Trạng th&#225;i" >
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                            Width="60px" />
                    </asp:CheckBoxField>
                    <asp:TemplateField HeaderText="Chức năng" >
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        <ItemTemplate>
                            <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("FaqID") %>' ImageUrl="~/images/Admin_Theme/images/btn_edit.png" /> &nbsp;
                            <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("FaqID") %>' ImageUrl="~/images/Admin_Theme/images/btn_delete.png" /> 
                        </ItemTemplate>
                        <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center"
                            Width="70px" />
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