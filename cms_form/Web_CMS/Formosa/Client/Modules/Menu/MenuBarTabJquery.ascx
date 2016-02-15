<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBarTabJquery.ascx.cs" Inherits="Fomusa.Client.Modules.Menu.MenuBarTabJquery" %>
<%@ Register Assembly="RadTabStrip.Net2" Namespace="Telerik.WebControls" TagPrefix="radTS" %>
<%@ Register Assembly="RadMenu.Net2" Namespace="Telerik.WebControls" TagPrefix="radM" %>

<script type="text/javascript">
    function SelectMyTab(obj, args) {
        args.Tab.Select();
    }

    function UnSelectMyTab(e) {
        var tabStrip = <%=RadTabStrip1.ClientID%>;
        //Find the element which the mouse is over   
        var destElement = e.relatedTarget || e.toElement;
        //Check if that element is part of the tabstrip              
        while (destElement) {
            if (destElement.parentNode == tabStrip.DomElement) {
                return;
            }
            destElement = destElement.parentNode;
        }
        tabStrip.FindTabByText("<%=MyTab %>").SelectParents();
    }        
</script>

<div class="menubar">
    <radTS:RadTabStrip ID="RadTabStrip1" runat="server" OnClientMouseOver="SelectMyTab"
        ClickSelectedTab="True" AutoPostBack="True" OnClientMouseOut="UnSelectMyTab(event)"
        SelectedIndex="0" Skin="NLDCMenu" MultiPageID="RadMultiPage1">
    </radTS:RadTabStrip>
</div>
<div class="menubarsub">
    <div class="menubarsub_panel">
        <radTS:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" Width="100%">
        </radTS:RadMultiPage>
    </div>
</div>