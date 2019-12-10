using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace OnBoardUWP.Views
{

    public sealed partial class Homepage : Page
    {

        public HomepageViewModel ViewModel;
        public WeatherViewModel WeatherViewModel;

        public Homepage()
        {
            this.InitializeComponent();
            // Using the, in app.cs initialized, viewmodel for databinding
            ViewModel = App.HomepageModel;
            WeatherViewModel = new WeatherViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Here because path must be updated when navigating to the homescreen.
            ShowFlightPath();
        }

        private async void ShowFlightPath()
        {
            if (ViewModel.Flight != null)
            {
                var locationAccess = await Geolocator.RequestAccessAsync();

                //origin
                BasicGeoposition start = new BasicGeoposition() { Latitude = ViewModel.Flight.StartLatitude, Longitude = ViewModel.Flight.StartLongitude };
                Geopoint geoStart = new Geopoint(start);
                MapIcon mapIconStart = new MapIcon();
                mapIconStart.Location = geoStart;
                mapIconStart.Title = ViewModel.Flight.Origin;
                mapIconStart.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIconStart.ZIndex = 0;
                MapControl1.MapElements.Add(mapIconStart);

                //destination
                BasicGeoposition end = new BasicGeoposition() { Latitude = ViewModel.Flight.EndLatitude, Longitude = ViewModel.Flight.EndLongitude };
                Geopoint geoEnd = new Geopoint(end);
                MapIcon mapIconEnd = new MapIcon();
                mapIconEnd.Location = geoEnd;
                mapIconEnd.Title = ViewModel.Flight.Destination;
                mapIconEnd.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIconEnd.ZIndex = 0;
                MapControl1.MapElements.Add(mapIconEnd);


                Geopath polylinePath = new Geopath(new List<BasicGeoposition> { start, end });


                switch (locationAccess)
                {
                    case GeolocationAccessStatus.Allowed:
                        Geolocator geolocator = new Geolocator()
                        {
                            DesiredAccuracyInMeters = 100
                        };
                        BasicGeoposition current = new BasicGeoposition();
                        Geoposition currentPosition = await geolocator.GetGeopositionAsync().AsTask();
                        current.Latitude = currentPosition.Coordinate.Point.Position.Latitude;
                        current.Longitude = currentPosition.Coordinate.Point.Position.Longitude;

                        Geopoint currentLocation = new Geopoint(current);

                        MapIcon mapIconCurrent = new MapIcon();
                        mapIconCurrent.Location = currentLocation;
                        mapIconCurrent.Title = "Current location";
                        mapIconCurrent.NormalizedAnchorPoint = new Point(0.5, 1.0);
                        mapIconCurrent.ZIndex = 0;
                        MapControl1.MapElements.Add(mapIconCurrent);
                        polylinePath = new Geopath(new List<BasicGeoposition> { start, current, end });
                        break;

                    default:
                        polylinePath = new Geopath(new List<BasicGeoposition> { start, end });
                        break;
                }

                MapPolyline mapPolyline = new MapPolyline();
                mapPolyline.StrokeColor = Colors.Indigo;
                mapPolyline.StrokeThickness = 4;
                mapPolyline.Path = polylinePath;
                MapControl1.MapElements.Add(mapPolyline);
            }
        }
    }
}
