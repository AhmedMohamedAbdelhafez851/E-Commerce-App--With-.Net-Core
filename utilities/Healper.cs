namespace Labs.utilities
{
    public static class Healper
    {
        // i will take object around system 
        // i will put the connection string and constants
        // i shoudnt inheritant from static class

        public static async Task<string> UploadImage(List<IFormFile> Files , string folderName)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/" + folderName , ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }



    }
}
