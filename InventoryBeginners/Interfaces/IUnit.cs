using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryBeginners.Models;
using static InventoryBeginners.Models.Unit;
using Tools;

namespace InventoryBeginners.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetItems(string SortProperty, SortOrder sortOrder);
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);
        Unit Delete(Unit unit);
    }
}
