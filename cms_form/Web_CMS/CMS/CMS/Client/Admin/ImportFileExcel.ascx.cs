using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ETO;
using BSO;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CMS.Client.Admin
{
    public partial class ImportFileExcel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Path
        {
            get
            {
                //Check Exist ViewState
                if (ViewState["Path"] != null && ViewState["Path"] is string)
                {
                    return (string)ViewState["Path"];
                }
                else

                    return "";
            }
            set { ViewState["Path"] = value; }
        }
        private string OpenExcelFile(string fPath)
        {
            string connectionstring = String.Empty;
            string[] splitdot = fPath.Split(new char[1] { '.' });
            string dot = splitdot[splitdot.Length - 1].ToLower();
            if (dot == "xls")
            {
                //tao chuoi ket noi voi Excel 2003
                connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (dot == "xlsx")
            {
                //tao chuoi ket noi voi Excel 2007
                connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            }
            return connectionstring;
        }
        public string UploadFile(HtmlInputFile fUpload)
        {
            string fPath = String.Empty;
            try
            {

                fPath = Server.MapPath(ResolveUrl("~/") + "Upload/Files/" + fUpload.PostedFile.FileName);


                string[] splitdot = fPath.Split(new char[1] { '.' });
                string dot = splitdot[splitdot.Length - 1].ToLower();
                if (dot.ToLower() == "xls")
                {
                    FileInfo fInfo = new FileInfo(fPath);
                    if (fInfo.Exists)
                    {
                        fInfo.Delete();
                    }
                    fUpload.PostedFile.SaveAs(fPath);
                    Path = fPath;
                }
                else
                {
                    //Tool.Message(this.Page, "Bạn phải chọn phải đuôi .xls");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return fPath;
        }
        public ArrayList GetSheetName(string fPath)
        {
            ArrayList sheetnames = new ArrayList();
            string connectionstring = OpenExcelFile(fPath);
            //mo ket noi den file excel
            OleDbConnection cnn = new OleDbConnection(connectionstring);
            cnn.Open();

            //tao bang luu tru tam cac du lieu trong file
            DataTable table = new DataTable();
            table = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //doc tung dong trong bang luu tru tam
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string name = table.Rows[i][2].ToString().Replace("'", "");//get ten tung sheet co trong bang luu tru
                //kiem tra sheet
                if (name.EndsWith("$"))
                {
                    sheetnames.Add(name.Replace("$", ""));
                }
            }
            cnn.Close();
            table.Dispose();
            return sheetnames;
        }

        public DataSet GetDataExcel(string sheetname)
        {
            //HtmlInputFile
            DataSet ds = new DataSet();
            string fPath = Path;
            string connectionstring = OpenExcelFile(fPath);
            string query = "SELECT * FROM [" + sheetname + "$]";
            using (OleDbConnection cnn = new OleDbConnection(connectionstring))
            {
                cnn.Open();
                OleDbDataAdapter oleAdapter = new OleDbDataAdapter(query, cnn);
                oleAdapter.Fill(ds, sheetname);
                oleAdapter.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            return ds;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool _check = false;
            UploadFile(fileAttach);
            DataSet _dset = GetDataExcel(txtSheet.Text.Trim());
            if (_dset != null)
            {
                if (_dset.Tables.Count > 0)
                {

                    foreach (DataRow _dr in _dset.Tables[0].Rows)
                    {
                        #region
                        try
                        {
                            Chart24h obj = new Chart24h();

                            obj.ChartPostDate = DateTime.Now;
                            obj.ChartStatus = true;
                            if (_dr["ChartName"] != null && _dr["ChartName"] != DBNull.Value)
                            {
                                obj.ChartName = _dr["ChartName"].ToString();
                            }

                            if (_dr["F2"] != null && _dr["F2"] != DBNull.Value)
                            {
                                obj.Hour_1 = Convert.ToInt32(_dr["F2"].ToString());
                            }
                            if (_dr["F3"] != null && _dr["F3"] != DBNull.Value)
                            {
                                obj.Hour_2 = Convert.ToInt32(_dr["F3"].ToString());
                            }
                            if (_dr["F4"] != null && _dr["F4"] != DBNull.Value)
                            {
                                obj.Hour_3 = Convert.ToInt32(_dr["F4"].ToString());
                            }
                            if (_dr["F5"] != null && _dr["F5"] != DBNull.Value)
                            {
                                obj.Hour_4 = Convert.ToInt32(_dr["F5"].ToString());
                            }
                            if (_dr["F6"] != null && _dr["F6"] != DBNull.Value)
                            {
                                obj.Hour_5 = Convert.ToInt32(_dr["F6"].ToString());

                            }
                            if (_dr["F7"] != null && _dr["F7"] != DBNull.Value)
                            {
                                obj.Hour_6 = Convert.ToInt32(_dr["F7"].ToString());
                            }
                            if (_dr["F8"] != null && _dr["F8"] != DBNull.Value)
                            {
                                obj.Hour_7 = Convert.ToInt32(_dr["F8"].ToString());
                            }
                            if (_dr["F9"] != null && _dr["F9"] != DBNull.Value)
                            {
                                obj.Hour_8 = Convert.ToInt32(_dr["F9"].ToString());
                            }

                            if (_dr["F10"] != null && _dr["F10"] != DBNull.Value)
                            {
                                obj.Hour_9 = Convert.ToInt32(_dr["F10"].ToString());
                            }

                            if (_dr["F11"] != null && _dr["F11"] != DBNull.Value)
                            {
                                obj.Hour_10 = Convert.ToInt32(_dr["F11"].ToString());
                            }
                            if (_dr["F12"] != null && _dr["F12"] != DBNull.Value)
                            {
                                obj.Hour_11 = Convert.ToInt32(_dr["F12"].ToString());
                            }
                            if (_dr["F13"] != null && _dr["F13"] != DBNull.Value)
                            {
                                obj.Hour_12 = Convert.ToInt32(_dr["F13"].ToString());
                            }
                            if (_dr["F14"] != null && _dr["F14"] != DBNull.Value)
                            {
                                obj.Hour_13 = Convert.ToInt32(_dr["F14"].ToString());
                            }
                            if (_dr["F15"] != null && _dr["F15"] != DBNull.Value)
                            {
                                obj.Hour_14 = Convert.ToInt32(_dr["F15"].ToString());
                            }
                            if (_dr["F16"] != null && _dr["F16"] != DBNull.Value)
                            {
                                obj.Hour_15 = Convert.ToInt32(_dr["F16"].ToString());

                            }
                            if (_dr["F17"] != null && _dr["F17"] != DBNull.Value)
                            {
                                obj.Hour_16 = Convert.ToInt32(_dr["F17"].ToString());
                            }
                            if (_dr["F18"] != null && _dr["F18"] != DBNull.Value)
                            {
                                obj.Hour_17 = Convert.ToInt32(_dr["F18"].ToString());
                            }
                            if (_dr["F19"] != null && _dr["F19"] != DBNull.Value)
                            {
                                obj.Hour_18 = Convert.ToInt32(_dr["F19"].ToString());
                            }

                            if (_dr["F20"] != null && _dr["F20"] != DBNull.Value)
                            {
                                obj.Hour_19 = Convert.ToInt32(_dr["F20"].ToString());
                            }

                            if (_dr["F21"] != null && _dr["F21"] != DBNull.Value)
                            {
                                obj.Hour_20 = Convert.ToInt32(_dr["F21"].ToString());
                            }
                            if (_dr["F22"] != null && _dr["F22"] != DBNull.Value)
                            {
                                obj.Hour_21 = Convert.ToInt32(_dr["F22"].ToString());
                            }
                            if (_dr["F23"] != null && _dr["F23"] != DBNull.Value)
                            {
                                obj.Hour_22 = Convert.ToInt32(_dr["F23"].ToString());
                            }
                            if (_dr["F24"] != null && _dr["F24"] != DBNull.Value)
                            {
                                obj.Hour_23 = Convert.ToInt32(_dr["F24"].ToString());
                            }
                            if (_dr["F25"] != null && _dr["F25"] != DBNull.Value)
                            {
                                obj.Hour_24 = Convert.ToInt32(_dr["F25"].ToString());
                            }
                            Chart24hBSO chart24hBSO = new Chart24hBSO();
                            chart24hBSO.CreateChart24h(obj);
                            _check = true;


                            Utils objUtil = new Utils();
                            string _path = ResolveUrl("~/") + "Upload/Chart";
                            DateTime _date = obj.ChartPostDate;
                            objUtil.DeleteFile(Server.MapPath(_path), _path, _date.ToString("dd_MM_yyyy") + ".png");
                        }
                        catch { }
                        #endregion
                    }

                }
            }
            if (_check == true)
            {
                Response.Write("<script language='javascript'> {window.close(); window.opener.SubmitForm(); }</script>");
            }
        }

    }
}