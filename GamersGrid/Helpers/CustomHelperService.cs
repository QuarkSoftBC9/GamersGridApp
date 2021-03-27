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
        public async Task<string> SaveAvatar(IFormFile photo)
        {
            if (photo != null)
            {
                var savePath = Path.Combine(_hostEnv.WebRootPath, "UsersAvatars\\");
                var file = Path.Combine(savePath, Guid.NewGuid() + photo.FileName);

                if (File.Exists(file))
                    return file;

                using (Stream fileStream = new FileStream(file, FileMode.Create))
                    await photo.CopyToAsync(fileStream);

                return file;
            }


            return null;
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
