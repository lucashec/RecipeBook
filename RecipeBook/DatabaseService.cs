using RecipeBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RecipeBook
{
    public static class DatabaseService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Ingredient>();

            Console.WriteLine("Table Ingredient Created");

            await db.CreateTableAsync<Recipe>();

            Console.WriteLine("Table Recipe Created");
        }

        public static async Task<List<Recipe>> GetRecipes()
        {
            await Init();

            var recipes = await db.Table<Recipe>().ToListAsync();
            return recipes;
        }
    }
}
