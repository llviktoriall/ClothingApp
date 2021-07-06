using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class MatchingStyleToWeather : EntityBase<long>
    {
        public long WeatherSettingId { get; set; }

        [ForeignKey("WeatherSettingId")]
        public WeatherSetting WeatherSetting { get; set; }

        public long StyleId { get; set; }

        [ForeignKey("StyleId")]
        public Style Style { get; set; }
    }
}
