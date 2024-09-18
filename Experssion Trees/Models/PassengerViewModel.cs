using Experssion_Trees.Data;

namespace Experssion_Trees.Models
{
    public class PassengerViewModel
    {
        public List<PassengerInfo> Passengers { get; set; }
        public PassengerFilterViewModel Filter { get; set; } = new PassengerFilterViewModel();
    }

}
