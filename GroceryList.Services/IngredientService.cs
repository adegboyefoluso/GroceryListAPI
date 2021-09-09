﻿using GroceryList.Data;
using GroceryList.Model.IngredientModel;
using GroceryListAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public class IngredientService
    {

        private readonly Guid _UserId;
        public IngredientService(Guid userid)
        {
            _UserId = userid;
        }

        // Create
        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    Name = model.Name,
                    IsOrganic = model.IsOrganic,
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read

        // Update

        // Delete

    }
}
