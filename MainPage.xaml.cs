using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;

namespace MediaElementPosition
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            //This code correctly displays the Position information as the video plays

            mediaElement1.Source =
                    MediaSource.FromUri(
                        "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4");

            mediaElement2.Source =
                    MediaSource.FromUri(
                        "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4");
        }

        void mediaElement_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MediaElement mediaElement = (MediaElement)sender;

            if (e.PropertyName == MediaElement.PositionProperty.PropertyName)
            {
                if (mediaElement == mediaElement1)
                {
                    Debug.Print(string.Format("/////////////////////////////////////////Position: {0}: {1}", "mediaElement1", mediaElement.Position.TotalSeconds));
                    lblInfo1.Text = String.Format("{0:#,0.000}", Math.Round(mediaElement.Position.TotalSeconds, 3)) + "/" + String.Format("{0:#,0.000}", Math.Round(mediaElement.Duration.TotalSeconds, 3)); 
                }
                else if (mediaElement == mediaElement2)
                {
                    Debug.Print(string.Format("/////////////////////////////////////////Position: {0}: {1}", "mediaElement2", mediaElement.Position.TotalSeconds));
                    lblInfo2.Text = String.Format("{0:#,0.000}", Math.Round(mediaElement.Position.TotalSeconds, 3)) + "/" + String.Format("{0:#,0.000}", Math.Round(mediaElement.Duration.TotalSeconds, 3));
                }
            }
        }

        void mediaElement_PositionChanged(object sender, MediaPositionChangedEventArgs e)
        {
            MediaElement mediaElement = (MediaElement)sender;

            if (mediaElement == mediaElement1)
            {
                Debug.Print(string.Format("/////////////////////////////////////////Position: {0}: {1}", "mediaElement1", e.Position.TotalSeconds));
                lblInfo1.Text = String.Format("{0:#,0.000}", Math.Round(mediaElement.Position.TotalSeconds, 3)) + "/" + String.Format("{0:#,0.000}", Math.Round(mediaElement.Duration.TotalSeconds, 3));
            }
            else if (mediaElement == mediaElement2)
            {
                Debug.Print(string.Format("/////////////////////////////////////////Position: {0}: {1}", "mediaElement2", e.Position.TotalSeconds));
                lblInfo2.Text = String.Format("{0:#,0.000}", Math.Round(mediaElement.Position.TotalSeconds, 3)) + "/" + String.Format("{0:#,0.000}", Math.Round(mediaElement.Duration.TotalSeconds, 3));
            }
        }

        private void btnPlayPause_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (mediaElement1.CurrentState == MediaElementState.Stopped ||
                            mediaElement1.CurrentState == MediaElementState.Paused)
            {
                mediaElement1.Play();
                btnPlayPause.Text = "Pause";

                mediaElement2.Play();
                btnPlayPause.Text = "Pause";
            }
            else if (mediaElement1.CurrentState == MediaElementState.Playing)
            {
                mediaElement1.Pause();
                btnPlayPause.Text = "Play";

                mediaElement2.Pause();
                btnPlayPause.Text = "Play";
            }
        }

        private void btnLoadVideo_Clicked(object sender, EventArgs e)
        {
            //This code does not display the Position information after the video reloads

            mediaElement1.Source =
                    MediaSource.FromUri(
                        "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4");
            mediaElement1.Play();

            mediaElement2.Source =
                    MediaSource.FromUri(
                        "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4");
            mediaElement2.Play();

            btnPlayPause.Text = "Pause";
        }
    }
}
