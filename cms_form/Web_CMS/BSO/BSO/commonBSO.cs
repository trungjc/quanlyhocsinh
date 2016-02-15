namespace BSO
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Web.UI.WebControls;

    public class commonBSO
    {
        private bool CheckFileType(string filename)
        {
            switch (Path.GetExtension(filename).ToLower())
            {
                case ".gif":
                    return true;

                case ".jpg":
                    return true;

                case ".png":
                    return true;

                case ".jpeg":
                    return true;

                case ".bmb":
                    return true;

                case ".GIF":
                    return true;

                case ".JPG":
                    return true;

                case ".PNG":
                    return true;

                case ".JPEG":
                    return true;

                case ".BMB":
                    return true;
            }
            return false;
        }

        public string cutString(string sString, int len, string more)
        {
            string str = string.Empty;
            if (sString.Equals("") || (sString.Length <= len))
            {
                str = sString;
            }
            if (sString.Length > len)
            {
                str = sString.Substring(0, len);
                str = str.Substring(0, str.LastIndexOf(" "));
                str = !more.Equals("") ? (str + more) : str;
            }
            return str;
        }

        public void DeleteFile(string path)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(path);
                if (!fileinfo.Exists)
                {
                    throw new BusinessException("Khong tin thay file de xoa");
                }
                fileinfo.Delete();
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
        }

        public void FillToCheckBoxList(CheckBoxList checkboxlist, DataTable datatable, string displayMember, string valueMember)
        {
            if (datatable != null)
            {
                checkboxlist.DataSource = datatable;
                checkboxlist.DataTextField = displayMember;
                checkboxlist.DataValueField = valueMember;
            }
            else
            {
                checkboxlist.DataSource = null;
            }
            checkboxlist.DataBind();
        }

        public void FillToDropDown(DropDownList dropDownList, DataTable dataTable, string firstDisplayMember, string firstValueMember, string displayMember, string valueMember, string selectedIndex)
        {
            dropDownList.Items.Clear();
            if ((firstDisplayMember != "") && (firstValueMember != ""))
            {
                dropDownList.Items.Add(new ListItem(firstDisplayMember, firstValueMember));
            }
            dropDownList.DataSource = dataTable;
            dropDownList.DataTextField = displayMember;
            dropDownList.DataValueField = valueMember;
            dropDownList.DataBind();
            if (selectedIndex != "")
            {
                try
                {
                    dropDownList.SelectedValue = selectedIndex;
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex.Message.ToString());
                }
            }
        }

        public void FillToGridView(GridView gridview, DataTable datatable)
        {
            if (datatable != null)
            {
                gridview.DataSource = datatable;
            }
            else
            {
                gridview.DataSource = null;
            }
            gridview.DataBind();
        }

        public void FillToRadioList(RadioButtonList radiolist, DataTable datatable, string displayMember, string valueMember)
        {
            if (datatable != null)
            {
                radiolist.DataSource = datatable;
                radiolist.DataTextField = displayMember;
                radiolist.DataValueField = valueMember;
            }
            else
            {
                radiolist.DataSource = null;
            }
            radiolist.DataBind();
        }

        public void FillToRadioList(RadioButtonList radiolist, DataTable datatable, string displayMember, string valueMember, string selectedIndex)
        {
            if (datatable != null)
            {
                radiolist.DataSource = datatable;
                radiolist.DataTextField = displayMember;
                radiolist.DataValueField = valueMember;
            }
            else
            {
                radiolist.DataSource = null;
            }
            radiolist.DataBind();
            if (selectedIndex != "")
            {
                try
                {
                    radiolist.SelectedValue = selectedIndex;
                }
                catch (Exception ex)
                {
                    throw new BusinessException(ex.Message.ToString());
                }
            }
        }

        private string ReNameFile(string str)
        {
            string newstr = DateTime.Now.ToString("ddMMyyyyHHmmss");
            int sublength = Path.GetExtension(str).Length;
            int length = str.Length;
            string oldstr = str.Substring(0, length - sublength);
            return str.Replace(oldstr, newstr);
        }

        private bool TypeFileUpload(string filename)
        {
            switch (Path.GetExtension(filename).ToLower())
            {
                case ".doc":
                    return true;

                case ".xls":
                    return true;

                case ".zip":
                    return true;

                case ".rar":
                    return true;

                case ".ppt":
                    return true;

                case ".docx":
                    return true;

                case ".xlsx":
                    return true;

                case ".pptx":
                    return true;

                case ".DOC":
                    return true;

                case ".PPT":
                    return true;

                case ".ZIP":
                    return true;

                case ".RAR":
                    return true;

                case ".XLS":
                    return true;

                case ".pdf":
                    return true;

                case ".PDF":
                    return true;
            }
            return false;
        }

        private bool TypeVideoUpload(string filename)
        {
            switch (Path.GetExtension(filename).ToLower())
            {
                case ".flv":
                    return true;

                case ".FLV":
                    return true;
            }
            return false;
        }

        public string UploadFile(FileUpload fileupload, string savepath, long size)
        {
            string filename = "";
            if (fileupload.HasFile)
            {
                string name = fileupload.FileName;
                if ((fileupload.PostedFile.ContentLength <= size) && this.TypeFileUpload(name))
                {
                    filename = filename + this.ReNameFile(name);
                    savepath = savepath + filename;
                    fileupload.SaveAs(savepath);
                    return filename;
                }
                return filename;
            }
            return filename;
        }

        public string UploadImage(FileUpload file_upload, string save_path, int max_width, int max_height)
        {
            string filename = "";
            string folder_path = save_path;
            if (file_upload.HasFile)
            {
                if (!Directory.Exists(folder_path)) // Nếu đường dẫn đến thư mục không tồn tại
                    Directory.CreateDirectory(folder_path); // thì sẽ tạo thư mục tương ứng để lưu lại
                filename = filename + this.ReNameFile(file_upload.FileName);
                save_path = save_path + filename;
                Stream sStream = file_upload.FileContent;
                try
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(sStream))
                    {
                        if ((image.Width <= max_width) && (image.Height <= max_height))
                        {
                            file_upload.SaveAs(save_path);
                        }
                        else if ((image.Width > max_width) || (image.Height > max_height))
                        {
                            double widthRatio = ((double)image.Width) / ((double)max_width);
                            double heightRatio = ((double)image.Height) / ((double)max_height);
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(((double)image.Width) / ratio);
                            int newHeight = (int)(((double)image.Height) / ratio);
                            System.Drawing.Image oThumbNail = new Bitmap(newWidth, newHeight, image.PixelFormat);
                            Graphics oGraphic = Graphics.FromImage(oThumbNail);
                            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Rectangle oRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            oGraphic.DrawImage(image, oRectangle);                            
                            oThumbNail.Save(save_path, image.RawFormat);
                        }
                    }
                }
                catch
                {
                    filename = "";
                }
                sStream.Dispose();
                sStream.Close();
            }
            return filename;
        }

        public string UploadVideo(FileUpload fileupload, string savepath, long size)
        {
            string filename = "";
            if (fileupload.HasFile)
            {
                string name = fileupload.FileName;
                if ((fileupload.PostedFile.ContentLength <= size) && this.TypeVideoUpload(name))
                {
                    filename = filename + this.ReNameFile(name);
                    savepath = savepath + filename;
                    fileupload.SaveAs(savepath);
                    return filename;
                }
                return filename;
            }
            return filename;
        }

        public string EmbedYoutubeLink(string strLink)
        {
            string newLink = "";
            if (strLink.Contains("youtube"))
            {
                newLink = strLink.Replace("watch?", "").Replace("=", "/").ToString();
                return newLink;
            }
            else
                return strLink;
        }
    }
}

