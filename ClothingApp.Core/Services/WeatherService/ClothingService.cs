using ClothingApp.Data.Common;
using ClothingApp.Data.Common.Entities;
using ClothingApp.Data.Common.Models;
using ClothingApp.Data.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Core.Services.WeatherService
{
    public class ClothingService : BaseRepository<MatchingStyleToWeather>, IClothingService
    {
        private readonly DataContext _context;
        public ClothingService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ClothingItem>> GetStyles(Weather weather)
        {
            //находим среднее арифметическое значение температуры
            double temp = (weather.TemperatureMax + weather.TemperatureMin) / 2;

            // проверяем есть ли дождь/снег/ветер и если есть,то создаём правило
            var booleanRuleRain = new BooleanRule();
            booleanRuleRain.BoolType = BoolType.PresenceOfRain;
            var booleanRuleSnow = new BooleanRule();
            booleanRuleSnow.BoolType = BoolType.PresenceOfSnow;
            if (weather.DescriptionSky.Contains("дождь"))
            {
                booleanRuleRain.IsExist = true;
            }
            else if (weather.DescriptionSky.Contains("снег"))
            {
                booleanRuleSnow.IsExist = true;
            }

            else
            {
                booleanRuleRain.IsExist = false;
                booleanRuleSnow.IsExist = false;
            }

            //находим в бд правила, которое соответствуют входным параметрам
            var selectBooleanRule = await _context.BooleanRules.FirstOrDefaultAsync(e => e.IsExist == booleanRuleRain.IsExist && e.BoolType == booleanRuleRain.BoolType ||
            e.IsExist == booleanRuleSnow.IsExist && e.BoolType == booleanRuleSnow.BoolType);//две строки - условие дождя и условие снега

            var selectRangeRule = await _context.RangeRules.FirstOrDefaultAsync(e => e.MinTemperature <= temp && temp <= e.MaxTemperarure);

            //находим в бд правила нужную нам настройку по правилам
            var weatherSetting = await _context.WeatherSettings.FirstOrDefaultAsync(x => x.BooleanRuleId == selectBooleanRule.Id && x.RangeRuleId == selectRangeRule.Id);

            //находим в бд стиль по настройкам
            var styleByWeathers = await _context.MatchingStyleToWeathers.Where(x => x.WeatherSettingId == weatherSetting.Id).ToListAsync();

            List<ClothingItem> items = new List<ClothingItem>();
            foreach (var s in styleByWeathers)
            {
                var style = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == s.ClothingItemId);
                items.Add(style);
            }
            return items;
        }
        
        public async Task<List<ClothingItem>> GetAllStyles()
        {
            var stylesList = await _context.ClothingItems.ToListAsync();
            return stylesList;
        }
        public string GetSovet(Weather weather)
        {
            string sovet = "";
            if (weather.DescriptionSky.Contains("дождь"))
            {
                sovet += "Возьмите зонтик. ";
            }
            else if (weather.DescriptionSky.Contains("снег"))
            {
                sovet += "\n" + "Не забудьте варежки и шарф. ";
            }
            else if (weather.TemperatureMin > 25)
            {
                sovet += "\n" + "Жаркий денёк, выбирайте светлые тона в одежде. ";
            }

            else if (weather.TemperatureMin < 0)
            {
                sovet += "\n" + "Оденьтесь теплее. ";
            }
            else if (weather.TemperatureMin < 15)
            {
                sovet += "\n" + "Не забудьте кофту или куртку. ";
            }
            else if (weather.TemperatureMin > 15)
            {
                sovet += "\n" + "Тёплый денёк, можно одеться полегче. ";
            }
            else
            {
                sovet += "Ваша улыбка и хорошее настроение - это главное украшение. ";
            }
            return sovet;
        }
        public string GetSovetFiveDays(List<List<Weather>> weathers)
        {
            string sovet = "";
            List<double> temperature = new List<double>();
            foreach (var w in weathers)
            {
                foreach(var j in w)
                {
                    temperature.Add(j.TemperatureMax);
                }
                
            }
            var tempSrednee = temperature.Sum() / temperature.Count();

            if(tempSrednee<10)
            {
                sovet += "\n" + "Неделя будет прохладной,одевайтесь теплее. ";
            }
            else if (tempSrednee > 10&& tempSrednee<20)
            {
                sovet += "\n" + "Неделя будет достаточно теплой, но куртка или кофта не помешает. ";
            }
            else if (tempSrednee > 20)
            {
                sovet += "\n" + "Неделя будет жаркой, одевайтесь полегче. ";
            }
            else
            {
                sovet += "Ваша улыбка и хорошее настроение - это главное украшение. ";
            }
            return sovet;
        }

    }

}
