using System;
using System.Web;
using System.Drawing;
using System.Web.Caching;
using System.IO;
using System.Drawing.Imaging;

namespace CMS
{
    public class ImageHandler : IHttpHandler
    {

        public int Width;
        public int Height;
        public static string NoImageUrl = @"Upload\Admin_Theme\images\module.jpg";
        public string ImageUrl;


        public void ProcessRequest(HttpContext context)
        {
            Bitmap bitOutput;

            if (context.Cache[("ImageQueryURL-" + context.Request.QueryString.ToString())] != null)
            {
                bitOutput = (Bitmap)context.Cache[("ImageQueryURL-" + context.Request.QueryString.ToString())];
            }
            else
            {
                var bitInput = GetImage(context);

                bitInput = RotateFlipImage(context, bitInput);

                bitOutput = SetHeightWidth(context, bitInput) ? ResizeImage(bitInput, Width, Height) : bitInput;

                context.Response.ContentType = "image/png";
                bitOutput.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);

                context.Cache.Insert(("ImageQueryURL-" + context.Request.QueryString.ToString()), bitOutput, new CacheDependency(ImageUrl), Cache.NoAbsoluteExpiration, TimeSpan.FromHours(8), System.Web.Caching.CacheItemPriority.BelowNormal, null);
            }

            context.Response.ContentType = "image/png";
            bitOutput.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            return;
        }


        /// <summary>
        /// Get the image requested via the query string. 
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Return the requested image or the "no image" default if it does not exist.</returns>
        public Bitmap GetImage(HttpContext context)
        {
            if (context.Cache[("ImagePath-" + context.Request.QueryString["image"])] == null)
            {
                var appPath = context.Server.MapPath(context.Request.ApplicationPath) + Path.DirectorySeparatorChar;

                if (String.IsNullOrEmpty(context.Request.QueryString["image"]))
                {
                    appPath += NoImageUrl;
                }
                else
                {
                    if (System.IO.File.Exists((appPath + context.Request.QueryString["image"])))
                    {
                        appPath += context.Request.QueryString["image"];
                    }
                    else
                    {
                        appPath += NoImageUrl;
                    }
                }

                ImageUrl = appPath;

                var bitOutput = new Bitmap(appPath);
                context.Cache.Insert(("ImagePath-" + context.Request.QueryString["image"]), bitOutput, new CacheDependency(ImageUrl), Cache.NoAbsoluteExpiration, TimeSpan.FromHours(8), System.Web.Caching.CacheItemPriority.BelowNormal, null);
                return bitOutput;
            }
            else
            {
                return (Bitmap)context.Cache[("ImagePath-" + context.Request.QueryString["image"])];
            }
        }


        /// <summary>
        /// Set the height and width of the handler class.
        /// </summary>
        /// <param name="context">The context to get the query string parameters, typically current context.</param>
        /// <param name="bitInput">The bitmap that determines the </param>
        /// <returns>True if image needs to be resized, false if original dimensions can be kept.</returns>
        public bool SetHeightWidth(HttpContext context, Bitmap bitInput)
        {
            var inputRatio = Convert.ToDouble(bitInput.Width) / Convert.ToDouble(bitInput.Height);

            if (!(String.IsNullOrEmpty(context.Request["width"])) && !(String.IsNullOrEmpty(context.Request["height"])))
            {
                Width = Int32.Parse(context.Request["width"]);
                Height = Int32.Parse(context.Request["height"]);
                return true;
            }
            else if (!(String.IsNullOrEmpty(context.Request["width"])))
            {
                Width = Int32.Parse(context.Request["width"]);
                Height = Convert.ToInt32((Width / inputRatio));
                return true;
            }
            else if (!(String.IsNullOrEmpty(context.Request["height"])))
            {
                Height = Int32.Parse(context.Request["height"]);
                Width = Convert.ToInt32((Height * inputRatio));
                return true;
            }
            else
            {
                Height = bitInput.Height;
                Width = bitInput.Width;
                return false;
            }
        }

        /// <summary>
        /// Flip or rotate the bitmap according to the query string parameters.
        /// </summary>
        /// <param name="context">The context of the query string parameters.</param>
        /// <param name="bitInput">The bitmap to be flipped or rotated.</param>
        /// <returns>The bitmap after it has been flipped or rotated.</returns>
        public Bitmap RotateFlipImage(HttpContext context, Bitmap bitInput)
        {
            var bitOut = bitInput;

            if (String.IsNullOrEmpty(context.Request["RotateFlip"]))
            {
                return bitInput;
            }
            else if (context.Request["RotateFlip"] == "Rotate180flipnone")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (context.Request["RotateFlip"] == "Rotate180flipx")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            else if (context.Request["RotateFlip"] == "Rotate180flipxy")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate180FlipXY);
            }
            else if (context.Request["RotateFlip"] == "Rotate180flipy")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            else if (context.Request["RotateFlip"] == "Rotate270flipnone")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (context.Request["RotateFlip"] == "Rotate270flipx")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate270FlipX);
            }
            else if (context.Request["RotateFlip"] == "Rotate270FlipXY")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate270FlipXY);
            }
            else if (context.Request["RotateFlip"] == "Rotate270FlipY")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate270FlipY);
            }
            else if (context.Request["RotateFlip"] == "Rotate90FlipNone")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (context.Request["RotateFlip"] == "Rotate90FlipX")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate90FlipX);
            }
            else if (context.Request["RotateFlip"] == "Rotate90FlipXY")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate90FlipXY);
            }
            else if (context.Request["RotateFlip"] == "Rotate90FlipY")
            {
                bitOut.RotateFlip(RotateFlipType.Rotate90FlipY);
            }
            else if (context.Request["RotateFlip"] == "RotateNoneFlipX")
            {
                bitOut.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else if (context.Request["RotateFlip"] == "RotateNoneFlipXY")
            {
                bitOut.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            }
            else if (context.Request["RotateFlip"] == "RotateNoneFlipY")
            {
                bitOut.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            else { return bitInput; }

            return bitOut;
        }


        /// <summary>
        /// Resizes bitmap using high quality algorithms.
        /// </summary>
        /// <param name="originalBitmap"></param>
        /// <param name="newWidth">The width of the returned bitmap.</param>
        /// <param name="newHeight">The height of the returned bitmap.</param>
        /// <returns>Resized bitmap.</returns>
        public static Bitmap ResizeImage(Bitmap originalBitmap, int newWidth, int newHeight)
        {
            var inputBitmap = originalBitmap;
            var resizedBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            var g = Graphics.FromImage(resizedBitmap);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            var rectangle = new Rectangle(0, 0, newWidth, newHeight);
            g.DrawImage(inputBitmap, rectangle, 0, 0, inputBitmap.Width, inputBitmap.Height, GraphicsUnit.Pixel);
            g.Dispose();

            return resizedBitmap;
        }


        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}