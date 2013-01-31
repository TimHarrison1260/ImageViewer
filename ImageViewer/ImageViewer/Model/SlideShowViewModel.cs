using System;
using System.Collections.ObjectModel;

using ImageViewer.Infrastructure;

using System.IO;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace ImageViewer.Model
{
    public class SlideShowViewModel : INotifyPropertyChanged
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

        private Slide _currentImage;
        /// <summary>
        /// Gets or set the current slide
        /// </summary>
        public Slide CurrentSlide
        {
            get { return _currentImage; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanging("CurrentSlide");
                    _currentImage = value;
                    OnPropertyChanged("CurrentSlide");
                }
            }
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
                Slide s = new Slide()
                {
                    Image = new BitmapImage(new Uri(p)),
                    Name = Path.GetFileName(p)
                };
                _slides.Add(s);
            }
            //  Set the current image to the first one in the collection
            _currentImage = _slides[0];
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        protected void OnPropertyChanged(string PropertyName)
        {
            var changedEvent = PropertyChanged;
            if (changedEvent != null)
            {
                changedEvent(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        protected void OnPropertyChanging(string PropertyName)
        {
            var changingEvent = PropertyChanging;
            if (changingEvent != null)
                changingEvent(this, new PropertyChangingEventArgs(PropertyName));
        }
    }
}
