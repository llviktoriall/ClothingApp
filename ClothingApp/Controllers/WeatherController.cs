using ClothingApp.Core.Services.WeatherService;
using ClothingApp.Data.Common.Entities;
using ClothingApp.Data.Common.Interfaces;
using ClothingApp.Data.Common.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;
        private readonly IClothingService _iClothongService;
        UserManager<ApplicationUser> _userManager;
        bool isDifferentPlaces;

        public WeatherController(IWeatherService weatherService, UserManager<ApplicationUser> userManager, IClothingService iClothongService)
        {
            _weatherService = weatherService;
            _iClothongService = iClothongService;
            _userManager = userManager;
            _iClothongService = iClothongService;
        }
        /// <summary>
        /// получить город по IP
        /// </summary>
        
        private string GetCityByIP()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            return _weatherService.GetCityName("46.0.40.18"); // ip adress
        }
        /// <summary>
        /// получить город пользователя
        /// </summary>
        private async Task<string> GetCityFromUser()
        {
            string userCity = null;
            if (this.User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(this.User.Identity.Name);
                userCity =  user.City;
            }
            return userCity;
        }
        /// <summary>
        /// Возвращает город пользователя, если он авторизован, иначе город по IP
        /// </summary>
        private string SelectCity()
        {
            string userCity = GetCityFromUser().Result;
            if (userCity != null)
            {
                isDifferentPlaces = true;
                return userCity;
            }
            return GetCityByIP();
        }
        
        private PartOfDay GetPartOfDay()
        {
            if (DateTime.Now.Hour > 6 && DateTime.Now.Hour < 18) return PartOfDay.Morning;
            else if (DateTime.Now.Hour > 18 && DateTime.Now.Hour < 21) return PartOfDay.Daytime;
            else return PartOfDay.Evening;
        }

        /// <summary>
        /// погода на сегодня
        /// </summary>
        /// <returns></returns>
        public List<Weather> GetWeatherToday(string city)
        {
            var respone = _weatherService.GetWeatherForToday(city);
            foreach (Weather weather in respone)
            {
                if (weather.PartOfDay == PartOfDay.Evening)
                {

                }
            }
            return respone;
        }

        /// <summary>
        /// погода на завтра
        /// </summary>
        /// <returns></returns>
        public List<Weather> GetWeatherTomorrow(string city)
        {      
            var respone = _weatherService.GetWeatherForTomorrow(city);           

            return respone;
        }
        /// <summary>
        /// погода на 5 дней
        /// </summary>
        public List<Weather> GetWeatherForFiveDays(string city)
        {
            var respone = _weatherService.GetWeatherForFiveDays(city);

            return respone;
        }
        [HttpGet]
        public async Task<ActionResult> Today()
        {
            string currentCity = SelectCity(); 
            var weatherToDay = GetWeatherToday(currentCity);
            ViewBag.GetWeatherToday = weatherToDay;
            Weather weather = weatherToDay.FirstOrDefault(x => x.PartOfDay == GetPartOfDay());
            var listStyles= _iClothongService.GetStyles(weather).Result;
            ViewBag.GetStyleToday = listStyles;
            ViewBag.ClothingItem = await _iClothongService.GetClothingItem(listStyles, weather);


            string[] dateTime = DateTime.Today.ToLongDateString().Split(' ');
            ViewBag.DateTime = dateTime;

            ViewBag.Sovet = _iClothongService.GetSovet(weather);

            ViewBag.City = GetCityByIP();
            ViewBag.IsDifferentPlaces = false;
            if (isDifferentPlaces)
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("Today");
        }

        [HttpGet]
        public async Task<ActionResult> Tomorrow()
        {
            string currentCity = SelectCity();
            var weatherTomorrow = GetWeatherTomorrow(currentCity);
            ViewBag.GetWeatherTomorrow = weatherTomorrow;
            Weather weather = weatherTomorrow.FirstOrDefault(x => x.PartOfDay == GetPartOfDay());
            var listStyles = _iClothongService.GetStyles(weather).Result;
            ViewBag.GetStyleTomorrow = listStyles;
            ViewBag.ClothingItem = await _iClothongService.GetClothingItem(listStyles, weather);

            ViewBag.Sovet = _iClothongService.GetSovet(weather);

            string[] dateTimeTomorrow = DateTime.Today.AddDays(1).ToLongDateString().Split(' ');
            ViewBag.DateTimeTomorrow = dateTimeTomorrow;

            ViewBag.City = GetCityByIP();
     
            ViewBag.IsDifferentPlaces = false;
            if (isDifferentPlaces)
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("Tomorrow");
        }
        [HttpGet]
        public ActionResult FiveDays()
        {
            string currentCity =  SelectCity();
            ViewBag.City = GetCityByIP();
            var getWeatherForFiveDays = GetWeatherForFiveDays(currentCity)
                .GroupBy(x => x.DateTime.Date).Select(x => x.OrderBy(x => x.DateTime).ToList())
                .OrderBy(x => x[0].DateTime.Date).ToList();
            ViewBag.GetWeatherForFiveDays = getWeatherForFiveDays;

            var styleForFiveDays = new List<List<Style>>();
            var listClothingItem= new List<List<ClothingItem>>();
            foreach (var i in getWeatherForFiveDays)
            {
                foreach (var j in i)
                {
                    //if (j.PartOfDay == PartOfDay.Daytime)
                    //{
                    //    var styles = _iClothongService.GetStyles(j).Result;
                    //    styleForFiveDays.Add(styles);
                    //    var clothingItems= _iClothongService.GetClothingItem(styles, weather).Result;
                    //    listClothingItem.Add(clothingItems);
                    //}
                }
            }
            ViewBag.GetStyleForFiveDays = styleForFiveDays;
            ViewBag.ClothingItem = listClothingItem;
            ViewBag.Sovet = _iClothongService.GetSovetFiveDays(getWeatherForFiveDays);
            var a = (ViewBag.GetWeatherForFiveDays[0][0].DateTime.ToUniversalTime().Date - DateTime.UtcNow.Date).TotalDays;
            ViewBag.IsDifferentPlaces = false;
            if (isDifferentPlaces)
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("FiveDays");
        }
        public async Task<ActionResult> ChangeCityToday()
        {
            string currentCity = GetCityByIP();
            var weatherToDay = GetWeatherToday(currentCity);
            ViewBag.GetWeatherToday = weatherToDay;
            Weather weather = weatherToDay.FirstOrDefault(x => x.PartOfDay == GetPartOfDay());
            var listStyles = _iClothongService.GetStyles(weather).Result;
            ViewBag.GetStyleToday = listStyles;
            ViewBag.ClothingItem = await _iClothongService.GetClothingItem(listStyles, weather);


            string[] dateTime = DateTime.Today.ToLongDateString().Split(' ');
            ViewBag.DateTime = dateTime;

            ViewBag.Sovet = _iClothongService.GetSovet(weather);

            ViewBag.City = GetCityByIP();
            ViewBag.IsDifferentPlaces = false;
            if (isDifferentPlaces)
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("Today");
        }
        public async Task<ActionResult> ChangeCityTomorrow()
        {
            string currentCity = GetCityByIP();
            var weatherTomorrow = GetWeatherTomorrow(currentCity);
            ViewBag.GetWeatherTomorrow = weatherTomorrow;
            Weather weather = weatherTomorrow.FirstOrDefault(x => x.PartOfDay == GetPartOfDay());
            var listStyles = _iClothongService.GetStyles(weather).Result;
            ViewBag.GetStyleTomorrow = listStyles;
            ViewBag.ClothingItem = await _iClothongService.GetClothingItem(listStyles, weather);

            ViewBag.Sovet = _iClothongService.GetSovet(weather);

            string[] dateTimeTomorrow = DateTime.Today.AddDays(1).ToLongDateString().Split(' ');
            ViewBag.DateTimeTomorrow = dateTimeTomorrow;

            ViewBag.City = GetCityByIP();

            ViewBag.IsDifferentPlaces = false;
            if (isDifferentPlaces)
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("Tomorrow");
        }
        public ActionResult ChangeCityFiveDays()
        {
            string currentCity = GetCityByIP();
            ViewBag.City = GetCityByIP();
            var getWeatherForFiveDays = GetWeatherForFiveDays(currentCity)
                .GroupBy(x => x.DateTime.Date).Select(x => x.OrderBy(x => x.DateTime).ToList())
                .OrderBy(x => x[0].DateTime.Date).ToList();
            ViewBag.GetWeatherForFiveDays = getWeatherForFiveDays;
            var styleForFiveDays = new List<List<Style>>();
            var listClothingItem = new List<List<ClothingItem>>();
            foreach (var i in getWeatherForFiveDays)
            {
                foreach (var j in i)
                {
                    //if (j.PartOfDay == PartOfDay.Daytime)
                    //{
                    //    var styles = _iClothongService.GetStyles(j).Result;
                    //    styleForFiveDays.Add(styles);
                    //    var clothingItems = _iClothongService.GetClothingItem(styles).Result;
                    //    listClothingItem.Add(clothingItems);
                    //}
                }
            }
            ViewBag.GetStyleForFiveDays = styleForFiveDays;
            ViewBag.ClothingItem = listClothingItem;
            var a = (ViewBag.GetWeatherForFiveDays[0][0].DateTime.ToUniversalTime().Date - DateTime.UtcNow.Date).TotalDays;
            ViewBag.IsDifferentPlaces = false;
            if (isDifferentPlaces)
            {
                ViewBag.IsDifferentPlaces = true;
            }
            return View("FiveDays");
        }
    }
}
    //[HttpGet]
    //public ActionResult<List<MatchingStyleToWeather>> GetAllStyles()
    //{
    //    var styles = _iClothongService.GetAllStyles().Result;
    //    return Ok(styles);
    //}
    ///// <summary>
    ///// добавление образа
    ///// </summary>
    ///// <param name="matchingStyleToWeather"></param>
    ///// <returns></returns>
    //[HttpPost]
    //public ActionResult CreateStyle(MatchingStyleToWeather matchingStyleToWeather)
    //{
    //    _iClothongService.CreateAsync(matchingStyleToWeather);
    //    return Ok(matchingStyleToWeather);
    //}
    ///// <summary>
    ///// изменение образа
    ///// </summary>
    ///// <param name="matchingStyleToWeather"></param>
    ///// <returns></returns>
    //[HttpPut]
    //public ActionResult UpdateStyle(MatchingStyleToWeather matchingStyleToWeather)
    //{
    //    _iClothongService.UpdateAsync(matchingStyleToWeather);
    //    return Ok(matchingStyleToWeather);
    //}
    ///// <summary>
    ///// удаление образа
    ///// </summary>
    ///// <param name="matchingStyleToWeather"></param>
    ///// <returns></returns>
    //[HttpPut]
    //public ActionResult DeleteStyle(MatchingStyleToWeather matchingStyleToWeather)
    //{
    //    _iClothongService.DeleteAsync(matchingStyleToWeather.WeatherSettingId);
    //    return Ok(matchingStyleToWeather);
    //}