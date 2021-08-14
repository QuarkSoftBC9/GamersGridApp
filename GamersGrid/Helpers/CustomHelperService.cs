using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Helpers
{
    public class CustomHelperService
    {
        private IWebHostEnvironment _hostEnv;
        public CustomHelperService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnv = hostEnvironment;
        }
        public async Task<string> SaveAvatar(IFormFile photo,string previousAvatar=null)
        {
            if (photo != null)
            {
                var savePath = Path.Combine(_hostEnv.WebRootPath, "UsersAvatars");
                Directory.CreateDirectory(savePath);

                var fileGuid = Guid.NewGuid().ToString();
                var fileName = $"{fileGuid}{IdentifyImageType(photo)}";
                var file = Path.Combine(savePath, fileName);


                //Search and delete previous file
                if (previousAvatar != null)
                    File.Delete(Path.Combine(savePath, previousAvatar));


                using (Stream fileStream = new FileStream(file, FileMode.Create))
                    await photo.CopyToAsync(fileStream);

                return fileName;
            }


            return null;
        }


        private string IdentifyImageType(IFormFile image)
        {
            var imageTypes = new List<string>() { "jpg", "jpeg", "png" };

            foreach (var imageType in imageTypes)
            {
                if (image.FileName.EndsWith(imageType, StringComparison.OrdinalIgnoreCase))
                    return $".{imageType}";
            }

            return ".jpg";
        }
        //public  double CalculateKda(List<DotaMatch> matches)
        //{
        //    int KillsAssists = 0;
        //    int deaths = 0;
        //    foreach (var dotaMatch in matches)
        //    {
        //        KillsAssists += dotaMatch.kills + dotaMatch.assists;
        //        deaths += dotaMatch.deaths;
        //    }
        //    return KillsAssists / deaths;
        //}
    }
}
