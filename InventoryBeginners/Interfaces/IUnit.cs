using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryBeginners.Models;

namespace InventoryBeginners.Interfaces
{
    public interface IUnit
    {
        List<Unit> GetItems();
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);
        Unit Delete(Unit unit);
    }
}
