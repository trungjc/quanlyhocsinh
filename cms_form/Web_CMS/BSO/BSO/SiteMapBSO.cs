namespace BSO
{
    using ETO;
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Web;
    using System.Xml;

    public class SiteMapBSO : StaticSiteMapProvider
    {
        private SiteMapNode _rootNode = null;
        private string _siteMapFileName;
        private bool m_RefreshSitemap;
        private const string SiteMapNodeName = "siteMapNode";

        private static XmlElement AddDynamicChildElement(XmlElement parentElement, string url, string title, string description)
        {
            XmlElement childElement = parentElement.OwnerDocument.CreateElement("siteMapNode");
            childElement.SetAttribute("url", url);
            childElement.SetAttribute("title", title);
            childElement.SetAttribute("description", description);
            parentElement.AppendChild(childElement);
            return childElement;
        }

        private void AddDynamicNodes(XmlElement rootElement)
        {
            DataTable datatable = new PagesBSO().GetPagesCate(Language.language);
            if (datatable != null)
            {
                foreach (DataRow rows in datatable.Rows)
                {
                    AddDynamicChildElement(rootElement, "~/Default2.aspx?goto=" + rows["PageName"].ToString(), rows["PageName"].ToString(), rows["PageName"].ToString());
                }
            }
        }

        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {
                if ((this._rootNode == null) || this.m_RefreshSitemap)
                {
                    this.m_RefreshSitemap = false;
                    this.Clear();
                    XmlElement rootElement = (XmlElement) this.LoadSiteMapXml().GetElementsByTagName("siteMapNode")[0];
                    this.AddDynamicNodes(rootElement);
                    this.GenerateSiteMapNodes(rootElement);
                }
            }
            return this._rootNode;
        }

        protected override void Clear()
        {
            lock (this)
            {
                this._rootNode = null;
                base.Clear();
            }
        }

        private void CreateChildNodes(XmlElement parentElement, SiteMapNode parentNode)
        {
            foreach (XmlNode xmlElement in parentElement.ChildNodes)
            {
                if (xmlElement.Name == "siteMapNode")
                {
                    SiteMapNode childNode = this.GetSiteMapNodeFromElement((XmlElement) xmlElement);
                    this.AddNode(childNode, parentNode);
                    this.CreateChildNodes((XmlElement) xmlElement, childNode);
                }
            }
        }

        private void GenerateSiteMapNodes(XmlElement rootElement)
        {
            this._rootNode = this.GetSiteMapNodeFromElement(rootElement);
            this.AddNode(this._rootNode);
            this.CreateChildNodes(rootElement, this._rootNode);
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return this.RootNode;
        }

        private SiteMapNode GetSiteMapNodeFromElement(XmlElement rootElement)
        {
            string url = rootElement.GetAttribute("url");
            string title = rootElement.GetAttribute("title");
            return new SiteMapNode(this, (url + title).GetHashCode().ToString(), url, title, rootElement.GetAttribute("description"));
        }

        public override void Initialize(string name, NameValueCollection attributes)
        {
            base.Initialize(name, attributes);
            this._siteMapFileName = attributes["siteMapFile"];
        }

        private XmlDocument LoadSiteMapXml()
        {
            XmlDocument siteMapXml = new XmlDocument();
            siteMapXml.Load(AppDomain.CurrentDomain.BaseDirectory + this._siteMapFileName);
            return siteMapXml;
        }

        public void RefreshSitemap()
        {
            this.m_RefreshSitemap = true;
        }

        public override SiteMapNode RootNode
        {
            get
            {
                return this.BuildSiteMap();
            }
        }
    }
}

