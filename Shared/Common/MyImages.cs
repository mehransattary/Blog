using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
   public static class MyImages
    {
        public static string FilePath(string imageName,string pathNameFolder_In_Folderimages_wwroot, IFormFile file)
        {
            //using var image = Image.Load(file.OpenReadStream());
            string imagename = RandomNumber.Random(100, 10000) + file.FileName;

            using (var image = Image.Load(file.OpenReadStream()))
            {
                
                string filePath = Path.Combine(
                                      Directory.GetCurrentDirectory(),
                                      "wwwroot",
                                       "images/" + pathNameFolder_In_Folderimages_wwroot,
                                        imagename
                                          );
                RemoveDuplicatePhotos(filePath);

                image.Save(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }      
                       
          

            return "/images/" + pathNameFolder_In_Folderimages_wwroot + "/" + imagename;


        }
        public static void RemoveDuplicatePhotos(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
              
            }
        
        }
        public static string CurrentDirectory(string imagepath)
        {
            string Current = (Directory.GetCurrentDirectory() + "/" + "wwwroot" + imagepath);
            return Current;
        }
    }
    public static class MyVideos
    {
        public static string FilePath(string videoName, string pathNameFolder_In_FolderVideos_wwroot, IFormFile file, int? with = 0, int? height = 0)
        {
            //using var image = Image.Load(file.OpenReadStream());
            string _videoName = RandomNumber.Random(100, 10000) + file.FileName;
            string filePath = Path.Combine(
                                               Directory.GetCurrentDirectory(),
                                               "wwwroot",
                                                "videos/" + pathNameFolder_In_FolderVideos_wwroot,
                                                 _videoName
                                                   );
            RemoveDuplicateVideoss(filePath);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }



            return "/videos/" + pathNameFolder_In_FolderVideos_wwroot + "/" + _videoName;


        }
        public static void RemoveDuplicateVideoss(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);

            }

        }
        public static string CurrentDirectory(string videopath)
        {
            string Current = (Directory.GetCurrentDirectory() + "/" + "wwwroot" + videopath);
            return Current;
        }
    }
    public static class MyFiles
    {
        public static string FilePath(string Name, string pathNameFolder_In_FolderVideos_wwroot, IFormFile file, int? with = 0, int? height = 0)
        {
            //using var image = Image.Load(file.OpenReadStream());
            string _videoName = RandomNumber.Random(100, 10000) + file.FileName;
            string filePath = Path.Combine(
                                               Directory.GetCurrentDirectory(),
                                               "wwwroot",
                                                "images/" + pathNameFolder_In_FolderVideos_wwroot,
                                                 _videoName
                                                   );
            RemoveDuplicateVideoss(filePath);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }



            return "/images/" + pathNameFolder_In_FolderVideos_wwroot + "/" + _videoName;


        }
        public static void RemoveDuplicateVideoss(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);

            }

        }
        public static string CurrentDirectory(string videopath)
        {
            string Current = (Directory.GetCurrentDirectory() + "/" + "wwwroot" + videopath);
            return Current;
        }
    }
}
