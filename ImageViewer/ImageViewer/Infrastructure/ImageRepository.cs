using System.Collections.Generic;

namespace ImageViewer.Infrastructure
{
    public class ImageRepository
    {
        private List<string> _imagePaths = new List<string>();
        private const string constImageFolder = @"..\..\Images";

        public ImageRepository()
        {
            //  Load the repository with the images from the image folder.
            LoadImages();
        }

        public List<string> GetImagePaths()
        {
            return _imagePaths;
        }

        private void LoadImages()
        {
            _imagePaths = FileHelper.GetFilePaths(constImageFolder);
        }

    }
}
