using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Model.IngredientListModel
{
    public class IngredientListDetail
    {
        public int IngredientListId { get; set; }
        public string IngredientListName { get; set; }
        public List<IngredientDetail> ListOfIngredientDetails { get; set; }
    }
}
