﻿using WebApp.API.Models;

namespace WebApp.API.Repositories.Interface
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetAllAsync();
        public Task<IEnumerable<Location>> GetVisibleAsync();
        public Task<Location?> GetAsync(int id);
        public Task<IEnumerable<Location>> GetLocationByCityIdAsync(int cityId);
        public Task<IEnumerable<Location>> GetVisibleLocationByCityIdAsync(int cityId);
        public Task<Location> CreateAsync(Location location);
        public Task UpdateAsync(Location location);
        public Task DeleteAsync(int id);
    }
}
