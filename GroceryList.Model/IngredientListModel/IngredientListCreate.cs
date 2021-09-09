using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Model.IngredientListModel
{
    public class IngredientListCreate
    {
        public string Name { get; set; }
        public List<int> IngredientIds { get; set; }

    }
}
