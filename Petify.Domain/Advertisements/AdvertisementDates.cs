using System;

namespace Petify.Domain.Advertisements
{
    public class AdvertisementDates
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public AdvertisementDates(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        private AdvertisementDates() { }
    }
}
