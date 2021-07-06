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

        public async Task<List<Style>> GetStyles(Weather weather)
        {
            //находим среднее арифметическое значение температуры
            double temp = (weather.TemperatureMax + weather.TemperatureMin) / 2;

            // проверяем есть ли дождь/снег/ветер и если есть,то создаём правило
            var booleanRule = new BooleanRule();
            if (weather.DescriptionSky.Contains("дождь"))
            {
                booleanRule.BoolType = BoolType.PresenceOfRain;
                booleanRule.IsExist = true;
            }
            else if (weather.DescriptionSky.Contains("снег"))
            {
                booleanRule.BoolType = BoolType.PresenceOfSnow;
                booleanRule.IsExist = true;
            }
            else if (weather.WindSpeed > 0)
            {
                booleanRule.BoolType = BoolType.PresenceOfWind;
                booleanRule.IsExist = true;
            }

            else
            {
                booleanRule.IsExist = false;
            }

            //находим в бд правила, которое соответствуют входным параметрам
            var selectBooleanRule = await _context.BooleanRules.FirstOrDefaultAsync(e => e.IsExist && e.BoolType == booleanRule.BoolType);

            var selectRangeRule = await _context.RangeRules.FirstOrDefaultAsync(e => e.MinTemperature <= temp && temp <= e.MaxTemperarure);

            //находим в бд правила нужную нам настройку по правилам
            var weatherSetting = await _context.WeatherSettings.FirstOrDefaultAsync(x => x.BooleanRuleId == selectBooleanRule.Id && x.RangeRuleId == selectRangeRule.Id);

            //находим в бд стиль по настройкам
            var styleByWeathers = await _context.MatchingStyleToWeathers.Where(x => x.WeatherSettingId == weatherSetting.Id).ToListAsync();

            List<Style> styles = new List<Style>();
            foreach (var s in styleByWeathers)
            {
                var style = await _context.Styles.FirstOrDefaultAsync(x => x.Id == s.StyleId);
                styles.Add(style);
            }
            return styles;
        }
        public async Task<List<ClothingItem>> GetClothingItem(List<Style> styles, Weather weather)
        {
            var compositionOfStyles = new List<CompositionOfStyle>();
            foreach (var st in styles)
            {
                var compositionOfStyle = await _context.CompositionOfStyles.FirstOrDefaultAsync(x => x.StyleId == st.Id);
                compositionOfStyles.Add(compositionOfStyle);
            }

            double temp = (weather.TemperatureMax + weather.TemperatureMin) / 2;
            var selectRangeRule = await _context.RangeRules.FirstOrDefaultAsync(e => e.MinTemperature <= temp && temp <= e.MaxTemperarure);
            
            var listClothingItem = new List<ClothingItem>();
            foreach (var s in compositionOfStyles)
            {
                if (selectRangeRule.Id == 1)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }
                else if (selectRangeRule.Id == 2)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }
                else if (selectRangeRule.Id == 3)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }
                else if (selectRangeRule.Id == 4)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }
                else if (selectRangeRule.Id == 5)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }
                else if (selectRangeRule.Id == 6)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }
                else if (selectRangeRule.Id == 7)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }
                else if (selectRangeRule.Id == 8)
                {
                    var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == selectRangeRule.Id);
                    listClothingItem.Add(clothingItem);
                    var count = selectRangeRule.Id + 3;
                    var clothingItemFemale = _context.ClothingItems.FirstOrDefault(x => x.Id == count);
                    listClothingItem.Add(clothingItemFemale);
                    break;
                }

            

            }
                return listClothingItem;
        }
        public async Task<List<Style>> GetAllStyles()
        {
            var stylesList = await _context.Styles.ToListAsync();
            return stylesList;
        }
        public string GetSovet(Weather weather)
        {
            string sovet = "";
            if (weather.DescriptionSky.Contains("дождь"))
            {
                sovet += "Возьмите зонтик";
            }
            else if (weather.DescriptionSky.Contains("снег"))
            {
                sovet += "\n" + "Не забудьте варежки и шарф";
            }
            else if (weather.TemperatureMin > 27)
            {
                sovet += "\n" + "Жаркий денёк, наденьте светлые тона";
            }

            else if (weather.TemperatureMin < 0)
            {
                sovet += "\n" + "Оденьтесь теплее";
            }
            else if (weather.TemperatureMin < 15)
            {
                sovet += "\n" + "Не забудьте кофту или куртку";
            }
            else if (weather.TemperatureMin > 15)
            {
                sovet += "\n" + "Тёплый денёк, можно одеться полегче";
            }
            else
            {
                sovet += "Ваша улыбка и хорошее настроение это главное украшение";
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
                sovet += "\n" + "Неделя будет прохладной,одевайтесь теплее";
            }
            else if (tempSrednee > 10&& tempSrednee<20)
            {
                sovet += "\n" + "Неделя будет достаточно теплой, но куртка или кофта не помешает";
            }
            else if (tempSrednee > 20)
            {
                sovet += "\n" + "Неделя будет жаркой, одевайтесь полегче";
            }
            else
            {
                sovet += "Ваша улыбка и хорошее настроение это главное украшение";
            }
            return sovet;
        }

        /// <summary>
        /// получить картинки по образу
        /// </summary>
        /// <returns></returns>
        //public async Task<List<ClothingItem>> GetClothingItem(Style style)
        //{
        //    var compositionOfStyle= await _context.CompositionOfStyles.Where(x => x.StyleId == style.Id).ToListAsync();
        //    var listClothingItem = new List<ClothingItem>();
        //    foreach(var s in compositionOfStyle)
        //    {
        //        var clothingItem = await _context.ClothingItems.FirstOrDefaultAsync(x => x.Id == s.Id);
        //        listClothingItem.Add(clothingItem);
        //    }
        //    return listClothingItem;
        //}
    }

}
