using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryBeginners.Data;
using InventoryBeginners.Models;
using System.Linq;

namespace InventoryBeginners.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index()//Read method of CRUD operations.  Lists all data from the units table
        {
            List<Unit> units = _context.Units.ToList(); //Gets the list of units from the context
            return View(units);
        }
     
        private readonly InventoryContext _context;

        //Dependency Injection
        public UnitController(InventoryContext context)
        {
            _context = context;
        }
    }
}
