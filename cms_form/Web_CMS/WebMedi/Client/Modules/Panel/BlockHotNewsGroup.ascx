<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockHotNewsGroup.ascx.cs"
    Inherits="WebMedi.Client.Modules.Panel.BlockHotNewsGroup" %>
<div class="row sidebar-content">
    <h4>
        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h4>
</div>
<asp:Repeater ID="rptListHotReport" runat="server">
    <ItemTemplate>
        <div class="row sidebar-body">
            <div class="col-md-1 icon-sidebar">
            </div>
            <div class="col-md-11 text-sidebar">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# "~/newsg/"+Eval("GroupCate")+"/" +Eval("NewsGroupID")+"/" + GetString(Eval("Title")) +"/default.aspx" %>'
                    Text='<%# Eval("Title") %>'></asp:HyperLink><br />
                <span class="listHotEventActivity">(<asp:Label ID="Label1" runat="server" Text='<%# Eval("PostDate","{0:dd/MM/yyyy}") %>'></asp:Label>)
                </span>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />