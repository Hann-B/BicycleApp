namespace Bicycle.Models
{
    public class Destination:BaseDataObject
    {
        string location = string.Empty;
        public string Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        string numOfTrails = string.Empty;
        public string NumOfTrails
        {
            get { return numOfTrails; }
            set { SetProperty(ref numOfTrails, value); }
        }

        string placeNumber = string.Empty;
        public string PlaceNumber
        {
            get { return placeNumber; }
            set { SetProperty(ref placeNumber, value); }
        }
    }
}
