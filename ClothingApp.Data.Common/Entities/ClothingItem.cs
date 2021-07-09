using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    /// <summary>
    /// Объект одежды
    /// </summary>
    public class ClothingItem : EntityBase<long>
    {
        /// <summary>
        /// Наименование одежды
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дополнительный аксессуар или что-то теплое
        /// </summary>
        public string UrlImageAdd { get; set; }
        /// <summary>
        /// Обувь
        /// </summary>
        public string UrlImageFootwear { get; set; }
        /// <summary>
        /// Аксессуар
        /// </summary>
        public string UrlImageAccessory { get; set; }
        /// <summary>
        /// Майки кофты
        /// </summary>
        public string UrlImageOuterwear { get; set; }
        /// <summary>
        /// Штаны, шорты, юбки
        /// </summary>
        public string UrlImageUnderwear { get; set; }

        //public ICollection<CompositionOfStyle> CompositionOfStyles { get; set; }

        public GenderType GenderType { get; set; }
        
    }
    public enum GenderType
    {
        /// <summary>
        /// Мужской пол
        /// </summary>
        Male = 1,

        /// <summary>
        /// Женский пол
        /// </summary>
        Female = 2
    }
}
