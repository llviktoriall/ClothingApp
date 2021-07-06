using ClothingApp.Data.Common.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ClothingApp.Data.Common
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherSetting> WeatherSettings { get; set; }
        public DbSet<RangeRule> RangeRules { get; set; }
        public DbSet<BooleanRule> BooleanRules { get; set; }
        public DbSet<MatchingStyleToWeather> MatchingStyleToWeathers { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<CompositionOfStyle> CompositionOfStyles { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClothesApp;Trusted_Connection=True;");
        }

        /// <summary>
        /// Заполнение бд тестовыми данными
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<IdentityUserLogin<string>>().HasNoKey();
            //builder.Entity<IdentityUserRole<string>>().HasNoKey();
            //builder.Entity<IdentityUserToken<string>>().HasNoKey();

            base.OnModelCreating(builder);

            // заполнение образов мужчин
            builder.Entity<ClothingItem>().HasData(
                new ClothingItem { Id = 1, Name = "Man:15-20",
                UrlImageFootwear = "/Images/Man/Man.15-20/footwear_3.png",
                UrlImageOuterwear = "/Images/Man/Man.15-20/hoodie.png",
                UrlImageUnderwear = "/Images/Man/Man.15-20/jeans.png",
                UrlImageAccessory = "/Images/Man/Man.15-20/umbrella.png" },
                
                new ClothingItem { Id = 2, Name = "Man:20-25",
                UrlImageFootwear = "/Images/Man/Man.20-25/footwear_3.png",
                UrlImageOuterwear = "/Images/Man/Man.20-25/mens.png",
                UrlImageUnderwear = "/Images/Man/Man.20-25/jeans.png",
                UrlImageAccessory = "/Images/Man/Man.20-25/umbrella.png",
                UrlImageHat = "/Images/Man/Man.20-25/hat_3.png"},
                
                new ClothingItem { Id = 3, Name = "25-30",
                UrlImageFootwear = "/Images/Man/Man.25-30/footwear_1.png",
                UrlImageOuterwear = "/Images/Man/Man.25-30/shirt.png",
                UrlImageUnderwear = "/Images/Man/Man.25-30/short.png",
                UrlImageAccessory = "/Images/Man/Man.25-30/accessory_3.png",
                UrlImageHat = "/Images/Man/Man.20-25/hat_3.png"},

                new ClothingItem { Id = 4, Name = "30-35",
                UrlImageFootwear = "/Images/Man/Man.30-35/footwear_5.png",
                UrlImageOuterwear = "/Images/Man/Man.30-35/tshirt.png",
                UrlImageUnderwear = "/Images/Man/Man.30-35/shorts_2.png",
                UrlImageAccessory = "/Images/Man/Man.30-35/umbrella.png",
                UrlImageHat = "/Images/Man/Man.30-35/hat_2"});

            // заполнение образов женщин
            builder.Entity<ClothingItem>().HasData(
                new ClothingItem { Id = 5, Name = "Woman:15-20",
                    UrlImageFootwear = "/Images/Woman/Woman.15-20/footwear_1.png",
                    UrlImageOuterwear = "/Images/Woman/Woman.15-20/jacket.png",
                    UrlImageUnderwear = "/Images/Woman/Woman.15-20/pants.png",
                    UrlImageAccessory = "/Images/Woman/Woman.15-20/umbrella.png" },

                new ClothingItem { Id = 6, Name = "Woman:20-25",
                    UrlImageFootwear = "/Images/Woman/Woman.20-25/footwear_1.png",
                    UrlImageOuterwear = "/Images/Woman/Woman.20-25/t-shirt.png",
                    UrlImageUnderwear = "/Images/Woman/Woman.20-25/pants.png",
                    UrlImageAccessory = "/Images/Woman/Woman.20-25/umbrella.png",
                    UrlImageHat = "/Images/Woman/Woman.20-25/hat_1.png" },

                new ClothingItem { Id = 7, Name = "Woman:25-30",
                    UrlImageFootwear = "/Images/Woman/Woman.25-30/footwear_4.png",
                    UrlImageOuterwear = "/Images/Woman/Woman.25-30/t-shirt.png",
                    UrlImageUnderwear = "/Images/Woman/Woman.25-30/skirt.png",
                    UrlImageAccessory = "/Images/Woman/Woman.25-30/umbrellf.png",
                    UrlImageHat = "/Images/Woman/Woman.25-30/hat_1.png" },

                new ClothingItem { Id = 8, Name = "Woman:30-35",
                    UrlImageFootwear = "/Images/Woman/Woman.30-35/footwear_4.png",
                    UrlImageOuterwear = "/Images/Woman/Woman.30-35/frock.png",
                    UrlImageAccessory = "/Images/Woman/Woman.30-35/umbrella.png",
                    UrlImageHat = "/Images/Woman/Woman.30-35/hat_1.png" });

            // заполнение таблицы образов
            builder.Entity<Style>().HasData(
                new Style { Id = 1, GenderType = GenderType.Male, Name = "Мужской образ" },
                new Style { Id = 2, GenderType = GenderType.Female, Name = "Женский образ" });

            // заполнение таблицы связывающей вещи и образ
            builder.Entity<CompositionOfStyle>().HasData(
                new CompositionOfStyle { Id = 1, ClothingItemId = 1, StyleId = 1 },
                new CompositionOfStyle { Id = 2, ClothingItemId = 2, StyleId = 1 },
                new CompositionOfStyle { Id = 3, ClothingItemId = 3, StyleId = 1 },
                new CompositionOfStyle { Id = 4, ClothingItemId = 4, StyleId = 1 },
                new CompositionOfStyle { Id = 5, ClothingItemId = 5, StyleId = 2 },
                new CompositionOfStyle { Id = 6, ClothingItemId = 6, StyleId = 2 },
                new CompositionOfStyle { Id = 7, ClothingItemId = 7, StyleId = 2 },
                new CompositionOfStyle { Id = 8, ClothingItemId = 8, StyleId = 2 });

            // заполнение RangeRule
            builder.Entity<RangeRule>().HasData(
                new RangeRule { Id = 1, MinTemperature = 10.0, MaxTemperarure = 15.0 },
                new RangeRule { Id = 2, MinTemperature = 15.0, MaxTemperarure = 20.0 },
                new RangeRule { Id = 3, MinTemperature = 20.0, MaxTemperarure = 25.0 },
                new RangeRule { Id = 4, MinTemperature = 25.0, MaxTemperarure = 30.0 },
                new RangeRule { Id = 5, MinTemperature = 30.0, MaxTemperarure = 35.0 });

            // заполнение BooleanRule
            builder.Entity<BooleanRule>().HasData(
                new BooleanRule { Id = 1, BoolType = BoolType.PresenceOfRain, IsExist = true },
                new BooleanRule { Id = 2, BoolType = BoolType.PresenceOfRain, IsExist = false },
                new BooleanRule { Id = 3, BoolType = BoolType.PresenceOfSnow, IsExist = true },
                new BooleanRule { Id = 4, BoolType = BoolType.PresenceOfSnow, IsExist = false },
                new BooleanRule { Id = 5, BoolType = BoolType.PresenceOfWind, IsExist = true },
                new BooleanRule { Id = 6, BoolType = BoolType.PresenceOfWind, IsExist = false });

            builder.Entity<WeatherSetting>().HasData(
                new WeatherSetting { Id = 1, Name = "Холодно, без ветра", BooleanRuleId = 6, RangeRuleId = 1 },
                new WeatherSetting { Id = 2, Name = "Холодно, с ветром", BooleanRuleId = 5, RangeRuleId = 1 },
                new WeatherSetting { Id = 3, Name = "Холодно, с дождем", BooleanRuleId = 1, RangeRuleId = 1 },
                new WeatherSetting { Id = 4, Name = "Холодно, без дождя", BooleanRuleId = 2, RangeRuleId = 1},

                new WeatherSetting { Id = 5, Name = "Прохладно, без ветра", BooleanRuleId = 6, RangeRuleId = 2 },
                new WeatherSetting { Id = 6, Name = "Прохладно, с ветром", BooleanRuleId = 5, RangeRuleId = 2 },
                new WeatherSetting { Id = 7, Name = "Прохладно, с дождем", BooleanRuleId = 1, RangeRuleId = 2 },
                new WeatherSetting { Id = 8, Name = "Прохладно, без дождя", BooleanRuleId = 2, RangeRuleId = 2 },

                new WeatherSetting { Id = 9, Name = "Тепло, без ветра", BooleanRuleId = 6, RangeRuleId = 3 },
                new WeatherSetting { Id = 10, Name = "Тепло, с ветром", BooleanRuleId = 5, RangeRuleId = 3 },
                new WeatherSetting { Id = 11, Name = "Тепло, с дождем", BooleanRuleId = 1, RangeRuleId = 3 },
                new WeatherSetting { Id = 12, Name = "Тепло, без дождя", BooleanRuleId = 2, RangeRuleId = 3 },

                new WeatherSetting { Id = 13, Name = "Жарко, без ветра", BooleanRuleId = 6, RangeRuleId = 4 },
                new WeatherSetting { Id = 14, Name = "Жарко, с ветром", BooleanRuleId = 5, RangeRuleId = 4 },
                new WeatherSetting { Id = 15, Name = "Жарко, с дождем", BooleanRuleId = 1, RangeRuleId = 4 },
                new WeatherSetting { Id = 16, Name = "Жарко, без дождя", BooleanRuleId = 2, RangeRuleId = 4 },

                new WeatherSetting { Id = 17, Name = "ЖАРИЩА, без ветра", BooleanRuleId = 6, RangeRuleId = 5 },
                new WeatherSetting { Id = 18, Name = "ЖАРИЩА, с ветром", BooleanRuleId = 5, RangeRuleId = 5 },
                new WeatherSetting { Id = 19, Name = "ЖАРИЩА, с дождем", BooleanRuleId = 1, RangeRuleId = 5 },
                new WeatherSetting { Id = 20, Name = "ЖАРИЩА, без дождя", BooleanRuleId = 2, RangeRuleId = 5 }
                );

            builder.Entity<MatchingStyleToWeather>().HasData(
                new MatchingStyleToWeather { Id = 1, WeatherSettingId = 1, StyleId = 1 },
                new MatchingStyleToWeather { Id = 2, WeatherSettingId = 2, StyleId = 1 },
                new MatchingStyleToWeather { Id = 3, WeatherSettingId = 3, StyleId = 1 },
                new MatchingStyleToWeather { Id = 4, WeatherSettingId = 4, StyleId = 1 },
                new MatchingStyleToWeather { Id = 5, WeatherSettingId = 5, StyleId = 1 },
                new MatchingStyleToWeather { Id = 6, WeatherSettingId = 6, StyleId = 1 },
                new MatchingStyleToWeather { Id = 7, WeatherSettingId = 7, StyleId = 1 },
                new MatchingStyleToWeather { Id = 8, WeatherSettingId = 8, StyleId = 1 },
                new MatchingStyleToWeather { Id = 9, WeatherSettingId = 9, StyleId = 1 },
                new MatchingStyleToWeather { Id = 10, WeatherSettingId = 10, StyleId = 1 },
                new MatchingStyleToWeather { Id = 11, WeatherSettingId = 11, StyleId = 1 },
                new MatchingStyleToWeather { Id = 12, WeatherSettingId = 12, StyleId = 1 },
                new MatchingStyleToWeather { Id = 13, WeatherSettingId = 13, StyleId = 1 },
                new MatchingStyleToWeather { Id = 14, WeatherSettingId = 14, StyleId = 1 },
                new MatchingStyleToWeather { Id = 15, WeatherSettingId = 15, StyleId = 1 },
                new MatchingStyleToWeather { Id = 16, WeatherSettingId = 16, StyleId = 1 },
                new MatchingStyleToWeather { Id = 17, WeatherSettingId = 17, StyleId = 1 },
                new MatchingStyleToWeather { Id = 18, WeatherSettingId = 18, StyleId = 1 },
                new MatchingStyleToWeather { Id = 19, WeatherSettingId = 19, StyleId = 1 },
                new MatchingStyleToWeather { Id = 20, WeatherSettingId = 20, StyleId = 1 },

                new MatchingStyleToWeather { Id = 21, WeatherSettingId = 1, StyleId = 2 },
                new MatchingStyleToWeather { Id = 22, WeatherSettingId = 2, StyleId = 2 },
                new MatchingStyleToWeather { Id = 23, WeatherSettingId = 3, StyleId = 2 },
                new MatchingStyleToWeather { Id = 24, WeatherSettingId = 4, StyleId = 2 },
                new MatchingStyleToWeather { Id = 25, WeatherSettingId = 5, StyleId = 2 },
                new MatchingStyleToWeather { Id = 26, WeatherSettingId = 6, StyleId = 2 },
                new MatchingStyleToWeather { Id = 27, WeatherSettingId = 7, StyleId = 2 },
                new MatchingStyleToWeather { Id = 28, WeatherSettingId = 8, StyleId = 2 },
                new MatchingStyleToWeather { Id = 29, WeatherSettingId = 9, StyleId = 2 },
                new MatchingStyleToWeather { Id = 30, WeatherSettingId = 10, StyleId = 2 },
                new MatchingStyleToWeather { Id = 31, WeatherSettingId = 11, StyleId = 2 },
                new MatchingStyleToWeather { Id = 32, WeatherSettingId = 12, StyleId = 2 },
                new MatchingStyleToWeather { Id = 33, WeatherSettingId = 13, StyleId = 2 },
                new MatchingStyleToWeather { Id = 34, WeatherSettingId = 14, StyleId = 2 },
                new MatchingStyleToWeather { Id = 35, WeatherSettingId = 15, StyleId = 2 },
                new MatchingStyleToWeather { Id = 36, WeatherSettingId = 16, StyleId = 2 },
                new MatchingStyleToWeather { Id = 37, WeatherSettingId = 17, StyleId = 2 },
                new MatchingStyleToWeather { Id = 38, WeatherSettingId = 18, StyleId = 2 },
                new MatchingStyleToWeather { Id = 39, WeatherSettingId = 19, StyleId = 2 },
                new MatchingStyleToWeather { Id = 40, WeatherSettingId = 20, StyleId = 2 });


        }
    }
}
