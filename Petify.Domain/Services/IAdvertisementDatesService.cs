using System;
using System.Collections.Generic;
using Petify.Domain.Advertisements;
using Petify.Domain.Advertisements.Parameters;

namespace Petify.Domain.Services
{
    public interface IAdvertisementDatesService
    {
        public AdvertisementDatesParameter GetAdvertisementDates(int advertisementTypeId, DateTime? startDate, DateTime? endDate);
        public List<CyclicalAssistanceDay> GetCyclicalAssistanceDays(int advertisementTypeId, DateTime startDate, DateTime? endDate, int? cyclicalAssistanceFrequency);

    }
}
