using System;
using System.Collections.ObjectModel;

using ImageViewer.Infrastructure;

using System.IO;
using System.Windows.Media.Imaging;

namespace ImageViewer.Model
{
    public class SlideShowViewModel
    {
        private ImageRepository repository = new ImageRepository();

        /// <summary>
        /// Constructor, initialise the SlideShowViewModel class
        /// and is parameterless.
        /// </summary>
        public SlideShowViewModel()
        {
            LoadData();
        }

        private ObservableCollection<Slide> _slides = new ObservableCollection<Slide>();
        /// <summary>
        /// Gets the current collection of slides.
        /// </summary>
        /// <remarks>
        /// This is the property we should bind to.
        /// </remarks>
        public ObservableCollection<Slide> Slides
        {
            get { return _slides; }
        }

        /// <summary>
        /// Gets all Slides
        /// </summary>
        /// <returns>ObservabeCollection of Slides</returns>
        /// <remarks>
        /// This will not be directly bindable.
        /// </remarks>
        public ObservableCollection<Slide> GetAllSlides()
        {
            return _slides;
        }


        /// <summary>
        /// Load the data into the model.
        /// </summary>
        private void LoadData()
        {
            //  TODO: refactor this code to use the Object constructor.
            var imagePaths = repository.GetImagePaths();
            foreach (var p in imagePaths)
            {
                Uri uri = new Uri(p);
                BitmapImage img = new BitmapImage(uri);
                Slide s = new Slide();
                s.Image = img;
                s.Name = Path.GetFileName(p);
                //{
                //    Image = new BitmapImage(new Uri(p)),
                //    Name = Path.GetFileName(p)
                //};
                _slides.Add(s);
               
            }
        }

    }
}
