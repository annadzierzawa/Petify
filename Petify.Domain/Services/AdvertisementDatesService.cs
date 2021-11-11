﻿using System;
using System.Collections.Generic;
using Petify.Domain.Advertisements;
using static Petify.Common.Lookups.AdvertisementTypeLookup;

namespace Petify.Domain.Services
{
    public class AdvertisementDatesService : IAdvertisementDatesService
    {
        public AdvertisementDates GetAdvertisementDates(int advertisementTypeId, DateTime? startDate, DateTime? endDate)
        {
            if ((advertisementTypeId == (int)AdvertisementTypeEnum.OneTimeHelp) || (advertisementTypeId == (int)AdvertisementTypeEnum.Adoption))
            {
                return new AdvertisementDates(startDate, startDate);
            }
            else
            {
                return new AdvertisementDates(startDate, endDate);
            }
        }

        public List<CyclicalAssistanceDay> GetCyclicalAssistanceDays(int advertisementTypeId, DateTime startDate, DateTime endDate, int cyclicalAssistanceFrequency)
        {
            if (advertisementTypeId == (int)AdvertisementTypeEnum.CyclicalAssistance)
            {
                var dates = new List<CyclicalAssistanceDay>();
                var date = startDate;
                dates.Add(new CyclicalAssistanceDay(date));

                var days = cyclicalAssistanceFrequency;

                while (date < endDate)
                {
                    date = date.AddDays(days);
                    dates.Add(new CyclicalAssistanceDay(date));
                    days += cyclicalAssistanceFrequency;
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
