﻿using WebApp.API.Models;
using WebApp.Platform.ClientAPI;
using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class HomeService : IHomeService
    {
        private readonly CityViewHttpClient _cityViewHttpClient;
        public HomeService(CityViewHttpClient cityHttpClient)
        {
            _cityViewHttpClient = cityHttpClient;
        }
        public async Task<List<CityInHomePage>> GetAllCityAsync()
        {
            var result = await _cityViewHttpClient.GetAllAsync();
            return result.ToList();
        }
        public async Task<List<CityInHomePage>> GetVisibleCityAsync()
        {
            var result = await _cityViewHttpClient.GetVisibleAsync();
            return result.ToList();
        }
    }
}
