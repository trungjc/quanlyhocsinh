<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainHomeTabGroupNews.ascx.cs" Inherits="Fomusa.Client.Modules.MainHome.MainHomeTabGroupNews" %>
<%@ Register Src="~/Client/Modules/MainHome/MainHomeOfficial.ascx" TagName="MainHomeOfficial"
    TagPrefix="panelMainHomeOfficial" %>
<%@ Register Src="~/Client/Modules/MainHome/MainHomeEventActivity.ascx" TagName="MainHomeEventActivity"
    TagPrefix="panelMainHomeEventActivity" %>
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

<radTS:RadTabStrip ID="RadTabStrip1" runat="server" Skin="NLDC1" MultiPageID="RadMultiPage1"
    SelectedIndex="0" OnClientMouseOver="SelectMyTab" ClickSelectedTab="true" OnClientMouseOut="UnSelectMyTab(event)"
    EnableEmbeddedSkins="true">
    <Tabs>
        <radTS:Tab ID="Tab1" runat="server" Text="Thông tin vận hành thị trường điện">
        </radTS:Tab>
        <radTS:Tab ID="Tab2" runat="server" Text="Văn bản pháp qui">
        </radTS:Tab>
    </Tabs>
</radTS:RadTabStrip>
<radTS:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="main_tab_group"
    Width="100%">
    <radTS:PageView ID="PageView1" runat="server">
        <panelMainHomeEventActivity:MainHomeEventActivity ID="MainHomeEventActivity1" runat="server" />
    </radTS:PageView>
    <radTS:PageView ID="PageView2" runat="server">
        <div class="main_tab_group_panel">
            <panelMainHomeOfficial:MainHomeOfficial ID="MainHomeOfficial1" runat="server" />
        </div>
    </radTS:PageView>
</radTS:RadMultiPage>
