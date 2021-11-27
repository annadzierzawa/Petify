namespace Petify.PublishedLanguage.Dtos.Pets
{
    public class PetAdvertisimentItemDTO : PetItemDTO
    {
        public bool IsChecked { get; set; }
    }

    public class PetAdvertisimentQueryItem : PetItemDTO
    {
        public int AdvertisementId { get; set; }
    }
}
