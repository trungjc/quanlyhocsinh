<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockVectorMap.ascx.cs"
    Inherits="WebMedi.Client.Modules.Panel.BlockVectorMap" %>
<h4>
    Việt Nam Map</h4>
<div id="main_content_wrap" class="row outer">
    <div id="vmap" style="width: 100%; height: 400px;">
    </div>
</div>
<script type="text/javascript">
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
    ga('create', 'UA-12306636-4', 'anshumania.github.io');
    ga('send', 'pageview');
</script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery('#vmap').vectorMap(
        {
            map: 'vn_map',
            backgroundColor: '#a5bfdd',
            borderColor: '#818181',
            borderOpacity: 0.25,
            borderWidth: 1,
            color: '#f4f3f0',
            enableZoom: true,
            hoverColor: '#c9dfaf',
            hoverOpacity: null,
            normalizeFunction: 'linear',
            scaleColors: ['#b6d6ff', '#005ace'],
            selectedColor: '#c9dfaf',
            selectedRegion: null,
            showTooltip: true
        });
    });
</script>
