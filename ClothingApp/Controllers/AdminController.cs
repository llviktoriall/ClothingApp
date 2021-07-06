using ClothingApp.Core.Services.WeatherService;
using ClothingApp.Data.Common.Entities;
using ClothingApp.Data.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IClothingService _iClothingService;
        private readonly IAdminRepository _adminRepository;
        public AdminController(IClothingService iClothingService, IAdminRepository adminRepository)
        {
            _iClothingService = iClothingService;
            _adminRepository = adminRepository;
        }
        /// <summary>
        /// получить все образы
        /// </summary>
        
        private List<Style> GetAllStyles()
        {
            var styles = _iClothingService.GetAllStyles().Result;
            return styles;
        }
        /// <summary>
        /// изменить образ - переход на страницу работы над образом
        /// </summary>
        [HttpPut]
        private async Task<ActionResult<Style>> UpdateStyle(Style style)
        {
            var selectStyle = await _adminRepository.GetByIdAsync(style.Id);
            if(selectStyle!=null)
            {
                selectStyle.Name = style.Name;
                selectStyle.CompositionOfStyles = style.CompositionOfStyles;
                selectStyle.GenderType = style.GenderType;
                await _adminRepository.UpdateAsync(selectStyle);
                return selectStyle;
            }
            return null;
        }
        /// <summary>
        /// удалить образ
        /// </summary>
        [HttpDelete]
        private async Task<ActionResult<Style>> DeleteStyle(long id)
        {
            var selectStyle = await _adminRepository.GetByIdAsync(id);
            if (selectStyle != null)
            {
                await _adminRepository.DeleteAsync(id);
                return selectStyle;
            }
            return null;
        }
        /// <summary>
        /// добавить образ- переход на страницу работы над образом
        /// </summary>
        [HttpPost]
        private async Task<ActionResult<Style>> CreateStyle(Style style)
        {
            if(style!=null)
            {
                await _adminRepository.CreateAsync(style);
                return style;
            }
            return null;
        }
        /// <summary>
        /// установить температуру
        /// </summary>
        private void SetTemperature(int min, int max)
        {

        }
        /// <summary>
        /// установить дождь
        /// </summary>
        private void SetRain(bool isItRaining)
        {

        }
        /// <summary>
        /// установить ветер
        /// </summary>
        private void SetWind(bool isItWinding)
        {

        }
        /// <summary>
        /// установить совет
        /// </summary>
        private void SetAdvise(string advise)
        {

        }

        /// <summary>
        /// главная страница админа
        /// </summary>
        /// 
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.AllStyles = GetAllStyles();
            return View("Index");
        }
        /// <summary>
        /// страница, на которой можно работать над 1 образом
        /// </summary>
        /// 
        [HttpGet]
        public IActionResult Style()
        {
            return View("Style");
        }
        public IActionResult GoToRoles()
        {
            return RedirectToRoute(new { controller = "Roles", action = "Index" });
        }
        public IActionResult GoToStyles()
        {
            return View("Index");
        }
    }
}
