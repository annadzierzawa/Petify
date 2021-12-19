using System;
using Petify.Domain.Services;
using Shouldly;
using Xunit;
using static Petify.Common.Lookups.AdvertisementTypeLookup;

namespace Petify.Domain.Tests
{
    public class AdvertisementDatesServiceTests
    {
        [Fact]
        public void AdvertisementDatesService_WhenAdvertisementTypeIsNotCyclicalAssistanceThenGetCyclicalAssistanceDaysReturnsNull()
        {
            //given
            AdvertisementDatesService service = new AdvertisementDatesService();

            //when and then
            service.GetCyclicalAssistanceDays((int)AdvertisementTypeEnum.Adoption, DateTime.Today, DateTime.Today.AddDays(30), 0).ShouldBeNull();
            service.GetCyclicalAssistanceDays((int)AdvertisementTypeEnum.OneTimeHelp, DateTime.Today, DateTime.Today.AddDays(30), 0).ShouldBeNull();
            service.GetCyclicalAssistanceDays((int)AdvertisementTypeEnum.TemporaryAdoption, DateTime.Today, DateTime.Today.AddDays(30), 0).ShouldBeNull();
        }

        [Fact]
        public void AdvertisementDatesService_WhenAdvertisementTypeCyclicalAssistanceAndDatesAndFrequencyAreProvided_ThenGetCyclicalAssistanceDaysReturnsValidListOfDays()
        {
            //given
            AdvertisementDatesService service = new AdvertisementDatesService();
            var startDate = new DateTime(2021, 1, 1);
            var endDate = new DateTime(2021, 1, 30);

            //when
            var everydayAssistanceDays = service.GetCyclicalAssistanceDays((int)AdvertisementTypeEnum.CyclicalAssistance, startDate, endDate, 1);
            var every2DaysAssistanceDays = service.GetCyclicalAssistanceDays((int)AdvertisementTypeEnum.CyclicalAssistance, startDate, endDate, 2);

            //then
            everydayAssistanceDays.Count.ShouldBe(30);
            every2DaysAssistanceDays.Count.ShouldBe(15);
        }

        [Fact]
        public void AdvertisementDatesService_WhenAdvertisementTypeIsOneTimeHelpOrAdoption_ThenStartAndEndDateReturnedByGetAdvertisementDatesAreTheSame()
        {
            //given
            AdvertisementDatesService service = new AdvertisementDatesService();
            var startDate = new DateTime(2021, 1, 1);
            var endDate = new DateTime(2021, 1, 30);

            //when
            var oneTimeHelpDates = service.GetAdvertisementDates((int)AdvertisementTypeEnum.OneTimeHelp, startDate, endDate);
            var adoptionDates = service.GetAdvertisementDates((int)AdvertisementTypeEnum.Adoption, startDate, endDate);

            //then
            oneTimeHelpDates.StartDate.ShouldBe(startDate);
            oneTimeHelpDates.EndDate.ShouldBe(startDate);
            adoptionDates.StartDate.ShouldBe(startDate);
            adoptionDates.EndDate.ShouldBe(startDate);
        }

        [Fact]
        public void AdvertisementDatesService_WhenAdvertisementTypeCyclicalAssistanceOrTemporaryAdoption_ThenStartAndEndDateReturnedByGetAdvertisementDatesAreSetProperly()
        {
            //given
            AdvertisementDatesService service = new AdvertisementDatesService();
            var startDate = new DateTime(2021, 1, 1);
            var endDate = new DateTime(2021, 1, 30);

            //when
            var temporaryAdoptionDates = service.GetAdvertisementDates((int)AdvertisementTypeEnum.TemporaryAdoption, startDate, endDate);
            var cyclicalAssistanceDates = service.GetAdvertisementDates((int)AdvertisementTypeEnum.CyclicalAssistance, startDate, endDate);

            //then
            temporaryAdoptionDates.StartDate.ShouldBe(startDate);
            temporaryAdoptionDates.EndDate.ShouldBe(endDate);
            cyclicalAssistanceDates.StartDate.ShouldBe(startDate);
            cyclicalAssistanceDates.EndDate.ShouldBe(endDate);
        }
    }
}
