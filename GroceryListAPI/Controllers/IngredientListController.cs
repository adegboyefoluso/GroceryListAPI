using GroceryList.Model.IngredientListModel;
using GroceryList.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryListAPI.Controllers
{
    [Authorize]
    public class IngredientListController : ApiController
    {
        private IngredientListServices CreateIngredientListServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var services = new IngredientListServices(userid);
            return services;
        }

        [HttpPost]
        public IHttpActionResult Post(IngredientListCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var servive = CreateIngredientListServices();
            var ingredientList = servive.CreateIngredientList(model);
            if(ingredientList is false)
            {
                return BadRequest("Ingredient List could not be created");
            }
            return Ok("Ingredient list Created Succesfully");
        }
    }
}
