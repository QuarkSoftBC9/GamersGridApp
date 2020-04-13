using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GamersGridApp.Helpers
{
    public class ExtraMethods
    {

        public static string UploadPhoto(string userName,HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var rondom = Guid.NewGuid() + fileName;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/"+userName), rondom);
                //var file = "UserPhotos/"+userName+"/" + fileName;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/"+userName)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/"+userName));
                }
                file.SaveAs(path);


                return rondom;
            }
            return "nofile.png";
        }
    }
}