﻿using WebApp.API.Models;

namespace WebApp.Platform.Services.Interfaces
{
    public interface ILocationByUser
    {
        public Task<List<Location>> GetAllAsync();
        public Task<Location?> GetAsync(int idLocation);
    }
}
