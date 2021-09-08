using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string RecipeDescription { get; set; }

        [ForeignKey(nameof(IngredientList))]
        public int IngredientListId { get; set; }
        public virtual IngredientList IngredientList { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
