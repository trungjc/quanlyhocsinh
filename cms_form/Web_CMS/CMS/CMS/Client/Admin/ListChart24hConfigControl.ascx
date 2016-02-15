<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListChart24hConfigControl.ascx.cs"
    Inherits="CMS.Client.Admin.ListChart24hConfigControl" %>
<asp:HiddenField ID="hdnUrl" runat="server" />
<div class="categoryEdit padCont">
    <div class="TitPage">
        <asp:Label ID="lblArticles" Text="Tiêu đề biểu đồ" runat="server"></asp:Label>
    </div>
    <table width="100%">
        <tr>
            <td>
                <div class="LineBE">
                    <asp:TextBox ID="txtTitleChart" runat="server" Height="150px" TextMode="MultiLine"
                        Width="450px" Text="" Font-Size="12px" Font-Names="Arial"></asp:TextBox>
                </div>
                <div id="NDBtnBE">
                    <asp:LinkButton runat="server" ID="btnSave" CssClass="SaveIcon" ValidationGroup="G"
                        Text="Lưu dữ liệu" OnClick="btnSave_Click" />
                </div>
            </td>
        </tr>
    </table>
</div>
