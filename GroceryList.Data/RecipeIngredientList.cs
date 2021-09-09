using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Data
{
    public class RecipeIngredientList //joining table or composite table
    {
        [Key, Column(Order=1)]
        public int RecipeId { get; set; }
        [Key, Column(Order = 2)]
        public int IngredientListId { get; set; }
        public IngredientList IngredientList { get; set; }
        public Recipe Recipe { get; set; }
    }
}// recipe1=>ingredientList1
// recipe1=>ingredientList2
// recipe1=>ingredientList2
