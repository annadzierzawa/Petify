using System;

namespace Petify.Domain.Advertisements.Parameters
{
    public class AdvertisementDatesParameter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public AdvertisementDatesParameter(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
