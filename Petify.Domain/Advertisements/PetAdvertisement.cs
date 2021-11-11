using Petify.Domain.Pets;

namespace Petify.Domain.Advertisements
{
    public class PetAdvertisement
    {
        public int AdvertisementId { get; set; }
        public int PetId { get; set; }

        public Advertisement Advertisement { get; set; }
        public Pet Pet { get; set; }
    }
}
