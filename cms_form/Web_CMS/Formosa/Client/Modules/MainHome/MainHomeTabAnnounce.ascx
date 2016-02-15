<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeTabAnnounce.ascx.cs" Inherits="Fomusa.Client.Modules.MainHome.MainHomeTabAnnounce" %>
<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>

<script type="text/javascript">
    function SelectMyTab(obj, args) {
        args.Tab.Select();
    }

    function UnSelectMyTab(e) {
        var tabStrip = $find('<%= RadTabStrip1.ClientID%>');
        if (!tabStrip) return;
        var destElement = e.relatedTarget || e.toElement;
        while (destElement) {
            if (destElement.parentNode == tabStrip.DomElement) {
                return;
            }
            destElement = destElement.parentNode;
        }
        var initialTab = tabStrip.FindTabByText("<%=MyTab %>").SelectParents();
        initialTab.unselect();
        initialTab.selectParents()

    } 
</script>

<div class="main_tab_hotannounce">
    <radTS:RadTabStrip ID="RadTabStrip1" runat="server" Skin="NLDC1" MultiPageID="RadMultiPage1"
        SelectedIndex="0" OnClientMouseOver="SelectMyTab" ClickSelectedTab="true" OnClientMouseOut="UnSelectMyTab(event)"
        EnableEmbeddedSkins="true">
    </radTS:RadTabStrip>
    <radTS:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="main_tab"
        Width="100%">
    </radTS:RadMultiPage>
</div>
