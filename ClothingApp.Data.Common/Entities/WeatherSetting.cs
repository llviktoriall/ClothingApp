using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class WeatherSetting : EntityBase<long>
    {
        /// <summary>
        /// Наименование настройки
        /// </summary>
        public string Name { get; set; }

        public long BooleanRuleId { get; set; }

        [ForeignKey("BooleanRuleId")]
        public BooleanRule BooleanRule { get; set; }

        public long RangeRuleId { get; set; }

        [ForeignKey("RangeRuleId")]
        public RangeRule RangeRule { get; set; }
    }

}
