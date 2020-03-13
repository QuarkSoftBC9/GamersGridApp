using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GamersGridApp.Helpers
{
    public class ExtraMethods
    {
        public static string UploadPhoto(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var rondom = Guid.NewGuid() + fileName;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos"), rondom);
                var filePathToSave = "UserPhotos/" + fileName;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos"));
                }
                file.SaveAs(path);

                return rondom;
            }
            return "nofile.png";
        }
    }
}