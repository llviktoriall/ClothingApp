using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClothingApp.Data.Common.Entities
{
    public class CompositionOfStyle : EntityBase<long>
    {
        public long StyleId { get; set; }

        [ForeignKey("StyleId")]
        public Style Style { get; set; }

        public long ClothingItemId { get; set; }

        [ForeignKey("ClothingItemId")]
        public ClothingItem ClothingItem { get; set; }
    }
}
