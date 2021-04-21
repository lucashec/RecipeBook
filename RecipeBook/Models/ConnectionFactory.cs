using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public static class ConnectionFactory
    {
        static SQLiteAsyncConnection connection;
        static async Task Init()
        {
            if (connection != null)
                return;

            var folder = new LocalRootFolder();
            var file = folder.CreateFile("recipeBook", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            connection = new SQLiteAsyncConnection(file.Path);
            await connection.CreateTableAsync<Ingredient>();

            Console.WriteLine("Ingredient Table Created");

            await connection.CreateTableAsync<RecipeModel>();

            Console.WriteLine("RecipeModel Table Created");

        }
        public static async Task<List<RecipeModel>> GetRecipes()
        {
            await Init();

            var recipes = await connection.Table<RecipeModel>().ToListAsync();
            return recipes;
        }

        public static async Task<int> InsertRecipe(RecipeModel recipe)
        {
            await Init();

            var id = await connection.InsertAsync(recipe);
            return id;
        }
        public static async Task<int> InsertIngredient(Ingredient ingredient)
        {
            await Init();

            var id = await connection.InsertAsync(ingredient);
            return id;
        }
        public static async Task Delete_AllIngredients()
        {

            await Init();
            await connection.DropTableAsync<Ingredient>();

        }
        public static async void Delete_Ingredient(Ingredient ingredient)
        {
            await Init();
           
            await connection.DeleteAsync(ingredient);
            
        }

        public static async Task<List<Ingredient>> GetIngredientsById(int id)
        {

            await Init();

            List<Ingredient> ingredients = await connection.QueryAsync<Ingredient>("select * from Ingredient where RecipeId=?", id);
            
            return ingredients;
        }
        public static async Task Delete_AllRecipeModel()
        {

            await Init();

            await connection.DeleteAllAsync<RecipeModel>();
            
        }

        public static async Task Delete_RecipeModel(RecipeModel recipe)
        {

            await Init();

            try
            {
                await connection.DeleteAsync<RecipeModel>(recipe.Id);
            }
            catch
            {
                return;
            }

        }
        public static async Task Update_RecipeModel(RecipeModel recipe)
        {

            await Init();

            try
            {
                await connection.UpdateAsync(recipe);
            }
            catch
            {
                return;
            }

        }
    }
}
