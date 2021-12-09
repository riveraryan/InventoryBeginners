using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryBeginners.Data;
using InventoryBeginners.Models;
using Microsoft.EntityFrameworkCore;
using InventoryBeginners.Interfaces;
using InventoryBeginners.Repositories;
using static InventoryBeginners.Models.Unit;

namespace InventoryBeginners.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnit _unitRepo;

        public UnitController(IUnit unitrepo)
        {
            _unitRepo = unitrepo;
        }

        public IActionResult Index(string sortExpression = "")
        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamDesc"] = "description";

            ViewData["SortIconName"] = "";
            ViewData["SortIconDesc"] = "";


            SortOrder sortOrder;
            string sortProperty;
            //Note, case expression name and the ViewData SortParam values are opposite, this is incase
            //a sort button is called more than once, it flips the order.
            switch(sortExpression.ToLower()){
                case "name_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    ViewData["SortParamName"] = "name";
                    break;
                case "description":
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    ViewData["SortParamDesc"] = "description_desc";
                    break;
                case "description_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    ViewData["SortParamDesc"] = "description";
                    break;
                default:
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-down";
                    ViewData["SortParamName"] = "name_desc";
                    break;
            }

            List<Unit> units = _unitRepo.GetItems(sortProperty, sortOrder);
            return View(units);
        }

        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try{
                unit = _unitRepo.Create(unit);
            }
            catch{
            
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try{
                _unitRepo.Edit(unit);
            }
            catch{
            
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                _unitRepo.Delete(unit);
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}