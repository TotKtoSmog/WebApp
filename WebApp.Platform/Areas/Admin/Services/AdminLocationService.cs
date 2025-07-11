﻿using WebApp.Platform.Areas.Admin.Models;
using WebApp.Platform.Areas.Admin.Services.Interfaces;
using WebApp.Platform.ClientAPI;

namespace WebApp.Platform.Areas.Admin.Services
{
    public class AdminLocationService : IAdminLocationService
    {
        private readonly LocationHttpClient _locationHttpClient;
        private readonly LocationGalleryHttpClient _locationGalleryHttpClient;
        public AdminLocationService(LocationHttpClient locationHttpClient, 
            LocationGalleryHttpClient locationGalleryHttpClient)
        {
            _locationHttpClient = locationHttpClient;
            _locationGalleryHttpClient = locationGalleryHttpClient;
        }

        public async Task<AllLocationInfo> GetAllLocationInfoAsync(int Id)
        {
            var location = await GetLocationAsync(Id);
            var gallery = await GetLocationGalleryAsync(Id);
            return new AllLocationInfo(Location.ConvertToUILocation(location), gallery);
        }

        public async Task<List<API.Models.Location>> GetAllLocationsAsync()
        {
            var locations = await _locationHttpClient.GetAllAsync();
            return locations.ToList();
        }

        public async Task<API.Models.Location?> GetLocationAsync(int Id)
            => await _locationHttpClient.GetAsync(Id);

        public async Task<List<API.Models.LocationGallery>> GetLocationGalleryAsync(int Id)
        {
            var gallery = await _locationGalleryHttpClient.GetLocationGalleryByIdLocationAsync(Id);
            return gallery.ToList();
        }

        public async Task UpdateLocation(Location location)
        {
            API.Models.Location dbLocation = Location.ConvertToDBLocation(location);
            await _locationHttpClient.UpdateAsync(dbLocation);
        }
        public async Task EditGallery(List<API.Models.LocationGallery> incomingGallery, int idLocation)
        {
            var existingGallery = await GetLocationGalleryAsync(idLocation);

            var updateTasks = new List<Task>();
            var deleteTasks = new List<Task>();
            var createTasks = new List<Task>();

            var unmatchedIncoming = new List<API.Models.LocationGallery >(incomingGallery);

            foreach (var existing in existingGallery)
            {
                var match = unmatchedIncoming.FirstOrDefault(newItem =>
                    newItem.Id == existing.Id || AreEqual(existing, newItem));

                if (match != null)
                {
                    if (match.Id != 0 && !AreEqual(existing, match))
                    {
                        updateTasks.Add(UpdateGallery(match));
                    }
                    unmatchedIncoming.Remove(match);
                }
                else
                {
                    deleteTasks.Add(DeleteGallery(existing.Id));
                }
            }
            foreach (var newItem in unmatchedIncoming)
                createTasks.Add(CreateGallery(newItem));

            await Task.WhenAll(updateTasks);
            await Task.WhenAll(deleteTasks);
            await Task.WhenAll(createTasks);
        }
        private async Task DeleteGallery(int id)
            => await _locationGalleryHttpClient.DeleteAsync(id);
        private async Task UpdateGallery(API.Models.LocationGallery gallery)
            => await _locationGalleryHttpClient.UpdateAsync(gallery);
        private async Task CreateGallery(API.Models.LocationGallery gallery)
            => await _locationGalleryHttpClient.CreateAsync(gallery);
        private bool AreEqual(API.Models.LocationGallery a, API.Models.LocationGallery b)
            => a.Id == b.Id && a.LocationId == b.LocationId && a.Title == b.Title && a.PictureLink == b.PictureLink;

        public async Task<API.Models.Location> CreateLocation(Location location)
        {
            API.Models.Location dbLocation = Location.ConvertToDBLocation(location);
            return await _locationHttpClient.CreateAsync(dbLocation); 
        }
        public async Task DeleteLocation(int id)
            => await _locationHttpClient.DeleteAsync(id);
    }
}
