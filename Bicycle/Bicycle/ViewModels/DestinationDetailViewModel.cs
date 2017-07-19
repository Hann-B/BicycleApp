using Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.ViewModels
{
    public class DestinationDetailViewModel:BaseViewModel
    {
        public Destination Destination { get; set; }

        public DestinationDetailViewModel(Destination destination=null)
        {
            Title = destination.Location;
            Destination = destination;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
