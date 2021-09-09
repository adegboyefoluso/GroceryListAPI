﻿using GroceryList.Data;
using GroceryList.Model.IngredientListModel;
using GroceryListAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public class IngredientListServices
    {
        private readonly Guid _UserId;
        public IngredientListServices(Guid userid)
        {
            _UserId = userid;
        }

        //Create IngredientList
        public bool CreateIngredientList(IngredientListCreate model)
        {
            var entity = new IngredientList()
            {
                Name = model.Name,
                OwnerId=_UserId
            };
            using (var ctx=new ApplicationDbContext())
            {
                foreach (var id in model.IngredientIds)
                {
                    var query = ctx
                                   .Ingredients
                                   .SingleOrDefault(i=>i.IngredientId==id);
                    if (query is null) return false;
                    entity.Ingredients.Add(query);
                }
                ctx.IngredientLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get Ingredient List
        public IEnumerable<IngredientListDetail> GetAllIngredientList()
        {
            using(var ctx= new ApplicationDbContext())
            {
                var query = ctx
                                .IngredientLists
                                .Select(e => new IngredientListDetail
                                {
                                    IngredientListId = e.IngredientListId,
                                    IngredientListName = e.Name,
                                    ListOfIngredientDetails = e.Ingredients.Select(p => new IngredientDetail()
                                    {
                                        IngredientId = p.IngredientId,
                                        IngredientAmount = p.AmountOfIngredient,
                                        IngredientName = p.Name,
                                        IsOrganic = p.IsOrganic
                                    }).ToList()
                                }).ToList();
                return query;
            }
            
        }
        //GetIngredientList By Id
        public IngredientListDetail GetIngredientListById(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query = ctx
                                .IngredientLists
                                .SingleOrDefault(e => e.IngredientListId == id);
                if (query is null) return null;
                return new IngredientListDetail()
                {
                    IngredientListId = query.IngredientListId,
                    IngredientListName = query.Name,
                    ListOfIngredientDetails = query.Ingredients.Select(p => new IngredientDetail()
                    {
                        IngredientId = p.IngredientId,
                        IngredientAmount = p.AmountOfIngredient,
                        IngredientName = p.Name,
                        IsOrganic = p.IsOrganic
                    }).ToList()
                };
            }
        }
        //Edit IngredientList
        public bool EditIngredientList(IngredientListEdit model)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var query = ctx
                                .IngredientLists
                                .SingleOrDefault(e => e.IngredientListId == model.IngredientListId);
                if (query is null) return false;
                query.Name = model.Name;
               return  ctx.SaveChanges() ==1;
                
            }
        }

        //Delete IngredientList

        public bool DeleteIngredientList(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query = ctx
                                .IngredientLists
                                .SingleOrDefault(e => e.IngredientListId == id);
                if (query is null) return false;
                ctx.IngredientLists.Remove(query);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get Recipe By Ingredient List Id
        public IEnumerable<RecipeList> GetRecipesByIngredientListId(int id)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var recipes = ctx
                                .IngredientLists
                                .SingleOrDefault(e => e.IngredientListId == id).Recipes.
                                Select(p => new RecipeList
                                {
                                    RecipeId = p.RecipeId,
                                    Name = p.Name,
                                    RecipeDescription = p.RecipeDescription
                                }).ToList();

                return recipes;              
            }
        }
    }
}
