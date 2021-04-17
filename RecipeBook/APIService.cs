using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RecipeBook.Models;

namespace RecipeBook
{
    public static class APIService
    {
        static HttpClient httpClient;
        static List<Recipe> recipes;
        public static async Task<List<Recipe>> GetRecipes()
        {
            if (recipes != null) return recipes;
            if(httpClient == null)
            {
                httpClient = new HttpClient();
            }
            var result = await httpClient.GetAsync("https://www.thewissen.io/pancakes.json");
            var resultAsString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Recipe>>(resultAsString);
        }
    }
}
