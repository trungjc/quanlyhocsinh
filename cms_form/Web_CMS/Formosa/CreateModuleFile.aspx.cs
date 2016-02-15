using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Xml;

namespace Fomusa
{
    public partial class CreateModuleFile : System.Web.UI.Page
    {
        public DataTable dt;
        string mdFolder = "Client/Modules/";
        string[] strModule;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCreateFile_Click(object sender, EventArgs e)
        {
            CreateXML();
        }

        public void CreateXML()
        {
            DataTable dtModule = TableGetFile();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                // tạo node cha
                XmlNode rootNode = xmlDoc.CreateElement("Client");
                xmlDoc.AppendChild(rootNode);

                foreach (string strFName in strModule)
                {
                    string _FName = strFName;
                    if (dtModule.Select("FolderName='" + _FName + "'").Count() > 0)
                    {
                        DataTable dtmdName = dtModule.Select("FolderName='" + _FName + "'").CopyToDataTable();
                        // tạo node con MainHome                
                        XmlNode childNode = xmlDoc.CreateElement(_FName);
                        rootNode.AppendChild(childNode);
                        for (int i = 0; i < dtmdName.Rows.Count; i++)
                        {
                            XmlNode mainHome = xmlDoc.CreateElement("md");
                            mainHome.InnerText = dtmdName.Rows[i]["Name"].ToString();
                            childNode.AppendChild(mainHome);
                        }
                    }
                }
                xmlDoc.Save(Server.MapPath(ResolveUrl("~/Module.xml")));
                lblMes.Text = "Tạo file Module thành công";
            }
            catch (Exception ex)
            {
                lblMes.Text = "Tạo file Module không thành công. Có lỗi xảy ra: " + ex.ToString();
            }
        }

        private DataTable TableGetFile()
        {
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("FolderName", Type.GetType("System.String"));
            myDataTable.Columns.Add("Name", Type.GetType("System.String"));

            #region Lấy danh sách tên thư mục trên ổ đĩa ném vào 1 mảng
            List<string> folders = new List<string>();

            string strModuleFolder = Server.MapPath(ResolveUrl("~/" + mdFolder));

            DirectoryInfo X = new DirectoryInfo(strModuleFolder);
            DirectoryInfo[] listaDeArchivos = X.GetDirectories();

            foreach (DirectoryInfo dI in listaDeArchivos)
            {
                folders.Add(dI.Name);
            }

            strModule = folders.ToArray();
            #endregion

            // Vào từng thư mục để lấy hết file UC trong đó ném vào DataTable
            foreach (string strParentFolder in strModule)
            {
                //load o len cay bang phuong phap de quy
                // khai bao mang o dia
                string upFolder = strModuleFolder + "\\" + strParentFolder;
                DirectoryInfo dir = new DirectoryInfo(upFolder);
                FileInfo[] fFileList = dir.GetFiles();
                if (fFileList != null)
                    if (fFileList.Length > 0)
                        foreach (FileInfo objFile in fFileList)
                        {
                            if (objFile.Extension.ToLower() == ".ascx")
                            {
                                DataRow myDataTableRow = myDataTable.NewRow();
                                myDataTableRow["FolderName"] = strParentFolder;
                                myDataTableRow["Name"] = objFile.Name.ToString();
                                myDataTable.Rows.Add(myDataTableRow);
                            }
                        }
            }
            return myDataTable;
        }
    }
}