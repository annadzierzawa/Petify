using System;
using System.Collections.Generic;
using Petify.Domain.Advertisements;

namespace Petify.Domain.Services
{
    public interface IAdvertisementDatesService
    {
        public AdvertisementDates GetAdvertisementDates(int advertisementTypeId, DateTime? startDate, DateTime? endDate);
        public List<CyclicalAssistanceDay> GetCyclicalAssistanceDays(int advertisementTypeId, DateTime startDate, DateTime endDate, int cyclicalAssistanceFrequency);

    }
}
