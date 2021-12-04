using Petify.Domain.Advertisements;

namespace Petify.ApplicationServices.Boundaries.Users
{
    public interface IAdvertisementRepository
    {
        void RemoveAdvertisement(Advertisement advertisement);
    }
}
