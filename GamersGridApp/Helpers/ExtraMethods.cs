using GamersGridApp.Dtos.ApiAcountsDtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GamersGridApp.Helpers
{
    public class ExtraMethods
    {
        public static string UploadPhoto(int id, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var rondom = Guid.NewGuid() + fileName;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/" + id), rondom);
                var filePathToSave = "UserPhotos/" + id + "/" + fileName;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/" + id)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Images/UserPhotos/" + id));
                }
                file.SaveAs(path);


                return rondom;
            }
            return "nofile.png";
        }

        public static double CalculateKda(List<DotaMatchDto> matches)
        {
            int KillsAssists = 0;
            int deaths = 0;
            foreach (var dotaMatch in matches)
            {
                KillsAssists += dotaMatch.kills + dotaMatch.assists;
                deaths += dotaMatch.deaths;
            }
            if(deaths == 0)
            {
                return 0;
            }
            return KillsAssists / deaths;
        }
        public static double CalculateKda(double avgDeaths, double avgEliminations)
        {

            return Math.Round(avgEliminations / avgDeaths);
        }
    }
}