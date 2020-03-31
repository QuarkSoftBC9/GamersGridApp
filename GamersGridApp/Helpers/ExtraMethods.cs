using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GamersGridApp.Helpers
{
    public class ExtraMethods
    {
        public static string UploadPhoto(int id,HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var rondom = Guid.NewGuid() + fileName;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/"+ id), rondom);
                var filePathToSave = "UserPhotos/"+ id + "/" + fileName;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/"+ id)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/"+ id));
                }
                file.SaveAs(path);


                return rondom;
            }
            return "nofile.png";
        }
    }
}