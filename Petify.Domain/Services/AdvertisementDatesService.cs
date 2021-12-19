using System;
using System.Collections.Generic;
using EnsureThat;
using Petify.Domain.Advertisements;
using Petify.Domain.Advertisements.Parameters;
using static Petify.Common.Lookups.AdvertisementTypeLookup;

namespace Petify.Domain.Services
{
    public class AdvertisementDatesService : IAdvertisementDatesService
    {
        public AdvertisementDatesParameter GetAdvertisementDates(int advertisementTypeId, DateTime? startDate, DateTime? endDate)
        {
            if ((advertisementTypeId == (int)AdvertisementTypeEnum.OneTimeHelp) || (advertisementTypeId == (int)AdvertisementTypeEnum.Adoption))
            {
                return new AdvertisementDatesParameter(startDate, startDate);
            }
            else
            {
                return new AdvertisementDatesParameter(startDate, endDate);
            }
        }

        public List<CyclicalAssistanceDay> GetCyclicalAssistanceDays(int advertisementTypeId, DateTime startDate, DateTime? endDate, int? cyclicalAssistanceFrequency)
        {
            if (advertisementTypeId == (int)AdvertisementTypeEnum.CyclicalAssistance)
            {
                EnsureArg.IsNotNull(endDate);
                if (cyclicalAssistanceFrequency is null)
                {
                    throw new ArgumentException($"{nameof(cyclicalAssistanceFrequency)} cannot be null");
                }

                var dates = new List<CyclicalAssistanceDay>();
                var date = startDate;
                dates.Add(new CyclicalAssistanceDay(date));

                var days = (int)cyclicalAssistanceFrequency;

                while (date < endDate)
                {
                    date = date.AddDays((int)cyclicalAssistanceFrequency);
                    if (date <= endDate)
                    {
                        dates.Add(new CyclicalAssistanceDay(date));
                    }
                    days += (int)cyclicalAssistanceFrequency;
                }

                return dates;
            }
            else
            {
                return null;
            }
        }
    }
}
