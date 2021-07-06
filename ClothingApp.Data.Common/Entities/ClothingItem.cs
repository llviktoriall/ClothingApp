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
        /// Путь к картинке
        /// </summary>
        public string UrlImageHat { get; set; }

        public string UrlImageFootwear { get; set; }

        public string UrlImageAccessory { get; set; }

        public string UrlImageOuterwear { get; set; }

        public string UrlImageUnderwear { get; set; }

        public ICollection<CompositionOfStyle> CompositionOfStyles { get; set; }
    }
}
