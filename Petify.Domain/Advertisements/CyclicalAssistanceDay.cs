using System;

namespace Petify.Domain.Advertisements
{
    public class CyclicalAssistanceDay
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public DateTime Date { get; set; }

        public CyclicalAssistanceDay(DateTime date)
        {
            Date = date;
        }

        CyclicalAssistanceDay() { }
    }
}
