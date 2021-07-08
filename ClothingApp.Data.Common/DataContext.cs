﻿using ClothingApp.Data.Common.Entities;
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
                new ClothingItem
                {
                    Id = 1,
                    Name = "Man:-40-",
                    UrlImageFootwear = "/Images/Man/Man.-40-/Man.-40-/footwear_6_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man.-40-/Man.-40-/sweater_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man.-40-/Man.-40-/trousers_2_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man.-40-/Man.-40-/hat_1_w_m.png",
                    UrlImageAdd = "/Images/Man/Man.-40-/Man.-40-/coat_2_w_m.png"
                },
                new ClothingItem
                {
                    Id = 2,
                    Name = "Man:-40-25",
                    UrlImageFootwear = "/Images/Man/Man:-40-25/Man:-40-25/footwear_7_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:-40-25/Man:-40-25/hoody_2_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:-40-25/Man:-40-25/trousers_2_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:-40-25/Man:-40-25/hat_1_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:-40-25/Man:-40-25/accessory_5_w_m.png"
                },
                new ClothingItem
                {
                    Id = 3,
                    Name = "Man:-25-15",
                    UrlImageFootwear = "/Images/Man/Man:-25-15/Man:-25-15/footwear_7_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:-25-15/Man:-25-15/undershirt_2_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:-25-15/Man:-25-15/trousers_2_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:-25-15/Man:-25-15/hat_1_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:-25-15/Man:-25-15/coat_2_w_m.png"
                },
                new ClothingItem
                {
                    Id = 4,
                    Name = "Man:-25-15.snow",
                    UrlImageFootwear = "/Images/Man/Man:-25-15/Man:-25-15.snow/footwear_7_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:-25-15/Man:-25-15.snow/coat_2_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:-25-15/Man:-25-15.snow/trousers_2_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:-25-15/Man:-25-15.snow/hat_1_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:-25-15/Man:-25-15.snow/accessory_5_w_m.png"
                },
                new ClothingItem
                {
                    Id = 5,
                    Name = "Man:-15-5",
                    UrlImageFootwear = "/Images/Man/Man:-15-5/Man:-15-5/footwear_4_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:-15-5/Man:-15-5/undershirt_1_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:-15-5/Man:-15-5/trousers_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:-15-5/Man:-15-5/hat_4_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:-15-5/Man:-15-5/coat_1_w_m.png"
                },
                new ClothingItem
                {
                    Id = 6,
                    Name = "Man:-5-0",
                    UrlImageFootwear = "/Images/Man/Man:-5-0/Man:-5-0/footwear_1_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:-5-0/Man:-5-0/jacket_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:-5-0/Man:-5-0/trousers_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:-5-0/Man:-5-0/hat_4_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:-5-0/Man:-5-0/coat_1_w_m.png"
                },
                new ClothingItem
                {
                    Id = 7,
                    Name = "Man:-5-0.snow",
                    UrlImageFootwear = "/Images/Man/Man:-5-0/Man:-5-0.snow/footwear_1_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:-5-0/Man:-5-0.snow/jacket_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:-5-0/Man:-5-0.snow/trousers_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:-5-0/Man:-5-0.snow/hat_4_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:-5-0/Man:-5-0.snow/coat_2_w_m.png"
                },
                new ClothingItem
                {
                    Id = 8,
                    Name = "Man:0+5",
                    UrlImageFootwear = "/Images/Man/Man:0+5/Man:0+5/footwear_2_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:0+5/Man:0+5/shirt_2_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:0+5/Man:0+5/trousers_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:0+5/Man:0+5/accessory_6_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:0+5/Man:0+5/blazer_1_w_m.png"
                },
                new ClothingItem
                {
                    Id = 9,
                    Name = "Man:0+5.rain",
                    UrlImageFootwear = "/Images/Man/Man:0+5/Man:0+5.rain/footwear_2_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:0+5/Man:0+5.rain/shirt_2_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:0+5/Man:0+5.rain/trousers_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:0+5/Man:0+5.rain/accessory_4_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:0+5/Man:0+5.rain/blazer_1_w_m.png"
                },
                new ClothingItem
                {
                    Id = 10,
                    Name = "Man:+5+15",
                    UrlImageFootwear = "/Images/Man/Man:+5+15/Man:+5+15/footwear_1_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+5+15/Man:+5+15/tshirt_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+5+15/Man:+5+15/jeans_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+5+15/Man:+5+15/hat_2_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+5+15/Man:+5+15/hoody_1_w_m.png"
                },
                new ClothingItem
                {
                    Id = 11,
                    Name = "Man:+5+15.rain",
                    UrlImageFootwear = "/Images/Man/Man:+5+15/Man:+5+15.rain/footwear_1_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+5+15/Man:+5+15.rain/hoody_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+5+15/Man:+5+15.rain/jeans_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+5+15/Man:+5+15.rain/hat_2_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+5+15/Man:+5+15.rain/accessory_4_w_m.png"
                },
                new ClothingItem
                {
                    Id = 12,
                    Name = "Man:+15+20",
                    UrlImageFootwear = "/Images/Man/Man:+15+20/Man:+15+20/footwear_3_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+15+20/Man:+15+20/tshirt_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+15+20/Man:+15+20/jeans_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+15+20/Man:+15+20/hat_2_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+15+20/Man:+15+20/accessory_3_w_m.png"
                },
                new ClothingItem
                {
                    Id = 13,
                    Name = "Man:+15+20.rain",
                    UrlImageFootwear = "/Images/Man/Man:+15+20/Man:+15+20.rain/footwear_3_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+15+20/Man:+15+20.rain/tshirt_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+15+20/Man:+15+20.rain/jeans_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+15+20/Man:+15+20.rain/accessory_2_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+15+20/Man:+15+20.rain/accessory_4_w_m.png"
                },
                new ClothingItem
                {
                    Id = 14,
                    Name = "Man:+20+25",
                    UrlImageFootwear = "/Images/Man/Man:+20+25/Man:+20+25/footwear_1_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+20+25/Man:+20+25/tshirt_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+20+25/Man:+20+25/shorts_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+20+25/Man:+20+25/hat_3_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+20+25/Man:+20+25/accessory_1_w_m.png"
                },
                new ClothingItem
                {
                    Id = 15,
                    Name = "Man:+20+25.rain",
                    UrlImageFootwear = "/Images/Man/Man:+20+25/Man:+20+25.rain/footwear_1_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+20+25/Man:+20+25.rain/tshirt_1_w_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+20+25/Man:+20+25.rain/shorts_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+20+25/Man:+20+25.rain/hat_3_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+20+25/Man:+20+25.rain/accessory_4_w_m.png"
                },
                new ClothingItem
                {
                    Id = 16,
                    Name = "Man:+25+30",
                    UrlImageFootwear = "/Images/Man/Man:+25+30/Man:+25+30/footwear_1_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+25+30/Man:+25+30/tshirt_1_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+25+30/Man:+25+30/shorts_2_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+25+30/Man:+25+30/hat_2_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+25+30/Man:+25+30/accessory_3_w_m.png"
                },
                new ClothingItem
                {
                    Id = 17,
                    Name = "Man:+25+30.rain",
                    UrlImageFootwear = "/Images/Man/Man:+25+30/Man:+25+30.rain/footwear_1_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+25+30/Man:+25+30.rain/tshirt_1_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+25+30/Man:+25+30.rain/shorts_2_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+25+30/Man:+25+30.rain/hat_2_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+25+30/Man:+25+30.rain/accessory_4_w_m.png"
                },
                new ClothingItem
                {
                    Id = 18,
                    Name = "Man:+30+35",
                    UrlImageFootwear = "/Images/Man/Man:+30+35/Man:+30+35/footwear_1_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+30+35/Man:+30+35/tshirt_2_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+30+35/Man:+30+35/shorts_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+30+35/Man:+30+35/accessory_7_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+30+35/Man:+30+35/accessory_3_w_m.png"
                },
                new ClothingItem
                {
                    Id = 19,
                    Name = "Man:+30+35.rain",
                    UrlImageFootwear = "/Images/Man/Man:+30+35/Man:+30+35.rain/footwear_1_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+30+35/Man:+30+35.rain/tshirt_2_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+30+35/Man:+30+35.rain/shorts_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+30+35/Man:+30+35.rain/hat_2_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+30+35/Man:+30+35.rain/accessory_4_w_m.png"
                },
                new ClothingItem
                {
                    Id = 20,
                    Name = "Man:+35+",
                    UrlImageFootwear = "/Images/Man/Man:+35+/Man:+35+/footwear_5_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+35+/Man:+35+/tshirt_1_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+35+/Man:+35+/shorts_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+35+/Man:+35+/accessory_7_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+35+/Man:+35+/hat_2_w_m.png"
                },
                new ClothingItem
                {
                    Id = 21,
                    Name = "Man:+35+.rain",
                    UrlImageFootwear = "/Images/Man/Man:+35+/Man:+35+.rain/footwear_5_w_m.png",
                    UrlImageOuterwear = "/Images/Man/Man:+35+/Man:+35+.rain/tshirt_1_m.png",
                    UrlImageUnderwear = "/Images/Man/Man:+35+/Man:+35+.rain/shorts_1_w_m.png",
                    UrlImageAccessory = "/Images/Man/Man:+35+/Man:+35+.rain/accessory_7_w_m.png",
                    UrlImageAdd = "/Images/Man/Man:+35+/Man:+35+.rain/accessory_4_w_m.png"
                }
                );

            // заполнение образов женщин
            builder.Entity<ClothingItem>().HasData(
                new ClothingItem
                {
                    Id = 2,
                    Name = "Man:20-25",
                    UrlImageFootwear = "/Images/Man/Man.20-25/footwear_3.png",
                    UrlImageOuterwear = "/Images/Man/Man.20-25/mens.png",
                    UrlImageUnderwear = "/Images/Man/Man.20-25/jeans.png",
                    UrlImageAccessory = "/Images/Man/Man.20-25/umbrella.png",
                    UrlImageAdd = "/Images/Man/Man.20-25/hat_3.png"
                },



                );

            // заполнение таблицы образов
            builder.Entity<Style>().HasData(
                new Style { Id = 1, GenderType = GenderType.Male, Name = "Мужской образ" },
                new Style { Id = 2, GenderType = GenderType.Female, Name = "Женский образ" });

            // заполнение таблицы связывающей вещи и образ (пол)
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
                new RangeRule { Id = 1, MinTemperature = -70.0, MaxTemperarure = -40.0 },
                new RangeRule { Id = 2, MinTemperature = -40.0, MaxTemperarure = -25.0 },
                new RangeRule { Id = 3, MinTemperature = -25.0, MaxTemperarure = -15.0 },
                new RangeRule { Id = 4, MinTemperature = -15.0, MaxTemperarure = -5.0 },
                new RangeRule { Id = 5, MinTemperature = -5.0, MaxTemperarure = 0.0 },
                new RangeRule { Id = 6, MinTemperature = 0.0, MaxTemperarure = 5.0 },
                new RangeRule { Id = 7, MinTemperature = 5.0, MaxTemperarure = 15.0 },
                new RangeRule { Id = 8, MinTemperature = 15.0, MaxTemperarure = 20.0 },
                new RangeRule { Id = 9, MinTemperature = 20.0, MaxTemperarure = 25.0 },
                new RangeRule { Id = 10, MinTemperature = 25.0, MaxTemperarure = 30.0 },
                new RangeRule { Id = 11, MinTemperature = 30.0, MaxTemperarure = 35.0 },
                new RangeRule { Id = 12, MinTemperature = 35.0, MaxTemperarure = 70.0 });

            // заполнение BooleanRule
            builder.Entity<BooleanRule>().HasData(
                new BooleanRule { Id = 1, BoolType = BoolType.PresenceOfRain, IsExist = true },
                new BooleanRule { Id = 2, BoolType = BoolType.PresenceOfRain, IsExist = false },
                new BooleanRule { Id = 3, BoolType = BoolType.PresenceOfSnow, IsExist = true },
                new BooleanRule { Id = 4, BoolType = BoolType.PresenceOfSnow, IsExist = false });

            builder.Entity<WeatherSetting>().HasData(
                new WeatherSetting { Id = 1, Name = "Холодно очень очень, без снега", BooleanRuleId = 4, RangeRuleId = 1 },
                new WeatherSetting { Id = 2, Name = "Холодно очень очень, со снегом", BooleanRuleId = 3, RangeRuleId = 1 },
                new WeatherSetting { Id = 3, Name = "Холодно очень очень, с дождем", BooleanRuleId = 1, RangeRuleId = 1 },
                new WeatherSetting { Id = 4, Name = "Холодно очень очень, без дождя", BooleanRuleId = 2, RangeRuleId = 1 },

                new WeatherSetting { Id = 5, Name = "Холодно очень, без снега", BooleanRuleId = 4, RangeRuleId = 2 },
                new WeatherSetting { Id = 6, Name = "Холодно очень, со снегом", BooleanRuleId = 3, RangeRuleId = 2 },
                new WeatherSetting { Id = 7, Name = "Холодно очень, с дождем", BooleanRuleId = 1, RangeRuleId = 2 },
                new WeatherSetting { Id = 8, Name = "Холодно очень, без дождя", BooleanRuleId = 2, RangeRuleId = 2 },

                new WeatherSetting { Id = 9, Name = "Холодно, без снега", BooleanRuleId = 4, RangeRuleId = 3 },
                new WeatherSetting { Id = 10, Name = "Холодно,со снегом", BooleanRuleId = 3, RangeRuleId = 3 },
                new WeatherSetting { Id = 11, Name = "Холодно, с дождем", BooleanRuleId = 1, RangeRuleId = 3 },
                new WeatherSetting { Id = 12, Name = "Холодно, без дождя", BooleanRuleId = 2, RangeRuleId = 3 },

                new WeatherSetting { Id = 13, Name = "Холодно немного, без снега", BooleanRuleId = 4, RangeRuleId = 4 },
                new WeatherSetting { Id = 14, Name = "Холодно немного, со снегом", BooleanRuleId = 3, RangeRuleId = 4 },
                new WeatherSetting { Id = 15, Name = "Холодно немного, с дождем", BooleanRuleId = 1, RangeRuleId = 4 },
                new WeatherSetting { Id = 16, Name = "Холодно немного, без дождя", BooleanRuleId = 2, RangeRuleId = 4 },

                new WeatherSetting { Id = 17, Name = "Прохладно, без снега", BooleanRuleId = 4, RangeRuleId = 5 },
                new WeatherSetting { Id = 18, Name = "Прохладно, со снегом", BooleanRuleId = 3, RangeRuleId = 5 },
                new WeatherSetting { Id = 19, Name = "Прохладно, с дождем", BooleanRuleId = 1, RangeRuleId = 5 },
                new WeatherSetting { Id = 20, Name = "Прохладно, без дождя", BooleanRuleId = 2, RangeRuleId = 5 },

                new WeatherSetting { Id = 21, Name = "Свежо, без снега", BooleanRuleId = 4, RangeRuleId = 6 },
                new WeatherSetting { Id = 22, Name = "Свежо, со снегом", BooleanRuleId = 3, RangeRuleId = 6 },
                new WeatherSetting { Id = 23, Name = "Свежо, с дождем", BooleanRuleId = 1, RangeRuleId = 6 },
                new WeatherSetting { Id = 24, Name = "Свежо, без дождя", BooleanRuleId = 2, RangeRuleId = 7 },

                new WeatherSetting { Id = 25, Name = "Чуть тепло, без снега", BooleanRuleId = 4, RangeRuleId = 8 },
                new WeatherSetting { Id = 26, Name = "Чуть тепло, со снегом", BooleanRuleId = 3, RangeRuleId = 8 },
                new WeatherSetting { Id = 27, Name = "Чуть тепло, с дождем", BooleanRuleId = 1, RangeRuleId = 8 },
                new WeatherSetting { Id = 28, Name = "Чуть тепло, без дождя", BooleanRuleId = 2, RangeRuleId = 8 },

                new WeatherSetting { Id = 29, Name = "Тепло, без снега", BooleanRuleId = 4, RangeRuleId = 9 },
                new WeatherSetting { Id = 30, Name = "Тепло, со снегом", BooleanRuleId = 3, RangeRuleId = 9 },
                new WeatherSetting { Id = 31, Name = "Тепло, с дождем", BooleanRuleId = 1, RangeRuleId = 9 },
                new WeatherSetting { Id = 32, Name = "Тепло, без дождя", BooleanRuleId = 2, RangeRuleId = 9},

                new WeatherSetting { Id = 33, Name = "Тепло очень, без снега", BooleanRuleId = 4, RangeRuleId = 10 },
                new WeatherSetting { Id = 34, Name = "Тепло очень, со снегом", BooleanRuleId = 3, RangeRuleId = 10 },
                new WeatherSetting { Id = 35, Name = "Тепло очень, с дождем", BooleanRuleId = 1, RangeRuleId = 10 },
                new WeatherSetting { Id = 36, Name = "Тепло очень, без дождя", BooleanRuleId = 2, RangeRuleId = 10 },

                new WeatherSetting { Id = 37, Name = "Жарко, без снега", BooleanRuleId = 4, RangeRuleId = 11 },
                new WeatherSetting { Id = 38, Name = "Жарко, со снегом", BooleanRuleId = 3, RangeRuleId = 11 },
                new WeatherSetting { Id = 39, Name = "Жарко, с дождем", BooleanRuleId = 1, RangeRuleId = 11 },
                new WeatherSetting { Id = 40, Name = "Жарко, без дождя", BooleanRuleId = 2, RangeRuleId = 11 },

                new WeatherSetting { Id = 41, Name = "Жарища, без снега", BooleanRuleId = 4, RangeRuleId = 12 },
                new WeatherSetting { Id = 42, Name = "Жарища, со снегом", BooleanRuleId = 3, RangeRuleId = 12 },
                new WeatherSetting { Id = 43, Name = "Жарища, с дождем", BooleanRuleId = 1, RangeRuleId = 12 },
                new WeatherSetting { Id = 44, Name = "Жарища, без дождя", BooleanRuleId = 2, RangeRuleId = 12 }
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
                new MatchingStyleToWeather { Id = 21, WeatherSettingId = 21, StyleId = 1 },
                new MatchingStyleToWeather { Id = 22, WeatherSettingId = 22, StyleId = 1 },
                new MatchingStyleToWeather { Id = 23, WeatherSettingId = 23, StyleId = 1 },
                new MatchingStyleToWeather { Id = 24, WeatherSettingId = 24, StyleId = 1 },
                new MatchingStyleToWeather { Id = 25, WeatherSettingId = 25, StyleId = 1 },
                new MatchingStyleToWeather { Id = 26, WeatherSettingId = 26, StyleId = 1 },
                new MatchingStyleToWeather { Id = 27, WeatherSettingId = 27, StyleId = 1 },
                new MatchingStyleToWeather { Id = 28, WeatherSettingId = 28, StyleId = 1 },
                new MatchingStyleToWeather { Id = 29, WeatherSettingId = 29, StyleId = 1 },
                new MatchingStyleToWeather { Id = 30, WeatherSettingId = 30, StyleId = 1 },
                new MatchingStyleToWeather { Id = 31, WeatherSettingId = 31, StyleId = 1 },
                new MatchingStyleToWeather { Id = 32, WeatherSettingId = 32, StyleId = 1 },
                new MatchingStyleToWeather { Id = 33, WeatherSettingId = 33, StyleId = 1 },
                new MatchingStyleToWeather { Id = 34, WeatherSettingId = 34, StyleId = 1 },
                new MatchingStyleToWeather { Id = 35, WeatherSettingId = 35, StyleId = 1 },
                new MatchingStyleToWeather { Id = 36, WeatherSettingId = 36, StyleId = 1 },
                new MatchingStyleToWeather { Id = 37, WeatherSettingId = 37, StyleId = 1 },
                new MatchingStyleToWeather { Id = 38, WeatherSettingId = 38, StyleId = 1 },
                new MatchingStyleToWeather { Id = 39, WeatherSettingId = 39, StyleId = 1 },
                new MatchingStyleToWeather { Id = 40, WeatherSettingId = 40, StyleId = 1 },
                new MatchingStyleToWeather { Id = 41, WeatherSettingId = 41, StyleId = 1 },
                new MatchingStyleToWeather { Id = 42, WeatherSettingId = 42, StyleId = 1 },
                new MatchingStyleToWeather { Id = 43, WeatherSettingId = 43, StyleId = 1 },
                new MatchingStyleToWeather { Id = 44, WeatherSettingId = 44, StyleId = 1 },

                new MatchingStyleToWeather { Id = 45, WeatherSettingId = 1, StyleId = 2 },
                new MatchingStyleToWeather { Id = 46, WeatherSettingId = 2, StyleId = 2 },
                new MatchingStyleToWeather { Id = 47, WeatherSettingId = 3, StyleId = 2 },
                new MatchingStyleToWeather { Id = 48, WeatherSettingId = 4, StyleId = 2 },
                new MatchingStyleToWeather { Id = 49, WeatherSettingId = 5, StyleId = 2 },
                new MatchingStyleToWeather { Id = 50, WeatherSettingId = 6, StyleId = 2 },
                new MatchingStyleToWeather { Id = 51, WeatherSettingId = 7, StyleId = 2 },
                new MatchingStyleToWeather { Id = 52, WeatherSettingId = 8, StyleId = 2 },
                new MatchingStyleToWeather { Id = 53, WeatherSettingId = 9, StyleId = 2 },
                new MatchingStyleToWeather { Id = 54, WeatherSettingId = 10, StyleId = 2 },
                new MatchingStyleToWeather { Id = 55, WeatherSettingId = 11, StyleId = 2 },
                new MatchingStyleToWeather { Id = 56, WeatherSettingId = 12, StyleId = 2 },
                new MatchingStyleToWeather { Id = 57, WeatherSettingId = 13, StyleId = 2 },
                new MatchingStyleToWeather { Id = 58, WeatherSettingId = 14, StyleId = 2 },
                new MatchingStyleToWeather { Id = 59, WeatherSettingId = 15, StyleId = 2 },
                new MatchingStyleToWeather { Id = 60, WeatherSettingId = 16, StyleId = 2 },
                new MatchingStyleToWeather { Id = 61, WeatherSettingId = 17, StyleId = 2 },
                new MatchingStyleToWeather { Id = 62, WeatherSettingId = 18, StyleId = 2 },
                new MatchingStyleToWeather { Id = 63, WeatherSettingId = 19, StyleId = 2 },
                new MatchingStyleToWeather { Id = 64, WeatherSettingId = 20, StyleId = 2 },
                new MatchingStyleToWeather { Id = 65, WeatherSettingId = 21, StyleId = 2 },
                new MatchingStyleToWeather { Id = 66, WeatherSettingId = 22, StyleId = 2 },
                new MatchingStyleToWeather { Id = 67, WeatherSettingId = 23, StyleId = 2 },
                new MatchingStyleToWeather { Id = 68, WeatherSettingId = 24, StyleId = 2 },
                new MatchingStyleToWeather { Id = 69, WeatherSettingId = 25, StyleId = 2 },
                new MatchingStyleToWeather { Id = 70, WeatherSettingId = 26, StyleId = 2 },
                new MatchingStyleToWeather { Id = 71, WeatherSettingId = 27, StyleId = 2 },
                new MatchingStyleToWeather { Id = 72, WeatherSettingId = 28, StyleId = 2 },
                new MatchingStyleToWeather { Id = 73, WeatherSettingId = 29, StyleId = 2 },
                new MatchingStyleToWeather { Id = 74, WeatherSettingId = 30, StyleId = 2 },
                new MatchingStyleToWeather { Id = 75, WeatherSettingId = 31, StyleId = 2 },
                new MatchingStyleToWeather { Id = 76, WeatherSettingId = 32, StyleId = 2 },
                new MatchingStyleToWeather { Id = 77, WeatherSettingId = 33, StyleId = 2 },
                new MatchingStyleToWeather { Id = 78, WeatherSettingId = 34, StyleId = 2 },
                new MatchingStyleToWeather { Id = 79, WeatherSettingId = 35, StyleId = 2 },
                new MatchingStyleToWeather { Id = 80, WeatherSettingId = 36, StyleId = 2 },
                new MatchingStyleToWeather { Id = 81, WeatherSettingId = 37, StyleId = 2 },
                new MatchingStyleToWeather { Id = 82, WeatherSettingId = 38, StyleId = 2 },
                new MatchingStyleToWeather { Id = 83, WeatherSettingId = 39, StyleId = 2 },
                new MatchingStyleToWeather { Id = 84, WeatherSettingId = 40, StyleId = 2 },
                new MatchingStyleToWeather { Id = 85, WeatherSettingId = 41, StyleId = 2 },
                new MatchingStyleToWeather { Id = 86, WeatherSettingId = 42, StyleId = 2 },
                new MatchingStyleToWeather { Id = 87, WeatherSettingId = 43, StyleId = 2 },
                new MatchingStyleToWeather { Id = 88, WeatherSettingId = 44, StyleId = 2 }
                );


        }
    }
}
