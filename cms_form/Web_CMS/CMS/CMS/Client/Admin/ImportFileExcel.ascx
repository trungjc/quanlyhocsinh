<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportFileExcel.ascx.cs"
    Inherits="CMS.Client.Admin.ImportFileExcel" %>
<asp:HiddenField ID="hdnUrl" runat="server" />
<div class="categoryEdit padCont">
    <div class="TitPage">
        <asp:Label ID="lblArticles" Text="Import dữ liệu" runat="server"></asp:Label>
    </div>
    <table width="100%">
        <tr>
            <td>
                <div class="LineBE">
                    <div class="LeftCol">
                        <asp:Label runat="server" ID="Label1" Text="Tên sheet"></asp:Label>
                    </div>
                    <div class="RightCol">
                        <asp:TextBox ID="txtSheet" runat="server" Width="434px" Text="Sheet1"></asp:TextBox>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="LineBE">
                    <div class="LeftCol">
                        <asp:Label runat="server" ID="Label4" Text="Chọn file"></asp:Label>
                    </div>
                    <div class="RightCol">
                        <input id="fileAttach" runat="server" name="fileAttach" type="file" style="width: 95%;"
                            size='56' cssclass="ButtonMovePage" class="NormalFile" onchange='EnabledButtonUpload();' />
                    </div>
                </div>
                <div id="NDBtnBE">
                    <asp:LinkButton runat="server" ID="btnSave" CssClass="SaveIcon" ValidationGroup="G"
                        Text="Import dữ liệu" OnClick="btnSave_Click" />
                </div>
            </td>
        </tr>
    </table>
</div>
<script language="javascript" type="text/javascript">
    function SelectImage() {
        alert('aaaa');
    }
    function SelectUrl() {
        var _url = document.getElementById("<%=hdnUrl.ClientID%>").value;
        return window.open(_url, '_blank', 'scrollbars=no,resizable=no,locationbar=no,width=800,height=480,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 250) / 2));
    } 

</script>
