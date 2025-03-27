using WebApp.API.Models;
namespace WebApp.Platform.Models
{
    public class AllLocationInformation
    {
        public LocationInHomePage Location { get; set; }
        public List<LocationGallery> Gallery { get; set; }

        public AllLocationInformation(LocationInHomePage location, List<LocationGallery> gallery)
        {
            Location = location;
            Gallery = gallery;
        }
    }
}
