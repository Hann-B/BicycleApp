using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.Models
{
    public class Trip:BaseDataObject
    {
        //host
        //rental
        //tour guide
        User host = null;
        public User Host
        {
            get { return host; }
            set { SetProperty(ref host, value); }
        }

        User rental = null;
        public User Rental
        {
            get { return rental; }
            set { SetProperty(ref rental, value); }
        }

        User guide = null;
        public User Guide
        {
            get { return guide; }
            set { SetProperty(ref guide, value); }
        }
    }
}
