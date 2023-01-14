using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.NetworkInformation;
//using Position = Microsoft.Maui.Devices.Sensors.Location;

using FieldGame.ViewModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;

namespace FieldGame;

public partial class MainPage : ContentPage
{


    public MainPage(PinViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private async void Pin_MarkerClicked(object sender, PinClickedEventArgs e)
    {
        var pin = sender as Pin;
        var location = pin.BindingContext as MapLocation;
        var userlocation = await Geolocation.GetLastKnownLocationAsync();



        if (userlocation != null)
        {
            var distance = Distance(location.Position.Latitude, location.Position.Longitude, userlocation.Latitude, userlocation.Longitude, 'M');
            if (distance < 10)
            {


                var answer = await DisplayAlert("You are within 100m of the pin. Here is your question:", location.Question, "Yes", "No");
                if (answer == location.Answer)
                {

                    await DisplayAlert("Congratulations!", location.Question, "ok");
                }
                else
                {

                    await DisplayAlert("Wrong answer!", "Maybe next time you will know the answer.", "ok");
                }
            }
            else { await DisplayAlert("You are to far away from the pin!", "", "ok"); }
        }

    }

    private double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
    {
        if ((lat1 == lat2) && (lon1 == lon2))
        {
            return 0;
        }
        else
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }
    }
    private double deg2rad(double deg)
    {
        return (deg * Math.PI / 180.0);
    }
    private double rad2deg(double rad)
    {
        return (rad / Math.PI * 180.0);
    }
    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
}

