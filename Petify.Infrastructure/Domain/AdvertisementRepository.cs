using Petify.ApplicationServices.Boundaries.Users;
using Petify.Domain.Advertisements;
using Petify.Infrastructure.DataModel.Context;

namespace Petify.Infrastructure.Domain
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly PetifyContext _context;

        public AdvertisementRepository(PetifyContext context)
        {
            _context = context;
        }

        public void RemoveAdvertisement(Advertisement advertisement)
        {
            _context.Advertisements.Remove(advertisement);
        }
    }
}
