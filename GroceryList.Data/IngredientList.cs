using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Data
{
    public class IngredientList
    {
        [Key]
        public int IngredientListId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeIngredientList> RecipeIngredientLists { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public IngredientList()
        {
            Ingredients = new HashSet<Ingredient>();

        }
    }
}
