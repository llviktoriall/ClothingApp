using ClothingApp.Data.Common.Entities;
using ClothingApp.Data.Common.Interfaces;
using ClothingApp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Core.Services.WeatherService
{
    public interface IClothingService : IBaseRepository<MatchingStyleToWeather>
    {
        Task<List<ClothingItem>> GetStyles(Weather weather);
        Task<List<ClothingItem>> GetAllStyles();
        string GetSovet(Weather weather);
        string GetSovetFiveDays(List<List<Weather>> weathers);

    }
}
