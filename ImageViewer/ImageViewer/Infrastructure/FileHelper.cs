using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ImageViewer.Infrastructure
{
    public static class FileHelper
    {
        public static List<string> GetFilePaths(string path)
        {
            //  GetFullPath returns the absolute path for the folder.
            //  Xaml will not work with relative paths as an image source.
            string[] filenames = Directory.GetFiles(Path.GetFullPath(path));
            if (filenames == null) return new List<string>();
            return filenames.ToList<string>();
        }
    }
}
