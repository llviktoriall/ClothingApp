﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class BooleanRule : EntityBase<long>
    {
        /// <summary>
        /// Существует правило или нет
        /// </summary>
        public bool IsExist { get; set; }
        /// <summary>
        /// осадки или ветер
        /// </summary>
        public BoolType BoolType { get; set; }

        public ICollection<WeatherSetting> WeatherSettings { get; set; }
    }
    public enum BoolType
    {
        /// <summary>
        /// Наличие дождя
        /// </summary>
        PresenceOfRain = 1,

        /// <summary>
        /// Наличие ветра
        /// </summary>
        PresenceOfWind = 2,

        /// <summary>
        /// Наличие снега
        /// </summary>
        PresenceOfSnow = 3
    }
}
