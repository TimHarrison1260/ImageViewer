using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;       // for Storyboard class

using ImageViewer.Infrastructure;
using ImageViewer.Model;
using System.IO;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  Hold a reference to the instance of the viewModel used for ths page.
        private SlideShowViewModel _vm;


        /// <summary>
        /// Constructor for the MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //  Get hold of the instance of the ViewModel for this page.  It's
            //  defined as a Window.Resource, so we can look for that resource.
            _vm = (SlideShowViewModel) this.FindResource("ImagesSource");
            //  Attach a handler for the PropertyChanging event of the ViewModel.
            _vm.PropertyChanging += _vm_PropertyChanging;
        }


        private void currentImage_Unloaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("currentImage_Unloaded event has fired");
        }

        private void currentImage_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("currentImage_Loaded event has fired");
        }

        private void currentImage_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            //MessageBox.Show("currentImage_SourceUpdated event has fired");
        }

        private void currentImage_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            //MessageBox.Show("currentImage_TargetUpdated event has fired");
        }

        private void imageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("imageList_SelectionChanged event has fired");
            //  Fade image out

            //  Change image source
            //var slide = (Slide) this.imageList.SelectedItem;
            //var imageSource = slide.Image;
            //this.currentImage.Source = imageSource;
            //  Fade new image in
            Storyboard fadeIn = (Storyboard)FindResource("FadeInImage");
            Image theImage = this.currentImage;
            if (this.currentImage != null)
                fadeIn.Begin(this.currentImage);
        }

        private void imageList_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            //MessageBox.Show("imageList_SourceUpdated event has fired");
        }



        /// <summary>
        /// Event handler for the PropertyChanging event 
        /// </summary>
        /// <param name="sender">An instance of the ovject that raosed the event.</param>
        /// <param name="e">An instance of the EventArgs for the PropertyChanging event.</param>
        private void _vm_PropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            MessageBox.Show(string.Format("Property '{0}' is about to change", e.PropertyName));
            //  Potentially we can start an animation on the image that's there before the new images is loaded
            //  Fade old image out
            Storyboard fadeOut = (Storyboard)FindResource("FadeOutImage");
            
            if (this.currentImage != null)
                fadeOut.Begin(this.currentImage);
        }

    }
}
