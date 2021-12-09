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
using Tools;

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
            SortModel sortModel = new SortModel();

            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            List<Unit> units = _unitRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder);
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