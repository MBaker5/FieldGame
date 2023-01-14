using CommunityToolkit.Mvvm.ComponentModel;
using FieldGame.Model;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FieldGame.ViewModel
{
    public partial class PinViewModel : ObservableObject
    {

        readonly ObservableCollection<MapLocation> _locations;

        public IEnumerable Locations => _locations;

        public ICommand AddLocationCommand { get; }

        public PinViewModel()
        {
            _locations = new ObservableCollection<MapLocation>()
            {
                new MapLocation("Question:", "Was Reksio produced in Bielsko-Biała?", new Location(34.11, -118.41), true),
                new MapLocation("Question:", "Is Maui a Hawaiian island?", new Location(37.77, -122.45), true),
                new MapLocation("Question:", "2+2*2=8?", new Location(37.42213800523519, -122.08435524454022), false)
            };
        }



    }
    public class MapLocation : INotifyPropertyChanged
    {
        Location _position;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Address { get; }
        public string Question { get; }
        public bool Answer { get; }

        public Location Position
        {
            get => _position;
            set
            {
                _position = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));

            }
        }


        public MapLocation(string address, string question, Location position, bool answer)
        {
            Address = address;
            Question = question;
            Position = position;
            Answer = answer;
        }

        public string GetQuestion()
        {
            return Question;
        }

        public bool GetAnswer()
        {
            return Answer;
        }





    }
}
