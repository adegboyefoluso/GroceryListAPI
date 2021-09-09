using GroceryList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Model.RecipeList
{
    public class RecipeCreate
    {
        public string Name { get; set; }
        public List<IngredientList> Ingredients { get; set; }
    }
}
